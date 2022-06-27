using BLL;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using static Modelos.Tipo;

namespace MoneyPro
{
    public partial class fmCarteiraVariacaoDiaria : MoneyPro.Base.fmBaseTopoRodape
    {
        const int LarguraMinima = 70;
        const decimal infinitoNegativo = (decimal)-9.9999;
        const decimal infinitoPositivo = (decimal)9.9999;

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
                labelTopo.Text = "Variação Diária de Investimentos em " + _DataBase.ToString("MM/yyyy");
                CarregarVariacaoDiaria(_DataBase);
            }
        }

        #region Singleton
        private Form Origem { get; set; }
        private int IDUsuario { get; set; }

        private static fmCarteiraVariacaoDiaria _singleton;

        private fmCarteiraVariacaoDiaria(Form origem, int usuarioID)
        {
            InitializeComponent();
            this.Origem = origem;
            this.IDUsuario = usuarioID;
            this.Visible = false;

            dateTimePickerDataBase.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);

            DtUltimaAtualizacao = Geral.UltimaAtualizacaoInvestimentos();

            variacaoDiariaInvestimentosDataGridView.Focus();
        }

        public static fmCarteiraVariacaoDiaria CreateInstance(Form origem, int usuarioID)
        {
            if (_singleton == null)
            {
                _singleton = new fmCarteiraVariacaoDiaria(origem, usuarioID);
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

        private void CarregarVariacaoDiaria(DateTime dataReferencia)
        {
            PesquisaBLL bll = new PesquisaBLL();
            variacaoDiariaInvestimentosDataGridView.DataSource = bll.VariacaoDiariaInvestimento(this.IDUsuario, dataReferencia);

            DateTime data = (DateTime)variacaoDiariaInvestimentosDataGridView.Rows[0].Cells["variacao_DataReferencia"].Value;

            variacaoDiariaInvestimentosDataGridView.Columns["variacao_Dia29"].Visible = true;
            variacaoDiariaInvestimentosDataGridView.Columns["variacao_Dia30"].Visible = true;
            variacaoDiariaInvestimentosDataGridView.Columns["variacao_Dia31"].Visible = true;

            switch (data.Month)
            {  // Meses com 31 dias: 1 3 5 7 8 10 12
                case 2:
                    if (DateTime.IsLeapYear(data.Year))
                    {
                        // Ano bissexto, dia 29 é exibido
                        variacaoDiariaInvestimentosDataGridView.Columns["variacao_Dia30"].Visible = false;
                        variacaoDiariaInvestimentosDataGridView.Columns["variacao_Dia31"].Visible = false;
                    }
                    else
                    {
                        // Ano não bissexto, dia 29 não é exibido
                        variacaoDiariaInvestimentosDataGridView.Columns["variacao_Dia29"].Visible = false;
                        variacaoDiariaInvestimentosDataGridView.Columns["variacao_Dia30"].Visible = false;
                        variacaoDiariaInvestimentosDataGridView.Columns["variacao_Dia31"].Visible = false;
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    variacaoDiariaInvestimentosDataGridView.Columns["variacao_Dia31"].Visible = false;
                    break;
                default:
                    break;
            }

            DateTime dia = new DateTime(data.Year, data.Month, 1).AddDays(-1);

            short i = 0;
            while (dia <= data)
            {
                string campo = "variacao_Dia" + i.ToString("00");

                if (variacaoDiariaInvestimentosDataGridView.Columns[campo].Visible)
                {
                    // Armazena o dia exibido na coluna na Tag da própria coluna
                    variacaoDiariaInvestimentosDataGridView.Columns[campo].Tag = dia;

                    // Renomeará o cabeçalho de Dia01, Dia02, etc para 01/08, 02/08, etc

                    if (i > 0)
                    {
                        variacaoDiariaInvestimentosDataGridView.Columns[campo].HeaderText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dia.ToString("ddd dd/MM"));
                    }
                    else
                    {
                        variacaoDiariaInvestimentosDataGridView.Columns[campo].HeaderText = "Anterior *";
                        variacaoDiariaInvestimentosDataGridView.Columns[campo].ToolTipText = "Último dia do mês anterior";
                    }
                    variacaoDiariaInvestimentosDataGridView.Columns[campo].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    variacaoDiariaInvestimentosDataGridView.Columns[campo].DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Format = "N2",
                    };
                    variacaoDiariaInvestimentosDataGridView.Columns[campo].MinimumWidth = LarguraMinima;
                    variacaoDiariaInvestimentosDataGridView.Columns[campo].SortMode = DataGridViewColumnSortMode.NotSortable;
                    variacaoDiariaInvestimentosDataGridView.Columns[campo].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                i++;
                dia = dia.AddDays(1);
            }

            variacaoDiariaInvestimentosDataGridView.Columns["variacao_Per0031"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            variacaoDiariaInvestimentosDataGridView.Columns["variacao_Per0031"].MinimumWidth = LarguraMinima;
            variacaoDiariaInvestimentosDataGridView.Columns["variacao_Per0031"].ToolTipText = "Variação entre o último dia do mês anterior e o último dia do mês corrente";
        }

        private void DateTimePickerDataBase_ValueChanged(object sender, EventArgs e)
        {
            DataBase = dateTimePickerDataBase.Value;
        }

        private void VariacaoDiariaInvestimentosDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (variacaoDiariaInvestimentosDataGridView.Columns[e.ColumnIndex].Visible)
                {
                    string campo = variacaoDiariaInvestimentosDataGridView.Columns[e.ColumnIndex].Name;
                    short tipoLinha = (short)variacaoDiariaInvestimentosDataGridView.Rows[e.RowIndex].Cells["variacao_TipoLinha"].Value;

                    if (tipoLinha == 1)
                    {
                        // Sub total
                        // Trata as fontes das células de detalhes
                        if (variacaoDiariaInvestimentosDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            if (variacaoDiariaInvestimentosDataGridView.Columns[e.ColumnIndex].Name.StartsWith("variacao_Dia"))
                            {
                                if (int.TryParse(campo.Substring(campo.Length - 2), out int mes))
                                {
                                    if (mes > 1)
                                    {
                                        string nomeReferencia = "variacao_Var" + (mes - 1).ToString("00") + (mes).ToString("00");
                                        short referencia = (short)variacaoDiariaInvestimentosDataGridView.Rows[e.RowIndex].Cells[nomeReferencia].Value;

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
                            else if (variacaoDiariaInvestimentosDataGridView.Columns[e.ColumnIndex].Name.Equals("variacao_Per0031"))
                            {

                                DataGridViewCell celula = variacaoDiariaInvestimentosDataGridView.Rows[e.RowIndex].Cells["variacao_Per0031"];
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
                                        SelectionForeColor = SystemColors.HighlightText,
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

                        // Linhas de detalhes
                        if (variacaoDiariaInvestimentosDataGridView.Columns[e.ColumnIndex].HeaderText.StartsWith("Sáb") ||
                            variacaoDiariaInvestimentosDataGridView.Columns[e.ColumnIndex].HeaderText.StartsWith("Dom") ||
                            variacaoDiariaInvestimentosDataGridView.Columns[e.ColumnIndex].HeaderText.StartsWith("Anterior"))
                        {
                            // Dias de fim de semana serão marcados como cinza claro
                            e.CellStyle.BackColor = Color.Gainsboro;
                        }
                        else
                        {
                            // Dias de semana serão branco (cor padrão)
                            e.CellStyle.BackColor = Color.White;
                        }

                        // Trata as fontes das células de detalhes
                        if (variacaoDiariaInvestimentosDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            if (variacaoDiariaInvestimentosDataGridView.Columns[e.ColumnIndex].Name.StartsWith("variacao_Dia"))
                            {
                                if (int.TryParse(campo.Substring(campo.Length - 2), out int mes))
                                {
                                    if (mes > 0)
                                    {
                                        string nomeReferencia = "variacao_Var" + (mes - 1).ToString("00") + (mes).ToString("00");
                                        short referencia = (short)variacaoDiariaInvestimentosDataGridView.Rows[e.RowIndex].Cells[nomeReferencia].Value;

                                        switch (referencia)
                                        {
                                            case -9:
                                            case -1:
                                                //e.CellStyle.BackColor = Color.White;
                                                e.CellStyle.ForeColor = Color.Red;
                                                break;
                                            case 0:
                                                //e.CellStyle.BackColor = Color.White;
                                                e.CellStyle.ForeColor = Color.Black;
                                                break;
                                            case 1:
                                            case 9:
                                                //e.CellStyle.BackColor = Color.White;
                                                e.CellStyle.ForeColor = Color.Green;
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        //e.CellStyle.BackColor = Color.White;
                                        e.CellStyle.ForeColor = Color.Black;
                                    }
                                }
                            }
                            else if (variacaoDiariaInvestimentosDataGridView.Columns[e.ColumnIndex].Name.Equals("variacao_Per0031"))
                            {
                                
                                DataGridViewCell celula = variacaoDiariaInvestimentosDataGridView.Rows[e.RowIndex].Cells["variacao_Per0031"];
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
                        }
                        else if (campo == "variacao_Risco")
                        {
                            ClassificacaoRisco risco = (ClassificacaoRisco)variacaoDiariaInvestimentosDataGridView.Rows[e.RowIndex].Cells["variacao_RiscoID"].Value;

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
                        if (variacaoDiariaInvestimentosDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            if (variacaoDiariaInvestimentosDataGridView.Columns[e.ColumnIndex].Name.StartsWith("variacao_Dia"))
                            {
                                if (int.TryParse(campo.Substring(campo.Length - 2), out int mes))
                                {
                                    if (mes > 1)
                                    {
                                        string nomeReferencia = "variacao_Var" + (mes - 1).ToString("00") + (mes).ToString("00");
                                        short referencia = (short)variacaoDiariaInvestimentosDataGridView.Rows[e.RowIndex].Cells[nomeReferencia].Value;

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
                            else if (variacaoDiariaInvestimentosDataGridView.Columns[e.ColumnIndex].Name.Equals("variacao_Per0031"))
                            {
                                decimal perc = (decimal)variacaoDiariaInvestimentosDataGridView.Rows[e.RowIndex].Cells["variacao_Per0031"].Value;

                                if (perc < infinitoNegativo)
                                {
                                    // menos infinito
                                    e.Value = "-" + ((char)0x221E).ToString();

                                    DataGridViewCellStyle especial = new DataGridViewCellStyle
                                    {
                                        Font = new Font("Lucida Console", 13, FontStyle.Regular),
                                        Alignment = DataGridViewContentAlignment.TopCenter,
                                        BackColor = Color.Black,
                                        ForeColor = Color.Tomato,
                                        SelectionBackColor = SystemColors.Highlight,
                                        SelectionForeColor = SystemColors.HighlightText
                                    };

                                    e.CellStyle = especial;
                                }
                                else if (perc < 0)
                                {
                                    // menor que zero até -999
                                    e.CellStyle.BackColor = Color.Black;
                                    e.CellStyle.ForeColor = Color.Tomato;
                                }
                                else if (perc == 0)
                                {
                                    // Zero
                                    e.CellStyle.BackColor = Color.Black;
                                    e.CellStyle.ForeColor = Color.Tomato;
                                }
                                else if (perc < infinitoPositivo)
                                {
                                    // maior que zero até 999
                                    e.CellStyle.BackColor = Color.Black;
                                    e.CellStyle.ForeColor = Color.Lime;
                                }
                                else
                                {
                                    // infinito
                                    e.Value = ((char)0x221E).ToString();

                                    DataGridViewCellStyle especial = new DataGridViewCellStyle
                                    {
                                        Font = new Font("Lucida Console", 13, FontStyle.Regular),
                                        Alignment = DataGridViewContentAlignment.TopCenter,
                                        BackColor = Color.Black,
                                        ForeColor = Color.Lime,
                                        SelectionBackColor = SystemColors.Highlight,
                                        SelectionForeColor = SystemColors.HighlightText
                                    };

                                    e.CellStyle = especial;
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

        private void FmCarteiraVariacaoDiaria_KeyDown(object sender, KeyEventArgs e)
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

        private void ExibeMesPosterior()
        {
            DateTime data = new DateTime(dateTimePickerDataBase.Value.Year, dateTimePickerDataBase.Value.Month, 15);
            dateTimePickerDataBase.Value = data.AddMonths(1);
        }

        private void VariacaoDiariaInvestimentosDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Pinta os CABEÇALHOS de dias após a última atualização de investimentos/poupança
            if (e.RowIndex == -1)
            {
                if (variacaoDiariaInvestimentosDataGridView.Columns[e.ColumnIndex].Tag != null)
                {
                    DateTime diaColuna = (DateTime)variacaoDiariaInvestimentosDataGridView.Columns[e.ColumnIndex].Tag;

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

        private void VariacaoDiariaInvestimentosDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Usa o evento CellMouseMove para sobrescrever a geração do ToolTip
            // Note que o ShowCellToolTips do DataGridView foi desligado para não haver sobreposição dos "esparadrapos"

            string dica;

            if (e.ColumnIndex >= 0 && e.RowIndex == -1)
            {
                dica = variacaoDiariaInvestimentosDataGridView.Columns[e.ColumnIndex].ToolTipText;
            }
            else if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && variacaoDiariaInvestimentosDataGridView[e.ColumnIndex, e.RowIndex].ToolTipText != null)
            {
                dica = variacaoDiariaInvestimentosDataGridView[e.ColumnIndex, e.RowIndex].ToolTipText;
            }
            else
            {
                return;
            }

            // verifica se a dica mudou, se não mudou não faz nada para evitar flicker
            if (dica == toolTip.GetToolTip(variacaoDiariaInvestimentosDataGridView))
            {
                return;
            }

            toolTip.SetToolTip(variacaoDiariaInvestimentosDataGridView, dica);
        }

        private void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
    }
}
