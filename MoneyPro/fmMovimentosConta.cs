using BLL;
using Microsoft.Graph.Models;
using Microsoft.Identity.Client;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Modelos.Tipo;

namespace MoneyPro
{
    public partial class fmMovimentosConta : MoneyPro.Base.fmBaseTopoRodape
    {
        // DataMovimento é utilizado para pintar os lançamentos 
        // futuros do mês de verde e dos meses seguintes de azul
        private DateTime DataMovimento;

        private fmMovimentosContaFluxo fmMovimentosContaFluxoEspecifico;
        MovimentoContaPesquisa mcPesquisa = new MovimentoContaPesquisa();

        private const int MAXIMO = 100;
        private FmPrincipal Origem = null;
        private Form Detalhes = null;

        private int[] selecaoLancamentoID = new int[MAXIMO];
        private int[] selecaoCategoriaID = new int[MAXIMO];
        private int[] selecaoGrupoCategoriaID = new int[MAXIMO];
        private DateTime[] selecaoData = new DateTime[2];

        private int IDUsuario { get; set; }
        private int IDConta { get; set; }

        private string _contaNome;
        private Tipo.Conta tipoDeConta = Tipo.Conta.Outras;

        private bool iniciado = false;

        //private bool emConciliacao = false;
        private bool exibeResumo = false;
        private readonly int decimais = 2;
        private readonly bool usaHora = false;
        private bool arquivoTXT = false;
        private bool csv = false;

        #region Singleton

        private static fmMovimentosConta _singleton;

        private fmMovimentosConta(FmPrincipal origem, int contaID, string contaNome, int decimais, bool usaHora, bool exibeResumo)
        {
            InitializeComponent();

            groupBoxPesquisa.Height = 0;

            panelObservacao.Tag = panelObservacao.Height;

            this.Origem = origem;
            this.IDUsuario = Geral.UserID;
            this.IDConta = contaID;
            this.ContaNome = contaNome;

            this.decimais = decimais;
            this.usaHora = usaHora;
            this.ExibeResumo = exibeResumo;

            LimpaArraySelecionados(selecaoLancamentoID);
            LimpaArraySelecionados(selecaoCategoriaID);
            LimpaArraySelecionados(selecaoGrupoCategoriaID);

            movimentoContaDataGridView.Columns["Debito"].DefaultCellStyle.Format = "N" + decimais.ToString("0");
            movimentoContaDataGridView.Columns["Credito"].DefaultCellStyle.Format = "N" + decimais.ToString("0");
            movimentoContaDataGridView.Columns["Valor"].DefaultCellStyle.Format = "N" + decimais.ToString("0");
            movimentoContaDataGridView.Columns["Balanco"].DefaultCellStyle.Format = "N" + decimais.ToString("0");

            // Formatos de data prevista
            // d - dd/MM/yyyy
            // G - dd/MM/yyyy hh:nn:ss

            movimentoContaDataGridView.Columns["Data"].DefaultCellStyle.Format = usaHora ? "G" : "d";

            movimentoContaDataGridView.Columns["Data"].HeaderCell.ContextMenuStrip = contextMenuStripData;
            movimentoContaDataGridView.Columns["Valor"].HeaderCell.ContextMenuStrip = contextMenuStripValor;
            movimentoContaDataGridView.Columns["Valor"].ContextMenuStrip = contextMenuStripValor;
            CarregaDados(contaID);
        }

        public static fmMovimentosConta CreateInstance(FmPrincipal origem, int contaID, string contaNome, int decimais, bool usaHora, bool exibirResumo)
        {
            if (_singleton == null)
            {
                _singleton = new fmMovimentosConta(origem, contaID, contaNome, decimais, usaHora, exibirResumo);
            }
            return _singleton;
        }

        protected override void OnClosed(EventArgs e)
        {
            _singleton = null;
            base.OnClosed(e);
        }

        #endregion Singleton

        public bool ExibeResumo
        {
            get
            {
                return this.exibeResumo;
            }

            set
            {
                this.exibeResumo = value;

                buttonMinimiza.Visible = !this.exibeResumo;
                buttonMaximiza.Visible = this.exibeResumo;
            }
        }

        public bool ArquivoTXT
        {
            get
            {
                return this.arquivoTXT;
            }

            set
            {
                this.arquivoTXT = value;

                // Percorre os componentes do painel do topo em busca de Botões com a tag "TXT"
                // Se achar, a torna visível
                foreach (var item in panelTopo.Controls)
                {
                    if (item is Button btn)
                    {
                        if ((string)btn.Tag == "TXT")
                        {
                            btn.Visible = this.arquivoTXT;
                        }
                    }
                }
            }
        }

        public bool CSV
        {
            get
            {
                return this.csv;
            }

            set
            {
                this.csv = value;

                // Percorre os componentes do painel do topo em busca de Botões com a tag "CSV"
                // Se achar, a torna visível
                foreach (var item in panelTopo.Controls)
                {
                    if (item is Button btn)
                    {
                        if ((string)btn.Tag == "CSV")
                        {
                            btn.Visible = this.csv;
                        }
                    }
                }
            }
        }

        public Tipo.Conta TipoDeConta
        {
            get
            {
                return this.tipoDeConta;
            }
            set
            {
                this.tipoDeConta = value;

                switch (this.tipoDeConta)
                {
                    case Tipo.Conta.Banco:
                        // Contas em banco têm a coluna número habilitada conforme configurações
                        movimentoContaDataGridView.Columns["Numero"].Visible = Origem.Configuracoes.NumeroEmContaBanco;
                        movimentoContaDataGridView.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        movimentoContaDataGridView.Columns["Numero"].SortMode = DataGridViewColumnSortMode.NotSortable;
                        movimentoContaDataGridView.Columns["Numero"].Width = 60;
                        movimentoContaDataGridView.Columns["Numero"].FillWeight = 60;
                        movimentoContaDataGridView.Columns["Numero"].MinimumWidth = 20;
                        break;
                    case Tipo.Conta.Cartao:
                        // Contas cartão têm os nomes das colunas de débito e crédito modificados.
                        movimentoContaDataGridView.Columns["Debito"].HeaderText = "Despesa";
                        movimentoContaDataGridView.Columns["Credito"].HeaderText = "Pagamento";
                        break;
                    case Tipo.Conta.Investimento:
                        movimentoContaDataGridView.Columns["Lancamento"].HeaderText = "Lançamento";
                        CriaColunaAcao(movimentoContaDataGridView.Columns["Descricao"].Index);
                        break;
                    case Tipo.Conta.Poupanca:
                        movimentoContaDataGridView.Columns["Lancamento"].HeaderText = "Lançamento";
                        break;
                    case Tipo.Conta.CDB:
                        movimentoContaDataGridView.Columns["Lancamento"].HeaderText = "Lançamento";
                        movimentoContaDataGridView.Columns["Numero"].Visible = true;
                        movimentoContaDataGridView.Columns["Numero"].HeaderText = "CDB #";
                        movimentoContaDataGridView.Columns["Numero"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        movimentoContaDataGridView.Columns["Numero"].SortMode = DataGridViewColumnSortMode.NotSortable;
                        movimentoContaDataGridView.Columns["Numero"].Width = 60;
                        movimentoContaDataGridView.Columns["Numero"].FillWeight = 60;
                        movimentoContaDataGridView.Columns["Numero"].MinimumWidth = 20;
                        break;
                    case Tipo.Conta.Outras:
                        movimentoContaDataGridView.Columns["Lancamento"].HeaderText = "Lançamento";
                        break;
                }
            }
        }

        private void CarregaDados(int contaID)
        {
            CriaColunaLancamento();
            CriaColunaCategoria();
            CriaColunaGrupoCategoria();
            CriaColunaLegenda();
            CarregarMovimentosContas(contaID);

            // Formata o cabeçalho coluna Observação
            movimentoContaDataGridView.Columns["Observacao"].HeaderCell.Style.Font = new Font("WebDings", 9.00F, FontStyle.Regular);
            movimentoContaDataGridView.Columns["Observacao"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            movimentoContaDataGridView.Columns["Observacao"].HeaderText = ((char)0x73).ToString();
        }

        private void CriaColunaAcao(int posicaoColuna)
        {
            DataGridViewTextBoxColumn text = new DataGridViewTextBoxColumn();
            text.Name = "Acao";
            text.DataPropertyName = "Transacao";
            text.HeaderText = "Ação";
            text.Visible = true;
            text.ReadOnly = true;
            text.SortMode = DataGridViewColumnSortMode.NotSortable;
            text.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            text.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            text.Width = 50;
            text.FillWeight = 50;
            text.MinimumWidth = 20;

            movimentoContaDataGridView.Columns.Insert(posicaoColuna, text);
        }

        private void CriaColunaLegenda()
        {
            DataGridViewTextBoxColumn text = new DataGridViewTextBoxColumn
            {
                Name = "Legenda",
                DataPropertyName = "Legenda",
                HeaderText = "",
                Visible = true,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 22,
                FillWeight = 22,
                MinimumWidth = 22,
                ContextMenuStrip = contextMenuStripLegenda,
                ToolTipText = ""
            };
            text.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            int ultima = movimentoContaDataGridView.Columns.Count;
            movimentoContaDataGridView.Columns.Insert(ultima, text);
        }

        private void CriaColunaLancamento()
        {
            string nomeColuna = "Lancamento";

            // Cria uma nova colluna do tipo ComboBox
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Name = nomeColuna;
            // Adiciona o menu de contexto
            combo.HeaderCell.ContextMenuStrip = contextMenuStripLancamento;

            combo.DataPropertyName = "LancamentoID";
            combo.DisplayMember = "Apelido";
            combo.ValueMember = "LancamentoID";
            combo.HeaderText = "Parceiro";
            combo.SortMode = DataGridViewColumnSortMode.NotSortable;
            // Atributos de formato
            combo.FlatStyle = FlatStyle.Flat;
            combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            combo.AutoComplete = true;
            combo.Width = 180;
            combo.DropDownWidth = 200;
            combo.FillWeight = 180;
            combo.MinimumWidth = 120;

            // Acha a posição da coluna numérica e coloca o combobox junto, deixando a coluna numérica invisível.
            int index = movimentoContaDataGridView.Columns["LancamentoID"].Index;
            movimentoContaDataGridView.Columns[index].Visible = false;
            movimentoContaDataGridView.Columns.Insert(index, combo);

            CarregaLancamentos(IDUsuario);
        }

        public void CarregaLancamentos(int usuarioID)
        {
            DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)movimentoContaDataGridView.Columns["Lancamento"];

            LancamentoBLL bll = new LancamentoBLL();
            combo.DataSource = bll.Listar(usuarioID);
        }

        private void CriaColunaCategoria()
        {
            string nomeColuna = "Categoria";

            // Cria uma nova colluna do tipo ComboBox
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Name = nomeColuna;
            // Adiciona o menu de contexto
            combo.HeaderCell.ContextMenuStrip = contextMenuStripCategoria;

            combo.DataPropertyName = "CategoriaID";
            combo.DisplayMember = "vFiltro";
            combo.ValueMember = "CategoriaID";
            combo.HeaderText = "Categoria";
            combo.SortMode = DataGridViewColumnSortMode.NotSortable;
            // Atributos de formato
            combo.FlatStyle = FlatStyle.Flat;
            combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            combo.AutoComplete = true;
            combo.Width = 180;
            combo.DropDownWidth = 200;
            combo.FillWeight = 180;
            combo.MinimumWidth = 120;

            // Acha a posição da coluna numérica e coloca o combobox junto, deixando a coluna numérica invisível.
            int index = movimentoContaDataGridView.Columns["CategoriaID"].Index;
            movimentoContaDataGridView.Columns[index].Visible = false;
            movimentoContaDataGridView.Columns.Insert(index, combo);

            CarregaCategorias(IDUsuario);
        }

        private void CarregaCategorias(int UsuarioID)
        {
            DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)movimentoContaDataGridView.Columns["Categoria"];

            CategoriaBLL bll = new CategoriaBLL();
            combo.DataSource = bll.ListarSelecionaveis(UsuarioID);
        }

        private void CriaColunaGrupoCategoria()
        {
            string nomeColuna = "GrupoCategoria";

            // Cria uma nova colluna do tipo ComboBox
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Name = nomeColuna;
            combo.DataPropertyName = "GrupoCategoriaID";
            // Adiciona o menu de contexto
            combo.HeaderCell.ContextMenuStrip = contextMenuStripGrupo;

            combo.DisplayMember = "Apelido";
            combo.ValueMember = "GrupoCategoriaID";
            combo.HeaderText = "Grupo";
            combo.SortMode = DataGridViewColumnSortMode.NotSortable;
            // Atributos de formato
            combo.FlatStyle = FlatStyle.Flat;
            combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            combo.AutoComplete = true;
            combo.Width = 100;
            combo.FillWeight = 100;
            combo.MinimumWidth = 80;

            // Acha a posição da coluna numérica e coloca o combobox junto, deixando a coluna numérica invisível.
            int index = movimentoContaDataGridView.Columns["GrupoCategoriaID"].Index;
            movimentoContaDataGridView.Columns[index].Visible = false;
            movimentoContaDataGridView.Columns.Insert(index, combo);

            CarregaGrupoCategorias();
        }

        private void CarregaGrupoCategorias()
        {
            DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)movimentoContaDataGridView.Columns["GrupoCategoria"];

            GrupoCategoriaBLL bll = new GrupoCategoriaBLL();
            combo.DataSource = bll.Listar(IDUsuario);
        }

        public void CarregarMovimentosContas(int contaID, bool ultimaLinha = false)
        {
            try
            {
                // Muda o cursor para ampulheta
                Cursor.Current = Cursors.WaitCursor;

                movimentoContaDataGridView.RowValidating -= MovimentoContaDataGridView_RowValidating;
                movimentoContaDataGridView.RowEnter -= MovimentoContaDataGridView_RowEnter;

                if (!mcPesquisa.Filtrado)
                {
                    int offset = -1;
                    int lin = 0;
                    int col = 0;

                    if (movimentoContaDataGridView.RowCount > 0)
                    {
                        offset = movimentoContaDataGridView.FirstDisplayedScrollingRowIndex;
                        lin = movimentoContaDataGridView.CurrentCell.RowIndex;
                        col = movimentoContaDataGridView.CurrentCell.ColumnIndex;
                    }

                    String filtro = MontaFiltro();

                    MovimentoContaBLL mvtoConta = new MovimentoContaBLL();

                    if (ExibeResumo)
                    {
                        // Se o botão minimiza estiver visível é porque a opção atual é maximizado
                        movimentoContaBindingSource.DataSource = mvtoConta.ListarMovimentosContaResumo(contaID, filtro);
                    }
                    else
                    {
                        // Se o botão minimiza não estiver visível é porque a opção atual é minimizado
                        movimentoContaBindingSource.DataSource = mvtoConta.ListarMovimentosConta(contaID, filtro);
                    }

                    if (offset >= 0 && !ultimaLinha && offset < movimentoContaDataGridView.RowCount)
                    {
                        movimentoContaDataGridView.FirstDisplayedScrollingRowIndex = offset;
                    }
                    else if (ultimaLinha)
                    {
                        PosicionaUltimaLinhaNaoFuturo();
                    }

                    ExibirContadorMovimentacoes(false);
                }
                else
                {
                    // Efetua carga com os valores indicados na pesquisa
                    MovimentoContaBLL mvtoConta = new MovimentoContaBLL();
                    movimentoContaBindingSource.DataSource = mvtoConta.ListarConteudoPesquisa(IDConta, mcPesquisa);

                    ExibirContadorMovimentacoes(true);
                }
            }
            finally
            {
                movimentoContaDataGridView.RowEnter += MovimentoContaDataGridView_RowEnter;
                movimentoContaDataGridView.RowValidating += MovimentoContaDataGridView_RowValidating;

                // Restaura o cursor padrão
                Cursor.Current = Cursors.Default;
            }
        }

        private void ExibirContadorMovimentacoes(bool filtro = false)
        {
            // Conta as movimentações e exibe no rodapé

            // Deve haver ao menos um lançamento de abertura na conta, 
            // se estiver vazio há algum erro na query que trouxe zero registros

            if (movimentoContaDataGridView.Rows.Count > 0)
            {

                // Pega o valor de "MovimentosAgrupados" que pode ser 1 caso se esteja exibindo
                // tudo ou COUNT(*) caso se esteja exibindo apenas os não reconciliados.
                int linhas = (int)movimentoContaDataGridView.Rows[0].Cells["MovimentosAgrupados"].Value;
                // Soma a contagem das linhas menos um pois o valor da primeira linha já foi incluído no passo anterior
                linhas += movimentoContaBindingSource.Count - 1;

                switch (linhas)
                {
                    case 0:
                        labelRegistros.Text = "Nenhuma movimentação" + (filtro ? " na pesquisa" : "");
                        break;
                    case 1:
                        labelRegistros.Text = "Uma movimentação" + (filtro ? " na pesquisa" : "");
                        break;
                    default:
                        labelRegistros.Text = linhas.ToString("#,##0") + " movimentações" + (filtro ? " na pesquisa" : "");
                        break;
                }
            }
        }

        public string ContaNome
        {
            get { return _contaNome; }
            set
            {
                _contaNome = value;
                labelTopo.Text = _contaNome;
            }
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            IncluirMovimentoConta();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            ExcluirMovimentoConta();
        }

        private void IncluirMovimentoConta()
        {
            // Se a linha atual não for nula
            if (movimentoContaDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)movimentoContaDataGridView.CurrentRow.Cells["MovimentoContaID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            if (movimentoContaDataGridView.CurrentCell.IsInEditMode || movimentoContaDataGridView.IsCurrentRowDirty)
            {
                // Se a célula corrente estiver em edição ou a linha estiver suja, não permite incluir uma linha nova
                return;
            }

            DataTable table = (DataTable)movimentoContaBindingSource.DataSource;
            DataRow row = table.NewRow();

            row["UsuarioID"] = IDUsuario;
            row["ContaID"] = IDConta;
            row["MovimentoContaID"] = MovimentoContaBLL.ProximoID;
            if (!usaHora)
            {
                row["Data"] = DateTime.Today;
            }
            else
            {
                row["Data"] = DateTime.Now;
            }
            row["CrdDeb"] = " ";       // Será mudado conforme for preenchido os valores de débito ou crédito.
            row["Conciliacao"] = " ";  // Não conciliado
            row["Sistema"] = false;
            row["Observacao"] = "";
            row["Legenda"] = 0;

            table.Rows.Add(row);

            movimentoContaDataGridView.Focus();

            int lin = movimentoContaDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(movimentoContaDataGridView);
            movimentoContaDataGridView.CurrentCell = movimentoContaDataGridView.Rows[lin].Cells[col];
        }

        private void ExcluirMovimentoConta()
        {
            if (movimentoContaDataGridView.CurrentRow != null)
            {
                if (((string)movimentoContaDataGridView.CurrentRow.Cells["Conciliacao"].Value == "C") ||
                    ((string)movimentoContaDataGridView.CurrentRow.Cells["Conciliacao"].Value == "R"))
                {
                    MessageBox.Show("Não é permitido excluir um lançamento conciliado.",
                                    "Erro",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                MovimentoContaBLL bll = new MovimentoContaBLL();

                if (bll.Conciliados((int)movimentoContaDataGridView.CurrentRow.Cells["MovimentoContaID"].Value) > 0)
                {
                    MessageBox.Show("Não é permitido excluir um lançamento com contra-partida conciliada.",
                                    "Erro",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                else
                if (movimentoContaDataGridView.CurrentRow.Cells["PlanejamentoID"].Value != DBNull.Value &&
                    !bll.UltimoDaPilhaDePlanejamento((int)movimentoContaDataGridView.CurrentRow.Cells["MovimentoContaID"].Value))
                {
                    // Se o movimento é proveniente de um planejamento (PlanejamentoID != null) e
                    // se o movimento não é o último da pilha de planejamentos --> apresenta mensagem e aborta a exclusão.

                    MessageBox.Show("Somente o último movimento proveniente\nde planejamento pode ser excluído.",
                                    "Erro",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                string msg;
                int movimentoID;

                if (movimentoContaDataGridView.CurrentRow.Cells["DoMovimentoContaID"].Value == DBNull.Value)
                {
                    // Este é um movimento único ou de origem ou de planejamento.
                    if (movimentoContaDataGridView.CurrentRow.Cells["PlanejamentoID"].Value != DBNull.Value)
                    {
                        msg = "Deseja excluir o lançamento proveniente de planejamento?";
                    }
                    else if (movimentoContaDataGridView.CurrentRow.Cells["MovimentoInvestimentoID"].Value != DBNull.Value)
                    {
                        msg = "Deseja excluir o lançamento de investimento?";
                    }
                    else if (movimentoContaDataGridView.CurrentRow.Cells["CotacaoMoedaID"].Value != DBNull.Value)
                    {
                        msg = "Deseja excluir o lançamento de câmbio?";
                    }
                    else
                    {
                        msg = "Deseja excluir o lançamento da conta?";
                    }

                    movimentoID = (int)movimentoContaDataGridView.CurrentRow.Cells["MovimentoContaID"].Value;
                }
                else
                {
                    // Este é um movimento de destino, criado a partir de um de origem
                    // (Origem = a conta de onde saiu o recurso, destino = a conta onde chegou o recurso).
                    msg = "Este lançamento foi criado a partir de outro, deseja\n" +
                          "excluir todos os lançamentos envolvidos?";

                    movimentoID = (int)movimentoContaDataGridView.CurrentRow.Cells["DoMovimentoContaID"].Value;
                }

                DialogResult dr = MessageBox.Show(msg, "Confirmação",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question,
                                                  MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    bll.Excluir(movimentoID);
                    CarregarMovimentosContas(IDConta);
                    Origem.CarregarRolContas();
                }
            }
        }

        private void fmMovimentosConta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && e.Modifiers == Keys.None)
            {
                // O F3 sem modificadores liga/desliga a caixa de pesquisa e essa caixa tem prioridade no tratamento

                // Liga ou desliga a pesquisa
                if (buttonExibirPesquisa.Visible)
                {
                    ButtonExibirPesquisa_Click(sender, null);
                }
                else
                {
                    ButtonEsconderPesquisa_Click(sender, null);
                }
            }
            else if (e.KeyCode == Keys.F4 && e.Modifiers == Keys.None && !buttonConciliacaoOn.Visible)
            {
                // O F4 sem modificadores carrega a tela de fluxo de caixa da conta atual
                ExibirFluxoEspecifico();
            }

            if (movimentoContaDataGridView.Focused)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down ||
                    e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown ||
                    e.KeyCode == Keys.Home || e.KeyCode == Keys.End)
                {
                    if (e.Modifiers == Keys.Shift)
                    {
                        movimentoContaDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    }
                    else
                    {
                        movimentoContaDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    }
                }
                else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
                {
                    // Se teclado insert chama rotina de inclusão.
                    IncluirMovimentoConta();
                }
                else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.N)
                {
                    // Se teclado ctrl + N chama a rotina de inclusão
                    IncluirMovimentoConta();
                }
                else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Insert)
                {
                    // Se teclado ctrl + insert chama rotina de inclusão específica

                    if (TipoDeConta == Tipo.Conta.Investimento)
                    {
                        // Se tipo de conta for investimento
                        IncluirMovimentoInvestimento();
                    }
                    else if (TipoDeConta == Tipo.Conta.CDB)
                    {
                        // Se tipo de conta for CDB
                        InformarSaldoAtualCDB();
                    }
                }
                else if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Insert)
                {
                    // Se teclado shit + insert chama a rotina de inclusão de câmbio
                    IncluirMovimentoCambio();
                }
                else if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Return)
                {
                    // Se teclado shit + return chama a rotina de alteração de câmbio
                    AlterarMovimentoCambio((int)movimentoContaDataGridView.CurrentRow.Cells["MovimentoContaID"].Value);
                }
                else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Return && movimentoContaDataGridView.IsCurrentCellDirty)
                {
                    movimentoContaDataGridView.EndEdit();
                    movimentoContaDataGridView.CausesValidation = true;
                }
                else if ((e.Modifiers == Keys.Control && e.KeyCode == Keys.Return) || (e.KeyCode == Keys.F2 && !buttonConciliacaoOn.Visible))
                {
                    // Tratamento exclusivo para contas Investimento
                    //
                    // Se tecla ctrl + enter e NÃO houver alteração na linha chama rotina para alteração de investimento
                    if (TipoDeConta == Tipo.Conta.Investimento)
                    {
                        e.Handled = true;
                        AlterarMovimentoInvestimento();
                    }
                }
                else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
                {
                    // Se teclado ctrl + delete chama rotina de exclusão.
                    ExcluirMovimentoConta();
                }
                else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
                {
                    // Se teclado Escape (sem modificadores (Alt ou Ctrl ou Shift))
                    CancelarLinhaNova();
                }
                else if (e.KeyCode == Keys.Back && e.Modifiers == Keys.None)
                {
                    if (!movimentoContaDataGridView.IsCurrentCellInEditMode)
                        movimentoContaDataGridView.CurrentCell.Value = DBNull.Value;
                }
                else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
                {
                    // Ctrl + V cola o conteúdo

                    string colName = movimentoContaDataGridView.CurrentCell.OwningColumn.Name;

                    if (colName == "Numero" || colName == "Descricao")
                    {
                        // Verifica se existe algum texto na área de transferência
                        if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                            // Coloca o texto dentro da célula
                            movimentoContaDataGridView.CurrentRow.Cells[colName].Value = Clipboard.GetDataObject().GetData(DataFormats.Text).ToString();
                    }
                    else if (colName == "Credito" || colName == "Debito")
                    {
                        // Verifica se existe algum texto na área de transferência
                        if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                        {
                            NumberStyles style;
                            CultureInfo culture;

                            string texto = Clipboard.GetDataObject().GetData(DataFormats.Text).ToString();
                            style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                            culture = CultureInfo.CreateSpecificCulture("pt-BR");

                            if (Double.TryParse(texto, style, culture, out double valor))
                            {
                                // Coloca o texto dentro da célula
                                movimentoContaDataGridView.CurrentRow.Cells[colName].Value = valor;
                            }
                        }
                    }
                }
                else if (e.Modifiers == Keys.None && e.KeyCode == Keys.F7)
                {
                    e.Handled = true;
                    // Alterna o modo de exibição entre tudo e somente os não conciliados
                    AlternaModoVisualizacao();
                }
                else if (e.Modifiers == Keys.None && e.KeyCode == Keys.F8)
                {
                    e.Handled = true;
                    // Alterna entre modo normal e modo conciliação
                    AlternaModoConciliacao();
                }
                else if ((e.Modifiers == Keys.Control && e.KeyCode == Keys.F9) || (e.KeyCode == Keys.F9 && buttonConciliacaoOn.Visible))
                {
                    e.Handled = true;
                    // Ctrl + F9 -> desmarca as conciliações/reconciliações
                    ProcessarConciliacao(TipoConciliacao.NaoConciliado);
                }
                else if ((e.Modifiers == Keys.Control && e.KeyCode == Keys.F10) || (e.KeyCode == Keys.F10 && buttonConciliacaoOn.Visible))
                {
                    e.Handled = true;
                    // Ctrl + F10 -> marca um evento futuro como agendado
                    ProcessarConciliacao(TipoConciliacao.Agendado);
                    //EnviarParaTodo((int)movimentoContaDataGridView.CurrentRow.Cells["MovimentoContaID"].Value);
                }
                else if ((e.Modifiers == Keys.Control && e.KeyCode == Keys.F11) || (e.KeyCode == Keys.F11 && buttonConciliacaoOn.Visible))
                {
                    e.Handled = true;
                    // Ctrl + F11 -> marca de conciliado (marca ou desmarca)
                    ProcessarConciliacao(TipoConciliacao.Conciliado);
                }
                else if (buttonConciliacaoOn.Visible && e.KeyCode == Keys.F4)
                {
                    e.Handled = true;
                    // F4 em modo conciliação -> marca de conciliado (marca ou desmarca)
                    ProcessarConciliacao(TipoConciliacao.Conciliado);
                }
                else if ((e.Modifiers == Keys.Control && e.KeyCode == Keys.F12) || (e.KeyCode == Keys.F12 && buttonConciliacaoOn.Visible))
                {
                    e.Handled = true;
                    // Ctrl + F12 -> marca de reconciliado (marca ou desmarca)
                    ProcessarConciliacao(TipoConciliacao.Reconciliado);
                }
            }
            else if (!textBoxObservacao.Focused)
            {
                if (e.KeyCode == Keys.Return)
                {
                    if (ActiveControl is TextBox || ActiveControl is DateTimePicker)
                    {
                        ButtonEfetuarPesquisa_Click(sender, null);
                    }
                    else if (ActiveControl is ComboBox && !((ComboBox)ActiveControl).DroppedDown)
                    {
                        ButtonEfetuarPesquisa_Click(sender, null);
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    if (ActiveControl is TextBox)
                    {
                        ((TextBox)ActiveControl).Clear();
                    }
                    else if (ActiveControl is ComboBox)
                    {
                        ((ComboBox)ActiveControl).SelectedIndex = -1;
                    }
                }
            }
        }

        private async Task EnviarParaTodo(int movimentoContaID)
        {
            // TODO Este método não funciona, não consigo fazer autenticação no Microsoft Entra
            string[] Scopes = { "user.read" };

            MovimentoTODO todo = new MovimentoContaBLL().MovimentoTODO(movimentoContaID);

            StringBuilder anotacao = new StringBuilder();
            anotacao.AppendLine($"<b>{todo.Subtitulo}</b>");
            anotacao.AppendLine(todo.Origem);

            if (todo.CrdDeb == "C")
                anotacao.AppendLine($"Valor a receber: <span style=\"color: green;\">{todo.valor.ToString("#0.00", new CultureInfo("pt-BR"))}</span>");
            else
                anotacao.AppendLine($"Valor a pagar: $<span style=\"color: red;\">{todo.valor.ToString("#0.00", new CultureInfo("pt-BR"))}</span>");

            anotacao.AppendLine("<br><br><sub>By MoneyPro</sub>");

            var requestBody = new TodoTask
            {
                Title = todo.Titulo,
                DueDateTime = new DateTimeTimeZone
                {
                    DateTime = todo.Data.ToString("yyyy-MM-dd"),
                    TimeZone = "UTC"
                },
                IsReminderOn = true,
                ReminderDateTime = new DateTimeTimeZone
                {
                    DateTime = todo.Data.AddHours(11).ToString("yyyy-MM-dd HH:mm:ss"),
                    TimeZone = "UTC"
                },
                Categories = new List<string>
                {
                    "Important"
                },
                Body = new ItemBody
                {
                    Content = anotacao.ToString(),
                    ContentType = BodyType.Html
                }
            };

            try
            {
                IPublicClientApplication publicClientApp = PublicClientApplicationBuilder.Create("dd35d433-f807-44e5-b493-c9070c984b6a")
                    .WithRedirectUri("https://login.live.com/oauth20_desktop.srf")
                    .WithAuthority(AzureCloudInstance.AzurePublic, "be29e748-5689-443e-90e8-2b7b1646dfdf")
                .Build();

                var authResult = await publicClientApp.AcquireTokenInteractive(Scopes).ExecuteAsync();

                if (authResult != null)
                {
                    MessageBox.Show(text: authResult.AccessToken);
                }
            }
            catch (MsalUiRequiredException ex)
            {
                MessageBox.Show(text: ex.Message);
            }
        }

        private void InformarSaldoAtualCDB()
        {
            // O usuário informa o saldo atual do CDB e a rotina calculará o valor do crédito

            string numeroCDB = null;

            if (movimentoContaDataGridView.CurrentRow != null)
            {
                DataGridViewRow linha = movimentoContaDataGridView.CurrentRow;
                numeroCDB = (string)linha.Cells["Numero"].Value;
            }

            fmMovimentosCDB form = new fmMovimentosCDB(IDUsuario, IDConta, numeroCDB, this.decimais);

            if (form.ShowDialog() == DialogResult.OK)
            {
                var storedRow = movimentoContaDataGridView.CurrentRow.Index;
                var storedCol = movimentoContaDataGridView.CurrentCell.ColumnIndex;

                CarregarMovimentosContas(IDConta);
                Origem.CarregarRolContas();

                // Esconde a caixa de observações após a gravação
                AlternaExibicaoCaixaObservacao(movimentoContaDataGridView.CurrentRow.Index, true);

                if (storedRow >= 0 && storedRow < movimentoContaDataGridView.Rows.Count)
                {
                    // Se a linha armazenada estiver dentro do intervalo de linhas da grid
                    movimentoContaDataGridView.CurrentCell = movimentoContaDataGridView.Rows[storedRow].Cells[storedCol];
                }
                else
                {
                    // Se a linha armazenada estiver fora do intervalo de linhas da grid
                    movimentoContaDataGridView.CurrentCell = movimentoContaDataGridView.Rows[movimentoContaDataGridView.Rows.Count - 1].Cells[storedCol];
                }
            }
        }

        private void ProcessarConciliacao(TipoConciliacao status)
        {
            try
            {
                movimentoContaDataGridView.RowValidating -= MovimentoContaDataGridView_RowValidating;

                DataGridViewCell storedCell = null;

                if (movimentoContaDataGridView.SelectedRows.Count == 0)
                {
                    storedCell = movimentoContaDataGridView.CurrentCell;

                    // Se status for não conciliado, conciliado ou reconciliado
                    if (status == TipoConciliacao.NaoConciliado || status == TipoConciliacao.Conciliado || status == TipoConciliacao.Reconciliado)
                    {
                        // Se a data de movimentação for menor que agora
                        if ((DateTime)movimentoContaDataGridView.CurrentRow.Cells["Data"].Value <= DateTime.Now)
                        {
                            // Atribui um novo status ou remove um antigo
                            if ((string)movimentoContaDataGridView.CurrentRow.Cells["Conciliacao"].Value != ((char)status).ToString())
                                movimentoContaDataGridView.CurrentRow.Cells["Conciliacao"].Value = ((char)status).ToString();
                            else
                                movimentoContaDataGridView.CurrentRow.Cells["Conciliacao"].Value = ((char)TipoConciliacao.NaoConciliado).ToString();
                        }
                        else
                        {
                            String msg = null;

                            if (status == TipoConciliacao.NaoConciliado)
                                msg = "Não é permitido limpar a situação futura.";
                            else if (status == TipoConciliacao.Conciliado)
                                msg = "Não é permitido conciliar um movimento futuro.";
                            else if (status == TipoConciliacao.Reconciliado)
                                msg = "Não é permitido reconciliar movimento futuro.";

                            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    // Se status for agendado ou futuro
                    else if (status == TipoConciliacao.Agendado || status == TipoConciliacao.Futuro)
                    {
                        // Se a data de movimentação for futura
                        if ((DateTime)movimentoContaDataGridView.CurrentRow.Cells["Data"].Value > DateTime.Now)
                        {
                            // Atribui um novo status ou remove um antigo (recoloca Futuro, nesse caso)
                            if ((string)movimentoContaDataGridView.CurrentRow.Cells["Conciliacao"].Value != ((char)status).ToString())
                                movimentoContaDataGridView.CurrentRow.Cells["Conciliacao"].Value = ((char)status).ToString();
                            else
                                movimentoContaDataGridView.CurrentRow.Cells["Conciliacao"].Value = ((char)TipoConciliacao.Futuro).ToString();
                        }
                        else
                        {
                            String msg = "Não é possível agendar movimento passado.";

                            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    DataGridViewRow linha = movimentoContaDataGridView.CurrentRow;
                    GravarConciliacao(linha);
                }
                else
                {
                    if (status != TipoConciliacao.Agendado)
                    {
                        // Marca as linhas selecionadas como reconciliadas se estiverem no passado
                        foreach (DataGridViewRow linha in movimentoContaDataGridView.SelectedRows)
                        {
                            if ((DateTime)linha.Cells["Data"].Value < DateTime.Now)
                            {
                                linha.Cells["Conciliacao"].Value = ((char)status).ToString();
                                GravarConciliacao(linha);
                            }
                        }
                    }
                    else
                    {
                        // Marca as linha selecionadas como agendadas se estivemre no futuro
                        foreach (DataGridViewRow linha in movimentoContaDataGridView.SelectedRows)
                        {
                            if ((DateTime)linha.Cells["Data"].Value > DateTime.Now)
                            {
                                linha.Cells["Conciliacao"].Value = ((char)status).ToString();
                                GravarConciliacao(linha);
                            }
                        }
                    }
                }

                movimentoContaDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                movimentoContaDataGridView.Focus();

                // Movimenta para a primeira coluna visível da linha
                int lin = movimentoContaDataGridView.CurrentRow.Index;
                int col = Geral.PrimeiraColunaVisivel(movimentoContaDataGridView);
                movimentoContaDataGridView.CurrentCell = movimentoContaDataGridView.Rows[lin].Cells[col];

                // Se a célula selecionada foi armazenada então movimenta até ela
                if (storedCell != null)
                {
                    movimentoContaDataGridView.CurrentCell = storedCell;
                }
            }
            finally
            {
                // Força o "repaint" da(s) linha(s) afetadas(s)

                if (movimentoContaDataGridView.SelectedRows.Count > 0)
                {
                    // Se há uma ou mais linhas selecionadas, invalida todas para que sejam atualizadas
                    foreach (DataGridViewRow linha in movimentoContaDataGridView.SelectedRows)
                    {
                        movimentoContaDataGridView.InvalidateRow(linha.Index);
                    }
                }
                else
                {
                    // Se não há linha selecionada, invalida a linha corrente
                    movimentoContaDataGridView.InvalidateRow(movimentoContaDataGridView.CurrentRow.Index);
                }

                movimentoContaDataGridView.RowValidating += MovimentoContaDataGridView_RowValidating;
            }
        }

        private void GravarConciliacao(DataGridViewRow linha)
        {
            MovimentoContaBLL bll = new MovimentoContaBLL();
            bll.GravarConciliacao(linha);
        }

        private void CancelarLinhaNova()
        {
            if ((int)movimentoContaDataGridView.CurrentRow.Cells["MovimentoContaID"].Value < 0)
            {
                movimentoContaDataGridView.Rows.Remove(movimentoContaDataGridView.CurrentRow);
            }
        }

        private void movimentoContaDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!movimentoContaDataGridView.IsCurrentCellInEditMode)
            {
                e.Handled = true;
                return;
            }

            if (movimentoContaDataGridView.CurrentRow != null)
            {
                // pega o número da coluna corrente
                int cell = movimentoContaDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = movimentoContaDataGridView.Columns[cell].Name;

                if (!char.IsControl(e.KeyChar))
                {
                    string conciliado = (string)movimentoContaDataGridView.CurrentRow.Cells["Conciliacao"].Value;
                    // Conciliado = " " - não é conciliado
                    // Conciliado = "A" - lançamento futuro agendado na instituição
                    // Conciliado = "F" - lançamento futuro

                    if (conciliado != " " && conciliado != "F" && conciliado != "A")
                    {
                        MessageBox.Show("Movimentos conciliados não podem ser alterados.",
                            "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Bloqueia a alteração
                        e.Handled = true;
                        return;
                    }

                    if (coluna == "Lancamento")
                    {
                        // Recebe o sender como combobox
                        ComboBox combobox = (ComboBox)movimentoContaDataGridView.EditingControl;
                        // Aceita qualquer texto de 1 a 40 caracters
                        if (Regex.IsMatch(combobox.Text + e.KeyChar, "^.{1,40}$"))
                        {
                            Geral.Capitaliza(combobox);                         // Capitaliza o conteúdo do combobox
                            combobox.DroppedDown = true;                        // abre a cortina do combobox
                        }
                        else
                        {
                            e.Handled = true;                                   // não passou pela regex
                        }
                    }
                    else if (coluna == "Categoria")
                    {
                        // Difere do ParceiroID devido ao tratamento do regex por
                        // aceitar apenas zero ou uma incidência de dois pontos

                        // Recebe o sender como combobox
                        ComboBox combobox = (ComboBox)movimentoContaDataGridView.EditingControl;
                        Geral.Capitaliza(combobox);                            // Capitaliza o conteúdo do combobox
                        combobox.DroppedDown = true;                           // abre a cortina do combobox
                    }
                    else if (coluna == "GrupoCategoria")
                    {
                        // Recebe o sender como combobox
                        ComboBox combobox = (ComboBox)movimentoContaDataGridView.EditingControl;
                        // Aceita qualquer texto de 1 a 40 caracters
                        if (Regex.IsMatch(combobox.Text + e.KeyChar, "^.{1,25}$"))
                        {
                            combobox.DroppedDown = true;                           // abre a cortina do combobox
                            Geral.Capitaliza(combobox);                            // Capitaliza o conteúdo do combobox
                        }
                        else
                        {
                            e.Handled = true;                                      // não passou pela regex
                        }
                    }
                    else if (coluna == "Descricao")
                    {
                        // Recebe o sender como TextBox
                        TextBox textbox = (TextBox)sender;
                        // Aceita qualquer texto de 0 a 100 caracters
                        if (Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,100}$"))
                        {
                            // Capitaliza o conteúdo do textbox
                            Geral.Capitaliza(textbox);
                        }
                        else
                        {
                            // não passou pela regex
                            e.Handled = true;
                        }
                    }
                    else if ((coluna == "Debito") || (coluna == "Credito"))
                    {
                        TextBox editingControl = (TextBox)sender;

                        if (editingControl.Text == editingControl.SelectedText)
                        {
                            editingControl.Text = string.Empty;
                            editingControl.SelectionStart = editingControl.TextLength;
                            editingControl.SelectionLength = 0;
                        }

                        // Aceita sinal de +, de - e até 12 dígitos de 0 a 9
                        // depois aceita uma vírgula opcional
                        // Se colocar a vírgula, pode incluir mais X dígitos de 0 a 9
                        // Se não colocar a vírgula, não aceita mais nada
                        //
                        // Exemplo de regex para 2 casas decimais
                        // ^[+]?[0-9]{0,12}((,[0-9]{0,2})|())$

                        string regex = "^[+]?[0-9]{0,12}((,[0-9]{0,X})|())$".Replace("X", decimais.ToString("0"));

                        // Se usar o PONTO, troca por VIRGULA, assim permite usar o teclado numérico.
                        if (e.KeyChar == '.')
                        {
                            e.KeyChar = ',';
                        }

                        if (!Regex.IsMatch(editingControl.Text + e.KeyChar, regex))
                        {
                            // não passou pela regex
                            e.Handled = true;
                        }
                    }
                    else if (coluna == "Conciliacao")
                    {
                        // aceita espaço em branco, C, R, F, A
                        e.KeyChar = char.ToUpper(e.KeyChar);

                        if (e.KeyChar == ' ' || e.KeyChar == 'C' || e.KeyChar == 'R' || e.KeyChar == 'F' || e.KeyChar == 'A')
                        {
                            TextBox textbox = (TextBox)sender;

                            if (textbox.Text == textbox.SelectedText)
                            {
                                textbox.Text = string.Empty;
                                textbox.SelectionStart = textbox.TextLength;
                                textbox.SelectionLength = 0;
                            }

                            if (!Regex.IsMatch(textbox.Text + e.KeyChar, "^[ ACFR]?$"))
                            {
                                e.Handled = true;                                  // não passou pela regex
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                    else if (coluna == "Data")
                    {
                        TextBox editingControl = (TextBox)sender;

                        if ((e.KeyChar == '+') || (e.KeyChar == '='))
                        {
                            // Se + ou = (dois valores da mesma tecla, mudados pelo shift)
                            // tenta avançar um dia na data
                            e.KeyChar = (char)Keys.None;
                            DateTime dt;
                            if (DateTime.TryParse(editingControl.Text, out dt))
                            {
                                dt = dt.AddDays(1);
                                editingControl.Text = dt.ToString().Substring(0, 10);
                            }
                            e.Handled = true;
                        }
                        else if ((e.KeyChar == '_') || (e.KeyChar == '-'))
                        {
                            // Se - ou _ (dois valores da mesma tecla, mudados pelo shift)
                            // tenta retroceder um dia na data
                            e.KeyChar = (char)Keys.None;
                            DateTime dt;
                            if (DateTime.TryParse(editingControl.Text, out dt))
                            {
                                dt = dt.AddDays(-1);
                                editingControl.Text = dt.ToString().Substring(0, 10);
                            }
                            e.Handled = true;
                        }
                        else
                        {
                            if (editingControl.Text == editingControl.SelectedText)
                            {
                                editingControl.Text = string.Empty;
                                editingControl.SelectionStart = editingControl.TextLength;
                                editingControl.SelectionLength = 0;
                            }

                            // Valida a data durante a digitação
                            // (permite usar ponto como qualquer separador)
                            char keyChar = e.KeyChar;
                            e.Handled = !Geral.ValidaDigitacaoData(editingControl.Text, ref keyChar, usaHora);
                            if (!e.Handled)
                            {
                                e.KeyChar = keyChar;
                            }
                        }
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void movimentoContaDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            movimentoContaDataGridView.EditingControl.KeyPress -= movimentoContaDataGridView_KeyPress;
            movimentoContaDataGridView.EditingControl.KeyPress += movimentoContaDataGridView_KeyPress;

            // Se a coluna for combobox, força o estilo como DropDown
            if (e.Control is ComboBox cbx)
            {
                cbx.MaxDropDownItems = 10;
                cbx.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }

        private void MovimentoContaDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (movimentoContaDataGridView.IsCurrentRowDirty)
            {
                bool conciliado = false;

                if (movimentoContaDataGridView.CurrentRow.Cells["Conciliacao"].Value != null)
                {
                    switch ((TipoConciliacao)((string)movimentoContaDataGridView.CurrentRow.Cells["Conciliacao"].Value)[0])
                    {
                        case TipoConciliacao.NaoConciliado:
                            conciliado = false;
                            break;
                        case TipoConciliacao.Agendado:
                            conciliado = false;
                            break;
                        case TipoConciliacao.Futuro:
                            conciliado = false;
                            break;
                        case TipoConciliacao.Conciliado:
                            conciliado = true;
                            break;
                        case TipoConciliacao.Reconciliado:
                            conciliado = true;
                            break;
                        default:
                            conciliado = false;
                            break;
                    }
                }

                // Se estiver em conciliação não poderá executar a validação da linha
                if (!conciliado && movimentoContaDataGridView.RowCount > 0 && movimentoContaDataGridView.CurrentRow != null)
                {
                    //if (movimentoContaDataGridView.CurrentRow.Cells["MovimentoContaID"].Value != null)
                    if (true)
                    {
                        if (movimentoContaDataGridView.IsCurrentRowDirty || (int)movimentoContaDataGridView.CurrentRow.Cells["MovimentoContaID"].Value < 0)
                        {
                            DataGridViewRow linha = movimentoContaDataGridView.CurrentRow;

                            // Movimentos gerados pelo sistema não são alterado nunca.
                            if (!(bool)linha.Cells["Sistema"].Value)
                            {
                                MovimentoConta modelo = new MovimentoConta();

                                modelo.MovimentoContaID = (int)linha.Cells["MovimentoContaID"].Value;
                                modelo.UsuarioID = (int)linha.Cells["UsuarioID"].Value;
                                modelo.ContaID = (int)linha.Cells["ContaID"].Value;

                                if (linha.Cells["Data"].Value != DBNull.Value)
                                    modelo.Data = (DateTime)linha.Cells["Data"].Value;
                                else
                                    modelo.Data = null;

                                if (linha.Cells["Numero"].Value != DBNull.Value)
                                    modelo.Numero = (string)linha.Cells["Numero"].Value;
                                else
                                    modelo.Numero = null;

                                if (linha.Cells["LancamentoID"].Value != DBNull.Value)
                                    modelo.LancamentoID = (int)linha.Cells["LancamentoID"].Value;
                                else
                                    modelo.LancamentoID = null;

                                if (linha.Cells["Descricao"].Value != DBNull.Value)
                                    modelo.Descricao = (string)linha.Cells["Descricao"].Value;
                                else
                                    modelo.Descricao = null;

                                if (linha.Cells["CategoriaID"].Value != DBNull.Value)
                                    modelo.CategoriaID = (int)linha.Cells["CategoriaID"].Value;
                                else
                                    modelo.CategoriaID = null;

                                if (linha.Cells["GrupoCategoriaID"].Value != DBNull.Value)
                                    modelo.GrupoCategoriaID = (int)linha.Cells["GrupoCategoriaID"].Value;
                                else
                                    modelo.GrupoCategoriaID = null;

                                if (linha.Cells["CrdDeb"].Value != DBNull.Value)
                                    modelo.CrdDeb = (string)linha.Cells["CrdDeb"].Value;
                                else
                                    modelo.CrdDeb = null;

                                if (linha.Cells["Credito"].Value != DBNull.Value)
                                    modelo.Credito = (decimal)linha.Cells["Credito"].Value;
                                else
                                    modelo.Credito = null;

                                if (linha.Cells["Debito"].Value != DBNull.Value)
                                    modelo.Debito = (decimal)linha.Cells["Debito"].Value;
                                else
                                    modelo.Debito = null;

                                if (modelo.Data != null && modelo.Data <= DateTime.Now)
                                {
                                    if (linha.Cells["Conciliacao"].Value != DBNull.Value)
                                    {
                                        modelo.Conciliacao = (string)linha.Cells["Conciliacao"].Value;
                                    }
                                    else
                                    {
                                        modelo.Conciliacao = null;
                                    }
                                }
                                else
                                {
                                    if (linha.Cells["Conciliacao"].Value != DBNull.Value && (string)linha.Cells["Conciliacao"].Value == "A")
                                    {
                                        // Marca como lançamento AGENDADO.
                                        modelo.Conciliacao = "A";
                                    }
                                    else
                                    {
                                        // Marca como lançamento FUTURO.
                                        modelo.Conciliacao = "F";
                                    }
                                }

                                if (linha.Cells["PilhaMovimentoContaID"].Value != DBNull.Value)
                                    modelo.PilhaMovimentoContaID = (int)linha.Cells["PilhaMovimentoContaID"].Value;
                                else
                                    modelo.PilhaMovimentoContaID = null;

                                if (linha.Cells["DoMovimentoContaID"].Value != DBNull.Value)
                                    modelo.DoMovimentoContaID = (int)linha.Cells["DoMovimentoContaID"].Value;
                                else
                                    modelo.DoMovimentoContaID = null;

                                modelo.Sistema = (bool)linha.Cells["Sistema"].Value;

                                if (movimentoContaDataGridView.CurrentRow.Cells["Observacao"].Value != DBNull.Value)
                                {
                                    modelo.Observacao = (string)movimentoContaDataGridView.CurrentRow.Cells["Observacao"].Value;
                                }
                                else
                                {
                                    modelo.Observacao = null;
                                }

                                MovimentoContaBLL bll = new MovimentoContaBLL();

                                if (bll.Validar(modelo))
                                {
                                    var storedRow = movimentoContaDataGridView.CurrentRow.Index;
                                    var storedCol = movimentoContaDataGridView.CurrentCell.ColumnIndex;

                                    int registro = bll.Gravar(modelo);
                                    CarregarMovimentosContas(IDConta);
                                    Origem.CarregarRolContas();

                                    // Esconde a caixa de observações após a gravação
                                    AlternaExibicaoCaixaObservacao(movimentoContaDataGridView.CurrentRow.Index, true);

                                    movimentoContaDataGridView.CurrentCell = movimentoContaDataGridView.Rows[storedRow].Cells[storedCol];

#if DEBUG
                                    MessageBox.Show("Gravação da linha executada.");
#endif
                                }
                                else
                                {
                                    e.Cancel = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void movimentoContaDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (movimentoContaDataGridView.CurrentRow != null)
            {
                if (e.Value != null)
                {
                    // Se é um movimento já gravado no banco e a sua data não é nula
                    if (((int)movimentoContaDataGridView.Rows[e.RowIndex].Cells["MovimentoContaID"].Value > 0) &&
                        (movimentoContaDataGridView.Rows[e.RowIndex].Cells["Data"].Value != DBNull.Value))
                    {
                        // Captura a data do movimento para colorir as células conforme o período
                        DateTime dataRegistro = (DateTime)movimentoContaDataGridView.Rows[e.RowIndex].Cells["Data"].Value;
                        // Se é movimento futuro (leva em consideração data e hora)
                        bool futuro = dataRegistro > DateTime.Now;

                        // Ou se foi marcado como lançamentos agendado ou futuros

                        futuro = futuro || (string)movimentoContaDataGridView.Rows[e.RowIndex].Cells["Conciliacao"].Value == "A"     // Agendado
                                        || (string)movimentoContaDataGridView.Rows[e.RowIndex].Cells["Conciliacao"].Value == "F";    // Futuro

                        if (futuro)
                        {
                            // Se não há movimentos no futuro o ano de DataMovimento será 1900.
                            // Se não houver movimentos no futuro porém houver movimentos marcados como "A" ou "F", 
                            // utilizará a comparação com 1900 para pintar a linha em verde.
                            if ((dataRegistro.Month == DataMovimento.Month && dataRegistro.Year == DataMovimento.Year) || DataMovimento.Year == 1900)
                            {
                                // Mês atual
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
                            else
                            {
                                // Meses futuros
                                // Pinta de azul claro alternado de azul escuro
                                if ((e.RowIndex % 2) == 0)
                                {
                                    e.CellStyle.BackColor = Color.PowderBlue;
                                }
                                else
                                {
                                    e.CellStyle.BackColor = Color.CadetBlue;
                                }
                            }
                        }
                    }
                    else if ((int)movimentoContaDataGridView.Rows[e.RowIndex].Cells["MovimentoContaID"].Value == -9999)
                    {
                        // Somente as totalizações do resumo de conta corrente apresenta MovimentoContaID = -9999 
                        e.CellStyle.BackColor = Color.Khaki;
                    }

                    if (movimentoContaDataGridView.Columns[e.ColumnIndex].Name.Equals("Observacao"))
                    {
                        DataGridViewCell celula = movimentoContaDataGridView.Rows[e.RowIndex].Cells["Observacao"];

                        if (celula.Value != DBNull.Value)
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
                    else if (movimentoContaDataGridView.Columns[e.ColumnIndex].Name.Equals("Legenda"))
                    {
                        DataGridViewCell celula = movimentoContaDataGridView.Rows[e.RowIndex].Cells["Legenda"];

                        int legenda = (int)celula.Value;

                        e.CellStyle.Font = new Font("WingDings", 9.25F, FontStyle.Regular);
                        char codigochar;
                        switch (legenda)
                        {
                            case 1: // Origem de transferência (pode editar)
                                    // Círculo
                                codigochar = (char)0x6C;
                                e.Value = codigochar.ToString();

                                e.CellStyle.ForeColor = Color.Green;
                                e.CellStyle.SelectionForeColor = Color.Green;
                                celula.ToolTipText = "Origem de transferência";
                                break;
                            case 2: // Destino de transferência (não pode editar)
                                    // Círculo
                                codigochar = (char)0x6C;
                                e.Value = codigochar.ToString();

                                e.CellStyle.ForeColor = Color.Red;
                                e.CellStyle.SelectionForeColor = Color.Red;
                                celula.ToolTipText = "Destino de transferência";
                                break;
                            case 3: // Investimento (só pode editar pela tela de investimento)
                                    // Círculo
                                codigochar = (char)0x6C;
                                e.Value = codigochar.ToString();

                                e.CellStyle.ForeColor = Color.Blue;
                                e.CellStyle.SelectionForeColor = Color.Blue;
                                celula.ToolTipText = "Investimento";
                                break;
                            case 4: // Despesas de investimento (não pode alterar)
                                    // Círculo
                                codigochar = (char)0x6C;
                                e.Value = codigochar.ToString();

                                e.CellStyle.ForeColor = Color.Yellow;
                                e.CellStyle.SelectionForeColor = Color.Yellow;
                                celula.ToolTipText = "Despesa de investimento";
                                break;
                            case 10: // Proveniente de planejamento
                                     // Losango
                                codigochar = (char)0x74;
                                e.Value = codigochar.ToString();

                                e.CellStyle.ForeColor = Color.Black;
                                e.CellStyle.SelectionForeColor = Color.Black;
                                celula.ToolTipText = "Proveniente de planejamento";
                                break;
                            case 11: // Origem de transferência proveniente de planejamento
                                     // Losango
                                codigochar = (char)0x74;
                                e.Value = codigochar.ToString();

                                e.CellStyle.ForeColor = Color.Green;
                                e.CellStyle.SelectionForeColor = Color.Green;
                                celula.ToolTipText = "Origem de transferência proveniente de planejamento";
                                break;
                            case 12: // Destino de transferência proveniente de planejamento
                                     // Losango
                                codigochar = (char)0x74;
                                e.Value = codigochar.ToString();

                                e.CellStyle.ForeColor = Color.Red;
                                e.CellStyle.SelectionForeColor = Color.Red;
                                celula.ToolTipText = "Destino de transferência proveniente de planjemento";
                                break;
                            default: // Demais transações
                                e.CellStyle.ForeColor = Color.White;
                                e.CellStyle.SelectionForeColor = Color.White;
                                e.Value = "";
                                celula.ToolTipText = "";
                                break;
                        }
                    }
                    else if (movimentoContaDataGridView.Columns[e.ColumnIndex].Name.Equals("Conciliacao"))
                    {
                        DataGridViewCell celula = movimentoContaDataGridView.Rows[e.RowIndex].Cells["Conciliacao"];
                        //// Pega o primeiro caracter da string "Conciliacao" e transforma em char
                        //char atual = ((string)e.Value)[0];
                        // Status conterá o tipo reference à conciliação

                        TipoConciliacao status = (TipoConciliacao)((string)e.Value)[0];

                        switch (status)
                        {
                            case TipoConciliacao.NaoConciliado:
                                e.CellStyle.ForeColor = Color.Black;
                                celula.ToolTipText = "";
                                break;
                            case TipoConciliacao.Agendado:
                                e.CellStyle.ForeColor = Color.Magenta;
                                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                                celula.ToolTipText = "Agendado";
                                break;
                            case TipoConciliacao.Futuro:
                                e.CellStyle.ForeColor = Color.Black;
                                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                                celula.ToolTipText = "Futuro";
                                break;
                            case TipoConciliacao.Conciliado:
                                e.CellStyle.ForeColor = Color.Blue;
                                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                                celula.ToolTipText = "Conciliado";
                                break;
                            case TipoConciliacao.Reconciliado:
                                e.CellStyle.ForeColor = Color.Green;
                                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                                celula.ToolTipText = "Reconciliado";
                                break;
                            default:
                                celula.ToolTipText = "";
                                break;
                        }
                    }
                    else if (movimentoContaDataGridView.Columns[e.ColumnIndex].Name.Equals("Valor") ||
                             movimentoContaDataGridView.Columns[e.ColumnIndex].Name.Equals("Balanco"))
                    {
                        try
                        {
                            // verifica se o número é positivo ou negativo
                            decimal valor = (decimal)e.Value;

                            string formato = "#,##0." + new String('0', this.decimais);
                            string fmtTexto = ((decimal)e.Value).ToString(formato);

                            e.Value = fmtTexto;

                            if (Math.Round(valor, decimais) < 0)
                            {
                                e.CellStyle.ForeColor = Color.Red;
                                e.CellStyle.SelectionForeColor = Color.Gold;
                            }
                            else
                            {
                                e.CellStyle.ForeColor = Color.Black;
                                e.CellStyle.SelectionForeColor = SystemColors.HighlightText;
                            }
                        }
                        catch
                        {

                        }
                    }
                    else if (movimentoContaDataGridView.Columns[e.ColumnIndex].Name.Equals("Data") ||
                             movimentoContaDataGridView.Columns[e.ColumnIndex].Name.Equals("Descricao") ||
                             movimentoContaDataGridView.Columns[e.ColumnIndex].Name.Equals("Lancamento") ||
                             movimentoContaDataGridView.Columns[e.ColumnIndex].Name.Equals("Categoria") ||
                             movimentoContaDataGridView.Columns[e.ColumnIndex].Name.Equals("GrupoCategoria"))
                    {
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.SelectionForeColor = SystemColors.HighlightText;

                        if (movimentoContaDataGridView.Rows[e.RowIndex].Cells["Passo"].Value != DBNull.Value)
                        {
                            if ((int)movimentoContaDataGridView.Rows[e.RowIndex].Cells["Passo"].Value >= 2)
                            {
                                // 2 é taxa de câmbio ou de entrada ou de saída
                                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);
                                e.CellStyle.ForeColor = Color.Gray;
                            }
                        }
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Black;
                        e.CellStyle.SelectionForeColor = SystemColors.HighlightText;
                    }
                }
            }
        }

        private void movimentoContaDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (movimentoContaDataGridView.IsCurrentCellDirty && e.FormattedValue != null)
            {
                if ((int)movimentoContaDataGridView.CurrentRow.Cells["MovimentoContaID"].Value != -9999)
                {
                    if (e.ColumnIndex == movimentoContaDataGridView.Columns["Credito"].Index)
                    {
                        // Se estiver na coluna crédito e ela não for nula, coloca nulo no débito
                        if ((string)e.FormattedValue != "")
                        {
                            if (double.TryParse((String)e.FormattedValue, out double credito))
                            {
                                movimentoContaDataGridView.CurrentRow.Cells["Credito"].Value = credito;
                                movimentoContaDataGridView.CurrentRow.Cells["Debito"].Value = DBNull.Value;
                                movimentoContaDataGridView.CurrentRow.Cells["CrdDeb"].Value = "C";
                            }
                        }
                    }
                    else if (e.ColumnIndex == movimentoContaDataGridView.Columns["Debito"].Index)
                    {
                        // Se estivar na coluna débito e ela não for nula, coloca nulo no crédito
                        if ((string)e.FormattedValue != "")
                        {
                            if (double.TryParse((String)e.FormattedValue, out double debito))
                            {
                                movimentoContaDataGridView.CurrentRow.Cells["Credito"].Value = DBNull.Value;
                                movimentoContaDataGridView.CurrentRow.Cells["Debito"].Value = debito;
                                movimentoContaDataGridView.CurrentRow.Cells["CrdDeb"].Value = "D";
                            }
                        }
                    }
                    else if (e.ColumnIndex == movimentoContaDataGridView.Columns["Lancamento"].Index)
                    {
                        // Se a célula atual está em edição
                        if (this.movimentoContaDataGridView.IsCurrentCellInEditMode)
                        {
                            // Capitaliza o conteúdo
                            string conteudo = Geral.Capitaliza((string)e.FormattedValue);
                            // Se o conteúdo não for vazio
                            if (conteudo != string.Empty)
                            {
                                // Passa o conteúdo digitado e retorna seu ID, se não existir, cria e devolve o novo ID.
                                int id = IDdoLancamento(IDUsuario, conteudo);

                                if (id < 0)
                                {
                                    CarregaLancamentos(IDUsuario);
                                }
                                movimentoContaDataGridView.EditingControl.Text = conteudo;

                                if ((int)movimentoContaDataGridView.CurrentRow.Cells["MovimentoContaID"].Value < 0 && id > 0)
                                {
                                    // somente preenche caso seja uma linha nova, pra
                                    // evitar mudar valores de campos já preenchidos.
                                    PreencheComDadosParceiro(id);
                                }
                            }
                            else
                            {
                                e.Cancel = true;
                            }
                        }
                    }
                    else if (e.ColumnIndex == movimentoContaDataGridView.Columns["GrupoCategoria"].Index)
                    {
                        // Se a célula atual está em edição
                        if (this.movimentoContaDataGridView.IsCurrentCellInEditMode)
                        {
                            // Capitaliza o conteúdo
                            string conteudo = Geral.Capitaliza((string)e.FormattedValue);
                            if (conteudo != string.Empty)
                            {
                                // Passa o conteúdo digitado e retorna seu ID, se não existir, cria e devolve o novo ID.
                                int id = IDdaGrupoCategoria(IDUsuario, conteudo);

                                if (id < 0)
                                {
                                    CarregaGrupoCategorias();
                                }
                                movimentoContaDataGridView.EditingControl.Text = conteudo;
                            }
                            else
                            {
                                e.Cancel = true;
                            }
                        }
                    }
                    else if (e.ColumnIndex == movimentoContaDataGridView.Columns["Categoria"].Index)
                    {
                        // Se a célula atual está em edição
                        if (this.movimentoContaDataGridView.IsCurrentCellInEditMode)
                        {
                            // Capitaliza o conteúdo
                            string conteudo = Geral.Capitaliza((string)e.FormattedValue);
                            // Se o conteúdo não for vazio
                            if (conteudo != string.Empty)
                            {
                                // Testa as categorias
                                bool digitacaoOK = Regex.IsMatch(conteudo, @"^[^:\[\]]{1,42}(:?|:[^: \[\]][^:\[\]]{0,42})$");

                                if (digitacaoOK)
                                {
                                    // Passa o conteúdo digitado e retorna seu ID, se não existir, cria e devolve o novo ID.
                                    int id = IDdaCategoria(IDUsuario, conteudo);
                                    // Se for maior que zero, configura um item válido
                                    // Se for igual a zero, configura item inválido
                                    // Se for menor que zero, configura item novo
                                    if (id < 0)
                                    {
                                        CarregaCategorias(IDUsuario);
                                    }

                                    if (id != 0)
                                    {
                                        // coloca o conteúdo encontrado/incluído no combobox
                                        movimentoContaDataGridView.EditingControl.Text = conteudo;
                                    }
                                    else
                                    {
                                        string msg = "Para incluir categoria principal, utiliza o cadastro de categorias.";

                                        MessageBox.Show(msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        // Limpa o campo do conteúdo
                                        movimentoContaDataGridView.CurrentRow.Cells["Categoria"].Value = DBNull.Value;
                                        // Informa que a alteração na célula foi cancelada
                                        e.Cancel = true;
                                    }
                                }
                                else
                                {
                                    // Testa conta de transferência
                                    if (Regex.IsMatch(conteudo, @"^\[[^:\[\]]{0,42}[\]]?$"))
                                    {
                                        e.Cancel = !(IDdaCategoria(IDUsuario, conteudo) > 0);
                                    }
                                    else
                                    {
                                        e.Cancel = true;
                                    }
                                }
                            }
                            else
                            {
                                e.Cancel = true;
                            }
                        }
                    }
                    else if (e.ColumnIndex == movimentoContaDataGridView.Columns["Descricao"].Index)
                    {
                        if (this.movimentoContaDataGridView.IsCurrentCellInEditMode)
                        {
                            //DataGridViewCell cell = this.movimentoContaDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                            string conteudo = Geral.Capitaliza((string)e.FormattedValue);
                            movimentoContaDataGridView.EditingControl.Text = conteudo;
                        }
                    }
                }
            }
        }

        private void PreencheComDadosParceiro(int parceiroID)
        {
            DataGridViewRow linha = movimentoContaDataGridView.CurrentRow;

            MovimentoContaBLL bll = new MovimentoContaBLL();
            bll.RecuperaUltimosDadosParceiro(IDConta, parceiroID, ref linha);
        }

        private int IDdoLancamento(int usuarioID, string conteudo)
        {
            LancamentoBLL bll = new LancamentoBLL();
            return bll.IDdoLancamento(usuarioID, conteudo, true);
        }

        private int IDdaGrupoCategoria(int usuarioID, string conteudo)
        {
            GrupoCategoriaBLL bll = new GrupoCategoriaBLL();
            return bll.IDdoGrupoCategoria(usuarioID, conteudo);
        }

        private int IDdaCategoria(int usuarioID, string conteudo)
        {
            CategoriaBLL bll = new CategoriaBLL();
            return bll.IDdaCategoria(usuarioID, conteudo);
        }

        private void buttonInvestimento_Click(object sender, EventArgs e)
        {
            IncluirMovimentoInvestimento();

            CarregarMovimentosContas(IDConta);
            Origem.CarregarRolContas();
        }

        private void IncluirMovimentoInvestimento()
        {
            // O movimento de investimento é ligado a um movimento de conta
            int movimentoContaID = MovimentoContaBLL.ProximoID;
            fmMovimentosInvestimento form = new fmMovimentosInvestimento(this, IDUsuario, IDConta, movimentoContaID);
            form.ShowDialog();
        }

        private void origemDeTransferênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Movimento gerador da transferência de recursos para outra conta.";
            MessageBox.Show(msg, "Origem de Transferência", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void destinoDeTransferênciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Movimento gerado a partir de transferência de recursos de outra conta.\nSomente a descrição pode ser alterada.";
            MessageBox.Show(msg, "Destino de Transferência", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void investimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Aplicação ou resgate de investimento.\nSomente pode ser alterado pela tela de investimento.";
            MessageBox.Show(msg, "Investimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void despesasDeInvestimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Despesas de aplicação ou resgate de investimento.\nSomente pode ser alterado pela tela de investimento.";
            MessageBox.Show(msg, "Investimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void contextMenuStripLegenda_Opening(object sender, CancelEventArgs e)
        {
            if (TipoDeConta != Tipo.Conta.Investimento)
            {
                investimentoToolStripMenuItem.Visible = false;
                despesasDeInvestimentoToolStripMenuItem.Visible = false;
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            AlterarMovimentoInvestimento();
        }

        private void AlterarMovimentoInvestimento()
        {
            if (movimentoContaDataGridView.CurrentRow != null)
            {
                int movimentoContaID = -1;

                if (movimentoContaDataGridView.CurrentRow.Cells["MovimentoInvestimentoID"].Value != DBNull.Value)
                    movimentoContaID = (int)movimentoContaDataGridView.CurrentRow.Cells["movimentoContaID"].Value;
                else if (movimentoContaDataGridView.CurrentRow.Cells["Legenda"].Value != DBNull.Value)
                    if ((int)movimentoContaDataGridView.CurrentRow.Cells["Legenda"].Value == (int)Tipo.Legenda.Despesas)
                        movimentoContaID = (int)movimentoContaDataGridView.CurrentRow.Cells["DoMovimentoContaID"].Value;

                if (movimentoContaID > 0)
                {
                    // O MovimentoInvestimentoID é ligado a um movimento de conta.
                    fmMovimentosInvestimento form = new fmMovimentosInvestimento(this, IDUsuario, IDConta, movimentoContaID);
                    form.ShowDialog();

                    CarregarMovimentosContas(IDConta);
                    Origem.CarregarRolContas();
                }
            }
        }

        private void movimentoContaDataGridView_BindingContextChanged(object sender, EventArgs e)
        {
            ExibirContadorMovimentacoes();
            PosicionaUltimaLinhaNaoFuturo();
        }

        private void PosicionaUltimaLinhaNaoFuturo()
        {
            // Somente quando a conta for carregada
            if (!iniciado)
            {
                // Posiciona na última linha do grid que não seja um lançamento futuro
                bool procurando = true;
                int lin = movimentoContaDataGridView.Rows.Count - 1;

                while (lin > 1 && procurando)
                {
                    if ((DateTime)movimentoContaDataGridView.Rows[lin].Cells["Data"].Value > DateTime.Now)
                        lin--;
                    else
                        procurando = false;
                }

                int col = Geral.PrimeiraColunaVisivel(movimentoContaDataGridView);

                if (lin >= 0 && col >= 0)
                {
                    movimentoContaDataGridView.CurrentCell = movimentoContaDataGridView.Rows[lin].Cells[col];
                }

                iniciado = true;
            }
        }

        private DateTime PrimeiroDiaFuturo()
        {
            DateTime data = new DateTime(1900, 1, 1);

            bool futuro;

            // Posiciona na última linha do grid que não seja um lançamento futuro
            for (int lin = movimentoContaDataGridView.Rows.Count - 1; lin > 1; lin--)
            {
                switch ((TipoConciliacao)((string)movimentoContaDataGridView.Rows[lin].Cells["Conciliacao"].Value)[0])
                {
                    case TipoConciliacao.Futuro:
                    case TipoConciliacao.Agendado:
                        futuro = true;
                        break;
                    default:
                        futuro = false;
                        break;
                }

                if (futuro || (DateTime)movimentoContaDataGridView.Rows[lin].Cells["Data"].Value > DateTime.Now)
                {
                    data = (DateTime)movimentoContaDataGridView.Rows[lin].Cells["Data"].Value;
                }
                else
                {
                    break;
                }
            }

            return data;
        }

        private void FiltrarPorColuna(string coluna)
        {
            // A variável selecao receberá o endereço do array conforme o nome da coluna
            int[] selecao = null;

            if (coluna == "Categoria")
            {
                selecao = selecaoCategoriaID;
                LimpaArraySelecionados(selecaoCategoriaID);
            }
            else if (coluna == "GrupoCategoria")
            {
                selecao = selecaoGrupoCategoriaID;
                LimpaArraySelecionados(selecaoGrupoCategoriaID);
            }
            else if (coluna == "Lancamento")
            {
                selecao = selecaoLancamentoID;
                LimpaArraySelecionados(selecaoLancamentoID);
            }

            int i = 0;

            int colunaIndex = movimentoContaDataGridView.Columns[coluna].Index;

            if (movimentoContaDataGridView.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cel in movimentoContaDataGridView.SelectedCells)
                {
                    if (cel.ColumnIndex == colunaIndex && i < MAXIMO)
                    {
                        if (cel.Value != DBNull.Value)
                        {
                            selecao[i++] = (int)cel.Value;
                        }
                    }
                }
            }

            if (i > 0)
            {
                CarregarMovimentosContas(this.IDConta);
            }
        }

        private void LimpaArraySelecionados(int[] selecionados)
        {
            for (int i = 0; i < selecionados.Length; i++)
                selecionados[i] = -1;
        }

        private String MontaFiltro()
        {
            String filtro = String.Empty;

            filtro = MontaFiltroCelulasSelecionadas(selecaoLancamentoID, "Lancamento", filtro);
            filtro = MontaFiltroCelulasSelecionadas(selecaoGrupoCategoriaID, "GrupoCategoria", filtro);
            filtro = MontaFiltroCelulasSelecionadas(selecaoCategoriaID, "Categoria", filtro);

            if ((string)contextMenuStripData.Tag == "1")
                filtro = MontaFiltroData(selecaoData, "Data", filtro);

            if (filtro != string.Empty)
                return "AND " + filtro;
            else
                return string.Empty;
        }

        private String MontaFiltroCelulasSelecionadas(int[] selecao, string nomeCampo, string preExistente)
        {
            if (!movimentoContaDataGridView.Columns.Contains(nomeCampo))
                return preExistente;

            String filtro = String.Empty;

            int numeroColuna = movimentoContaDataGridView.Columns[nomeCampo].Index;

            string campo = movimentoContaDataGridView.Columns[numeroColuna].DataPropertyName;

            for (int i = 0; i < selecao.Length && selecao[i] >= 0; i++)
            {
                if (selecao[i] >= 0)
                {
                    if (filtro.Length == 0)
                        filtro = "vmMC." + campo + " IN (" + selecao[i].ToString();
                    else
                        filtro = filtro + ", " + selecao[i].ToString();
                }
            }

            DataGridViewColumn col = movimentoContaDataGridView.Columns[numeroColuna];

            if (filtro.Length != 0)
            {
                filtro = filtro + ")";
                col.HeaderCell.Style.BackColor = Color.Gainsboro;
            }
            else
            {
                col.HeaderCell.Style.BackColor = SystemColors.Control;
            }

            if (filtro != String.Empty)
            {
                TrataCancelarFiltro(nomeCampo, true);

                if (preExistente == String.Empty)
                    return filtro;
                else
                    return preExistente + " AND " + filtro;
            }
            else
            {
                TrataCancelarFiltro(nomeCampo, false);

                return preExistente;
            }
        }

        private string MontaFiltroData(DateTime[] selecaoData, string nomeCampo, string preExistente)
        {
            if (!movimentoContaDataGridView.Columns.Contains(nomeCampo))
                return preExistente;

            int numeroColuna = movimentoContaDataGridView.Columns[nomeCampo].Index;

            string campo = movimentoContaDataGridView.Columns[numeroColuna].DataPropertyName;

            String filtro = campo + " BETWEEN '" + selecaoData[0].ToString("yyyy-MM-dd") + "' AND '" + selecaoData[1].ToString("yyyy-MM-dd") + "'";

            DataGridViewColumn col = movimentoContaDataGridView.Columns[numeroColuna];

            col.HeaderCell.Style.BackColor = Color.Gainsboro;

            if (preExistente == String.Empty)
            {
                return filtro;
            }
            else
            {
                return preExistente + " AND " + filtro;
            }
        }

        private void TrataCancelarFiltro(string nomeCampo, bool liga)
        {
            string valor = Convert.ToInt16(liga).ToString();

            if (nomeCampo == "Categoria")
                contextMenuStripCategoria.Tag = valor;
            else if (nomeCampo == "GrupoCategoria")
                contextMenuStripGrupo.Tag = valor;
            else if (nomeCampo == "Lancamento")
                contextMenuStripLancamento.Tag = valor;
            else if (nomeCampo == "Data")
                contextMenuStripData.Tag = valor;

            iniciado = false;
        }

        #region Trata filtro por grupo de categoria

        private void contextMenuStripGrupo_Opening(object sender, CancelEventArgs e)
        {
            // Item de cancelamento de filtro por grupo somente existe se o grupo está filtrado.
            int tag = 0;

            string txt = (string)contextMenuStripGrupo.Tag;

            if (int.TryParse(txt, out tag))
            {
                cancelarFiltroPeloGrupoToolStripMenuItem.Visible = tag != 0;
            }
        }

        private void filtrarPeloGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltrarPorColuna("GrupoCategoria");
        }

        private void cancelarFiltroPeloGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpaArraySelecionados(selecaoGrupoCategoriaID);
            CarregarMovimentosContas(this.IDConta);
        }

        #endregion Trata filtro por grupo de categoria

        #region Trata filtro por categoria

        private void contextMenuStripCategoria_Opening(object sender, CancelEventArgs e)
        {
            // Item de cancelamento de filtro por categoria somente exibe se a categoria está filtrada.
            int tag = 0;

            string txt = (string)contextMenuStripCategoria.Tag;

            if (int.TryParse(txt, out tag))
            {
                cancelarFiltroPelaCategoriaToolStripMenuItem.Visible = tag != 0;
            }
        }

        private void filtrarPelaCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltrarPorColuna("Categoria");
        }

        private void cancelarFiltroPelaCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpaArraySelecionados(selecaoCategoriaID);
            CarregarMovimentosContas(this.IDConta);
        }

        #endregion Trata filtro por categoria

        #region Trata filtro por lançamento
        private void contextMenuStripParceiro_Opening(object sender, CancelEventArgs e)
        {
            // Item de cancelamento de filtro por parceiro somente exibe se o parceiro está filtrado.
            int tag = 0;

            string txt = (string)contextMenuStripLancamento.Tag;

            if (int.TryParse(txt, out tag))
            {
                cancelarFiltroPeloLancamentoToolStripMenuItem.Visible = tag != 0;
            }
        }

        private void filtrarPeloLancamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltrarPorColuna("Lancamento");
        }

        private void cancelarFiltroPeloLancamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LimpaArraySelecionados(selecaoLancamentoID);
            CarregarMovimentosContas(this.IDConta);
        }

        #endregion Trata filtro por lançamento

        #region Trata filtro por data
        private void contextMenuStripData_Opening(object sender, CancelEventArgs e)
        {
            // Item de cancelamento de filtro por parceiro somente exibe se o parceiro está filtrado.
            int tag = 0;

            string txt = (string)contextMenuStripData.Tag;

            if (int.TryParse(txt, out tag))
            {
                cancelarFiltroPorDataToolStripMenuItem.Visible = tag != 0;
            }
        }

        private void filtrarPorDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltrarPorData("Data");
        }

        private void FiltrarPorData(string coluna)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;

            selecaoData[0] = DateTime.ParseExact("01/01/2100", "d", provider);
            selecaoData[1] = DateTime.ParseExact("01/01/2000", "d", provider);

            int colunaIndex = movimentoContaDataGridView.Columns[coluna].Index;

            if (movimentoContaDataGridView.SelectedCells.Count > 0)
                foreach (DataGridViewCell cel in movimentoContaDataGridView.SelectedCells)
                {
                    if (cel.ColumnIndex == colunaIndex)
                    {
                        if (cel.Value != DBNull.Value)
                        {
                            DateTime data = (DateTime)cel.Value;
                            if (data.CompareTo(selecaoData[0]) < 0)
                            {
                                selecaoData[0] = data;
                            }
                            if (data.CompareTo(selecaoData[1]) > 0)
                            {
                                selecaoData[1] = data;
                            }
                        }
                    }
                }

            // Se a primeira data for menor ou igual à segunda data, o filtro foi feito.
            if (selecaoData[0].CompareTo(selecaoData[1]) <= 0)
            {
                contextMenuStripData.Tag = "1";
                CarregarMovimentosContas(this.IDConta);
            }
        }

        private void cancelarFiltroPorDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            movimentoContaDataGridView.Columns["Data"].HeaderCell.Style.BackColor = SystemColors.Control;
            contextMenuStripData.Tag = "0";
            CarregarMovimentosContas(this.IDConta);
        }

        #endregion Trata filtro por data

        private void contextMenuStripValor_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStripValor.Items.Clear();

            Dictionary<string, decimal> valores = new Dictionary<string, decimal>();

            int colunaGrupo = movimentoContaDataGridView.Columns["GrupoCategoria"].Index;
            int colunaValor = movimentoContaDataGridView.Columns["Valor"].Index;

            if (movimentoContaDataGridView.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cel in movimentoContaDataGridView.SelectedCells)
                {
                    if (cel.ColumnIndex == colunaValor)
                    {
                        if (cel.Value != DBNull.Value)
                        {
                            string grupo = (string)movimentoContaDataGridView.Rows[cel.RowIndex].Cells[colunaGrupo].FormattedValue;

                            if (grupo == String.Empty)
                                grupo = "Não Classificado";

                            decimal valor = (decimal)cel.Value;

                            if (valores.ContainsKey(grupo))
                            {
                                valor += valores[grupo];
                                valores[grupo] = valor;
                            }
                            else
                            {
                                valores.Add(grupo, valor);
                            }
                        }
                    }
                }

                if (valores.Count > 0)
                {
                    decimal total = 0;

                    foreach (var item in valores)
                    {
                        decimal val = item.Value;
                        total += val;
                        string texto = item.Key + ":  " + val.ToString("C2");
                        contextMenuStripValor.Items.Add(texto);
                    }

                    if (valores.Count > 1)
                    {
                        contextMenuStripValor.Items.Add("-");
                        contextMenuStripValor.Items.Add("Total: " + total.ToString("C2"));
                    }
                }
            }
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            IncluirPlanejamento(IDUsuario);
        }

        private void IncluirPlanejamento(int IDUsuario)
        {
            movimentoContaDataGridView.Focus();

            if (movimentoContaDataGridView.CurrentRow != null)
            {
                if ((int)movimentoContaDataGridView.CurrentRow.Cells["MovimentoContaID"].Value > 0)
                {
                    int lancamentoID = (int)movimentoContaDataGridView.CurrentRow.Cells["LancamentoID"].Value;
                    int categoriaID = (int)movimentoContaDataGridView.CurrentRow.Cells["CategoriaID"].Value;
                    int grupoID = -1;

                    if (movimentoContaDataGridView.CurrentRow.Cells["GrupoCategoriaID"].Value != DBNull.Value)
                    {
                        grupoID = (int)movimentoContaDataGridView.CurrentRow.Cells["GrupoCategoriaID"].Value;
                    }

                    decimal valor = Math.Abs((decimal)movimentoContaDataGridView.CurrentRow.Cells["Valor"].Value);
                    string crddeb = (string)movimentoContaDataGridView.CurrentRow.Cells["CrdDeb"].Value;
                    DateTime data = (DateTime)movimentoContaDataGridView.CurrentRow.Cells["Data"].Value;

                    Boolean incluir = true;

                    #region Verificação sobre planejamento
                    // Verifica se já existe planejamento para este lançamento e catoria nesta conta, se já existe, avisa.

                    PlanejamentoBLL bll = new PlanejamentoBLL();
                    Boolean existe = bll.ExistePlanejamento(this.IDConta, lancamentoID, categoriaID);

                    if (existe)
                    {
                        string msg = "Já existe lançamento semelhante para esta conta.\nDeseja incluir mesmo assim?";
                        DialogResult resp = MessageBox.Show(msg, "Atenção",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning,
                                                            MessageBoxDefaultButton.Button2);

                        incluir = resp == DialogResult.Yes;
                    }

                    #endregion Verificação sobre planejamento

                    if (incluir)
                    {
                        fmPlanejamentoManutencao form = new fmPlanejamentoManutencao(IDUsuario, -1, this.IDConta, lancamentoID, categoriaID, grupoID, valor, crddeb, data);
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("Item incluído no planejamento.", "Informação",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void buttonConciliacaoOff_Click(object sender, EventArgs e)
        {
            AlternaModoConciliacao();
        }

        private void buttonConciliacaoOn_Click(object sender, EventArgs e)
        {
            AlternaModoConciliacao();
        }

        private void AlternaModoConciliacao()
        {
            buttonConciliacaoOff.Visible = !buttonConciliacaoOff.Visible;
            buttonConciliacaoOn.Visible = !buttonConciliacaoOn.Visible;
        }

        private void buttonMinimiza_Click(object sender, EventArgs e)
        {
            AlternaModoVisualizacao();
        }

        private void buttonMaximiza_Click(object sender, EventArgs e)
        {
            AlternaModoVisualizacao();
        }

        private void AlternaModoVisualizacao()
        {
            ExibeResumo = !ExibeResumo;

            ContaBLL bll = new ContaBLL();
            bll.AlternarExibicaoResumo(IDConta, ExibeResumo);

            Origem.CarregarRolContas();

            CarregarMovimentosContas(IDConta, true);
        }

        private void movimentoContaDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (movimentoContaDataGridView.CurrentRow != null)
            {
                // Se não for uma linha nula
                if ((string)movimentoContaDataGridView.CurrentRow.Cells["Conciliacao"].Value == "R" ||
                    (string)movimentoContaDataGridView.CurrentRow.Cells["Conciliacao"].Value == "C")
                {
                    // Se o registro estiver marcado como Conciliado ou Reconciliado não poderá ser alterado.
                    e.Cancel = true;
                }
                else if (buttonConciliacaoOn.Visible)
                {
                    // Se estiver em mode de conciliação nada poderá ser alterado. 
                    // (o botão para delisgar o modo fica visível somente qdo em conciliação)
                    e.Cancel = true;
                }
                else
                {
                    // pega o número da coluna corrente
                    int cell = movimentoContaDataGridView.CurrentCell.ColumnIndex;

                    // pega o valor da legenda para decidir o que pode ou não ser alterado.
                    //
                    // se legenda = 0, 1, 10 ou 11, pode alterar qualquer coisa.
                    // Caso contrário pode alterar apenas número e descrição
                    int legenda = (int)movimentoContaDataGridView.CurrentRow.Cells["Legenda"].Value;

                    if (legenda != 0 && legenda != 1 && legenda != 10 && legenda != 11)
                    {
                        // pega o campo de dados associado a coluna
                        string coluna = movimentoContaDataGridView.Columns[cell].Name;

                        if (!(coluna == "Descricao" || coluna == "Numero"))
                        {
                            string msg = null;

                            switch (legenda)
                            {
                                case 2:
                                    msg = "Este movimento é um destino de transferência, somente a descrição pode ser alterada.";
                                    break;
                                case 3:
                                    msg = "Este movimento é um investimento, use a tela investimentos para alterar.";
                                    break;
                                case 4:
                                    msg = "Este movimento é uma despesa de investimento, somente a descrição pode ser alterada.";
                                    break;
                                default:
                                    msg = "Este moviment não pode ser alterado, porém o código do bloqueio não é conhecido.";
                                    break;
                            }

                            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            // Bloqueia a alteração
                            e.Cancel = true;
                        }
                    }
                }
            }
        }

        private void provenienteDePlanejamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Movimento proveniente de planejamento, se colorido é combinação com demais opções disponíveis.";
            MessageBox.Show(msg, "Investimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonCarregarArquivoTXT_Click(object sender, EventArgs e)
        {
            MovimentoContaBLL bll = new MovimentoContaBLL();
            string tipoArquivo = bll.TipoArquivo(IDConta);

            try
            {
                TipoArquivo ta = (TipoArquivo)Enum.Parse(typeof(TipoArquivo), tipoArquivo, true);

                switch (ta)
                {
                    case TipoArquivo.OFX:
                        CarregarConciliacao();
                        break;
                    case TipoArquivo.HitBTC:
                        CarregarArquivoHitBTC();
                        break;
                    default:
                        break;
                }
                CarregaLancamentos(IDUsuario);
                CarregarMovimentosContas(IDConta);
                Origem.CarregarRolContas();
            }
            catch
            {
                MessageBox.Show("Informações sobre carga por arquivo texto não encontradas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CarregarArquivoHitBTC()
        {
            Geral.CarregarArquivoTradeHitBTC();
            Geral.ExecutarMovimentosContaTradeHitBTC(IDUsuario, IDConta);
        }

        private void CarregarConciliacao()
        {
            fmConciliacao form = new fmConciliacao(IDConta, labelTopo.Text);
            form.ShowDialog();
        }

        private void opcaoDetalhesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem origem = sender as ToolStripMenuItem;

            // Esconde o form atual
            this.WindowState = FormWindowState.Minimized;

            string titulo = "Detalhes de " + origem.Text.Replace("[", "").Replace("]", "");

            // Cria o novo form
            fmDetalhesMovimentacao detalhes = null;

            if ((string)origem.Tag == "especificoLancamento")
            {
                int lancamentoID = (int)movimentoContaDataGridView.CurrentRow.Cells["LancamentoID"].Value;

                detalhes = fmDetalhesMovimentacao.CreateInstance(this, titulo, IDUsuario, IDConta, lancamentoID, null, null);
            }
            else if ((string)origem.Tag == "especificoCategoria")
            {
                int categoriaID = (int)movimentoContaDataGridView.CurrentRow.Cells["CategoriaID"].Value;

                detalhes = fmDetalhesMovimentacao.CreateInstance(this, titulo, IDUsuario, IDConta, null, categoriaID, null);
            }
            else if ((string)origem.Tag == "especificoGrupoCategoria")
            {
                int grupoCategoriaID = (int)movimentoContaDataGridView.CurrentRow.Cells["GrupoCategoriaID"].Value;

                detalhes = fmDetalhesMovimentacao.CreateInstance(this, titulo, IDUsuario, IDConta, null, null, grupoCategoriaID);
            }
            else if ((string)origem.Tag == "geralLancamento")
            {
                int lancamentoID = (int)movimentoContaDataGridView.CurrentRow.Cells["LancamentoID"].Value;

                detalhes = fmDetalhesMovimentacao.CreateInstance(this, titulo, IDUsuario, null, lancamentoID, null, null);
            }
            else if ((string)origem.Tag == "geralCategoria")
            {
                int categoriaID = (int)movimentoContaDataGridView.CurrentRow.Cells["CategoriaID"].Value;

                detalhes = fmDetalhesMovimentacao.CreateInstance(this, titulo, IDUsuario, null, null, categoriaID, null);
            }
            else if ((string)origem.Tag == "geralGrupoCategoria")
            {
                int grupoCategoriaID = (int)movimentoContaDataGridView.CurrentRow.Cells["GrupoCategoriaID"].Value;

                detalhes = fmDetalhesMovimentacao.CreateInstance(this, titulo, IDUsuario, null, null, null, grupoCategoriaID);
            }

            this.Detalhes = detalhes;

            // Ajusta o form de detalhes para que seja semelhante ao da movimentação de contas
            AjustaAparenciaDetalhes(detalhes);

            // Exibe
            detalhes.Show();
            detalhes.Focus();
        }

        private void AjustaAparenciaDetalhes(fmDetalhesMovimentacao detalhes)
        {
            // Ajusta o form de detalhes para que seja semelhante ao da movimentação de contas

            // Atribui o MdiParent ao form atual
            detalhes.MdiParent = this.MdiParent;
            // Remove as bordas
            detalhes.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            // Remove os botões (remover todos os botões faz com que o menu do filho não seja fundido (merged))
            detalhes.ControlBox = false;
            detalhes.MaximizeBox = false;
            detalhes.MinimizeBox = false;
            // Desabilita exibição do ícone
            detalhes.ShowIcon = false;
            // Maximiza
            detalhes.WindowState = FormWindowState.Maximized;
            // Remove o título da janela
            detalhes.Text = string.Empty;
            // Preenche o dock
            detalhes.Dock = DockStyle.Fill;
            // Atribui o padding 3;3;3;3 (todos lados iguais)
            detalhes.Padding = new Padding(3);
            // Procura groupbox no formulário
            foreach (Control C1 in detalhes.Controls)
            {
                if (C1 is GroupBox)
                {
                    C1.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                    foreach (Control C2 in C1.Controls)
                    {
                        C2.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    }
                }
                else
                {
                    C1.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                }
            }
        }

        private void contextMenuStripDetalhes_Opening(object sender, CancelEventArgs e)
        {

            e.Cancel = !contextMenuStripDetalhes.Enabled;

            // Apaga itens anteriores
            contextMenuStripDetalhes.Items.Clear();

            // Verifica se há itens sendo exibidos
            if (movimentoContaDataGridView.RowCount > 0)
            {
                // Verifica se há linha atual selecionada
                if (movimentoContaDataGridView.CurrentRow != null)
                {

                    ToolStripMenuItem itemTitulo = new ToolStripMenuItem();

                    itemTitulo.Text = "Pesquisas Disponíveis";
                    itemTitulo.DisplayStyle = ToolStripItemDisplayStyle.Text;
                    itemTitulo.BackColor = Color.DarkGray;
                    itemTitulo.ForeColor = Color.White;
                    itemTitulo.Font = new Font("Segoe UI", 9, FontStyle.Bold);

                    contextMenuStripDetalhes.Items.Add(itemTitulo);

                    //
                    // Pesquisa na conta ativa
                    //

                    // Se o nome do lançamento não for nulo
                    if (movimentoContaDataGridView.CurrentRow.Cells["Lancamento"].Value != DBNull.Value)
                    {
                        ToolStripMenuItem itemLancamento = new ToolStripMenuItem();

                        itemLancamento.DisplayStyle = ToolStripItemDisplayStyle.Text;
                        itemLancamento.Text = (string)movimentoContaDataGridView.CurrentRow.Cells["Lancamento"].FormattedValue + " em " + labelTopo.Text;
                        itemLancamento.Tag = "especificoLancamento";
                        itemLancamento.Click += opcaoDetalhesToolStripMenuItem_Click;

                        contextMenuStripDetalhes.Items.Add(itemLancamento);
                    }

                    // Se o nome da categoria não for nulo
                    if (movimentoContaDataGridView.CurrentRow.Cells["Categoria"].Value != DBNull.Value)
                    {
                        ToolStripMenuItem itemCategoria = new ToolStripMenuItem();

                        itemCategoria.DisplayStyle = ToolStripItemDisplayStyle.Text;
                        itemCategoria.Text = (string)movimentoContaDataGridView.CurrentRow.Cells["Categoria"].FormattedValue + " em " + labelTopo.Text;
                        itemCategoria.Tag = "especificoCategoria";
                        itemCategoria.Click += opcaoDetalhesToolStripMenuItem_Click;

                        contextMenuStripDetalhes.Items.Add(itemCategoria);
                    }

                    // Se o agrupamento não for nulo
                    if (movimentoContaDataGridView.CurrentRow.Cells["GrupoCategoria"].Value != DBNull.Value)
                    {
                        ToolStripMenuItem itemGrupoCategoria = new ToolStripMenuItem();

                        itemGrupoCategoria.DisplayStyle = ToolStripItemDisplayStyle.Text;
                        itemGrupoCategoria.Text = (string)movimentoContaDataGridView.CurrentRow.Cells["GrupoCategoria"].FormattedValue + " em " + labelTopo.Text;
                        itemGrupoCategoria.Tag = "especificoGrupoCategoria";
                        itemGrupoCategoria.Click += opcaoDetalhesToolStripMenuItem_Click;

                        contextMenuStripDetalhes.Items.Add(itemGrupoCategoria);
                    }

                    //
                    // Inclui um separador
                    //

                    ToolStripSeparator separador = new ToolStripSeparator();
                    contextMenuStripDetalhes.Items.Add(separador);

                    //
                    // Pesquisa em todas as contas
                    //

                    // Se o nome do lançamento não for nulo
                    if (movimentoContaDataGridView.CurrentRow.Cells["Lancamento"].Value != DBNull.Value)
                    {
                        ToolStripMenuItem geralLancamento = new ToolStripMenuItem();

                        geralLancamento.DisplayStyle = ToolStripItemDisplayStyle.Text;
                        geralLancamento.Text = (string)movimentoContaDataGridView.CurrentRow.Cells["Lancamento"].FormattedValue + " em todas as contas";
                        geralLancamento.Tag = "geralLancamento";
                        geralLancamento.Click += opcaoDetalhesToolStripMenuItem_Click;

                        contextMenuStripDetalhes.Items.Add(geralLancamento);
                    }

                    // Se o nome da categoria não for nulo
                    if (movimentoContaDataGridView.CurrentRow.Cells["Categoria"].Value != DBNull.Value)
                    {
                        ToolStripMenuItem geralCategoria = new ToolStripMenuItem();

                        geralCategoria.DisplayStyle = ToolStripItemDisplayStyle.Text;
                        geralCategoria.Text = (string)movimentoContaDataGridView.CurrentRow.Cells["Categoria"].FormattedValue + " em todas as contas";
                        geralCategoria.Tag = "geralCategoria";
                        geralCategoria.Click += opcaoDetalhesToolStripMenuItem_Click;

                        contextMenuStripDetalhes.Items.Add(geralCategoria);
                    }

                    // Se o agrupamento não for nulo
                    if (movimentoContaDataGridView.CurrentRow.Cells["GrupoCategoria"].Value != DBNull.Value)
                    {
                        ToolStripMenuItem geralGrupoCategoria = new ToolStripMenuItem();

                        geralGrupoCategoria.DisplayStyle = ToolStripItemDisplayStyle.Text;
                        geralGrupoCategoria.Text = (string)movimentoContaDataGridView.CurrentRow.Cells["GrupoCategoria"].FormattedValue + " em todas as contas";
                        geralGrupoCategoria.Tag = "geralGrupoCategoria";
                        geralGrupoCategoria.Click += opcaoDetalhesToolStripMenuItem_Click;

                        contextMenuStripDetalhes.Items.Add(geralGrupoCategoria);
                    }
                }
            }

            if (contextMenuStripDetalhes.Items.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void movimentoContaDataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            contextMenuStripDetalhes.Enabled = false;

            if (e.Button == MouseButtons.Right)
            {
                int rowSelected = e.RowIndex;
                int colSelected = e.ColumnIndex;

                if (rowSelected > -1 && colSelected > -1)
                {
                    movimentoContaDataGridView.ClearSelection();
                    int i = movimentoContaDataGridView.SelectedRows.Count;

                    if (i > 0)
                    {
                        movimentoContaDataGridView.ClearSelection();
                    }

                    movimentoContaDataGridView.CurrentCell = movimentoContaDataGridView.Rows[rowSelected].Cells[colSelected];

                    contextMenuStripDetalhes.Enabled = true;
                }
            }
        }

        private void fmMovimentosConta_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Como o formulário pode ser destruído ao mudar de conta, clicando-se no painel à esquerda, 
            // é necessário ver se o formário de detalhes existe, caso exista, deve ser fechado.
            if (Detalhes != null)
            {
                Detalhes.Close();
            }
        }

        private void buttonCambio_Click(object sender, EventArgs e)
        {
            IncluirMovimentoCambio();

            CarregarMovimentosContas(IDConta);
            Origem.CarregarRolContas();
        }

        private void IncluirMovimentoCambio()
        {
            // O movimento de câmbio é ligado a um movimento de conta
            // O valor na moeda X saí de uma conta e o valor na moeda Y entra na outra conta
            // É anotado a taxa de câmbio utilizada em CotacaoMoeda.MovimentoContaID
            int movimentoContaID = MovimentoContaBLL.ProximoID;
            using (fmMovimentosCambio form = new fmMovimentosCambio(Origem, this, IDUsuario, IDConta, movimentoContaID))
            {
                form.ShowDialog();
            }
        }

        private void AlterarMovimentoCambio(int movimentoContaID)
        {
            // O movimento de câmbio é ligado a um movimento de conta
            // O valor na moeda X saí de uma conta e o valor na moeda Y entra na outra conta
            // É anotado a taxa de câmbio utilizada em CotacaoMoeda.MovimentoContaID
            using (fmMovimentosCambio form = new fmMovimentosCambio(Origem, this, IDUsuario, IDConta, movimentoContaID))
            {
                form.ShowDialog();
            }
        }

        private void ButtonExibirPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Limpa uma eventual pesquisa anterior
                mcPesquisaBindingSource.DataSource = mcPesquisa;

                mcPesquisa.Clear();
                mcPesquisaBindingSource.ResetBindings(true);

                dateTimePickerDe.Value = Geral.PrimeiroDiaMovimento(IDUsuario);
                dateTimePickerAte.Value = Geral.UltimoDiaMovimento(IDUsuario);

                buttonExibirPesquisa.Visible = false;
                buttonEsconderPesquisa.Visible = !buttonExibirPesquisa.Visible;

                CarregarDadosComboBox(IDConta);

                short tamanho = short.Parse((string)groupBoxPesquisa.Tag);

                for (short i = 0; i <= tamanho; i += 6)
                {
                    groupBoxPesquisa.Height = i;
                    System.Windows.Forms.Application.DoEvents();
                }

                textBoxDescricao.Focus();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void CarregarDadosComboBox(int idConta)
        {
            PesquisaBLL bll = new PesquisaBLL();

            comboBoxParceiro.DataSource = bll.ListarParceirosUsadosNaConta(idConta);
            comboBoxParceiro.SelectedIndex = -1;

            comboBoxCategoria.DataSource = bll.ListarCategoriasUsadosNaConta(idConta);
            comboBoxCategoria.SelectedIndex = -1;

            comboBoxGrupo.DataSource = bll.ListarGruposUsadosNaContas(idConta);
            comboBoxGrupo.SelectedIndex = -1;
        }

        private void ButtonEsconderPesquisa_Click(object sender, EventArgs e)
        {
            mcPesquisa.Filtrado = false;

            buttonEsconderPesquisa.Visible = false;
            buttonExibirPesquisa.Visible = !buttonEsconderPesquisa.Visible;

            short tamanho = (short)groupBoxPesquisa.Height;

            for (int i = tamanho; i >= 0; i -= 6)
            {
                groupBoxPesquisa.Height = i;
                System.Windows.Forms.Application.DoEvents();
            }

            // Ao esconder a barra de pesquisas volta a exibir o grid normal.
            CarregarMovimentosContas(IDConta);

            movimentoContaDataGridView.Focus();
        }

        private void ButtonLimparPesquisa_Click(object sender, EventArgs e)
        {
            // Recarrega o conteúdo dos comboboxes de pesquisa
            CarregarDadosComboBox(IDConta);

            mcPesquisa.Clear();
            mcPesquisaBindingSource.ResetBindings(true);

            dateTimePickerDe.Value = Geral.PrimeiroDiaMovimento(IDUsuario);
            dateTimePickerAte.Value = Geral.UltimoDiaMovimento(IDUsuario);

            textBoxDescricao.Focus();
        }

        private void ButtonEfetuarPesquisa_Click(object sender, EventArgs e)
        {
            if (!mcPesquisa.Vazia())
            {
                mcPesquisa.Filtrado = true;

                mcPesquisa.Subjacente = checkBoxSubjacente.Checked;

                // Efetua carga com os valores indicados na pesquisa
                MovimentoContaBLL mvtoConta = new MovimentoContaBLL();
                movimentoContaBindingSource.DataSource = mvtoConta.ListarConteudoPesquisa(IDConta, mcPesquisa);

                ExibirContadorMovimentacoes(true);

                movimentoContaDataGridView.Focus();
            }
            else
            {
                MessageBox.Show("Preencha ao menos um dos campos de pesquisa.",
                                "Atenção",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void TextBoxValorDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                string regex = "^[+-]?[0-9]{0,12}((,[0-9]{0,2})|())$";

                // Se usar o PONTO, troca por VIRGULA, assim permite usar o teclado numérico.
                if (e.KeyChar == '.')
                {
                    e.KeyChar = ',';
                }

                if (!Regex.IsMatch(((TextBox)sender).Text + e.KeyChar, regex))
                {
                    // não passou pela regex
                    e.Handled = true;
                }
            }
        }

        private void ButtonFluxoEspecifico_Click(object sender, EventArgs e)
        {
            ExibirFluxoEspecifico();
        }

        private void ExibirFluxoEspecifico()
        {
            // Cria uma instância do form de detalhes
            fmMovimentosContaFluxoEspecifico = fmMovimentosContaFluxo.CreateInstance(this, IDUsuario, IDConta, ContaNome);

            // Ajusta a aparência do formulário para que ele se encaixe no lugar do formulário atual 
            Geral.AjustaAparenciaSubForm(this, fmMovimentosContaFluxoEspecifico);

            // Esconde o form atual
            this.WindowState = FormWindowState.Minimized;

            // Exibe o sub form
            fmMovimentosContaFluxoEspecifico.Show();
            fmMovimentosContaFluxoEspecifico.Focus();
        }

        private void AlternaExibicaoCaixaObservacao(int novaLinha, bool esconde = false)
        {
            if (!buttonSoltar.Visible)
            {
                if (panelObservacao.Visible || esconde)
                {
                    for (int i = (int)panelObservacao.Tag; i >= 0; i--)
                    {
                        panelObservacao.Height = i;
                    }
                    panelObservacao.Visible = false;

                    movimentoContaDataGridView.Focus();
                }
                else
                {
                    RecuperarObservacao(novaLinha);

                    // Se o registro for conciliado ou for contra-partirda a observação será ReadOnly
                    textBoxObservacao.ReadOnly = RegistroConciliado(novaLinha) || movimentoContaDataGridView.CurrentRow.Cells["DoMovimentoContaID"].Value != DBNull.Value;

                    panelObservacao.Height = 0;
                    panelObservacao.Visible = true;

                    for (int i = 0; i <= (int)panelObservacao.Tag; i++)
                    {
                        panelObservacao.Height = i;
                        System.Windows.Forms.Application.DoEvents();
                    }

                    if (!textBoxObservacao.ReadOnly)
                    {
                        // Remove a sobrecarga do RowValidating para que não seja executado pelo DataGridView perder o foco.
                        movimentoContaDataGridView.RowValidating -= MovimentoContaDataGridView_RowValidating;
                        textBoxObservacao.Focus();
                        textBoxObservacao.SelectionStart = textBoxObservacao.Text.Length;
                        movimentoContaDataGridView.RowValidating += MovimentoContaDataGridView_RowValidating;
                        textBoxObservacao.BackColor = SystemColors.Window;
                    }
                    else
                    {
                        textBoxObservacao.BackColor = Color.Khaki;
                    }
                }
            }
            else
            {
                RecuperarObservacao(novaLinha);

                // Se o registro for conciliado ou for contra-partirda a observação será ReadOnly
                textBoxObservacao.ReadOnly = RegistroConciliado(novaLinha) || movimentoContaDataGridView.Rows[novaLinha].Cells["DoMovimentoContaID"].Value != DBNull.Value;

                textBoxObservacao.BackColor = textBoxObservacao.ReadOnly ? Color.Khaki : SystemColors.Window;
            }
        }

        private void RecuperarObservacao(int linha)
        {
            if (movimentoContaDataGridView.Rows[linha].Cells["Observacao"].Value != DBNull.Value)
            {
                textBoxObservacao.Text = (string)movimentoContaDataGridView.Rows[linha].Cells["Observacao"].Value;
            }
            else
            {
                textBoxObservacao.Clear();
            }
        }

        #region Trata exibição do text box Observação

        private bool RegistroConciliado(int linha)
        {
            string conciliado = (string)movimentoContaDataGridView.Rows[linha].Cells["Conciliacao"].Value;
            // Conciliado = " " - não é conciliado
            // Conciliado = "A" - lançamento futuro agendado na instituição
            // Conciliado = "F" - lançamento futuro
            // Conciliado = "C" - lançamento é conciliado
            // Conciliado = "R" - lançamento é reconciliado

            return conciliado == "C" || conciliado == "R";
        }

        private void MovimentoContaDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && movimentoContaDataGridView.CurrentRow.Index >= 0)
            {
                AlternaExibicaoCaixaObservacao(movimentoContaDataGridView.CurrentRow.Index);
            }
        }

        private void MovimentoContaDataGridView_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            AlternaExibicaoCaixaObservacao(movimentoContaDataGridView.CurrentRow.Index, true);
        }

        private void TextBoxObservacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                AlternaExibicaoCaixaObservacao(movimentoContaDataGridView.CurrentRow.Index, true);
            }
            else if (e.KeyCode == Keys.Return)
            {
                movimentoContaDataGridView.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                RecuperarObservacao(movimentoContaDataGridView.CurrentRow.Index);
            }
        }

        private void TextBoxObservacao_Leave(object sender, EventArgs e)
        {
            if (movimentoContaDataGridView.CurrentRow.Cells["Observacao"].Value != DBNull.Value)
            {
                // Se o campo no banco de dados não for nulo compara seu conteúdo com o valor digitado/alterado
                if ((string)movimentoContaDataGridView.CurrentRow.Cells["Observacao"].Value != textBoxObservacao.Text.Trim())
                {
                    movimentoContaDataGridView.CurrentRow.Cells["Observacao"].Value = textBoxObservacao.Text.Trim();
                }
            }
            else
            {
                // Se o campo no banco de dados for nulo e o valor digitado/alterado for não nulo
                if (!string.IsNullOrWhiteSpace(textBoxObservacao.Text.Trim()))
                {
                    movimentoContaDataGridView.CurrentRow.Cells["Observacao"].Value = textBoxObservacao.Text.Trim();
                }
            }
            movimentoContaDataGridView.Focus();
        }

        #endregion Trata exibição do text box Observação

        private void MovimentoContaDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (movimentoContaDataGridView.CurrentRow != null && e.RowIndex != movimentoContaDataGridView.CurrentRow.Index)
            {
                AlternaExibicaoCaixaObservacao(e.RowIndex, true);
            }
        }

        private void FmMovimentosConta_Shown(object sender, EventArgs e)
        {
            movimentoContaDataGridView.Focus();
        }

        private void MovimentoContaDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // DataMovimento é utilizado para pintar os lançamentos futuros do
            // mês de verde e dos meses seguintes de azul, a cada recarga do
            // banco de dados é necessário zerar a data para que as linhas
            // sejam pintadas corretamente.
            try
            {
                // Remove a sobrecarga para evitar a chamada recursiva
                movimentoContaDataGridView.DataBindingComplete -= MovimentoContaDataGridView_DataBindingComplete;

                DataMovimento = PrimeiroDiaFuturo();
            }
            finally
            {
                // Recria a sobrecarga
                movimentoContaDataGridView.DataBindingComplete += MovimentoContaDataGridView_DataBindingComplete;
            }
        }

        private void MovimentoContaDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (movimentoContaDataGridView.CurrentCell.ColumnIndex == movimentoContaDataGridView.Columns["Observacao"].Index)
            {
                if (movimentoContaDataGridView.CurrentRow.Cells["Observacao"].Value != DBNull.Value)
                {
                    AlternaExibicaoCaixaObservacao(movimentoContaDataGridView.CurrentRow.Index);
                }
            }
        }

        private void ButtonFixarOuSoltar_Click(object sender, EventArgs e)
        {
            buttonFixar.Visible = !buttonFixar.Visible;
            buttonSoltar.Visible = !buttonFixar.Visible;
        }

        private void MovimentoContaDataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Usa o evento CellMouseMove para sobrescrever a geração do ToolTip
            // Note que o ShowCellToolTips do DataGridView foi desligado para não haver sobreposição dos "esparadrapos"

            string dica = string.Empty;

            if (e.ColumnIndex >= 0 && e.RowIndex == -1)
            {
                dica = movimentoContaDataGridView.Columns[e.ColumnIndex].ToolTipText;
            }
            else if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && !string.IsNullOrWhiteSpace(movimentoContaDataGridView[e.ColumnIndex, e.RowIndex].ToolTipText))
            {
                dica = movimentoContaDataGridView[e.ColumnIndex, e.RowIndex].ToolTipText;
            }
            else if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && movimentoContaDataGridView[e.ColumnIndex, e.RowIndex].Value != DBNull.Value)
            {
                if (movimentoContaDataGridView[e.ColumnIndex, e.RowIndex].ValueType == typeof(string))
                {
                    dica = (string)movimentoContaDataGridView[e.ColumnIndex, e.RowIndex].Value;
                }
            }
            else
            {
                return;
            }

            // verifica se a dica mudou, se não mudou não faz nada para evitar flicker
            if (dica == toolTip.GetToolTip(movimentoContaDataGridView))
            {
                return;
            }

            toolTip.SetToolTip(movimentoContaDataGridView, dica);
        }

        private void movimentoContaDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            var Selecao = (sender as DataGridView).SelectedCells;

            bool invalida = false;

            if (Selecao.Count > 1)
            {
                int colIndex = Selecao[0].ColumnIndex;
                Decimal total = 0;

                for (int cel = 0; cel < Selecao.Count; cel++)
                {
                    // Se for tudo da mesma coluna e a coluna for decimal
                    if ((Selecao[cel].ValueType == Type.GetType("System.Decimal")) && (Selecao[cel].ColumnIndex == colIndex))
                    {
                        if (Selecao[cel].Value != DBNull.Value)
                        {
                            total += (Decimal)Selecao[cel].Value;
                        }
                    }
                    else
                    {
                        invalida = true;
                    }
                }

                if (!invalida)
                {
                    // Colocar as casas decimais de acordo com this.decimais
                    Origem.statusSomatoria.Text = (sender as DataGridView).Columns[colIndex].HeaderText + ": " +
                                                   total.ToString("#,##0." + new String('0', this.decimais));
                    Origem.statusSomatoria.Tag = total;
                }
            }
            else
            {
                invalida = true;
            }

            Origem.statusSomatoria.Visible = !invalida;
        }

        private void movimentoContaDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            Origem.statusSomatoria.Visible = false;
        }
    }
}
