using BLL;
using Modelos;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using static Modelos.Tipo;

namespace MoneyPro
{
    public partial class fmMovimentosContaFluxo : MoneyPro.Base.fmBaseTopoRodape
    {
        const int LarguraMinima = 70;
        private CelulaSelecionada Selecao = new CelulaSelecionada();

        private Form Origem { get; set; }
        private int UsuarioID { get; set; }
        private int ContaID { get; set; }
        private string ContaNome { get; set; }

        private DateTime _DataBase;
        private DateTime DataBase
        {
            get
            {
                return _DataBase;
            }

            set
            {
                if (_DataBase.Year != value.Year || _DataBase.Month != value.Month)
                {
                    _DataBase = value;
                    this.labelTopo.Text = this.ContaNome + " em " + _DataBase.ToString("MM/yyyy");
                    CarregarDados(ContaID);
                }
            }
        }


        #region Singleton

        private static fmMovimentosContaFluxo _singleton;

        private fmMovimentosContaFluxo(Form origem, int usuarioID, int contaID, string contaNome)
        {
            InitializeComponent();
            this.Origem = origem;
            this.UsuarioID = usuarioID;
            this.ContaID = contaID;
            this.ContaNome = contaNome;

            dateTimePickerDataBase.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);
        }

        public static fmMovimentosContaFluxo CreateInstance(Form origem, int usuarioID, int contaID, string contaNome)
        {
            if (_singleton == null)
            {
                _singleton = new fmMovimentosContaFluxo(origem, usuarioID, contaID, contaNome);
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

            dateTimePickerDataBase.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);
            DataBase = DateTime.Today;
        }

        #endregion Singleton


        private void CarregarDados(int contaID)
        {
            PesquisaBLL bll = new PesquisaBLL();
            fluxoCaixaDataGridView.DataSource = bll.FluxoCaixaContaEspecifica(contaID, DataBase);

            DateTime data = (DateTime)fluxoCaixaDataGridView.Rows[0].Cells["fluxo_PrimeiroDia"].Value;

            fluxoCaixaDataGridView.Columns["fluxo_Dia29"].Visible = true;
            fluxoCaixaDataGridView.Columns["fluxo_Dia30"].Visible = true;
            fluxoCaixaDataGridView.Columns["fluxo_Dia31"].Visible = true;

            switch (data.Month)
            {  // Meses com 31 dias: 1 3 5 7 8 10 12
                case 2:
                    if (DateTime.IsLeapYear(data.Year))
                    {
                        // Ano bissexto, dia 29 é exibido
                        fluxoCaixaDataGridView.Columns["fluxo_Dia30"].Visible = false;
                        fluxoCaixaDataGridView.Columns["fluxo_Dia31"].Visible = false;
                    }
                    else
                    {
                        // Ano não bissexto, dia 29 não é exibido
                        fluxoCaixaDataGridView.Columns["fluxo_Dia29"].Visible = false;
                        fluxoCaixaDataGridView.Columns["fluxo_Dia30"].Visible = false;
                        fluxoCaixaDataGridView.Columns["fluxo_Dia31"].Visible = false;
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    fluxoCaixaDataGridView.Columns["fluxo_Dia31"].Visible = false;
                    break;
                default:
                    break;
            }

            for (short i = 1; i <= DateTime.DaysInMonth(data.Year, data.Month); i++)
            {
                DateTime dia = data.AddDays(i - 1);
                string campo = "fluxo_Dia" + dia.Day.ToString("00");

                // Armazena o dia exibido na coluna na Tag da própria coluna
                fluxoCaixaDataGridView.Columns[campo].Tag = dia;

                fluxoCaixaDataGridView.Columns[campo].HeaderText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dia.ToString("ddd dd/MM"));
                fluxoCaixaDataGridView.Columns[campo].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Define o estilo da célula para as colunas contendo os valores
                fluxoCaixaDataGridView.Columns[campo].DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N2",
                };
                fluxoCaixaDataGridView.Columns[campo].MinimumWidth = LarguraMinima;
                fluxoCaixaDataGridView.Columns[campo].SortMode = DataGridViewColumnSortMode.NotSortable;
                fluxoCaixaDataGridView.Columns[campo].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            fluxoCaixaDataGridView.Columns["fluxo_TotalCategoria"].HeaderText = "Total do Mês";
            fluxoCaixaDataGridView.Columns["fluxo_TotalCategoria"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Define o estilo da célula para as colunas contendo os valores
            fluxoCaixaDataGridView.Columns["fluxo_TotalCategoria"].DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleRight,
                Format = "N2",
            };
            fluxoCaixaDataGridView.Columns["fluxo_TotalCategoria"].MinimumWidth = LarguraMinima;
            fluxoCaixaDataGridView.Columns["fluxo_TotalCategoria"].SortMode = DataGridViewColumnSortMode.NotSortable;
            fluxoCaixaDataGridView.Columns["fluxo_TotalCategoria"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void DateTimePickerDataBase_ValueChanged(object sender, EventArgs e)
        {
            DataBase = dateTimePickerDataBase.Value;
        }

        private void ButtonFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FluxoCaixaContaEspecificaDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (fluxoCaixaDataGridView.Columns[e.ColumnIndex].Visible)
                {
                    short tipoLinha = (short)fluxoCaixaDataGridView.Rows[e.RowIndex].Cells["fluxo_TipoLinha"].Value;

                    if (tipoLinha == 2)
                    {
                        // Linhas de detalhes
                        if (fluxoCaixaDataGridView.Columns[e.ColumnIndex].HeaderText.StartsWith("Sáb ") ||
                            fluxoCaixaDataGridView.Columns[e.ColumnIndex].HeaderText.StartsWith("Dom "))
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
                        if (fluxoCaixaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            decimal valor = 0;

                            if (fluxoCaixaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value)
                            {
                                valor = (decimal)fluxoCaixaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                            }

                            if (valor >= 0)
                            {
                                e.CellStyle.ForeColor = Color.Black;
                            }
                            else
                            {
                                e.CellStyle.ForeColor = Color.Red;
                            }
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.Black;
                        }
                    }
                    else if (tipoLinha == 1)
                    {
                        // Total do grupo
                        e.CellStyle.BackColor = Color.DarkGray;

                        if (fluxoCaixaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            decimal valor = 0;

                            if (fluxoCaixaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value)
                            {
                                valor = (decimal)fluxoCaixaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                            }

                            if (valor >= 0)
                            {
                                e.CellStyle.ForeColor = Color.Black;
                            }
                            else
                            {
                                e.CellStyle.ForeColor = Color.Red;
                            }
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.Black;
                        }
                    }
                    else if (tipoLinha == 0 || tipoLinha == 3)
                    {
                        // Saldo Anterior e Saldo Final
                        e.CellStyle.BackColor = Color.Black;

                        if (fluxoCaixaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            decimal valor = 0;

                            if (fluxoCaixaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value)
                            {
                                valor = (decimal)fluxoCaixaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                            }

                            if (valor >= 0)
                            {
                                e.CellStyle.ForeColor = Color.White;
                            }
                            else
                            {
                                e.CellStyle.ForeColor = Color.Gold;
                            }
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.White;
                        }
                    }
                }
            }
        }

        private void FluxoCaixaContaEspecificaDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Pinta os CABEÇALHOS de dias após a última atualização de investimentos/poupança
            if (e.RowIndex == -1)
            {
                if (fluxoCaixaDataGridView.Columns[e.ColumnIndex].Tag != null)
                {
                    DateTime diaColuna = (DateTime)fluxoCaixaDataGridView.Columns[e.ColumnIndex].Tag;

                    if (diaColuna > DateTime.Today)
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

        private void FmMovimentosContaFluxoEspecifico_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.Escape)
            {
                ButtonFechar_Click(sender, null);
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

        private void FluxoCaixaContaEspecificaDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (!detalhesMovimentacaoDataGridView.Visible)
            {
                AnalisarCelulaSelecionada();
            }
            else if (fluxoCaixaDataGridView.CurrentCell != null)
            {
                if (Selecao.Coluna != fluxoCaixaDataGridView.CurrentCell.ColumnIndex ||
                    Selecao.Linha != fluxoCaixaDataGridView.CurrentCell.RowIndex)
                {
                    AnalisarCelulaSelecionada();
                }
                else
                {
                    splitterHorizontal.Visible = false;
                    detalhesMovimentacaoDataGridView.Visible = false;
                }
            }
            else
            {
                splitterHorizontal.Visible = false;
                detalhesMovimentacaoDataGridView.Visible = false;
            }
        }

        private void FluxoCaixaContaEspecificaDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (!detalhesMovimentacaoDataGridView.Visible)
                {
                    AnalisarCelulaSelecionada();
                }
                else if (fluxoCaixaDataGridView.CurrentCell != null)
                {
                    if (Selecao.Coluna != fluxoCaixaDataGridView.CurrentCell.ColumnIndex ||
                        Selecao.Linha != fluxoCaixaDataGridView.CurrentCell.RowIndex)
                    {
                        AnalisarCelulaSelecionada();
                    }
                    else
                    {
                        splitterHorizontal.Visible = false;
                        detalhesMovimentacaoDataGridView.Visible = false;
                    }
                }
                else
                {
                    splitterHorizontal.Visible = false;
                    detalhesMovimentacaoDataGridView.Visible = false;
                }
            }
        }

        private void AnalisarCelulaSelecionada()
        {
            if (fluxoCaixaDataGridView.CurrentCell != null)
            {
                int categoriaID = (int)fluxoCaixaDataGridView.CurrentRow.Cells["fluxo_CategoriaID"].Value;

                if ((short)fluxoCaixaDataGridView.CurrentRow.Cells["fluxo_TipoLinha"].Value == 2 && categoriaID != 0)
                {
                    int coluna = fluxoCaixaDataGridView.CurrentCell.ColumnIndex;
                    string nome = fluxoCaixaDataGridView.Columns[coluna].Name;

                    if (nome.Contains("fluxo_Dia"))
                    {
                        // Se clicado num dia, exibe todos os lançamentos da categoria selecionada no dia específico

                        //if (int.TryParse(nome.Substring(16, 2), out int dia))
                        {
                            Selecao.Coluna = fluxoCaixaDataGridView.CurrentCell.ColumnIndex;
                            Selecao.Linha = fluxoCaixaDataGridView.CurrentCell.RowIndex;

                            DateTime diaSelecionado = (DateTime)fluxoCaixaDataGridView.Columns[coluna].Tag;

                            // Exibe os detalhes no grid inferior
                            ExibirDetalhesCategoriaNoDia(UsuarioID, ContaID, categoriaID, diaSelecionado);

                            splitterHorizontal.Visible = true;
                            detalhesMovimentacaoDataGridView.Visible = true;
                        }
                    }
                    else
                    {
                        // Se clicado em colunas que não são dia, exibe todos os lançamentos 
                        // da categoria selecionada no mês apresentado em tela
                        Selecao.Coluna = fluxoCaixaDataGridView.CurrentCell.ColumnIndex;
                        Selecao.Linha = fluxoCaixaDataGridView.CurrentCell.RowIndex;

                        DateTime mesSelecionado = (DateTime)fluxoCaixaDataGridView.CurrentRow.Cells["fluxo_PrimeiroDia"].Value;

                        // Exibe os detalhes no grid inferior
                        // TODO Criar visualização mensal
                        //ExibirDetalhesCategoriaNoMes(ContaID, categoriaID, mesSelecionado);

                        splitterHorizontal.Visible = true;
                        detalhesMovimentacaoDataGridView.Visible = true;
                    }
                }
            }
        }

        private void ExibirDetalhesCategoriaNoDia(int usuarioID, int contaID, int categoriaID, DateTime diaSelecionado)
        {
            PesquisaBLL bll = new PesquisaBLL();
            detalhesMovimentacaoBindingSource.DataSource = bll.ListarMovimentosCategoriaNoDia(usuarioID, contaID, categoriaID, diaSelecionado);
        }

        private void DetalhesMovimentacaoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (detalhesMovimentacaoDataGridView.CurrentRow != null)
            {
                // Itens da movimentação

                if (e.Value != null)
                {
                    // Se é movimento futuro (leva em consideração data e hora)
                    bool futuro = (DateTime)detalhesMovimentacaoDataGridView.Rows[e.RowIndex].Cells["detalhe_Data"].Value > DateTime.Now;
                    // Ou se foi marcado como lançamentos agendado ou futuros
                    futuro = futuro || (string)detalhesMovimentacaoDataGridView.Rows[e.RowIndex].Cells["detalhe_Conciliacao"].Value == "A"     // Agendado
                                    || (string)detalhesMovimentacaoDataGridView.Rows[e.RowIndex].Cells["detalhe_Conciliacao"].Value == "F";    // Futuro

                    if (futuro)
                    {
                        // Pinta de verde claro alternado de verde escuro
                        if ((e.RowIndex % 2) == 0)
                        {
                            e.CellStyle.BackColor = Color.PaleGreen;
                        }
                        else
                        {
                            e.CellStyle.BackColor = Color.DarkSeaGreen;
                        }
                    }

                    if (detalhesMovimentacaoDataGridView.Columns[e.ColumnIndex].Name == "detalhe_Conciliacao")
                    {
                        try
                        {
                            // Pega o primeiro caracter da string "Conciliacao" e transforma em char
                            char atual = ((string)e.Value)[0];
                            // Status conterá o tipo reference à conciliação
                            TipoConciliacao status = ((TipoConciliacao)atual);

                            if (status == TipoConciliacao.Conciliado)
                                e.CellStyle.ForeColor = Color.Blue;
                            else if (status == TipoConciliacao.Reconciliado)
                                e.CellStyle.ForeColor = Color.Green;
                            else if (status == TipoConciliacao.Agendado)
                                e.CellStyle.ForeColor = Color.Magenta;
                            else if (status == TipoConciliacao.Futuro)
                                e.CellStyle.ForeColor = Color.Black;

                            if (status != TipoConciliacao.NaoConciliado)
                                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        }
                        catch
                        {
                            // não faz nada.
                        }
                    }
                    else if (detalhesMovimentacaoDataGridView.Columns[e.ColumnIndex].Name == "detalhe_Debito")
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Gold;
                    }
                    else if (detalhesMovimentacaoDataGridView.Columns[e.ColumnIndex].Name == "detalhe_Credito")
                    {
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.SelectionForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.SelectionForeColor = SystemColors.HighlightText;
                    }
                }
            }
        }
    }
}
