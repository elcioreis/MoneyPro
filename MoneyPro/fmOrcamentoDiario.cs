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
    public partial class fmOrcamentoDiario : MoneyPro.Base.fmBaseTopoRodape
    {
        private CelulaSelecionada Selecao = new CelulaSelecionada();

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

        private Form Origem { get; set; }
        private int UsuarioID { get; set; }

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
                    this.labelTopo.Text = "Orçamento Diário de " + _DataBase.ToString("MM/yyyy");
                    CarregarDados(UsuarioID);
                }
            }
        }

        #region Singleton

        private static fmOrcamentoDiario _singleton;

        private fmOrcamentoDiario(Form origem, int usuarioID)
        {
            InitializeComponent();
            this.UsuarioID = usuarioID;
            this.Origem = origem;

            DtUltimaAtualizacao = Geral.UltimaAtualizacaoInvestimentos();

            dateTimePickerDataBase.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);
        }

        public static fmOrcamentoDiario CreateInstance(Form origem, int usuarioID)
        {
            if (_singleton == null)
            {
                _singleton = new fmOrcamentoDiario(origem, usuarioID);
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
            DataBase = DateTime.Today;
            //CarregaDados(UsuarioID);
        }

        #endregion Singleton

        private void DateTimePickerDataBase_ValueChanged(object sender, EventArgs e)
        {
            // Ao mudar a data de exibição esconde os detalhes da pesquisa anterior (grid inferior)
            splitterHorizontal.Visible = false;
            detalhesMovimentacaoDataGridView.Visible = false;

            DataBase = new DateTime(dateTimePickerDataBase.Value.Year, dateTimePickerDataBase.Value.Month, 15);

            orcamentoDiarioDataGridView.Focus();
        }

        private void CarregarDados(int usuarioID)
        {
            bool Comparar = false;

#if DEBUG
            Comparar = true;
#endif

            PesquisaBLL bll = new PesquisaBLL();
            orcamentoDiarioDataGridView.DataSource = bll.OrcamentoDiario(usuarioID, DataBase, Comparar);

            DateTime data = (DateTime)orcamentoDiarioDataGridView.Rows[0].Cells["dataGridView_DataReferencia"].Value;

            orcamentoDiarioDataGridView.Columns["dataGridView_Dia29"].Visible = true;
            orcamentoDiarioDataGridView.Columns["dataGridView_Dia30"].Visible = true;
            orcamentoDiarioDataGridView.Columns["dataGridView_Dia31"].Visible = true;

            switch (data.Month)
            {  // Meses com 31 dias: 1 3 5 7 8 10 12
                case 2:
                    if (DateTime.IsLeapYear(data.Year))
                    {
                        // Ano bissexto, dia 29 é exibido
                        orcamentoDiarioDataGridView.Columns["dataGridView_Dia30"].Visible = false;
                        orcamentoDiarioDataGridView.Columns["dataGridView_Dia31"].Visible = false;
                    }
                    else
                    {
                        // Ano não bissexto, dia 29 não é exibido
                        orcamentoDiarioDataGridView.Columns["dataGridView_Dia29"].Visible = false;
                        orcamentoDiarioDataGridView.Columns["dataGridView_Dia30"].Visible = false;
                        orcamentoDiarioDataGridView.Columns["dataGridView_Dia31"].Visible = false;
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    orcamentoDiarioDataGridView.Columns["dataGridView_Dia31"].Visible = false;
                    break;
                default:
                    break;
            }

            for (short i = 1; i <= 31; i++)
            {
                string campo = "dataGridView_Dia" + i.ToString("00");

                if (orcamentoDiarioDataGridView.Columns[campo].Visible)
                {
                    // Renomeará o cabeçalho de Dia01, Dia02, etc para 01/08, 02/08, etc
                    DateTime dia = DateTime.Parse(DataBase.ToString("yyyy/MM") + "/" + i.ToString("00"), CultureInfo.InvariantCulture);

                    // Armazena o dia exibido na coluna na Tag da própria coluna
                    orcamentoDiarioDataGridView.Columns[campo].Tag = dia;

                    orcamentoDiarioDataGridView.Columns[campo].HeaderText = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dia.ToString("ddd dd/MM"));
                    orcamentoDiarioDataGridView.Columns[campo].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void OrcamentoDiarioDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (orcamentoDiarioDataGridView.Columns[e.ColumnIndex].Visible)
                {
                    short tipoLinha = (short)orcamentoDiarioDataGridView.Rows[e.RowIndex].Cells["dataGridView_TipoLinha"].Value;

                    if (tipoLinha == 2)
                    {
                        // Linhas de detalhes

                        if (orcamentoDiarioDataGridView.Columns[e.ColumnIndex].HeaderText.StartsWith("Sáb ") ||
                            orcamentoDiarioDataGridView.Columns[e.ColumnIndex].HeaderText.StartsWith("Dom "))
                        {
                            // Dias de fim de semana serão marcados como cinza claro
                            e.CellStyle.BackColor = Color.Gainsboro;
                        }
                        else
                        {
                            if ((int)orcamentoDiarioDataGridView.Rows[e.RowIndex].Cells["dataGridView_CategoriaID"].Value == 0)
                            {
                                if (orcamentoDiarioDataGridView.Columns[e.ColumnIndex].Tag != null)
                                {
                                    //DateTime diaColuna = (DateTime)orcamentoDiarioDataGridView.Columns[e.ColumnIndex].Tag;
                                    if ((DateTime)orcamentoDiarioDataGridView.Columns[e.ColumnIndex].Tag <= dtUltimaAtualizacao)
                                    {
                                        e.CellStyle.BackColor = Color.White;
                                    }
                                    else
                                    {
                                        e.CellStyle.BackColor = Color.Gold;
                                    }
                                }
                                else
                                {
                                    e.CellStyle.BackColor = Color.White;
                                }
                            }
                            else
                            {
                                // Dias de semana serão branco (cor padrão)
                                e.CellStyle.BackColor = Color.White;
                            }
                        }

                        // Trata as fontes das células de detalhes
                        if (orcamentoDiarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            decimal valor = 0;

                            if (orcamentoDiarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value)
                            {
                                valor = (decimal)orcamentoDiarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
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

                        if (orcamentoDiarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            decimal valor = 0;

                            if (orcamentoDiarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value)
                            {
                                valor = (decimal)orcamentoDiarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
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
                    else if (tipoLinha == 0 || tipoLinha == 3 || tipoLinha == 99)
                    {
                        // Saldo Anterior e Saldo Final
                        e.CellStyle.BackColor = Color.Black;

                        if (orcamentoDiarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            decimal valor = 0;

                            if (orcamentoDiarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value)
                            {
                                valor = (decimal)orcamentoDiarioDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
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
#if DEBUG
                    else if (tipoLinha == -1)
                    {
                        // Comparativo (só existe em mode Debug)
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.Yellow;
                    }
#endif
                }
            }
        }

        private void OrcamentoDiarioDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (!detalhesMovimentacaoDataGridView.Visible)
            {
                AnalisarCelulaSelecionada();
            }
            else if (orcamentoDiarioDataGridView.CurrentCell != null)
            {
                if (Selecao.Coluna != orcamentoDiarioDataGridView.CurrentCell.ColumnIndex ||
                    Selecao.Linha != orcamentoDiarioDataGridView.CurrentCell.RowIndex)
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

        private void OrcamentoDiarioDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (!detalhesMovimentacaoDataGridView.Visible)
                {
                    AnalisarCelulaSelecionada();
                }
                else if (orcamentoDiarioDataGridView.CurrentCell != null)
                {
                    if (Selecao.Coluna != orcamentoDiarioDataGridView.CurrentCell.ColumnIndex ||
                        Selecao.Linha != orcamentoDiarioDataGridView.CurrentCell.RowIndex)
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
            if (orcamentoDiarioDataGridView.CurrentCell != null)
            {
                if ((short)orcamentoDiarioDataGridView.CurrentRow.Cells["dataGridView_TipoLinha"].Value == 2)
                {
                    int coluna = orcamentoDiarioDataGridView.CurrentCell.ColumnIndex;
                    string nome = orcamentoDiarioDataGridView.Columns[coluna].Name;

                    if (nome.Contains("dataGridView_Dia"))
                    {
                        // Se clicado num dia, exibe todos os lançamentos da categoria selecionada no dia específico

                        if (int.TryParse(nome.Substring(16, 2), out int dia))
                        {
                            Selecao.Coluna = orcamentoDiarioDataGridView.CurrentCell.ColumnIndex;
                            Selecao.Linha = orcamentoDiarioDataGridView.CurrentCell.RowIndex;

                            int categoriaID = (int)orcamentoDiarioDataGridView.CurrentRow.Cells["dataGridView_CategoriaID"].Value;
                            DateTime diaSelecionado = DateTime.Parse(DataBase.ToString("yyyy/MM") + "/" + dia.ToString("00"), CultureInfo.InvariantCulture);

                            // Exibe os detalhes no grid inferior
                            ExibirDetalhesCategoriaNoDia(UsuarioID, categoriaID, diaSelecionado);

                            splitterHorizontal.Visible = true;
                            detalhesMovimentacaoDataGridView.Visible = true;
                        }
                    }
                    else
                    {
                        // Se clicado em colunas que não são dia, exibe todos os lançamentos 
                        // da categoria selecionada no mês apresentado em tela
                        Selecao.Coluna = orcamentoDiarioDataGridView.CurrentCell.ColumnIndex;
                        Selecao.Linha = orcamentoDiarioDataGridView.CurrentCell.RowIndex;

                        int categoriaID = (int)orcamentoDiarioDataGridView.CurrentRow.Cells["dataGridView_CategoriaID"].Value;
                        DateTime mesSelecionado = (DateTime)orcamentoDiarioDataGridView.CurrentRow.Cells["dataGridView_DataReferencia"].Value;

                        // Exibe os detalhes no grid inferior
                        ExibirDetalhesCategoriaNoMes(UsuarioID, categoriaID, mesSelecionado);

                        splitterHorizontal.Visible = true;
                        detalhesMovimentacaoDataGridView.Visible = true;
                    }
                }
            }
        }

        private void ExibirDetalhesCategoriaNoDia(int usuarioID, int categoriaID, DateTime diaSelecionado)
        {
            PesquisaBLL bll = new PesquisaBLL();
            detalhesMovimentacaoBindingSource.DataSource = bll.ListarMovimentosCategoriaNoDia(usuarioID, categoriaID, diaSelecionado);
        }

        private void ExibirDetalhesCategoriaNoMes(int usuarioID, int categoriaID, DateTime mesSelecionado)
        {
            PesquisaBLL bll = new PesquisaBLL();
            detalhesMovimentacaoBindingSource.DataSource = bll.ListarMovimentosCategoriaNoMes(usuarioID, categoriaID, mesSelecionado);
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

        private void ButtonOrcamentoMensal_Click(object sender, EventArgs e)
        {
            ((FmPrincipal)Origem).ExibirFormOrcamentoMensal();
        }

        private void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void FmOrcamentoDiario_KeyDown(object sender, KeyEventArgs e)
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

        private void OrcamentoDiarioDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Pinta os CABEÇALHOS de dias após a última atualização de investimentos/poupança
            if (e.RowIndex == -1)
            {
                if (orcamentoDiarioDataGridView.Columns[e.ColumnIndex].Tag != null)
                {
                    DateTime diaColuna = (DateTime)orcamentoDiarioDataGridView.Columns[e.ColumnIndex].Tag;

                    if (diaColuna == DateTime.Today)
                    {
                        // Money green

                        Color c1 = ColorTranslator.FromHtml("#85bb65");
                        Color c2 = ColorTranslator.FromHtml("#85bb65");
                        Color c3 = ColorTranslator.FromHtml("#85bb65");

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
    }
}
