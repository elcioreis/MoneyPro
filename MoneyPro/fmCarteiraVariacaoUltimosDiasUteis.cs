using BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static Modelos.Tipo;

namespace MoneyPro
{
    public partial class fmCarteiraVariacaoUltimosDiasUteis : MoneyPro.Base.fmBaseTopoRodape
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

                CarregarGrid(IDUsuario);
            }
        }

        #region Singleton
        private Form Origem { get; set; }
        private int IDUsuario { get; set; }

        private static fmCarteiraVariacaoUltimosDiasUteis _singleton;

        private fmCarteiraVariacaoUltimosDiasUteis(Form origem, int usuarioID)
        {
            InitializeComponent();
            this.Origem = origem;
            this.IDUsuario = usuarioID;
            this.Visible = false;

            dateTimePickerDataBase.Value = Geral.UltimaAtualizacaoInvestimentos();

            variacaoDezDiasInvestimentosDataGridView.Focus();
        }

        public static fmCarteiraVariacaoUltimosDiasUteis CreateInstance(Form origem, int usuarioID)
        {
            if (_singleton == null)
            {
                _singleton = new fmCarteiraVariacaoUltimosDiasUteis(origem, usuarioID);
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

        private void CarregarGrid(int usuarioID)
        {
            PesquisaBLL bll = new PesquisaBLL();
            variacaoDezDiasInvestimentosDataGridView.DataSource = bll.VariacaoUltimosDiasUteisInvestimento(usuarioID, dtUltimaAtualizacao);

            // Exemplo de retorno do campo ListaDatasISO
            // 20190814;20190815;20190816;20190819;20190820
            string datasISO = (string)variacaoDezDiasInvestimentosDataGridView.Rows[0].Cells["variacao_ListaDatasISO"].Value;

            List<String> lista = datasISO.Split(';').ToList<string>();

            labelTopo.Text = "Variação Últimos Dias até " + DateTime.ParseExact(lista[lista.Count - 1], "yyyyMMdd", null).ToString("dd/MM/yyyy");

            int Col = 1;
            foreach (string dataISO in lista)
            {
                DateTime Dia = DateTime.ParseExact(dataISO, "yyyyMMdd", null);

                string campoDias = "variacao_Dia" + Col.ToString("00");
                string campoVarR = "variacao_VarR" + Col.ToString("00") + (Col + 1).ToString("00");
                string campoPerc = "variacao_Perc" + Col.ToString("00") + (++Col).ToString("00");

                variacaoDezDiasInvestimentosDataGridView.Columns[campoDias].HeaderText = Dia.ToString("ddd dd/MM");
                variacaoDezDiasInvestimentosDataGridView.Columns[campoDias].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                variacaoDezDiasInvestimentosDataGridView.Columns[campoDias].DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N2",
                };
                variacaoDezDiasInvestimentosDataGridView.Columns[campoDias].MinimumWidth = LarguraMinima;
                variacaoDezDiasInvestimentosDataGridView.Columns[campoDias].SortMode = DataGridViewColumnSortMode.NotSortable;
                variacaoDezDiasInvestimentosDataGridView.Columns[campoDias].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                variacaoDezDiasInvestimentosDataGridView.Columns[campoDias].Tag = 1;

                if (Col <= lista.Count)
                {
                    // Converte a string ANSI em data para converter novamente em string no formato brasileiro
                    string variacao = string.Format("{0} e {1}",
                                                    DateTime.ParseExact(lista[Col - 2], "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"),
                                                    DateTime.ParseExact(lista[Col - 1], "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy"));
                    // Campo que exibe a variação da aplicação em reais
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoVarR].HeaderText = "R$";
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoVarR].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoVarR].DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Format = "N2",
                    };
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoVarR].MinimumWidth = LarguraMinima;
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoVarR].SortMode = DataGridViewColumnSortMode.NotSortable;
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoVarR].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoVarR].Tag = 2;
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoVarR].ToolTipText = "Variação em Reais entre " + variacao;


                    // Campo que exibe a variação da aplicação em porcentagem
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoPerc].HeaderText = "%";
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoPerc].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoPerc].DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleRight,
                        Format = "P4",
                    };
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoPerc].MinimumWidth = LarguraMinima;
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoPerc].SortMode = DataGridViewColumnSortMode.NotSortable;
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoPerc].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoPerc].Tag = 2;
                    variacaoDezDiasInvestimentosDataGridView.Columns[campoPerc].ToolTipText = "Variação em percentual entre " + variacao;
                }
            }
        }

        private void VariacaoDezDiasInvestimentosDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (variacaoDezDiasInvestimentosDataGridView.Columns[e.ColumnIndex].Visible)
                {
                    DataGridViewColumn coluna = variacaoDezDiasInvestimentosDataGridView.Columns[e.ColumnIndex];
                    string campo = variacaoDezDiasInvestimentosDataGridView.Columns[e.ColumnIndex].Name;
                    short tipoLinha = (short)variacaoDezDiasInvestimentosDataGridView.Rows[e.RowIndex].Cells["variacao_TipoLinha"].Value;

                    if (tipoLinha == 1)
                    {
                        // Sub total
                        // Trata as fontes das células de detalhes
                        if (coluna.ValueType == typeof(decimal))
                        {
                            if (coluna.Name.StartsWith("variacao_Perc") && e.Value != DBNull.Value)
                            {
                                DataGridViewCell celula = variacaoDezDiasInvestimentosDataGridView.Rows[e.RowIndex].Cells[coluna.Index];
                                decimal valor = (decimal)e.Value;

                                if (valor < infinitoNegativo)
                                {
                                    // menos infinito
                                    e.Value = "-" + ((char)0x221E).ToString();

                                    e.CellStyle = new DataGridViewCellStyle
                                    {
                                        Font = new Font("Lucida Console", 13, FontStyle.Regular),
                                        Alignment = DataGridViewContentAlignment.TopCenter,
                                        BackColor = Color.DarkGray,
                                        ForeColor = Color.Red,
                                        SelectionBackColor = SystemColors.Highlight,
                                        SelectionForeColor = SystemColors.HighlightText
                                    };

                                    celula.ToolTipText = "Resgate total";
                                }
                                else if (valor < 0)
                                {
                                    // menor que zero até -999
                                    e.CellStyle.BackColor = Color.DarkGray;
                                    e.CellStyle.ForeColor = Color.Red;
                                }
                                else if (valor == 0)
                                {
                                    // Zero
                                    e.CellStyle.BackColor = Color.DarkGray;
                                    e.CellStyle.ForeColor = Color.Black;
                                }
                                else if (valor < infinitoPositivo)
                                {
                                    // maior que zero até 999
                                    e.CellStyle.BackColor = Color.DarkGray;
                                    e.CellStyle.ForeColor = Color.Green;
                                }
                                else
                                {
                                    // infinito
                                    e.Value = "+" + ((char)0x221E).ToString();

                                    e.CellStyle = new DataGridViewCellStyle
                                    {
                                        Font = new Font("Lucida Console", 13, FontStyle.Regular),
                                        Alignment = DataGridViewContentAlignment.TopCenter,
                                        BackColor = Color.DarkGray,
                                        ForeColor = Color.Green,
                                        SelectionBackColor = SystemColors.Highlight,
                                        SelectionForeColor = SystemColors.HighlightText
                                    };

                                    celula.ToolTipText = "Aporte inicial";
                                }
                            }
                            else if (coluna.Name.StartsWith("variacao_VarR") && e.Value != DBNull.Value)
                            {
                                decimal valor = (decimal)e.Value;

                                e.CellStyle.BackColor = Color.DarkGray;
                                if (valor < 0)
                                {
                                    e.CellStyle.ForeColor = Color.Red;
                                }
                                else if (valor > 0)
                                {
                                    e.CellStyle.ForeColor = Color.Green;
                                }
                                else
                                {
                                    e.CellStyle.ForeColor = Color.Black;
                                }
                            }
                            else
                            {
                                e.CellStyle.BackColor = Color.DarkGray;
                                e.CellStyle.ForeColor = Color.Black;
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
                        if (coluna.ValueType == typeof(decimal))
                        {
                            int posicao = 0;

                            if (coluna.Tag != null)
                            {
                                posicao = (int)coluna.Tag;
                            }

                            if (coluna.Name.StartsWith("variacao_Perc") && e.Value != DBNull.Value)
                            {
                                DataGridViewCell celula = variacaoDezDiasInvestimentosDataGridView.Rows[e.RowIndex].Cells[coluna.Index];
                                decimal valor = (decimal)e.Value;

                                if (valor < infinitoNegativo)
                                {
                                    // menos infinito
                                    e.Value = "-" + ((char)0x221E).ToString();

                                    e.CellStyle = new DataGridViewCellStyle
                                    {
                                        Font = new Font("Lucida Console", 13, FontStyle.Regular),
                                        Alignment = DataGridViewContentAlignment.TopCenter,
                                        BackColor = (posicao % 2 == 0 ? Color.White : Color.Gainsboro),
                                        ForeColor = Color.Red,
                                        SelectionBackColor = SystemColors.Highlight,
                                        SelectionForeColor = SystemColors.HighlightText
                                    };
                                    celula.ToolTipText = "Resgate total";
                                }
                                else if (valor < 0)
                                {
                                    // menor que zero até -999
                                    e.CellStyle.BackColor = (posicao % 2 == 0 ? Color.White : Color.Gainsboro);
                                    e.CellStyle.ForeColor = Color.Red;
                                }
                                else if (valor == 0)
                                {
                                    // Zero
                                    e.CellStyle.BackColor = (posicao % 2 == 0 ? Color.White : Color.Gainsboro);
                                    e.CellStyle.ForeColor = Color.Black;
                                }
                                else if (valor < infinitoPositivo)
                                {
                                    // maior que zero até 999
                                    e.CellStyle.BackColor = (posicao % 2 == 0 ? Color.White : Color.Gainsboro);
                                    e.CellStyle.ForeColor = Color.Green;
                                }
                                else
                                {
                                    // infinito
                                    e.Value = "+" + ((char)0x221E).ToString();

                                    e.CellStyle = new DataGridViewCellStyle
                                    {
                                        Font = new Font("Lucida Console", 13, FontStyle.Regular),
                                        Alignment = DataGridViewContentAlignment.TopCenter,
                                        BackColor = (posicao % 2 == 0 ? Color.White : Color.Gainsboro),
                                        ForeColor = Color.Green,
                                        SelectionBackColor = SystemColors.Highlight,
                                        SelectionForeColor = SystemColors.HighlightText
                                    };
                                    celula.ToolTipText = "Aporte inicial";
                                }
                            }
                            else if (coluna.Name.StartsWith("variacao_VarR") && e.Value != DBNull.Value)
                            {
                                decimal valor = (decimal)e.Value;

                                e.CellStyle.BackColor = (posicao % 2 == 0 ? Color.White : Color.Gainsboro);
                                if (valor < 0)
                                {
                                    e.CellStyle.ForeColor = Color.Red;
                                }
                                else if (valor > 0)
                                {
                                    e.CellStyle.ForeColor = Color.Green;
                                }
                                else
                                {
                                    e.CellStyle.ForeColor = Color.Black;
                                }
                            }
                            else
                            {
                                e.CellStyle.BackColor = (posicao % 2 == 0 ? Color.White : Color.Gainsboro);
                                e.CellStyle.ForeColor = Color.Black;
                            }
                        }
                        else if (coluna.Name == "variacao_Risco")
                        {

                            ClassificacaoRisco risco = (ClassificacaoRisco)variacaoDezDiasInvestimentosDataGridView.Rows[e.RowIndex].Cells["variacao_RiscoID"].Value;

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
                        if (coluna.ValueType == typeof(decimal))
                        {
                            if (coluna.Name.StartsWith("variacao_Perc") && e.Value != DBNull.Value)
                            {
                                decimal valor = (decimal)e.Value;

                                if (valor > 0)
                                {
                                    e.CellStyle.BackColor = Color.Black;
                                    e.CellStyle.ForeColor = Color.Lime;

                                }
                                else if (valor < 0)
                                {
                                    e.CellStyle.BackColor = Color.Black;
                                    e.CellStyle.ForeColor = Color.Tomato;

                                }
                                else
                                {
                                    e.CellStyle.BackColor = Color.Black;
                                    e.CellStyle.ForeColor = Color.White;
                                }
                            }
                            else if (coluna.Name.StartsWith("variacao_VarR") && e.Value != DBNull.Value)
                            {
                                decimal valor = (decimal)e.Value;
                                e.CellStyle.BackColor = Color.Black;

                                if (valor < 0)
                                {
                                    e.CellStyle.ForeColor = Color.Tomato;
                                }
                                else if (valor > 0)
                                {
                                    e.CellStyle.ForeColor = Color.Lime;
                                }
                                else
                                {
                                    e.CellStyle.ForeColor = Color.White;
                                }
                            }
                            else
                            {
                                e.CellStyle.BackColor = Color.Black;
                                e.CellStyle.ForeColor = Color.White;
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

        private void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void VariacaoDezDiasInvestimentosDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Usa o evento CellMouseMove para sobrescrever a geração do ToolTip
            // Note que o ShowCellToolTips do DataGridView foi desligado para não haver sobreposição dos "esparadrapos"

            string dica;

            if (e.ColumnIndex >= 0 && e.RowIndex == -1)
            {
                dica = variacaoDezDiasInvestimentosDataGridView.Columns[e.ColumnIndex].ToolTipText;
            }
            else if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && variacaoDezDiasInvestimentosDataGridView[e.ColumnIndex, e.RowIndex].ToolTipText != null)
            {
                dica = variacaoDezDiasInvestimentosDataGridView[e.ColumnIndex, e.RowIndex].ToolTipText;
            }
            else
            {
                return;
            }

            // verifica se a dica mudou, se não mudou não faz nada para evitar flicker
            if (dica == toolTip.GetToolTip(variacaoDezDiasInvestimentosDataGridView))
            {
                return;
            }

            toolTip.SetToolTip(variacaoDezDiasInvestimentosDataGridView, dica);
        }

        private void VariacaoDezDiasInvestimentosDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Pinta o cabeçalho somente da coluna de segunda-feira
            if (e.RowIndex == -1)
            {
                if (variacaoDezDiasInvestimentosDataGridView.Columns[e.ColumnIndex].HeaderText.StartsWith("seg "))
                {
                    Color c1 = ColorTranslator.FromHtml("#85bb65");  // Money green
                    Color c2 = ColorTranslator.FromHtml("#85bb65");  // Money green
                    Color c3 = ColorTranslator.FromHtml("#85bb65");  // Money green

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

        private void DateTimePickerDataBase_ValueChanged(object sender, EventArgs e)
        {
            DtUltimaAtualizacao = dateTimePickerDataBase.Value;
            variacaoDezDiasInvestimentosDataGridView.Focus();
        }

        private void FmCarteiraVariacaoUltimosDiasUteis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                DateTime t = dateTimePickerDataBase.Value.AddDays(-1);

                while (t.DayOfWeek == DayOfWeek.Sunday || t.DayOfWeek == DayOfWeek.Saturday)
                {
                    t = t.AddDays(-1);
                }

                dateTimePickerDataBase.Value = t;
            }
            else if (e.KeyCode == Keys.Right && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                DateTime t = dateTimePickerDataBase.Value.AddDays(1);

                while (t.DayOfWeek == DayOfWeek.Sunday || t.DayOfWeek == DayOfWeek.Saturday)
                {
                    t = t.AddDays(1);
                }

                dateTimePickerDataBase.Value = t;
            }
            else if (e.KeyCode == Keys.Up && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                dateTimePickerDataBase.Value = Geral.UltimaAtualizacaoInvestimentos();
            }
            else if (e.KeyCode == Keys.Down && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                dateTimePickerDataBase.Value = Geral.UltimaAtualizacaoInvestimentos();
            }
        }
    }
}
