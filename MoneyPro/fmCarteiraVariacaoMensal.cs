using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BLL;
using static Modelos.Tipo;

namespace MoneyPro
{
    public partial class fmCarteiraVariacaoMensal : MoneyPro.Base.fmBaseTopoRodape
    {
        const int LarguraMinima = 70;
        const decimal infinitoNegativo = (decimal)-9.9999;
        const decimal infinitoPositivo = (decimal)9.9999;

        private DateTime _DataBase;
        public DateTime DataBase
        {
            get
            {
                return _DataBase;
            }
            set
            {
                _DataBase = value;
                labelTopo.Text = "Variação Mensal de Investimentos até " + _DataBase.ToString("MM/yyyy");
                CarregarVariacaoMensal(_DataBase);
            }
        }

        private DateTime dtUltimaAtualizacao;

        public DateTime DtUltimaAtualizacao
        {
            get
            {
                return dtUltimaAtualizacao;
            }

            set
            {
                dtUltimaAtualizacao = value;
                labelUltimaAtualizacao.Text = "Cotações atualizadas até " + dtUltimaAtualizacao.ToString("dd/MM/yyyy");
            }
        }

        #region Singleton
        private Form Origem { get; set; }
        private int IDUsuario { get; set; }

        private static fmCarteiraVariacaoMensal _singleton;

        private fmCarteiraVariacaoMensal(Form origem, int usuarioID)
        {
            InitializeComponent();
            this.Origem = origem;
            this.IDUsuario = usuarioID;
            this.Visible = false;

            dateTimePickerDataBase.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);

            DtUltimaAtualizacao = Geral.UltimaAtualizacaoInvestimentos();

            variacaoMensalInvestimentosDataGridView.Focus();
        }

        public static fmCarteiraVariacaoMensal CreateInstance(Form origem, int usuarioID)
        {
            if (_singleton == null)
            {
                _singleton = new fmCarteiraVariacaoMensal(origem, usuarioID);
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

        private void CarregarVariacaoMensal(DateTime dataReferencia)
        {
            PesquisaBLL bll = new PesquisaBLL();
            variacaoMensalInvestimentosDataGridView.DataSource = bll.VariacaoMensalInvestimento(this.IDUsuario, dataReferencia);

            for (short i = 1; i <= 13; i++)
            {
                string campo = "variacao_Mes" + i.ToString("00");

                DateTime mes = DataBase.AddMonths((13 - i) * -1);

                // Encontra o último dia do mês e o coloca na Tag do campo
                DateTime dia = new DateTime(mes.Year, mes.Month, DateTime.DaysInMonth(mes.Year, mes.Month));

                variacaoMensalInvestimentosDataGridView.Columns[campo].Tag = dia;
                variacaoMensalInvestimentosDataGridView.Columns[campo].HeaderText = dia.ToString("MM/yyyy");

                variacaoMensalInvestimentosDataGridView.Columns[campo].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                variacaoMensalInvestimentosDataGridView.Columns[campo].MinimumWidth = LarguraMinima;
            }
            variacaoMensalInvestimentosDataGridView.Columns["variacao_Perc1213"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            variacaoMensalInvestimentosDataGridView.Columns["variacao_Perc1213"].HeaderText = "Variação *";
            variacaoMensalInvestimentosDataGridView.Columns["variacao_Perc1213"].MinimumWidth = LarguraMinima;
            variacaoMensalInvestimentosDataGridView.Columns["variacao_Perc1213"].ToolTipText = "Variação do mês anterior para o mês atual";
        }

        private void VariacaoMensalInvestimentosDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (variacaoMensalInvestimentosDataGridView.Columns[e.ColumnIndex].Visible)
                {
                    string campo = variacaoMensalInvestimentosDataGridView.Columns[e.ColumnIndex].Name;
                    short tipoLinha = (short)variacaoMensalInvestimentosDataGridView.Rows[e.RowIndex].Cells["variacao_TipoLinha"].Value;

                    if (tipoLinha == 1)
                    {
                        // Sub total
                        // Trata as fontes das células de detalhes
                        if (variacaoMensalInvestimentosDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            if (campo.Equals("variacao_Perc1213") && e.Value != DBNull.Value)
                            {
                                DataGridViewCell celula = variacaoMensalInvestimentosDataGridView.Rows[e.RowIndex].Cells["variacao_Perc1213"];
                                decimal perc = (decimal)celula.Value;

                                if (perc < infinitoNegativo)
                                {
                                    // menos infinito
                                    e.Value = "-" + ((char)0x221E).ToString();

                                    DataGridViewCellStyle especial = new DataGridViewCellStyle
                                    {
                                        Font = new Font("Lucida Console", 13, FontStyle.Regular),
                                        Alignment = DataGridViewContentAlignment.TopCenter,
                                        BackColor = Color.DarkGray,
                                        ForeColor = Color.Red,
                                        SelectionBackColor = SystemColors.Highlight,
                                        SelectionForeColor = SystemColors.HighlightText
                                    };

                                    e.CellStyle = especial;
                                    celula.ToolTipText = "Resgate total";
                                }
                                else if (perc < 0)
                                {
                                    // menor que zero até -999
                                    e.CellStyle.BackColor = Color.DarkGray;
                                    e.CellStyle.ForeColor = Color.Red;
                                }
                                else if (perc == 0)
                                {
                                    // Zero
                                    e.CellStyle.BackColor = Color.DarkGray;
                                    e.CellStyle.ForeColor = Color.Black;
                                }
                                else if (perc < infinitoPositivo)
                                {
                                    // maior que zero até 999
                                    e.CellStyle.BackColor = Color.DarkGray;
                                    e.CellStyle.ForeColor = Color.Green;
                                }
                                else
                                {
                                    // infinito
                                    e.Value = "+" + ((char)0x221E).ToString();

                                    DataGridViewCellStyle especial = new DataGridViewCellStyle
                                    {
                                        Font = new Font("Lucida Console", 13, FontStyle.Regular),
                                        Alignment = DataGridViewContentAlignment.TopCenter,
                                        BackColor = Color.DarkGray,
                                        ForeColor = Color.Green,
                                        SelectionBackColor = SystemColors.Highlight,
                                        SelectionForeColor = SystemColors.HighlightText
                                    };

                                    e.CellStyle = especial;
                                    celula.ToolTipText = "Aporte inicial";
                                }
                            }
                            else if (int.TryParse(campo.Substring(campo.Length - 2), out int mes))
                            {
                                if (mes > 1)
                                {
                                    string nomeReferencia = "variacao_Var" + (mes - 1).ToString("00") + (mes).ToString("00");
                                    short referencia = (short)variacaoMensalInvestimentosDataGridView.Rows[e.RowIndex].Cells[nomeReferencia].Value;

                                    switch (referencia)
                                    {
                                        case -9:
                                        case -1:
                                            e.CellStyle.BackColor = Color.DarkGray;
                                            e.CellStyle.ForeColor = Color.Red;
                                            break;
                                        case 0:
                                            e.CellStyle.BackColor = Color.DarkGray;
                                            e.CellStyle.ForeColor = Color.Black;
                                            break;
                                        case 1:
                                        case 9:
                                            e.CellStyle.BackColor = Color.DarkGray;
                                            e.CellStyle.ForeColor = Color.Green;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    e.CellStyle.BackColor = Color.DarkGray;
                                    e.CellStyle.ForeColor = Color.Black;
                                }
                            }
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.DarkGray;
                            e.CellStyle.ForeColor = Color.Black;
                        }
                    }
                    else if (tipoLinha == 2)
                    {
                        // Detalhe

                        // Trata as fontes das células de detalhes

                        if (variacaoMensalInvestimentosDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            if (campo.Equals("variacao_Perc1213") && e.Value != DBNull.Value)
                            {
                                DataGridViewCell celula = variacaoMensalInvestimentosDataGridView.Rows[e.RowIndex].Cells["variacao_Perc1213"];
                                decimal perc = (decimal)celula.Value;

                                if (perc < infinitoNegativo)
                                {
                                    // menos infinito
                                    e.Value = "-" + ((char)0x221E).ToString();

                                    DataGridViewCellStyle especial = new DataGridViewCellStyle
                                    {
                                        Font = new Font("Lucida Console", 13, FontStyle.Regular),
                                        Alignment = DataGridViewContentAlignment.TopCenter,
                                        BackColor = Color.White,
                                        ForeColor = Color.Red,
                                        SelectionBackColor = SystemColors.Highlight,
                                        SelectionForeColor = SystemColors.HighlightText
                                    };

                                    e.CellStyle = especial;
                                    celula.ToolTipText = "Resgate total";
                                }
                                else if (perc < 0)
                                {
                                    // menor que zero até -999
                                    e.CellStyle.BackColor = Color.White;
                                    e.CellStyle.ForeColor = Color.Red;
                                }
                                else if (perc == 0)
                                {
                                    // Zero
                                    e.CellStyle.BackColor = Color.White;
                                    e.CellStyle.ForeColor = Color.Black;
                                }
                                else if (perc < infinitoPositivo)
                                {
                                    // maior que zero até 999
                                    e.CellStyle.BackColor = Color.White;
                                    e.CellStyle.ForeColor = Color.Green;
                                }
                                else
                                {
                                    // infinito
                                    e.Value = "+" + ((char)0x221E).ToString();

                                    DataGridViewCellStyle especial = new DataGridViewCellStyle
                                    {
                                        Font = new Font("Lucida Console", 13, FontStyle.Regular),
                                        Alignment = DataGridViewContentAlignment.TopCenter,
                                        BackColor = Color.White,
                                        ForeColor = Color.Green,
                                        SelectionBackColor = SystemColors.Highlight,
                                        SelectionForeColor = SystemColors.HighlightText
                                    };

                                    e.CellStyle = especial;
                                    celula.ToolTipText = "Aporte inicial";
                                }
                            }
                            else if (int.TryParse(campo.Substring(campo.Length - 2), out int mes))
                            {
                                if (mes > 1)
                                {
                                    string nomeReferencia = "variacao_Var" + (mes - 1).ToString("00") + (mes).ToString("00");
                                    short referencia = (short)variacaoMensalInvestimentosDataGridView.Rows[e.RowIndex].Cells[nomeReferencia].Value;

                                    switch (referencia)
                                    {
                                        case -9:
                                        case -1:
                                            e.CellStyle.BackColor = Color.White;
                                            e.CellStyle.ForeColor = Color.Red;
                                            break;
                                        case 0:
                                            e.CellStyle.BackColor = Color.White;
                                            e.CellStyle.ForeColor = Color.Black;
                                            break;
                                        case 1:
                                        case 9:
                                            e.CellStyle.BackColor = Color.White;
                                            e.CellStyle.ForeColor = Color.Green;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    e.CellStyle.BackColor = Color.White;
                                    e.CellStyle.ForeColor = Color.Black;
                                }
                            }
                        }
                        else if (campo == "variacao_Risco")
                        {
                            ClassificacaoRisco risco = (ClassificacaoRisco)variacaoMensalInvestimentosDataGridView.Rows[e.RowIndex].Cells["variacao_RiscoID"].Value;

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
                        else
                        {
                            e.CellStyle.BackColor = Color.White;
                            e.CellStyle.ForeColor = Color.Black;
                        }
                    }
                    else if (tipoLinha == 3)
                    {
                        // Total geral                        
                        if (variacaoMensalInvestimentosDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            if (int.TryParse(campo.Substring(campo.Length - 2), out int mes))
                            {
                                if (mes > 1)
                                {
                                    string nomeReferencia = "variacao_Var" + (mes - 1).ToString("00") + (mes).ToString("00");
                                    short referencia = (short)variacaoMensalInvestimentosDataGridView.Rows[e.RowIndex].Cells[nomeReferencia].Value;

                                    switch (referencia)
                                    {
                                        case -9:
                                        case -1:
                                            e.CellStyle.BackColor = Color.Black;
                                            e.CellStyle.ForeColor = Color.Tomato;
                                            break;
                                        case 0:
                                            e.CellStyle.BackColor = Color.Black;
                                            e.CellStyle.ForeColor = Color.White;
                                            break;
                                        case 1:
                                        case 9:
                                            e.CellStyle.BackColor = Color.Black;
                                            e.CellStyle.ForeColor = Color.Lime;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    e.CellStyle.BackColor = Color.Black;
                                    e.CellStyle.ForeColor = Color.White;
                                }
                            }
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.Black;
                            e.CellStyle.ForeColor = Color.White;
                        }
                    }
                }
            }
        }

        private void DateTimePickerDataBase_ValueChanged(object sender, EventArgs e)
        {
            DataBase = dateTimePickerDataBase.Value;
        }

        private void FmCarteiraVariacaoMensal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                ExibeMesAnterior();
            }
            else if (e.KeyCode == Keys.Right && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                ExibeMesPosterior();
            }
            else if (e.KeyCode == Keys.Up && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                ExibeMesCorrente();
            }
            else if (e.KeyCode == Keys.Down && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                ExibeMesUltimoMesComCotacoes();
            }
        }

        private void ExibeMesAnterior()
        {
            DateTime data = new DateTime(dateTimePickerDataBase.Value.Year, dateTimePickerDataBase.Value.Month, 15);
            dateTimePickerDataBase.Value = data.AddMonths(-1);
        }

        private void ExibeMesCorrente()
        {
            dateTimePickerDataBase.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);
        }

        private void ExibeMesUltimoMesComCotacoes()
        {
            // Informa o dia 15 do mês que contém a última cotação
            dateTimePickerDataBase.Value = new DateTime(DtUltimaAtualizacao.Year, DtUltimaAtualizacao.Month, 15);
        }

        private void ExibeMesPosterior()
        {
            DateTime data = new DateTime(dateTimePickerDataBase.Value.Year, dateTimePickerDataBase.Value.Month, 15);
            dateTimePickerDataBase.Value = data.AddMonths(1);
        }

        private void VariacaoMensalInvestimentosDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Pinta os CABEÇALHOS de dias após a última atualização de investimentos/poupança
            if (e.RowIndex == -1)
            {
                if (variacaoMensalInvestimentosDataGridView.Columns[e.ColumnIndex].Tag != null)
                {
                    DateTime diaColuna = (DateTime)variacaoMensalInvestimentosDataGridView.Columns[e.ColumnIndex].Tag;

                    if (diaColuna > dtUltimaAtualizacao)
                    {
                        Color c1 = Color.Gold; // FromArgb(255, 54, 54, 54);
                        Color c2 = Color.Gold; // FromArgb(255, 62, 62, 62);
                        Color c3 = Color.Gold; // FromArgb(255, 98, 98, 98);

                        LinearGradientBrush br = new LinearGradientBrush(e.CellBounds, c1, c3, 90, true);
                        ColorBlend cb = new ColorBlend();
                        cb.Positions = new[] { 0, (float)0.5, 1 };
                        cb.Colors = new[] { c1, c2, c3 };
                        br.InterpolationColors = cb;

                        e.Graphics.FillRectangle(br, e.CellBounds);
                        e.PaintContent(e.ClipBounds);

                        e.Handled = true;
                    }
                }
            }
        }

        private void VariacaoMensalInvestimentosDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Usa o evento CellMouseMove para sobrescrever a geração do ToolTip
            // Note que o ShowCellToolTips do DataGridView foi desligado para não haver sobreposição dos "esparadrapos"

            string dica;

            if (e.ColumnIndex >= 0 && e.RowIndex == -1)
            {
                dica = variacaoMensalInvestimentosDataGridView.Columns[e.ColumnIndex].ToolTipText;
            }
            else if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && variacaoMensalInvestimentosDataGridView[e.ColumnIndex, e.RowIndex].ToolTipText != null)
            {
                dica = variacaoMensalInvestimentosDataGridView[e.ColumnIndex, e.RowIndex].ToolTipText;
            }
            else
            {
                return;
            }

            // verifica se a dica mudou, se não mudou não faz nada para evitar flicker
            if (dica == toolTip.GetToolTip(variacaoMensalInvestimentosDataGridView))
            {
                return;
            }

            toolTip.SetToolTip(variacaoMensalInvestimentosDataGridView, dica);
        }

        private void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
    }
}
