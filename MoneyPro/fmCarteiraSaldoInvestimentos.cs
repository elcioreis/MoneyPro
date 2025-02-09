using BLL;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Modelos.Tipo;

namespace MoneyPro
{
    public partial class fmCarteiraSaldoInvestimentos : MoneyPro.Base.fmBaseTopoRodape
    {
        private DateTime _inicio;
        private DateTime _fim;
        private DateTime _dtUltimaAtualizacao;

        public DateTime DataInicio
        {
            get
            {
                return _inicio;
            }
            set
            {
                _inicio = value;
                dateTimePickerInicio.Value = DataInicio;
                labelTopo.Text = $"Variação de {DataInicio.ToString("dd/MM/yyyy")} até {DataFim.ToString("dd/MM/yyyy")}";
            }
        }

        public DateTime DataFim
        {
            get
            {
                return _fim;
            }
            set
            {
                _fim = value;
                dateTimePickerFim.Value = DataFim;
                labelTopo.Text = $"Variação de {DataInicio.ToString("dd/MM/yyyy")} até {DataFim.ToString("dd/MM/yyyy")}";
            }
        }

        public DateTime DtUltimaAtualizacao
        {
            get { return _dtUltimaAtualizacao; }
            set
            {
                _dtUltimaAtualizacao = value;
                labelUltimaAtualizacao.Text = "Cotações atualizadas até " + _dtUltimaAtualizacao.ToString("dd/MM/yyyy");
            }
        }

        #region Singleton
        private Form Origem { get; set; }
        private int IDUsuario { get; set; }

        private static fmCarteiraSaldoInvestimentos _singleton;

        private fmCarteiraSaldoInvestimentos(Form origem, int usuarioID)
        {
            InitializeComponent();
            this.Origem = origem;
            this.IDUsuario = usuarioID;
            this.Visible = false;

            buttonAno.Text = DateTime.Today.Year.ToString();
            buttonMes.Text = DateTime.Today.ToString("MMM");

            DataInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DataFim = DateTime.Today;
            DtUltimaAtualizacao = Geral.UltimaAtualizacaoInvestimentos();
            CarregarSaldoInvestimento(DataInicio, DataFim);
            SaldoInvestimentosDataGridView.Focus();
        }

        public static fmCarteiraSaldoInvestimentos CreateInstance(Form origem, int usuarioID)
        {
            if (_singleton == null)
            {
                _singleton = new fmCarteiraSaldoInvestimentos(origem, usuarioID);
            }
            return _singleton;
        }

        protected override void OnClosed(EventArgs e)
        {
            _singleton = null;
            base.OnClosed(e);
            Origem.WindowState = FormWindowState.Maximized;
        }

        #endregion Singleton

        private void ButtonFecharDetalhes_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CarregarSaldoInvestimento(DateTime dataInicio, DateTime dataFim)
        {
            // Muda o cursor para ampulheta
            Cursor.Current = Cursors.WaitCursor;

            PesquisaBLL bll = new PesquisaBLL();
            SaldoInvestimentosDataGridView.DataSource = bll.SaldoInvestimento(this.IDUsuario, dataInicio, dataFim);

            // Restaura o cursor padrão
            Cursor.Current = Cursors.Default;
        }

        private void SaldoInvestimentosDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (SaldoInvestimentosDataGridView.Columns[e.ColumnIndex].Visible)
                {
                    string campo = SaldoInvestimentosDataGridView.Columns[e.ColumnIndex].Name;
                    int tipoLinha = (int)SaldoInvestimentosDataGridView.Rows[e.RowIndex].Cells["saldoinicial_TipoLinha"].Value;

                    Color corFundo = Color.White;
                    Color corFonte = Color.Black;

                    switch (tipoLinha)
                    {
                        case (int)TipoCores.TotalGrupo:
                            corFundo = Color.Gray;
                            corFonte = Color.Yellow;
                            break;
                        case (int)TipoCores.TotalSubGrupo:
                            corFundo = Color.LightGray;
                            corFonte = Color.Black;
                            break;
                        case (int)TipoCores.TotalGeral:
                            corFundo = Color.Black;
                            corFonte = Color.Yellow;
                            break;
                        default:
                            corFundo = Color.White;
                            corFonte = Color.Black;
                            break;
                    }

                    if (SaldoInvestimentosDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                    {
                        if (e.Value != DBNull.Value) // && campo.Equals("LucroPrejuizoPerc"))
                        {
                            DataGridViewCell celula = SaldoInvestimentosDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                            decimal valor = (decimal)celula.Value;

                            if (valor < 0)
                            {
                                // menor que zero
                                e.CellStyle.BackColor = corFundo;
                                e.CellStyle.ForeColor = Color.Red;
                            }
                            else if (valor > 0)
                            {
                                // maior que zero
                                e.CellStyle.BackColor = corFundo;
                                e.CellStyle.ForeColor = tipoLinha == 10 || tipoLinha == 99 ? corFonte : Color.Green;
                            }
                            else
                            {
                                // Igual a Zero
                                e.CellStyle.BackColor = corFundo;
                                e.CellStyle.ForeColor = corFonte;
                            }
                        }
                        else
                        {
                            // Nulos
                            e.CellStyle.BackColor = corFundo;
                            e.CellStyle.ForeColor = corFonte;
                        }
                    }
                    else if (campo == "saldoinicial_Risco")
                    {
                        int risco = (int)SaldoInvestimentosDataGridView.Rows[e.RowIndex].Cells["saldoinicial_RiscoID"].Value;
                        switch ((ClassificacaoRisco)risco)
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
                                e.CellStyle.BackColor = corFundo;
                                e.CellStyle.ForeColor = corFonte;
                                break;
                        }
                    }
                    else
                    {
                        e.CellStyle.BackColor = corFundo;
                        e.CellStyle.ForeColor = corFonte;
                    }
                }
            }
        }

        private void SaldoInvestimentosDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Usa o evento CellMouseMove para sobrescrever a geração do ToolTip
            // Note que o ShowCellToolTips do DataGridView foi desligado para não haver sobreposição dos "esparadrapos"

            string dica;

            if (e.ColumnIndex >= 0 && e.RowIndex == -1)
            {
                dica = SaldoInvestimentosDataGridView.Columns[e.ColumnIndex].ToolTipText;
            }
            else if (
                e.ColumnIndex >= 0
                && e.RowIndex >= 0
                && SaldoInvestimentosDataGridView[e.ColumnIndex, e.RowIndex].ToolTipText
                    != null
            )
            {
                dica = SaldoInvestimentosDataGridView[
                    e.ColumnIndex,
                    e.RowIndex
                ].ToolTipText;
            }
            else
            {
                return;
            }

            // verifica se a dica mudou, se não mudou não faz nada para evitar flicker
            if (dica == toolTip.GetToolTip(SaldoInvestimentosDataGridView))
            {
                return;
            }

            toolTip.SetToolTip(SaldoInvestimentosDataGridView, dica);
        }

        private void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void buttonSaldoInvestimentos_Click(object sender, EventArgs e)
        {
            DataInicio = dateTimePickerInicio.Value;
            DataFim = dateTimePickerFim.Value;
            CarregarSaldoInvestimento(DataInicio, DataFim);
        }

        private void buttonAno_Click(object sender, EventArgs e)
        {
            DataInicio = new DateTime(DateTime.Now.Year, 1, 1);
            DataFim = DateTime.Today;
            CarregarSaldoInvestimento(DataInicio, DataFim);
        }

        private void buttonMes_Click(object sender, EventArgs e)
        {
            DataInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DataFim = DateTime.Today;
            CarregarSaldoInvestimento(DataInicio, DataFim);
        }

        private void button1M_Click(object sender, EventArgs e)
        {
            DataInicio = DateTime.Today.AddMonths(-1).AddDays(1);
            DataFim = DateTime.Today;
            CarregarSaldoInvestimento(DataInicio, DataFim);
        }

        private void button3M_Click(object sender, EventArgs e)
        {
            DataInicio = DateTime.Today.AddMonths(-3).AddDays(1);
            DataFim = DateTime.Today;
            CarregarSaldoInvestimento(DataInicio, DataFim);
        }

        private void button6M_Click(object sender, EventArgs e)
        {
            DataInicio = DateTime.Today.AddMonths(-6).AddDays(1);
            DataFim = DateTime.Today;
            CarregarSaldoInvestimento(DataInicio, DataFim);
        }

        private void button1A_Click(object sender, EventArgs e)
        {
            DataInicio = DateTime.Today.AddYears(-1).AddDays(1);
            DataFim = DateTime.Today;
            CarregarSaldoInvestimento(DataInicio, DataFim);
        }

        private void buttonMaximo_Click(object sender, EventArgs e)
        {
            DataInicio = Geral.PrimeiroDiaMovimento(IDUsuario);
            DataFim = DateTime.Today;
            CarregarSaldoInvestimento(DataInicio, DataFim);
        }
    }

    enum TipoCores
    {
        TotalGrupo = 10,
        TotalSubGrupo = 21,
        Detalhe = 22,
        TotalGeral = 99
    }
}
