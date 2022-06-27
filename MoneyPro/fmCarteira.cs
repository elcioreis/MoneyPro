using BLL;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Modelos.Tipo;

namespace MoneyPro
{
    public partial class fmCarteira : MoneyPro.Base.fmBaseTopoRodape
    {
        private fmCarteiraTabelaVariacaoAcumulada tabelaVariacaoAcumulada;
        private fmCarteiraTabelaDetalhes tabelaDetalhes;
        private fmCarteiraTabelaResumo tabelaResumo;
        private fmCarteiraVariacaoUltimosDiasUteis tabelaVariacaoDezDiasUteis;
        private fmCarteiraVariacaoDiaria tabelaVariacaoDiaria;
        private fmCarteiraVariacaoMensal tabelaVariacaoMensal;
        private fmCarteiraGraficoComparativo graficoComparativo;
        private fmCarteiraGraficoRendimentoMensal graficoRendimentoMensal;
        private fmCarteiraGraficoRendimentoDiario graficoRendimentoDiario;
        private fmCarteiraGraficoComposicaoCarteira graficoComposicaoCarteira;
        private fmCarteiraGraficoPercentual graficoPercentual;
        private fmCarteiraListaMovimentosFundo listaMovimentosFundo;

        private int IDUsuario { get; set; }

        #region Singleton

        private static fmCarteira _singleton;

        private fmCarteira(int usuarioID)
        {
            InitializeComponent();
            this.IDUsuario = usuarioID;
        }

        public static fmCarteira CreateInstance(int usuarioID)
        {
            if (_singleton == null)
            {
                _singleton = new fmCarteira(usuarioID);
            }
            return _singleton;
        }

        protected override void OnClosed(EventArgs e)
        {
            _singleton = null;
            base.OnClosed(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CarregaDados();
        }

        private void AlturaGridSuperior()
        {
            // Pega a altura da linha
            int altLinha = carteiraDataGridView.RowTemplate.Height;

            // Quatro linha + Uma de cabeçalho
            int rows = Math.Min(carteiraDataGridView.Rows.Count, 4) + 1;

            int altura = (altLinha * rows) + 1;

            carteiraDataGridView.MinimumSize = new Size(0, altura);
            carteiraDataGridView.Height = altura;
        }

        #endregion Singleton

        private void CarregaDados()
        {
            carteiraDataGridView.Size = new Size(609, 133);
            carteiraDataGridView.MinimumSize = new Size(0, 133);

            CarteiraBLL bll = new CarteiraBLL();
            carteiraBindingSource.DataSource = bll.Listar(IDUsuario, buttonComSaldo.Visible);

            // Troca todos os espaços dos cabeçalhos das colunas visíveis por espaços inseparáveis
            foreach (DataGridViewColumn col in carteiraDataGridView.Columns)
            {
                if (col.Visible)
                {
                    col.MinimumWidth = 40;
                    col.HeaderText = col.HeaderText.Trim().Replace(' ', '\u00A0');
                }
            }

            // Faz com que a altura da linha do cabeçalho seja igual ao das linhas do grid
            carteiraDataGridView.ColumnHeadersHeight = carteiraDataGridView.RowTemplate.Height;
        }

        private void carteiraDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                // O campo total tem valor ZERO para não totais e UM para total (como se fosse boolean)
                int detalhe = (int)carteiraDataGridView.Rows[e.RowIndex].Cells["Detalhe"].Value;

                if (detalhe == 0)
                {
                    if (carteiraDataGridView.Columns[e.ColumnIndex].Name == "Apelido")
                    {
                        //  É uma linha de total
                        using (Font font = new Font(carteiraDataGridView.DefaultCellStyle.Font.FontFamily, 8, FontStyle.Bold))
                        {
                            e.CellStyle.Font = font;
                        }
                    }

                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Black;
                    e.CellStyle.SelectionBackColor = Color.Black;
                }
                else
                {
                    if (carteiraDataGridView.Columns[e.ColumnIndex].Name == "Risco")
                    {
                        if (carteiraDataGridView.Rows[e.RowIndex].Cells["RiscoID"].Value != DBNull.Value)
                        {
                            ClassificacaoRisco risco = (ClassificacaoRisco)carteiraDataGridView.Rows[e.RowIndex].Cells["RiscoID"].Value;

                            switch (risco)
                            {
                                case ClassificacaoRisco.Baixo:
                                    e.CellStyle.BackColor = Color.FromArgb(255, Color.FromArgb((Int32)CorRisco.Baixo));
                                    e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                                    break;
                                case ClassificacaoRisco.MedioBaixo:
                                    e.CellStyle.BackColor = Color.FromArgb(255, Color.FromArgb((Int32)CorRisco.MedioBaixo));
                                    e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                                    break;
                                case ClassificacaoRisco.Medio:
                                    e.CellStyle.BackColor = Color.FromArgb(255, Color.FromArgb((Int32)CorRisco.Medio));
                                    e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                                    break;
                                case ClassificacaoRisco.MedioAlto:
                                    e.CellStyle.BackColor = Color.FromArgb(255, Color.FromArgb((Int32)CorRisco.MedioAlto));
                                    e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                                    break;
                                case ClassificacaoRisco.Alto:
                                    e.CellStyle.BackColor = Color.FromArgb(255, Color.FromArgb((Int32)CorRisco.Alto));
                                    e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void buttonVariacaoAcumulada_Click(object sender, EventArgs e)
        {
            //
            // Cria uma janela com a variação acumulada dos investimentos
            // Ao fechar a janela criada, a atual é restaurada.
            //

            // Cria uma instância do form de detalhes
            //fmCarteiraVariacaoAcumulada variacao = fmCarteiraVariacaoAcumulada.CreateInstance(this);
            tabelaVariacaoAcumulada = fmCarteiraTabelaVariacaoAcumulada.CreateInstance(this);

            // Ajusta a aparência do formulário para que ele se encaixe no lugar do formulário atual 
            Geral.AjustaAparenciaSubForm(this, tabelaVariacaoAcumulada);

            // Esconde o form atual
            this.WindowState = FormWindowState.Minimized;

            // Exibe o sub form
            tabelaVariacaoAcumulada.Show();
            tabelaVariacaoAcumulada.Focus();
        }

        private void buttonComSaldo_Click(object sender, EventArgs e)
        {
            // Liga/Desliga botão que filtra somente os itens com saldo.
            buttonComSaldo.Visible = !buttonComSaldo.Visible;

            CarteiraBLL bll = new CarteiraBLL();
            carteiraBindingSource.DataSource = bll.Listar(IDUsuario, buttonComSaldo.Visible);

            //AlturaGridSuperior();
        }

        //private void AjustaAparenciaSubForm(Form subForm)
        //{
        //    // Ajusta o form de detalhes para que seja semelhante ao da movimentação de contas

        //    // Atribui o MdiParent ao form atual
        //    subForm.MdiParent = this.MdiParent;
        //    // Remove as bordas
        //    subForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        //    // Remove os botões (remover todos os botões faz com que o menu do filho não seja fundido (merged))
        //    subForm.ControlBox = false;
        //    subForm.MaximizeBox = false;
        //    subForm.MinimizeBox = false;
        //    // Desabilita exibição do ícone
        //    subForm.ShowIcon = false;
        //    // Maximiza
        //    subForm.WindowState = FormWindowState.Maximized;
        //    // Remove o título da janela
        //    subForm.Text = string.Empty;
        //    // Preenche o dock
        //    subForm.Dock = DockStyle.Fill;
        //    // Atribui o padding 3;3;3;3 (todos lados iguais)
        //    subForm.Padding = new Padding(3);
        //    // Procura groupbox no formulário
        //    foreach (Control C1 in subForm.Controls)
        //    {
        //        if (C1 is GroupBox)
        //        {
        //            C1.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
        //            foreach (Control C2 in C1.Controls)
        //            {
        //                C2.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        //            }
        //        }
        //        else
        //        {
        //            C1.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        //        }
        //    }
        //}

        private void buttonGraficosInvestimentos_Click(object sender, EventArgs e)
        {
            contextMenuStripGraficosDisponiveis.Show(MousePosition);
        }

        #region Exibição de Tabelas

        private void ExibirTabelaDetalhes()
        {
            //
            // Cria uma janela com os detalhes do fundo selecionado no grid.
            // Ao fechar a janela criada, a atual é restaurada.
            //

            if (carteiraDataGridView.CurrentRow != null)
            {
                if (carteiraDataGridView.CurrentRow.Cells["InvestimentoID"].Value != DBNull.Value)
                {
                    int investimentoID = (int)carteiraDataGridView.CurrentRow.Cells["InvestimentoID"].Value;
                    string investimentoNome = (string)carteiraDataGridView.CurrentRow.Cells["Apelido"].Value;

                    // Cria uma instância do form de detalhes
                    tabelaDetalhes = fmCarteiraTabelaDetalhes.CreateInstance(this, investimentoID, investimentoNome);

                    // Ajusta a aparência do formulário para que ele se encaixe no lugar do formulário atual 
                    Geral.AjustaAparenciaSubForm(this, tabelaDetalhes);

                    // Esconde o form atual
                    this.WindowState = FormWindowState.Minimized;

                    // Exibe o sub form
                    tabelaDetalhes.Show();
                    tabelaDetalhes.Focus();

                }
            }
        }

        private void ExibirTabelaResumo()
        {
            //
            // Cria uma janela com os detalhes do fundo selecionado no grid.
            // Ao fechar a janela criada, a atual é restaurada.
            //

            if (carteiraDataGridView.CurrentRow != null)
            {
                if (carteiraDataGridView.CurrentRow.Cells["InvestimentoID"].Value != DBNull.Value)
                {
                    int investimentoID = (int)carteiraDataGridView.CurrentRow.Cells["InvestimentoID"].Value;
                    string investimentoNome = (string)carteiraDataGridView.CurrentRow.Cells["Apelido"].Value;

                    // Cria uma instância do form de detalhes
                    tabelaResumo = fmCarteiraTabelaResumo.CreateInstance(this, investimentoID, investimentoNome);

                    // Ajusta a aparência do formulário para que ele se encaixe no lugar do formulário atual 
                    Geral.AjustaAparenciaSubForm(this, tabelaResumo);

                    // Esconde o form atual
                    this.WindowState = FormWindowState.Minimized;

                    // Exibe o sub form
                    tabelaResumo.Show();
                    tabelaResumo.Focus();
                }
            }
        }

        private void ExibirVariacaoDezUltimosDias()
        {
            // Cria uma instância do form de detalhes
            tabelaVariacaoDezDiasUteis = fmCarteiraVariacaoUltimosDiasUteis.CreateInstance(this, IDUsuario);

            // Ajusta a aparência do formulário para que ele se encaixe no lugar do formulário atual 
            Geral.AjustaAparenciaSubForm(this, tabelaVariacaoDezDiasUteis);

            // Esconde o form atual
            this.WindowState = FormWindowState.Minimized;

            // Exibe o sub form
            tabelaVariacaoDezDiasUteis.Show();
            tabelaVariacaoDezDiasUteis.Focus();
        }

        private void ExibirVariacaoDiaria()
        {
            // Cria uma instância do form de detalhes
            tabelaVariacaoDiaria = fmCarteiraVariacaoDiaria.CreateInstance(this, IDUsuario);

            // Ajusta a aparência do formulário para que ele se encaixe no lugar do formulário atual 
            Geral.AjustaAparenciaSubForm(this, tabelaVariacaoDiaria);

            // Esconde o form atual
            this.WindowState = FormWindowState.Minimized;

            // Exibe o sub form
            tabelaVariacaoDiaria.Show();
            tabelaVariacaoDiaria.Focus();
        }

        private void ExibirVariacaoMensal()
        {
            // Cria uma instância do form de detalhes
            tabelaVariacaoMensal = fmCarteiraVariacaoMensal.CreateInstance(this, IDUsuario);

            // Ajusta a aparência do formulário para que ele se encaixe no lugar do formulário atual 
            Geral.AjustaAparenciaSubForm(this, tabelaVariacaoMensal);

            // Esconde o form atual
            this.WindowState = FormWindowState.Minimized;

            // Exibe o sub form
            tabelaVariacaoMensal.Show();
            tabelaVariacaoMensal.Focus();
        }

        #endregion Exibição de Tabelas

        #region Exibição de Gráficos

        private void ExibeGraficoVariacaoCotacoes()
        {
            // Deve haver de uma a cinco linhas de fundos selecionadas.
            if (carteiraDataGridView.SelectedRows.Count < 1 || carteiraDataGridView.SelectedRows.Count > 8)
            {
                MessageBox.Show("Selecione de um a oito itens para criar o gráfico.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //
            // Cria uma janela com o gráfico comparativo dos investimentos
            // Ao fechar a janela criada, a atual é restaurada.
            //

            // Cria uma instância do form de detalhes
            graficoComparativo = fmCarteiraGraficoComparativo.CreateInstance(this, carteiraDataGridView);

            // Ajusta a aparência do formulário para que ele se encaixe no lugar do formulário atual 
            Geral.AjustaAparenciaSubForm(this, graficoComparativo);

            // Esconde o form atual
            this.WindowState = FormWindowState.Minimized;

            // Exibe o sub form
            graficoComparativo.Show();
            graficoComparativo.Focus();
        }

        private void ExibeGraficoRendimentoMensal(TipoConsultaInvestimentoVariacao tipoConsulta)
        {
            // Exibe uma sub janela com o gráfico
            //

            // Deve haver de uma a cinco linhas de fundos selecionadas.
            if (carteiraDataGridView.SelectedRows.Count < 1 || carteiraDataGridView.SelectedRows.Count > 8)
            {
                MessageBox.Show("Selecione de um a oito itens para criar o gráfico.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //
            // Cria uma janela com o gráfico comparativo dos investimentos
            // Ao fechar a janela criada, a atual é restaurada.
            //

            // Cria uma instância do form de detalhes
            graficoRendimentoMensal = fmCarteiraGraficoRendimentoMensal.CreateInstance(this, carteiraDataGridView, tipoConsulta);

            if (graficoRendimentoMensal != null)
            {

                // Ajusta a aparência do formulário para que ele se encaixe no lugar do formulário atual 
                Geral.AjustaAparenciaSubForm(this, graficoRendimentoMensal);

                // Esconde o form atual
                this.WindowState = FormWindowState.Minimized;

                graficoRendimentoMensal.Show();
                graficoRendimentoMensal.Focus();
            }
            else
            {
                MessageBox.Show("Não existem informações a serem exibidas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExibeGraficoRendimentoDiario(TipoConsultaInvestimentoVariacao tipoConsulta)
        {
            // Exibe uma sub janela com o gráfico
            //

            // Deve haver de uma a cinco linhas de fundos selecionadas.
            if (carteiraDataGridView.SelectedRows.Count < 1 || carteiraDataGridView.SelectedRows.Count > 8)
            {
                MessageBox.Show("Selecione de um a oito itens para criar o gráfico.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //
            // Cria uma janela com o gráfico comparativo dos investimentos
            // Ao fechar a janela criada, a atual é restaurada.
            //

            // Cria uma instância do form de detalhes
            graficoRendimentoDiario = fmCarteiraGraficoRendimentoDiario.CreateInstance(this, carteiraDataGridView, tipoConsulta);

            if (graficoRendimentoDiario != null)
            {

                // Ajusta a aparência do formulário para que ele se encaixe no lugar do formulário atual 
                Geral.AjustaAparenciaSubForm(this, graficoRendimentoDiario);

                // Esconde o form atual
                this.WindowState = FormWindowState.Minimized;

                graficoRendimentoDiario.Show();
                graficoRendimentoDiario.Focus();
            }
            else
            {
                MessageBox.Show("Não existem informações a serem exibidas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExibirGraficoPercentual(TipoConsultaInvestimentoVariacao tipoConsulta)
        {
            // Exibe uma sub janela com o gráfico
            //

            // Deve haver de uma a cinco linhas de fundos selecionadas.
            if (carteiraDataGridView.SelectedRows.Count < 1 || carteiraDataGridView.SelectedRows.Count > 8)
            {
                MessageBox.Show("Selecione de um a oito itens para criar o gráfico.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //
            // Cria uma janela com o gráfico
            // Ao fechar a janela criada, a atual é restaurada.
            //

            // Cria uma instância do form de detalhes
            graficoPercentual = fmCarteiraGraficoPercentual.CreateInstance(this, carteiraDataGridView, tipoConsulta);

            if (graficoPercentual != null)
            {

                // Ajusta a aparência do formulário para que ele se encaixe no lugar do formulário atual 
                Geral.AjustaAparenciaSubForm(this, graficoPercentual);

                // Esconde o form atual
                this.WindowState = FormWindowState.Minimized;

                graficoPercentual.Show();
                graficoPercentual.Focus();
            }
            else
            {
                MessageBox.Show("Não existem informações a serem exibidas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ExibeGraficoComposicaoCarteira()
        {
            // Exibe uma sub janela com o gráfico
            //

            // Deve haver de uma a cinco linhas de fundos selecionadas.
            if (carteiraDataGridView.SelectedRows.Count < 1 || carteiraDataGridView.SelectedRows.Count > 8)
            {
                MessageBox.Show("Selecione de um a oito itens para criar o gráfico.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //
            // Cria uma janela com o gráfico comparativo dos investimentos
            // Ao fechar a janela criada, a atual é restaurada.
            //

            // Cria uma instância do form de detalhes
            graficoComposicaoCarteira = fmCarteiraGraficoComposicaoCarteira.CreateInstance(this, carteiraDataGridView);

            if (graficoComposicaoCarteira != null)
            {

                // Ajusta a aparência do formulário para que ele se encaixe no lugar do formulário atual 
                Geral.AjustaAparenciaSubForm(this, graficoComposicaoCarteira);

                // Esconde o form atual
                this.WindowState = FormWindowState.Minimized;

                graficoComposicaoCarteira.Show();
                graficoComposicaoCarteira.Focus();
            }
            else
            {
                MessageBox.Show("Não existem informações a serem exibidas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        #endregion Exibição de Gráficos

        private void variacaoDasCotacoesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibeGraficoVariacaoCotacoes();
        }

        private void rendimentoMensalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibeGraficoRendimentoMensal(TipoConsultaInvestimentoVariacao.AcumuladoMensal);
        }
        private void variacaoMensalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibeGraficoRendimentoMensal(TipoConsultaInvestimentoVariacao.VariacaoMensal);
        }

        private void rendimentoDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibeGraficoRendimentoDiario(TipoConsultaInvestimentoVariacao.AcumuladoDiario);
        }

        private void variacaoDiariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibeGraficoRendimentoDiario(TipoConsultaInvestimentoVariacao.VariacaoDiaria);
        }

        private void composicaoDaCarteiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibeGraficoComposicaoCarteira();
        }

        private void buttonDetalhesInvestimento_Click(object sender, EventArgs e)
        {
            ExibirTabelaDetalhes();
        }

        private void buttonResumo_Click(object sender, EventArgs e)
        {
            ExibirTabelaResumo();
        }

        private void percentualDiarioAcumuladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirGraficoPercentual(TipoConsultaInvestimentoVariacao.AcumuladoDiario);
        }

        private void ButtonListarMovimentacao_Click(object sender, EventArgs e)
        {
            //
            // Cria uma janela com os lançamentos do fundo selecionado no grid.
            // Ao fechar a janela criada, a atual é restaurada.
            //

            if (carteiraDataGridView.CurrentRow != null)
            {
                if (carteiraDataGridView.CurrentRow.Cells["InvestimentoID"].Value != DBNull.Value)
                {
                    if (Convert.ToBoolean((int)carteiraDataGridView.CurrentRow.Cells["Fundo"].Value))
                    {
                        int investimentoID = (int)carteiraDataGridView.CurrentRow.Cells["InvestimentoID"].Value;
                        string investimentoNome = (string)carteiraDataGridView.CurrentRow.Cells["Apelido"].Value;

                        // Cria uma instância do form de detalhes
                        listaMovimentosFundo = fmCarteiraListaMovimentosFundo.CreateInstance(this, investimentoID, investimentoNome);

                        // Ajusta a aparência do formulário para que ele se encaixe no lugar do formulário atual 
                        Geral.AjustaAparenciaSubForm(this, listaMovimentosFundo);

                        // Esconde o form atual
                        this.WindowState = FormWindowState.Minimized;

                        // Exibe o sub form
                        listaMovimentosFundo.Show();
                        listaMovimentosFundo.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Esta opção está disponível apenas para fundos de investimento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void ButtonVariacaoDiaria_Click(object sender, EventArgs e)
        {
            contextMenuStripVariacoesDisponiveis.Show(MousePosition);
        }

        private void VariacaoDiariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirVariacaoDiaria();
        }

        private void VariacaoMensalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirVariacaoMensal();
        }

        private void VariacaoDezUltimosDiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirVariacaoDezUltimosDias();
        }
    }
}
