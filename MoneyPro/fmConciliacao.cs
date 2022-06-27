using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelos;
using BLL;
using System.IO;
using OFXSharp;

namespace MoneyPro
{
    public partial class fmConciliacao : MoneyPro.Base.fmBaseTopoRodape
    {
        private int IDConta
        {
            get
            {
                return idConta;
            }

            set
            {
                idConta = value;

                MovimentoContaBLL bll = new MovimentoContaBLL();
                DataInicial = bll.PrimeiroDiaNaoReconciliado(idConta);
            }
        }

        private int idConta;

        private int Coluna { get; set; }

        private DateTime DataInicial { get; set; }
        private int Posicao
        {
            get
            {
                return posicao;
            }

            set
            {
                posicao = value;

                buttonAnterior.Enabled = (posicao > 0);
                buttonProximo.Enabled = (posicao < ofxDocument.Transactions.Count - 1);
            }
        }
        private int posicao;

        private OFXDocument ofxDocument;
        public fmConciliacao(int contaID, string nome)
        {
            InitializeComponent();

            IDConta = contaID;

            labelTopo.Text = "Conciliação de " + nome;

            CarregarArquivoOFX();

            if (ofxDocument != null)
            {
                CarregarDados();
                Coluna = Geral.PrimeiraColunaVisivel(movimentoContaDataGridView);
                Posicao = 0;
            }
        }

        private void ExibirLancamentoArquivo(int posicao)
        {
            // Desliga o evento para não causar recursividade involuntária
            dateTimePickerData.ValueChanged -= dateTimePickerData_ValueChanged;

            var registro = ofxDocument.Transactions[posicao];

            dateTimePickerData.Value = registro.Date;
            textBoxDescricao.Text = registro.Memo.Trim();
            textBoxValor.Text = (Math.Abs(registro.Amount)).ToString("N2");

            if (registro.Amount < 0)
            {
                labelCrdDeb.Text = "Lançamento a débito";
                labelCrdDeb.ForeColor = Color.Red;
            }
            else
            {
                labelCrdDeb.Text = "Lançamento a crédito";
                labelCrdDeb.ForeColor = Color.Green;
            }

            // Tenta encontrar na grade qual a linha que combina com o registro atual

            int match = -1;

            for (int i = 0; i < movimentoContaDataGridView.Rows.Count && match < 0; i++)
            {
                DataGridViewRow item = movimentoContaDataGridView.Rows[i];

                if ((DateTime)item.Cells["Data"].Value == registro.Date)
                {
                    if ((Decimal)item.Cells["Valor"].Value == registro.Amount)
                    {
                        if (item.Cells["IdentificacaoOFX"].Value == DBNull.Value)
                        {
                            // Possível match
                            match = i;
                        }
                        else
                        {
                            // Se o lançamento não for nulo tem que ser igual ao registro do arquivo OFX
                            if ((string)item.Cells["IdentificacaoOFX"].Value == registro.TransactionID)
                            {
                                // Possível match
                                match = i;
                            }
                        }
                    }
                }
            }

            if (match >= 0)
            {
                timerAtencao.Enabled = false;
                buttonAtencao.Visible = false;
                buttonAtencao.BackColor = Color.Gold;
                movimentoContaDataGridView.CurrentCell = movimentoContaDataGridView.Rows[match].Cells[Coluna];

                buttonConciliado.Visible = (movimentoContaDataGridView.CurrentRow.Cells["IdentificacaoOFX"].Value != DBNull.Value);
            }
            else
            {
                buttonConciliado.Visible = false;
                buttonAtencao.Visible = true;
                timerAtencao.Enabled = true;
            }

            groupBoxLancamento.Text = "Lançamento " + (Posicao + 1).ToString("N0") + " de " + ofxDocument.Transactions.Count.ToString("N0") + " do arquivo";

            // Religa o evento
            dateTimePickerData.ValueChanged += dateTimePickerData_ValueChanged;
        }

        private void CarregarDados()
        {
            MovimentoContaBLL bll = new MovimentoContaBLL();
            movimentoContaBindingSource.DataSource = bll.ListarNaoConciliados(IDConta, DataInicial);

            switch (movimentoContaBindingSource.Count)
            {
                case 0:
                    toolStripStatusLabelLancamentos.Text = "Nenhum lançamento pendente";
                    break;
                case 1:
                    toolStripStatusLabelLancamentos.Text = "Um lançamento pendente";
                    break;
                default:
                    toolStripStatusLabelLancamentos.Text = (movimentoContaBindingSource.Count).ToString("F0") + " lançamentos pendentes";
                    break;
            }

            switch (ofxDocument.Transactions.Count)
            {
                case 0:
                    toolStripStatusLabelArquivo.Text = "Nenhum lançamento no arquivo";
                    break;
                case 1:
                    toolStripStatusLabelArquivo.Text = "Um lançamento no arquivo";
                    break;
                default:
                    toolStripStatusLabelArquivo.Text = (ofxDocument.Transactions.Count).ToString("F0") + " lançamentos no arquivo";
                    break;
            }
        }

        private void CarregarArquivoOFX()
        {
            // Carrega arquivo OFX, que são arquivos padrão Money 2000.

            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string pathDownload = Path.Combine(pathUser, "Downloads");

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = pathDownload;
            openFileDialog.Filter = "Arquivos OFX (*.OFX)|*.OFX";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string file = openFileDialog.FileName;
                    var parser = new OFXDocumentParser();
                    ofxDocument = parser.Import(new FileStream(file, FileMode.Open));
                }
                catch (Exception ex)
                {
                    ofxDocument = null;
                    MessageBox.Show("Não foi possível ler o arquivo.\n" + ex.Message, "Erro",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void fmConciliacao_Shown(object sender, EventArgs e)
        {
            if (ofxDocument == null)
            {
                this.Close();
            }
            else
            {
                ExibirLancamentoArquivo(Posicao);
            }
        }

        private void dateTimePickerData_ValueChanged(object sender, EventArgs e)
        {
            ExibirLancamentoArquivo(Posicao);
        }

        private void buttonProximo_Click(object sender, EventArgs e)
        {
            Posicao++;
            ExibirLancamentoArquivo(Posicao);
        }

        private void buttonAnterior_Click(object sender, EventArgs e)
        {
            Posicao--;
            ExibirLancamentoArquivo(Posicao);
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void buttonLigar_Click(object sender, EventArgs e)
        {
            ExecutarLigacao();
        }

        private void ExecutarLigacao()
        {
            // Faz a ligação entre o lançamento do sistema e o lançamento do arquivo
            // Desliga o evento para não causar recursividade involuntária

            bool continua = true;

            // Pega o registro atual dos lançamentos do sistema
            DataGridViewRow item = movimentoContaDataGridView.CurrentRow;

            // Pega o registro atual do arquivo OFX
            Transaction registro = ofxDocument.Transactions[posicao];

            bool dataIgual = ((DateTime)item.Cells["Data"].Value == registro.Date);
            bool valorIgual = ((Decimal)item.Cells["Valor"].Value == registro.Amount);
            bool jaReconciliado = ((string)item.Cells["Conciliacao"].Value == "R");

            string msg = null;

            if (!dataIgual && !valorIgual)
            {
                msg = "As datas e os valores dos lançamentos são diferentes, deseja continuar?";
            }
            else if (!dataIgual && valorIgual)
            {
                msg = "As datas dos lançamentos são diferentes, deseja continuar?";
            }
            else if (dataIgual && !valorIgual)
            {
                msg = "Os valores dos lançamentos são diferentes, deseja continuar?";
            }

            if (msg != null)
            {
                continua = ((MessageBox.Show(msg, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.Yes);
            }

            if (continua)
            {
                MovimentoContaBLL bll = new MovimentoContaBLL();
                if (bll.ConciliacaoViaOFX((int)item.Cells["MovimentoContaID"].Value, registro, jaReconciliado))
                {
                    CarregarDados();
                    ExibirLancamentoArquivo(Posicao);
                }
            }
        }

        private void timerAtencao_Tick(object sender, EventArgs e)
        {
            if (buttonAtencao.BackColor == Color.Gold)
                buttonAtencao.BackColor = Color.Red;
            else
                buttonAtencao.BackColor = Color.Gold;
        }

        private void movimentoContaDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (movimentoContaDataGridView.CurrentRow != null)
            {
                if (e.Value != null)
                {
                    if (movimentoContaDataGridView.Columns[e.ColumnIndex].Name == "Conciliacao")
                    {
                        try
                        {
                            string txt = (string)e.Value;

                            if (txt == "C")
                            {
                                e.CellStyle.ForeColor = Color.Blue;
                                e.CellStyle.SelectionForeColor = Color.Blue;
                            }
                            else if (txt == "R")
                            {
                                e.CellStyle.ForeColor = Color.Green;
                                e.CellStyle.SelectionForeColor = Color.Green;
                            }

                            if (txt != " ")
                                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

                            if (movimentoContaDataGridView.Rows[e.RowIndex].Cells["IdentificacaoOFX"].Value != DBNull.Value)
                            {
                                e.CellStyle.BackColor = Color.Gold;
                                e.CellStyle.SelectionBackColor = Color.Gold;
                            }

                        }
                        catch
                        {
                            // não faz nada.
                        }
                    }
                }
            }
        }

        private void movimentoContaDataGridView_DoubleClick(object sender, EventArgs e)
        {
            // Quando há o duplo clique, tenta encontra o registro OFX correspondente.           

            if (movimentoContaDataGridView.CurrentRow != null)
            {
                string lancamento = String.Empty;

                if (movimentoContaDataGridView.CurrentRow.Cells["IdentificacaoOFX"].Value != DBNull.Value)
                {
                    lancamento = (string)movimentoContaDataGridView.CurrentRow.Cells["IdentificacaoOFX"].Value;
                }

                int novaPosicao = -1;

                if (lancamento != String.Empty)
                {
                    // Procura pelo lançamento já conciliado

                    for (int i = 0; i < ofxDocument.Transactions.Count && novaPosicao < 0; i++)
                    {
                        if (ofxDocument.Transactions[i].TransactionID == lancamento)
                        {
                            novaPosicao = i;
                        }
                    }

                }
                else
                {
                    // Procura pelo lançamento ainda não conciliado
                    for (int i = 0; i < ofxDocument.Transactions.Count && novaPosicao < 0; i++)
                    {
                        if (ofxDocument.Transactions[i].Date == (DateTime)movimentoContaDataGridView.CurrentRow.Cells["Data"].Value)
                        {
                            if (ofxDocument.Transactions[i].Amount == (decimal)movimentoContaDataGridView.CurrentRow.Cells["Valor"].Value)
                            {
                                if (NaoConciliado(ofxDocument.Transactions[i].TransactionID))
                                {
                                    novaPosicao = i;
                                }
                            }
                        }
                    }
                }

                if (novaPosicao != -1)
                {
                    Posicao = novaPosicao;
                    ExibirLancamentoArquivo(Posicao);
                }

            }
        }

        private bool NaoConciliado(string transacaoID)
        {
            for (int i = 0; i < movimentoContaDataGridView.Rows.Count; i++)
            {
                DataGridViewRow item = movimentoContaDataGridView.Rows[i];

                if (item.Cells["IdentificacaoOFX"].Value != DBNull.Value)
                {
                    if ((string)item.Cells["IdentificacaoOFX"].Value == transacaoID)
                    {
                        // Encontrou a conciliacao;
                        return false;
                    }
                }
            }

            // Não encontrou a conciliação
            return true;
        }

        private void buttonAjustarData_Click(object sender, EventArgs e)
        {
            // Pega o registro atual do arquivo OFX
            Transaction registro = ofxDocument.Transactions[posicao];

            string msg = "Altera a data de lançamento do movimento atual para " + registro.Date.ToString("dd/MM/yyyy") + "?";

            if (MessageBox.Show(msg, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Pega o registro atual dos lançamentos do sistema
                DataGridViewRow item = movimentoContaDataGridView.CurrentRow;

                MovimentoContaBLL bll = new MovimentoContaBLL();
                if (bll.AtribuirNovaDataAoMovimento((int)item.Cells["MovimentoContaID"].Value, registro.Date))
                {
                    CarregarDados();
                    ExibirLancamentoArquivo(Posicao);
                }
                else
                {
                    MessageBox.Show("Houve problemas atualizando a data do movimento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
