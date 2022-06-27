using BLL;
using Modelos;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static Modelos.Tipo;

namespace MoneyPro
{
    public partial class fmOrcamentoMensal : MoneyPro.Base.fmBaseTopoRodape
    {
        const int LarguraMinima = 68;

        // Constantes utilizadas na formatação da coluna gráfica
        const decimal bolaCheia = (decimal)9999.9999;
        const decimal bolaVazia = (decimal)-9999.9999;

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
                    this.labelTopo.Text = "Orçamento Mensal até " + _DataBase.ToString("MM/yyyy");
                    CarregarDados(UsuarioID);
                }
            }
        }

        #region Singleton

        private static fmOrcamentoMensal _singleton;

        private fmOrcamentoMensal(Form origem, int usuarioID)
        {
            InitializeComponent();
            this.UsuarioID = usuarioID;
            this.Origem = origem;

            dateTimePickerDataBase.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);

            DtUltimaAtualizacao = Geral.UltimaAtualizacaoInvestimentos();
        }

        public static fmOrcamentoMensal CreateInstance(Form origem, int usuarioID)
        {
            if (_singleton == null)
            {
                _singleton = new fmOrcamentoMensal(origem, usuarioID);
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
        }

        #endregion Singleton

        private void DateTimePickerDataBase_ValueChanged(object sender, EventArgs e)
        {
            //splitContainer.Panel2.Height = 0;

            // Ao mudar a data de exibição esconde os detalhes da pesquisa anterior (grid inferior)
            detalhesMovimentacaoDataGridView.Visible = false;
            splitterHorizontal.Visible = false;

            DataBase = new DateTime(dateTimePickerDataBase.Value.Year, dateTimePickerDataBase.Value.Month, 15);

            orcamentoMensalDataGridView.Focus();
        }

        private void CarregarDados(int usuarioID)
        {
            bool Comparar = false;

#if DEBUG
            Comparar = true;
#endif

            PesquisaBLL bll = new PesquisaBLL();
            orcamentoMensalDataGridView.DataSource = bll.OrcamentoMensal(usuarioID, DataBase, Comparar);

            DateTime data = (DateTime)orcamentoMensalDataGridView.Rows[0].Cells["dataGridView_DataReferencia"].Value;

            for (short i = 1; i <= 13; i++)
            {
                string campo = "dataGridView_Mes" + i.ToString("00");

                DateTime mes = data.AddMonths((13 - i) * -1);
                // Encontra o último dia do mês e coloca o dia na Tag da coluna
                DateTime dia = new DateTime(mes.Year, mes.Month, DateTime.DaysInMonth(mes.Year, mes.Month));
                orcamentoMensalDataGridView.Columns[campo].Tag = dia;
                orcamentoMensalDataGridView.Columns[campo].HeaderText = dia.ToString("MM/yyyy");
                orcamentoMensalDataGridView.Columns[campo].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                orcamentoMensalDataGridView.Columns[campo].MinimumWidth = LarguraMinima;
            }

            orcamentoMensalDataGridView.Columns["dataGridView_TotalCategoria"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            orcamentoMensalDataGridView.Columns["dataGridView_TotalCategoria"].MinimumWidth = LarguraMinima;

            orcamentoMensalDataGridView.Columns["dataGridView_MediaCategoria"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            orcamentoMensalDataGridView.Columns["dataGridView_MediaCategoria"].MinimumWidth = LarguraMinima;

            orcamentoMensalDataGridView.Columns["dataGridView_VarMedia13"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void OrcamentoMensalDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (orcamentoMensalDataGridView.Columns[e.ColumnIndex].Visible)
                {
                    short tipoLinha = (short)orcamentoMensalDataGridView.Rows[e.RowIndex].Cells["dataGridView_TipoLinha"].Value;

                    if (tipoLinha == 2)
                    {
                        // Linhas de detalhes

                        if (orcamentoMensalDataGridView.Columns[e.ColumnIndex].Name.Equals("dataGridView_TotalCategoria") ||
                            orcamentoMensalDataGridView.Columns[e.ColumnIndex].Name.Equals("dataGridView_MediaCategoria"))
                        {
                            // Coluna total e média serão pintadas de cinza claro
                            e.CellStyle.BackColor = Color.Gainsboro;
                        }
                        else
                        {
                            // As demais colunas serão pintadas de branco
                            e.CellStyle.BackColor = Color.White;
                        }

                        // Trata as fontes das células de detalhes
                        if (orcamentoMensalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            decimal valor = 0;

                            if (orcamentoMensalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value)
                            {
                                valor = (decimal)orcamentoMensalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
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

                        if (orcamentoMensalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            decimal valor = 0;

                            if (orcamentoMensalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value)
                            {
                                valor = (decimal)orcamentoMensalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
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

                        if (orcamentoMensalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ValueType == typeof(decimal))
                        {
                            decimal valor = 0;

                            if (orcamentoMensalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value)
                            {
                                valor = (decimal)orcamentoMensalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
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

                    if (orcamentoMensalDataGridView.Columns[e.ColumnIndex].Name.Equals("dataGridView_VarMedia13"))
                    {
                        if (orcamentoMensalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value)
                        {
                            DataGridViewCell celula = orcamentoMensalDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                            decimal valor = (decimal)celula.Value;
                            // Pega o primeiro caracter do campo Ordem
                            char tipo = ((string)orcamentoMensalDataGridView.Rows[e.RowIndex].Cells["dataGridView_Ordem"].Value)[0];

                            e.CellStyle.Font = new Font("WingDings", 10, FontStyle.Regular);
                            char codigochar;

                            if (valor == bolaCheia)
                            {
                                // Bola cheia (não tinha e passou a ter)
                                codigochar = (char)0x6C;
                                e.Value = codigochar.ToString();

                                if (tipo == 'C')
                                {
                                    // Se crédito: VERDE
                                    e.CellStyle.ForeColor = Color.Green;
                                    e.CellStyle.SelectionForeColor = Color.LightGreen;
                                    celula.ToolTipText = "Não tinha valores na categoria de crédito e passou a ter";
                                }
                                else if (tipo == 'D')
                                {
                                    // Se débito: VERMELHO
                                    e.CellStyle.ForeColor = Color.Red;
                                    e.CellStyle.SelectionForeColor = Color.Tomato;
                                    celula.ToolTipText = "Não tinha valores na categoria de débito e passou a ter";
                                }
                                else
                                {
                                    // Se investimento: Preto
                                    e.CellStyle.ForeColor = SystemColors.WindowText;
                                    e.CellStyle.SelectionForeColor = SystemColors.HighlightText;
                                    celula.ToolTipText = "Não tinha valores na categoria e passou a ter";

                                }
                            }
                            else if (valor == bolaVazia)
                            {
                                // Bola vazia (tinha e passou a não ter)
                                codigochar = (char)0xA1;
                                e.Value = codigochar.ToString();

                                if (tipo == 'C')
                                {
                                    // Se crédito: Vermelho
                                    e.CellStyle.ForeColor = Color.Red;
                                    e.CellStyle.SelectionForeColor = Color.Tomato;
                                    celula.ToolTipText = "Tinha valores na categoria de crédito e passou a não ter";
                                }
                                else if (tipo == 'D')
                                {
                                    // Se débito: Verde
                                    e.CellStyle.ForeColor = Color.Green;
                                    e.CellStyle.SelectionForeColor = Color.LightGreen;
                                    celula.ToolTipText = "Tinha valores na categoria de débito e passou a não ter";
                                }
                                else
                                {
                                    // Se investimento: Preto
                                    e.CellStyle.ForeColor = SystemColors.WindowText;
                                    e.CellStyle.SelectionForeColor = SystemColors.HighlightText;
                                    celula.ToolTipText = "Tinha valores na categoria e passou a não ter";

                                }
                            }
                            else if (valor > 0)
                            {
                                // Seta pra cima (aumentou o valor)
                                codigochar = (char)0xF1;
                                e.Value = codigochar.ToString();

                                if (tipo == 'C')
                                {
                                    // Se crédito: Verde
                                    e.CellStyle.ForeColor = Color.Green;
                                    e.CellStyle.SelectionForeColor = Color.LightGreen;
                                    celula.ToolTipText = "Valor maior que a média na categoria de crédito";

                                }
                                else if (tipo == 'D')
                                {
                                    // Se débito: VERMELHO
                                    e.CellStyle.ForeColor = Color.Red;
                                    e.CellStyle.SelectionForeColor = Color.Tomato;
                                    celula.ToolTipText = "Valor maior que a média na categoria de débito";
                                }
                                else
                                {
                                    // Se investimento: Preto
                                    e.CellStyle.ForeColor = SystemColors.WindowText;
                                    e.CellStyle.SelectionForeColor = SystemColors.HighlightText;
                                    celula.ToolTipText = "Valor maior que a média";
                                }
                            }
                            else if (valor < 0)
                            {
                                // Seta pra baixo (diminuiu o valor)
                                codigochar = (char)0xF2;
                                e.Value = codigochar.ToString();

                                if (tipo == 'C')
                                {
                                    // Se crédito: Vermelho
                                    e.CellStyle.ForeColor = Color.Red;
                                    e.CellStyle.SelectionForeColor = Color.Tomato;
                                    celula.ToolTipText = "Valor menor que a média na categoria de crédito";
                                }
                                else if (tipo == 'D')
                                {
                                    // Se débito: Azul
                                    e.CellStyle.ForeColor = Color.Green;
                                    e.CellStyle.SelectionForeColor = Color.LightGreen;
                                    celula.ToolTipText = "Valor menor que a média na categoria de débito";
                                }
                                else
                                {
                                    // Se investimento: Preto
                                    e.CellStyle.ForeColor = SystemColors.WindowText;
                                    e.CellStyle.SelectionForeColor = SystemColors.HighlightText;
                                    celula.ToolTipText = "Valor menor que a média";
                                }
                            }
                            else
                            {
                                // Seta para ambos os lados (manteve o valor)
                                codigochar = (char)0xF3;
                                e.Value = codigochar.ToString();

                                e.CellStyle.ForeColor = Color.Black;
                                e.CellStyle.SelectionForeColor = Color.Black;
                            }
                        }
                    }
                }
            }
        }

        private void OrcamentoMensalDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (!detalhesMovimentacaoDataGridView.Visible)
            {
                AnalisarCelulaSelecionada();
            }
            else if (orcamentoMensalDataGridView.CurrentCell != null)
            {
                if (Selecao.Coluna != orcamentoMensalDataGridView.CurrentCell.ColumnIndex ||
                    Selecao.Linha != orcamentoMensalDataGridView.CurrentCell.RowIndex)
                {
                    AnalisarCelulaSelecionada();
                }
                else
                {
                    detalhesMovimentacaoDataGridView.Visible = false;
                    splitterHorizontal.Visible = false;
                }
            }
        }

        private void OrcamentoMensalDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (!detalhesMovimentacaoDataGridView.Visible)
                {
                    AnalisarCelulaSelecionada();
                }
                else if (orcamentoMensalDataGridView.CurrentCell != null)
                {
                    if (Selecao.Coluna != orcamentoMensalDataGridView.CurrentCell.ColumnIndex ||
                        Selecao.Linha != orcamentoMensalDataGridView.CurrentCell.RowIndex)
                    {
                        AnalisarCelulaSelecionada();
                    }
                    else
                    {
                        detalhesMovimentacaoDataGridView.Visible = false;
                        splitterHorizontal.Visible = false;
                    }
                }
            }
        }

        private void AnalisarCelulaSelecionada()
        {
            if (orcamentoMensalDataGridView.CurrentCell != null)
            {
                if ((short)orcamentoMensalDataGridView.CurrentRow.Cells["dataGridView_TipoLinha"].Value == 2)
                {
                    int coluna = orcamentoMensalDataGridView.CurrentCell.ColumnIndex;
                    string nome = orcamentoMensalDataGridView.Columns[coluna].Name;

                    Selecao.Coluna = orcamentoMensalDataGridView.CurrentCell.ColumnIndex;
                    Selecao.Linha = orcamentoMensalDataGridView.CurrentCell.RowIndex;

                    DateTime data;
                    DateTime inicioPeriodo = DateTime.Today;
                    DateTime fimPeriodo = DateTime.Today;

                    int categoriaID = 0;

                    if (nome.StartsWith("dataGridView_Mes"))
                    {
                        // Se clicado num mês exibe todos os lançamentos da categoria selecionada no mês específico

                        if (int.TryParse(nome.Substring(nome.Length - 2), out int valor))
                        {
                            data = DataBase.AddMonths((13 - valor) * -1);
                            fimPeriodo = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
                            data = fimPeriodo.AddMonths(-1);
                            inicioPeriodo = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month)).AddDays(1);

                            categoriaID = (int)orcamentoMensalDataGridView.CurrentRow.Cells["dataGridView_CategoriaID"].Value;
                        }
                    }
                    else
                    {
                        fimPeriodo = new DateTime(DataBase.Year, DataBase.Month, DateTime.DaysInMonth(DataBase.Year, DataBase.Month));
                        data = fimPeriodo.AddMonths(-13);
                        inicioPeriodo = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month)).AddDays(1);

                        //inicioPeriodo = fimPeriodo.AddMonths(-13).AddDays(1);

                        categoriaID = (int)orcamentoMensalDataGridView.CurrentRow.Cells["dataGridView_CategoriaID"].Value;
                    }

                    if (categoriaID != 0)
                    {
                        // Exibe os detalhes no grid inferior
                        ExibirDetalhesCategoriaNoPeriodo(UsuarioID, categoriaID, inicioPeriodo, fimPeriodo);
                        splitterHorizontal.Visible = true;
                        detalhesMovimentacaoDataGridView.Visible = true;
                    }
                }
            }
        }

        private void ExibirDetalhesCategoriaNoPeriodo(int usuarioID, int categoriaID, DateTime inicio, DateTime fim)
        {
            PesquisaBLL bll = new PesquisaBLL();
            detalhesMovimentacaoBindingSource.DataSource = bll.ListarMovimentosCategoriaNoPeriodo(usuarioID, categoriaID, inicio, fim);
        }

        private void DetalhesMovimentacaoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (detalhesMovimentacaoDataGridView.CurrentRow != null)
            {
                // Itens da movimentação

                if (e.Value != null)
                {
                    // Se é movimento futuro (leva em consideração data e hora)
                    bool futuro = (DateTime)detalhesMovimentacaoDataGridView.Rows[e.RowIndex].Cells["Data"].Value > DateTime.Now;
                    // Ou se foi marcado como lançamentos agendado ou futuros
                    futuro = futuro || (string)detalhesMovimentacaoDataGridView.Rows[e.RowIndex].Cells["Conciliacao"].Value == "A"     // Agendado
                                    || (string)detalhesMovimentacaoDataGridView.Rows[e.RowIndex].Cells["Conciliacao"].Value == "F";    // Futuro

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

                    if (detalhesMovimentacaoDataGridView.Columns[e.ColumnIndex].Name == "Conciliacao")
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
                    else if (detalhesMovimentacaoDataGridView.Columns[e.ColumnIndex].Name == "Debito")
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Gold;
                    }
                    else if (detalhesMovimentacaoDataGridView.Columns[e.ColumnIndex].Name == "Credito")
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

        private void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void ButtonOrcamentoDiario_Click(object sender, EventArgs e)
        {
            ((FmPrincipal)Origem).ExibirFormOrcamentoDiario();
        }

        private void FmOrcamentoMensal_KeyDown(object sender, KeyEventArgs e)
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

        private void OrcamentoMensalDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            bool PintaConteudo = false;

            if (orcamentoMensalDataGridView.Columns[e.ColumnIndex].Tag != null)
            {
                if (e.RowIndex == -1)
                {
                    // Pinta o CABEÇALHO da coluna do mês atual ou futuro
                    PintaConteudo = (DateTime)orcamentoMensalDataGridView.Columns[e.ColumnIndex].Tag >= DateTime.Today;
                }
                else
                {
                    string Ordem = (string)orcamentoMensalDataGridView.Rows[e.RowIndex].Cells["dataGridView_Ordem"].Value;
                    if (Ordem == "N")
                    {
                        // Se a Tag da coluna for maior que a última data de atualização das cotações, marca para pintura
                        PintaConteudo = (DateTime)orcamentoMensalDataGridView.Columns[e.ColumnIndex].Tag > DtUltimaAtualizacao;
                    }
                }
            }

            if (PintaConteudo)
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

        private void OrcamentoMensalDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Usa o evento CellMouseMove para sobrescrever a geração do ToolTip
            // Note que o ShowCellToolTips do DataGridView foi desligado para não haver sobreposição dos "esparadrapos"

            string dica;

            if (e.ColumnIndex >= 0 && e.RowIndex == -1)
            {
                dica = orcamentoMensalDataGridView.Columns[e.ColumnIndex].ToolTipText;
            }
            else if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && orcamentoMensalDataGridView[e.ColumnIndex, e.RowIndex].ToolTipText != null)
            {
                dica = orcamentoMensalDataGridView[e.ColumnIndex, e.RowIndex].ToolTipText;
            }
            else
            {
                return;
            }

            // verifica se a dica mudou, se não mudou não faz nada para evitar flicker
            if (dica == toolTip.GetToolTip(orcamentoMensalDataGridView))
            {
                return;
            }

            toolTip.SetToolTip(orcamentoMensalDataGridView, dica);
        }
    }
}
