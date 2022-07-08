using BLL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MoneyPro
{
    public partial class fmPlanejamento : MoneyPro.Base.fmBaseTopoRodape
    {

        private int IDUsuario { get; set; }
        private Form Origem { get; set; }
        private DateTime limite;

        #region Singleton

        private static fmPlanejamento _singleton;

        private fmPlanejamento(Form origem, int usuarioID)
        {
            InitializeComponent();
            this.IDUsuario = usuarioID;
            this.Origem = origem;
        }

        public static fmPlanejamento CreateInstance(Form origem, int idusuario)
        {
            if (_singleton == null)
            {
                _singleton = new fmPlanejamento(origem, idusuario);
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

            // Se está exibindo apenas as contas ativas, exibe o botão Exibe Todas as Contas para poder
            // mudar o status.
            btnExibeTodosPlanejamentos.Visible = !(this.Origem as FmPrincipal).Configuracoes.Planejamento_ExibeAtivas;
            btnExibeSomentePlanejamentosAtivos.Visible = !btnExibeTodosPlanejamentos.Visible;

            planejamentoDataGridView.Columns["Ativo"].Visible = (this.Origem as FmPrincipal).Configuracoes.Planejamento_ExibeAtivas;

            CarregarPlanejamento(IDUsuario, (this.Origem as FmPrincipal).Configuracoes.Planejamento_ExibeAtivas);
        }

        #endregion Singleton

        private void CarregarPlanejamento(int UsuarioID, Boolean TodosPlanejamentos)
        {
            PlanejamentoBLL bll = new PlanejamentoBLL();

            DateTime primeiroLancamento = bll.PrimeiroDiaPlanejamento(UsuarioID);
            int ultimo = DateTime.DaysInMonth(primeiroLancamento.Year, primeiroLancamento.Month);
            limite = new DateTime(primeiroLancamento.Year, primeiroLancamento.Month, ultimo);

            planejamentoBindingSource.DataSource = bll.Listar(UsuarioID, TodosPlanejamentos);

            // Formata o cabeçalho coluna Observação
            planejamentoDataGridView.Columns["Observacao"].HeaderCell.Style.Font = new Font("WebDings", 9.00F, FontStyle.Regular);
            planejamentoDataGridView.Columns["Observacao"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            planejamentoDataGridView.Columns["Observacao"].HeaderText = ((char)0x73).ToString();
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            IncluirPlanejamento(IDUsuario);
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            ExcluirPlanejamento();
        }

        private void IncluirPlanejamento(int IDUsuario)
        {
            fmPlanejamentoManutencao form = new fmPlanejamentoManutencao(IDUsuario, -1);
            if (form.ShowDialog() == DialogResult.OK)
            {
                CarregarPlanejamento(IDUsuario, (this.Origem as FmPrincipal).Configuracoes.Planejamento_ExibeAtivas);
            }
        }

        private void AlterarPlanejamento(int IDUsuario)
        {
            if (planejamentoDataGridView.CurrentRow != null)
            {
                int planejamentoID = (int)planejamentoDataGridView.CurrentRow.Cells["PlanejamentoID"].Value;
                if (planejamentoID > 0)
                {
                    fmPlanejamentoManutencao form = new fmPlanejamentoManutencao(IDUsuario, planejamentoID);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CarregarPlanejamento(IDUsuario, (this.Origem as FmPrincipal).Configuracoes.Planejamento_ExibeAtivas);
                    }
                }
            }
        }

        private void EfetivarPlanejamento()
        {
            if (planejamentoDataGridView.CurrentRow != null)
            {
                int planejamentoID = (int)planejamentoDataGridView.CurrentRow.Cells["PlanejamentoID"].Value;
                if (planejamentoID > 0)
                {
                    fmPlanejamentoManutencao form = new fmPlanejamentoManutencao(true, IDUsuario, planejamentoID);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        CarregarPlanejamento(IDUsuario, (this.Origem as FmPrincipal).Configuracoes.Planejamento_ExibeAtivas);
                        int col = Geral.PrimeiraColunaVisivel(planejamentoDataGridView);
                        planejamentoDataGridView.CurrentCell = planejamentoDataGridView.Rows[0].Cells[col];

                        if (Origem is FmPrincipal)
                            (Origem as FmPrincipal).CarregarRolContas();
                    }
                }
            }
        }

        private void ExcluirPlanejamento()
        {
            if (planejamentoDataGridView.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("Confirma a exclusão do planejamento?", "Confirma",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question,
                                                  MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    int planejamentoID = (int)planejamentoDataGridView.CurrentRow.Cells["PlanejamentoID"].Value;
                    PlanejamentoBLL bll = new PlanejamentoBLL();
                    if (bll.ExcluirPlanejamento(planejamentoID))
                    {
                        CarregarPlanejamento(IDUsuario, (this.Origem as FmPrincipal).Configuracoes.Planejamento_ExibeAtivas);
                    }
                }
            }
        }

        private void fmPlanejamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                // Inserir item no planejamento
                IncluirPlanejamento(IDUsuario);
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
            {
                // Excluir item do planejamento
                ExcluirPlanejamento();
            }
            else if (e.Modifiers == Keys.None && e.KeyCode == Keys.F2)
            {
                // Alterar item do planejamento
                AlterarPlanejamento(IDUsuario);
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                // Efetivar item do planejamento
                EfetivarPlanejamento();
            }
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            // Alterar item do planejamento
            AlterarPlanejamento(IDUsuario);
        }

        private void buttonEfetivar_Click(object sender, EventArgs e)
        {
            // Efetivar planejamento
            EfetivarPlanejamento();
        }

        private void planejamentoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (planejamentoDataGridView.CurrentRow != null)
            {
                //if (e.Value != null)
                {
                    // Para saber se o item do planejamento está ou não está ativo.
                    bool ativo = (bool)planejamentoDataGridView.Rows[e.RowIndex].Cells["Ativo"].Value;
                    // Para saber se o lançamento faz parte do mês corrente.
                    DateTime data = (DateTime)planejamentoDataGridView.Rows[e.RowIndex].Cells["DtInicial"].Value;
                    //int ultimo = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
                    //DateTime limite = new DateTime(DateTime.Today.Year, DateTime.Today.Month, ultimo);

                    if (!ativo)
                    {
                        // Se o item do planejamento estiver inativo, ativa a propriedade strikeout (riscado) sobre o fonte
                        e.CellStyle.Font = new Font(e.CellStyle.Font.Name, e.CellStyle.Font.Size, FontStyle.Strikeout);
                    }

                    if (data > limite)
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

                    if (planejamentoDataGridView.Columns[e.ColumnIndex].Name.Equals("Valor"))
                    {
                        // verifica se o número é positivo ou negativo
                        decimal valor = (decimal)e.Value;

                        string fmtTexto = ((decimal)e.Value).ToString("#,##0.00");

                        e.Value = fmtTexto;

                        if (Math.Round(valor, 2) < 0)
                        {
                            e.CellStyle.ForeColor = Color.Red;
                            e.CellStyle.SelectionForeColor = Color.Red;
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.Blue;
                            e.CellStyle.SelectionForeColor = Color.Blue;
                        }
                    }
                    else if (planejamentoDataGridView.Columns[e.ColumnIndex].Name.Equals("Observacao"))
                    {
                        DataGridViewCell celula = planejamentoDataGridView.Rows[e.RowIndex].Cells["Observacao"];

                        if (celula.Value != DBNull.Value && celula.Value != null)
                        {
                            e.CellStyle.Font = new Font("WebDings", 9.00F, FontStyle.Regular);
                            // Sinal de interrogação estilizado
                            char codigochar = (char)0x73;
                            e.Value = codigochar.ToString();
                            // Coloca a observação no ToolTip da célula
                            celula.ToolTipText = (string)celula.Value;
                        }
                        else
                        {
                            celula.ToolTipText = "";
                        }
                    }
                }
            }
        }

        private void buttonCalendario_Click(object sender, EventArgs e)
        {
            fmCalendario form = new fmCalendario();
            form.ShowDialog();
        }

        private void BtnExibeTodosPlanejamentos_Click(object sender, EventArgs e)
        {
            // Marca que deve exibir todas as contas
            btnExibeTodosPlanejamentos.Visible = !btnExibeTodosPlanejamentos.Visible;
            btnExibeSomentePlanejamentosAtivos.Visible = !btnExibeTodosPlanejamentos.Visible;

            (this.Origem as FmPrincipal).Configuracoes.Planejamento_ExibeAtivas = btnExibeSomentePlanejamentosAtivos.Visible;

            CarregarPlanejamento(IDUsuario, (this.Origem as FmPrincipal).Configuracoes.Planejamento_ExibeAtivas);

            (this.Origem as FmPrincipal).ArmazenarConfiguracao();
        }

        private void PlanejamentoDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Usa o evento CellMouseMove para sobrescrever a geração do ToolTip
            // Note que o ShowCellToolTips do DataGridView foi desligado para não haver sobreposição dos "esparadrapos"

            string dica;

            if (e.ColumnIndex >= 0 && e.RowIndex == -1)
            {
                dica = planejamentoDataGridView.Columns[e.ColumnIndex].ToolTipText;
            }
            else if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && planejamentoDataGridView[e.ColumnIndex, e.RowIndex].ToolTipText != null)
            {
                dica = planejamentoDataGridView[e.ColumnIndex, e.RowIndex].ToolTipText;
            }
            else
            {
                return;
            }

            // verifica se a dica mudou, se não mudou não faz nada para evitar flicker
            if (dica == toolTip.GetToolTip(planejamentoDataGridView))
            {
                return;
            }

            toolTip.SetToolTip(planejamentoDataGridView, dica);
        }
    }
}
