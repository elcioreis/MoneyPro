using BLL;
using Modelos;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MoneyPro
{
    public partial class FmPrincipal : Form
    {
        public ConfiguracaoPrincipal Configuracoes;
        private fmPrevisaoSaldoNegativo formPrevisaoSaldoNegativo;

        private int _userID = 0;
        private string _user = String.Empty;
        private string _nomeAcesso = String.Empty;
        private DateTime dataUltimoBackup;

        public FmPrincipal()
        {
            // Inicializa os componentes do fmPrincipal
            InitializeComponent();

            // Istancia o formulário de login
            fmLogin login = new fmLogin
            {
                // Informa que o fmPrincipal é o proprietário do fmLogin
                Owner = this
            };

            // Exibe o formulário de login como modal
            DialogResult dr = login.ShowDialog();

            // Se a resposta do modal for OK
            if (dr == DialogResult.OK)
            {
                ExibeTitulo();

                // 1 minuto X 60 segundos X 1000 milésimos
                // ou de 10 em 10 minuto
                timerTicker.Interval = 1 * 60 * 1000;
                TimerTicker_Tick(this, null);
                timerTicker.Enabled = true;
            }
        }

        private void ExibeTitulo()
        {
            // Coloca o nome e a versão no projeto no título da janela principal
            this.Text = Geral.Sistema(true);
        }

        public int UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
                if (_userID == 1)
                {
                    // Administrador do Sistema
                    statusUsuario.ForeColor = Color.Yellow;
                    statusUsuario.BackColor = Color.Red;
                }
                else
                {
                    // Todos os outros usuários
                    statusUsuario.ForeColor = Control.DefaultForeColor;
                    statusUsuario.BackColor = Control.DefaultBackColor;
                }

                Boolean isDebugMode = false;

#if DEBUG
                isDebugMode = true;
#endif

                if (Environment.Is64BitProcess)
                {
                    if (!isDebugMode)
                    {
                        statusMaquina.Text = "x64";
                        statusMaquina.ForeColor = Control.DefaultForeColor;
                        statusMaquina.BackColor = Control.DefaultBackColor;
                    }
                    else
                    {
                        statusMaquina.Text = "x64 (Debug)";
                        // Se debug, informa em amarelo sobre vermelho
                        statusMaquina.ForeColor = Color.Yellow;
                        statusMaquina.BackColor = Color.Red;
                    }
                }
                else
                {
                    if (!isDebugMode)
                    {
                        statusMaquina.Text = "x32";
                        statusMaquina.ForeColor = Control.DefaultForeColor;
                        statusMaquina.BackColor = Control.DefaultBackColor;
                    }
                    else
                    {
                        statusMaquina.Text = "x32 (Debug)";
                        // Se debug, informa em amarelo sobre vermelho
                        statusMaquina.ForeColor = Color.Yellow;
                        statusMaquina.BackColor = Color.Red;
                    }
                }

                using (ConfiguracaoPrincipalBLL bll = new ConfiguracaoPrincipalBLL())
                {
                    Configuracoes = bll.CarregarConfiguracaoPrincipal();
                }

                CarregarRolContas();

                Geral.UserID = value;
            }
        }

        internal void PosicionaRolDeContas(int contaID)
        {
            foreach (DataGridViewRow linha in rolContasDataGridView.Rows)
            {
                if ((int)linha.Cells["ContaID"].Value == contaID)
                {
                    rolContasDataGridView.Rows[linha.Index].Cells["Conta"].Selected = true;
                    CarregarContaDoRol();
                    break;
                }
            }
        }

        public void CarregarRolContas()
        {
            int lin = -1;
            int offset = -1;

            if (rolContasDataGridView.RowCount > 0)
            {
                // Armazena o índice para recolocar na mesma posição
                lin = rolContasDataGridView.CurrentRow.Index;
                offset = rolContasDataGridView.FirstDisplayedScrollingRowIndex;
            }

            ContaBLL conta = new ContaBLL();
            rolContasDataGridView.DataSource = conta.RolContas(_userID);

            foreach (DataGridViewColumn col in rolContasDataGridView.Columns)
            {
                if (col.Name == "Conta")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.Visible = true;
                }
                else if (col.Name == "ValorFormatado")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    col.Visible = true;
                }
                else
                {
                    col.Visible = false;
                }
            }

            if (lin >= 0)
            {
                if (offset > 0 && offset < rolContasDataGridView.RowCount)
                {
                    rolContasDataGridView.FirstDisplayedScrollingRowIndex = offset;
                }

                int col = Geral.PrimeiraColunaVisivel(rolContasDataGridView);

                if (col >= 0)
                {
                    rolContasDataGridView.CurrentCell = rolContasDataGridView.Rows[lin].Cells[col];
                }
            }

            toolStripButtonPrevisaoSaldoNegativo.Visible = Geral.ContasQueFicaraoNegativas(_userID, Configuracoes.DiasPrevisaoSaldoNegativo) > 0;
        }

        public string Usuario
        {
            get { return _user; }
            set
            {
                _user = value;
                statusUsuario.Text = _user;
            }
        }

        public string NomeAcesso
        {
            get { return _nomeAcesso; }
            set
            {
                _nomeAcesso = value;
                statusNomeAcesso.Text = _nomeAcesso;
            }
        }

        public DateTime DataUltimoBackup
        {
            get
            {
                return dataUltimoBackup;
            }

            set
            {
                dataUltimoBackup = value;
                statusUltimoBackup.Text = statusUltimoBackup.Text = "Backup em " + dataUltimoBackup.ToString("dd/MM/yyyy HH:mm");

                if ((DateTime.Now - dataUltimoBackup).TotalDays > 10.0)
                {
                    // Se o último backup tiver mais de 10 dias de idade, pinta o box de vermelho.
                    statusUltimoBackup.BackColor = Color.Red;
                    statusUltimoBackup.ForeColor = Color.Yellow;
                }
            }
        }

        public bool Producao
        {
            set
            {
                if (value)
                {
                    // Base de producao
                    statusNomeAcesso.ForeColor = Control.DefaultForeColor;
                    statusNomeAcesso.BackColor = Control.DefaultBackColor;
                }
                else
                {
                    // Banco de desenvolvimento
                    // Se banco de desenvolvimento, informa em amarelo sobre vermelho
                    statusNomeAcesso.ForeColor = Color.Yellow;
                    statusNomeAcesso.BackColor = Color.Red;
                }
            }
        }

        private void FormataFormulario(Form formulario)
        {
            // Fecha todos os outros formulários que podem estar abertos
            FechaOutros(this, formulario);

            // Atribui o MdiParent ao form atual
            formulario.MdiParent = this;

            // Remove as bordas
            formulario.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            // Remove os botões (remover todos os botões faz com que o menu do filho não seja fundido (merged)
            formulario.ControlBox = false;
            formulario.MaximizeBox = false;
            formulario.MinimizeBox = false;
            // Desabilita exibição do ícone
            formulario.ShowIcon = false;
            // Maximiza
            formulario.WindowState = FormWindowState.Maximized;
            // Remove o título da janela
            formulario.Text = string.Empty;
            // Preenche o dock
            formulario.Dock = DockStyle.Fill;
            // Atribui o padding 3;3;3;3 (todos lados iguais)
            formulario.Padding = new Padding(3);
            // Procura groupbox no formulário
            foreach (Control C1 in formulario.Controls)
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
            // Exibe
            formulario.Show();
            formulario.Focus();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //CarregaPainel();
        }

        private void FechaOutros(Form Origem, Form novoForm)
        {
            foreach (Form f in Origem.MdiChildren)
            {
                if (f.Name != novoForm.Name)
                {
                    f.Close();
                }
            }
        }

        private void FechaTodos()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
        }

        private void ExibeFormUsuarios()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmUsuarios newUsuarios = fmUsuarios.CreateInstance();
                FormataFormulario(newUsuarios);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ExibeFormCategorias()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmCategorias newCategorias = fmCategorias.CreateInstance();
                FormataFormulario(newCategorias);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ExibeFormParceiros()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmParceiros newLancamentos = fmParceiros.CreateInstance();
                FormataFormulario(newLancamentos);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ExibeFormContas()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmContas newContas = fmContas.CreateInstance(this, _userID);
                FormataFormulario(newContas);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void RolContasDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CarregarContaDoRol();
        }

        private void CarregarContaDoRol()
        {
            if (rolContasDataGridView.CurrentRow != null)
            {
                if ((bool)rolContasDataGridView.CurrentRow.Cells["Detalhe"].Value)
                {
                    int contaID = (int)rolContasDataGridView.CurrentRow.Cells["ContaID"].Value;
                    string contaNome = (string)rolContasDataGridView.CurrentRow.Cells["Conta"].Value;
                    bool exibirResumo = (bool)rolContasDataGridView.CurrentRow.Cells["ExibirResumo"].Value;
                    int decimais = (int)rolContasDataGridView.CurrentRow.Cells["Decimais"].Value;
                    bool usaHora = (bool)rolContasDataGridView.CurrentRow.Cells["UsaHora"].Value;

                    FechaTodos();

                    fmMovimentosConta movimentoConta = fmMovimentosConta.CreateInstance(this, contaID, contaNome, decimais, usaHora, exibirResumo);

                    if ((bool)rolContasDataGridView.CurrentRow.Cells["Banco"].Value)
                    {
                        movimentoConta.TipoDeConta = Tipo.Conta.Banco;
                    }
                    else if ((bool)rolContasDataGridView.CurrentRow.Cells["Poupanca"].Value)
                    {
                        movimentoConta.TipoDeConta = Tipo.Conta.Poupanca;
                    }
                    else if ((bool)rolContasDataGridView.CurrentRow.Cells["Cartao"].Value)
                    {
                        movimentoConta.TipoDeConta = Tipo.Conta.Cartao;
                    }
                    else if ((bool)rolContasDataGridView.CurrentRow.Cells["Investimento"].Value)
                    {
                        movimentoConta.TipoDeConta = Tipo.Conta.Investimento;
                    }
                    else if ((bool)rolContasDataGridView.CurrentRow.Cells["CDB"].Value)
                    {
                        movimentoConta.TipoDeConta = Tipo.Conta.CDB;
                    }
                    else
                    {
                        movimentoConta.TipoDeConta = Tipo.Conta.Outras;
                    }

                    movimentoConta.ArquivoTXT = (bool)rolContasDataGridView.CurrentRow.Cells["OFX"].Value ||
                                                (bool)rolContasDataGridView.CurrentRow.Cells["CSV"].Value;

                    FormataFormulario(movimentoConta);
                }
            }

            statusSomatoria.Visible = false;
        }

        private void RolContasDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (rolContasDataGridView.CurrentRow != null)
            {
                if (e.Value != null)
                {
                    // Se não for detalhe (é cabeçalho) deixa o nome em negrito
                    if (!(bool)rolContasDataGridView.Rows[e.RowIndex].Cells["Detalhe"].Value)
                    {
                        if ((int)rolContasDataGridView.Rows[e.RowIndex].Cells["Ordem"].Value < 9999)
                        {
                            e.CellStyle.ForeColor = Color.Black;
                            e.CellStyle.BackColor = Color.DarkGray;
                            e.CellStyle.SelectionForeColor = Color.Black;
                            e.CellStyle.SelectionBackColor = Color.DarkGray;
                        }
                        else
                        {
                            e.CellStyle.ForeColor = Color.White;
                            e.CellStyle.BackColor = Color.Black;
                            e.CellStyle.SelectionForeColor = Color.White;
                            e.CellStyle.SelectionBackColor = Color.Black;
                        }

                        // Verifica se está na coluna de nome da conta
                        if (e.ColumnIndex == rolContasDataGridView.Columns["Conta"].Index)
                        {
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        }

                        // Verifica se está na coluna de valores formatados
                        else if (e.ColumnIndex == rolContasDataGridView.Columns["ValorFormatado"].Index)
                        {
                            // Se o valor for negativo, pinta a fonte de vermelho
                            if ((decimal)rolContasDataGridView.Rows[e.RowIndex].Cells["Valor"].Value < 0)
                            {
                                e.CellStyle.ForeColor = Color.Red;
                                e.CellStyle.SelectionForeColor = Color.Red;
                            }
                            else
                            {
                                if ((int)rolContasDataGridView.Rows[e.RowIndex].Cells["Ordem"].Value < 9999)
                                {
                                    // Linhas Gerais
                                    e.CellStyle.ForeColor = Color.Black;
                                    e.CellStyle.SelectionForeColor = Color.Black;
                                }
                                else
                                {
                                    // Total Geral
                                    e.CellStyle.ForeColor = Color.White;
                                    e.CellStyle.SelectionForeColor = Color.White;
                                }
                            }
                        }
                    }
                    else
                    {
                        // Verifica se está na coluna de valores formatados
                        if (e.ColumnIndex == rolContasDataGridView.Columns["ValorFormatado"].Index)
                        {
                            // Se o valor for negativo, pinta a fonte de vermelho
                            if ((decimal)rolContasDataGridView.Rows[e.RowIndex].Cells["Valor"].Value < 0)
                            {
                                e.CellStyle.ForeColor = Color.Red;
                                e.CellStyle.SelectionForeColor = Color.Gold;
                            }
                            else
                            {
                                e.CellStyle.ForeColor = Color.Black;
                                e.CellStyle.SelectionForeColor = Color.White;
                            }
                        }
                    }
                }
            }
        }

        private void PictureBoxCategoria_Click(object sender, EventArgs e)
        {
            ExibeFormCategorias();
        }

        private void PictureBoxContas_Click(object sender, EventArgs e)
        {
            ExibeFormContas();
        }

        private void PictureBoxParceiros_Click(object sender, EventArgs e)
        {
            ExibeFormParceiros();
        }

        private void PictureBoxUsuarios_Click(object sender, EventArgs e)
        {
            ExibeFormUsuarios();
        }

        private void ToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            // Muda a forma do ToolTip ser exibido na tela
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void PictureBoxInvestimentos_Click(object sender, EventArgs e)
        {
            ExibeFormInvestimentos();
        }

        private void ExibeFormInvestimentos()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmInvestimentos newInvestimento = fmInvestimentos.CreateInstance();
                FormataFormulario(newInvestimento);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void PictureBoxCarteira_Click(object sender, EventArgs e)
        {
            ExibeFormCarteira();
        }

        private void ExibeFormCarteira()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmCarteira newCarteira = fmCarteira.CreateInstance(_userID);
                FormataFormulario(newCarteira);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void PictureBoxSaldoFuturo_Click(object sender, EventArgs e)
        {
            ExibeFormSaldoFuturo();
        }

        private void ExibeFormSaldoFuturo()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmSaldoFuturo newSaldoFuturo = fmSaldoFuturo.CreateInstance(_userID);
                FormataFormulario(newSaldoFuturo);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void PictureBoxPainel_Click(object sender, EventArgs e)
        {
            ExibeFormPainel();
        }

        private void ExibeFormPainel()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmPainel newPainel = fmPainel.CreateInstance();
                FormataFormulario(newPainel);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #region Teclado

        private Tipo.VariacaoTeclado _variacao;

        public Tipo.VariacaoTeclado Variacao
        {
            get
            {
                return _variacao;
            }

            set
            {
                _variacao = value;

                switch (_variacao)
                {
                    case Tipo.VariacaoTeclado.Nenhuma:
                        panelCarteira.BackColor = Color.WhiteSmoke;
                        panelOrcamento.BackColor = Color.WhiteSmoke;
                        break;
                    case Tipo.VariacaoTeclado.Carteira:
                        panelOrcamento.BackColor = Color.WhiteSmoke;
                        panelCarteira.BackColor = Color.Gold;
                        break;
                    case Tipo.VariacaoTeclado.Orcamento:
                        panelCarteira.BackColor = Color.WhiteSmoke;
                        panelOrcamento.BackColor = Color.Gold;
                        break;
                    default:
                        break;
                }
            }
        }

        private void FmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (formPrevisaoSaldoNegativo != null)
                {
                    formPrevisaoSaldoNegativo.Close();
                }
            }

            if (Variacao == Tipo.VariacaoTeclado.Nenhuma)
            {
                if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
                {
                    // Se Ctrl+K
                    Variacao = Tipo.VariacaoTeclado.Carteira;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
                {
                    // Se Ctrl+O
                    Variacao = Tipo.VariacaoTeclado.Orcamento;
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.F6)
                {
                    // Verifica se há conexão de rede disponível
                    if (Geral.InternetGetConnectedState(out int desc, 0))
                    {
                        // Se teclado F6, processa apenas o último lote disponível
                        // Se teclado Ctrl+F6, processa todos lotes necessários
                        using (fmDownloadCotacoes processamento = new fmDownloadCotacoes(this, e.Modifiers == Keys.Control))
                        {
                            processamento.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não há conexão de rede disponível.", "Atenção",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    e.Handled = true;
                }
                else if (e.Modifiers == (Keys.Control | Keys.Shift) && e.KeyCode == Keys.B)
                {
                    // Se teclado Ctrl + Shift + B 
                    PictureBoxBackup_Click(sender, null);
                    e.Handled = true;
                }
                else if (e.Modifiers == (Keys.Control | Keys.Shift) && e.KeyCode == Keys.T)
                {
                    // Se teclado Ctrl + Shift + T tentará acessar as trades

                    // Verifica se há conexão de rede disponível
                    if (Geral.InternetGetConnectedState(out int desc, 0))
                    {
                        using (Rotinas.AcessoHitBTC acessoHitBTC = new Rotinas.AcessoHitBTC(this, _userID))
                        {
                            acessoHitBTC.CarregarTrades();
                        }
                    }
                }
                else if (e.Modifiers == (Keys.Control | Keys.Shift) && e.KeyCode == Keys.D)
                {
                    // Se teclado Ctrl + Shift + D

                    // Verifica se há conexão de rede disponível
                    if (Geral.InternetGetConnectedState(out int desc, 0))
                    {
                        using (Rotinas.AcessoHitBTC acessoHitBTC = new Rotinas.AcessoHitBTC(this, _userID))
                        {
                            acessoHitBTC.CarregarCandles(HitBTCTiposEnum.period.D1);
                        }
                    }
                }
            }
            else if (Variacao == Tipo.VariacaoTeclado.Carteira)
            {
                switch (e.KeyCode)
                {
                    case Keys.D:
                        ExibirFormCarteiraVariacaoDiaria();
                        e.Handled = true;
                        break;
                    case Keys.M:
                        ExibirFormCarteiraVariacaoMensal();
                        e.Handled = true;
                        break;
                    case Keys.U:
                        ExibirFormCarteiraVariacaoDezDiasUteis();
                        e.Handled = true;
                        break;
                    default:
                        break;
                }
                Variacao = Tipo.VariacaoTeclado.Nenhuma;
            }
            else if (Variacao == Tipo.VariacaoTeclado.Orcamento)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                        ExibirFormFluxoCaixaCredito();
                        e.Handled = true;
                        break;
                    case Keys.D:
                        ExibirFormOrcamentoDiario();
                        e.Handled = true;
                        break;
                    case Keys.F:
                        ExibirFormFluxoCaixaDisponivel();
                        e.Handled = true;
                        break;
                    case Keys.M:
                        ExibirFormOrcamentoMensal();
                        e.Handled = true;
                        break;
                    case Keys.P:
                        ExibirFormPagamentoCartaoCredito();
                        e.Handled = true;
                        break;

                    default:
                        break;
                }
                Variacao = Tipo.VariacaoTeclado.Nenhuma;
            }
            else
            {
                Variacao = Tipo.VariacaoTeclado.Nenhuma;
                e.Handled = true;
            }
        }

        #endregion Teclado

        private void FmPrincipal_Show(object sender, EventArgs e)
        {
            if (Configuracoes != null)
                panelEsquerdo.Width = Configuracoes.PanelEsquerdoWidth;
        }


        private void PictureBoxPlanejamento_Click(object sender, EventArgs e)
        {
            ExibeFormPlanejamento();
        }

        private void ExibeFormPlanejamento()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmPlanejamento newPlanejamento = fmPlanejamento.CreateInstance(this, _userID);
                FormataFormulario(newPlanejamento);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void FmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resp = MessageBox.Show("Deseja fechar o MoneyPro?", Geral.Sistema(true), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = resp == DialogResult.No;
        }

        private void PictureBoxCVM_Click(object sender, EventArgs e)
        {
            // Carrega tela de cotações
            using (fmDownloadCotacoes processamento = new fmDownloadCotacoes(this, true))
            {
                processamento.ShowDialog();
            }
        }

        private void PictureBoxBackup_Click(object sender, EventArgs e)
        {
            // Executa o backup
            ConfiguracaoBLL bll = new ConfiguracaoBLL();

            // O caminho da gravação do backup está em MoneyPro.CaminhoBackup
            //bll.NovoCaminhoBackup(@"C:\Users\Elcio\Dropbox\Backup");
            string retorno = bll.ExecutaBackup(NomeAcesso);

            if (String.IsNullOrEmpty(retorno))
            {
                bll.LimparTickers();
                bll.AtualizaDataBackup();
                MessageBox.Show("Backup efetuado com sucesso.", Geral.Sistema(true));
                DataUltimoBackup = Geral.UltimoBackupEfetuado();

                if (!bll.TruncarArquivoLogSQLServer())
                {
                    MessageBox.Show("Problemas ao tentar truncar o arquivo de log do SQL Server.\n" + retorno, Geral.Sistema(true));
                }
            }
            else
            {
                MessageBox.Show("Problemas ao efetuar o backup.\n" + retorno, Geral.Sistema(true));
            }
        }

        private void Splitter_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Configuracoes.PanelEsquerdoWidth = panelEsquerdo.Width;

            ArmazenarConfiguracao();
        }

        public void ArmazenarConfiguracao()
        {
            ConfiguracaoPrincipalBLL bll = new ConfiguracaoPrincipalBLL();
            bll.ArmazenarConfiguracaoPrincipal(Configuracoes);
        }

        private void PictureBoxPesquisar_Click(object sender, EventArgs e)
        {
            ExibeFormPesquisa();
        }

        private void ExibeFormPesquisa()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmPesquisa newPesquisa = fmPesquisa.CreateInstance(this, _userID);
                FormataFormulario(newPesquisa);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void PictureBoxAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (rolContasDataGridView.CurrentRow != null)
                {
                    if ((bool)rolContasDataGridView.CurrentRow.Cells["Detalhe"].Value)
                    {
                        int contaID = (int)rolContasDataGridView.CurrentRow.Cells["ContaID"].Value;
                        ContaBLL bll = new ContaBLL();
                        bll.AtualizaBalancoConta(contaID);

                        CarregarContaDoRol();
                    }
                }

                CarregarRolContas();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void StatusUltimoBackup_DoubleClick(object sender, EventArgs e)
        {
            string caminho = Geral.CaminhoBackup();
            System.Diagnostics.Process.Start("Explorer", caminho);
        }

        private void PictureBoxOrcamento_Click(object sender, EventArgs e)
        {
            contextMenuStripOrcamento.Show(MousePosition);
        }

        public void ExibirFormOrcamentoDiario()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmOrcamentoDiario fmOrcamentoDiario = fmOrcamentoDiario.CreateInstance(this, _userID);
                FormataFormulario(fmOrcamentoDiario);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void ExibirFormOrcamentoMensal()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmOrcamentoMensal fmOrcamentoMensal = fmOrcamentoMensal.CreateInstance(this, _userID);
                FormataFormulario(fmOrcamentoMensal);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void ExibirFormCarteiraVariacaoDiaria()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmCarteiraVariacaoDiaria fmCarteiraVariacaoDiaria = fmCarteiraVariacaoDiaria.CreateInstance(this, _userID);
                FormataFormulario(fmCarteiraVariacaoDiaria);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void ExibirFormCarteiraVariacaoMensal()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmCarteiraVariacaoMensal fmCarteiraVariacaoMensal = fmCarteiraVariacaoMensal.CreateInstance(this, _userID);
                FormataFormulario(fmCarteiraVariacaoMensal);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void ExibirFormCarteiraVariacaoDezDiasUteis()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fmCarteiraVariacaoUltimosDiasUteis fmCarteiraVariacaoDezDiasUteis = fmCarteiraVariacaoUltimosDiasUteis.CreateInstance(this, _userID);
                FormataFormulario(fmCarteiraVariacaoDezDiasUteis);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void OrcamentoDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirFormOrcamentoDiario();
        }

        private void OrcamentoMensalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirFormOrcamentoMensal();
        }

        private void FluxoDeCaixaDisponívelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirFormFluxoCaixaDisponivel();
        }

        private void FluxoDeCaixaCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirFormFluxoCaixaCredito();
        }

        private void PagamentoCartaoDeCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirFormPagamentoCartaoCredito();
        }

        private void ExibirFormFluxoCaixaDisponivel()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                FechaTodos();

                fmMovimentosContaFluxoDisponivel form = fmMovimentosContaFluxoDisponivel.CreateInstance(this, _userID, Tipo.TipoFluxoCaixa.Disponivel);
                FormataFormulario(form);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ExibirFormFluxoCaixaCredito()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                FechaTodos();

                fmMovimentosContaFluxoDisponivel form = fmMovimentosContaFluxoDisponivel.CreateInstance(this, _userID, Tipo.TipoFluxoCaixa.Credito);
                FormataFormulario(form);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ExibirFormPagamentoCartaoCredito()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                FechaTodos();

                fmPagamentoCartaoCredito form = fmPagamentoCartaoCredito.CreateInstance(this, _userID);
                FormataFormulario(form);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void ToolStripButtonSaldoNegativo_Click(object sender, EventArgs e)
        {
            FechaPrevisaoSaldoNegativo();

            Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
            // Diferença entra a área de exibição e a área da janela principal
            // A linha abaixo encontra o tamanho do cabeçalho da Janela do Windows
            // int dif_Y = screenRectangle.Top - this.Top;

            int X = screenRectangle.Left + 1;
            int Y = screenRectangle.Top + screenRectangle.Height;

            formPrevisaoSaldoNegativo = new fmPrevisaoSaldoNegativo(this, _userID, Configuracoes.DiasPrevisaoSaldoNegativo, X, Y);
            formPrevisaoSaldoNegativo.Show();

            this.Focus();
        }

        private void FmPrincipal_Resize(object sender, EventArgs e)
        {
            AtualizaPosicaoJanelaSaldo();
        }

        private void FmPrincipal_Move(object sender, EventArgs e)
        {
            AtualizaPosicaoJanelaSaldo();
        }

        private void AtualizaPosicaoJanelaSaldo()
        {
            if (formPrevisaoSaldoNegativo != null)
            {
                Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);

                int X = screenRectangle.Left + 1;
                int Y = screenRectangle.Top + screenRectangle.Height;

                formPrevisaoSaldoNegativo.Posiciona(X, Y);
            }
        }

        private void FechaPrevisaoSaldoNegativo()
        {
            if (formPrevisaoSaldoNegativo != null)
            {
                formPrevisaoSaldoNegativo.Close();
                formPrevisaoSaldoNegativo = null;
            }
        }

        #region Ticker e Trader do HitBTC

        private void TimerTicker_Tick(object sender, EventArgs e)
        {
            /////#if !DEBUG
            if (!backgroundWorkerTicker.IsBusy)
            {
                backgroundWorkerTicker.RunWorkerAsync();
            }
            /////#endif
        }

        private void TimerAtualizarRolContas_Tick(object sender, EventArgs e)
        {
            // A execução desse Timer é a cada 500 milisegundos, porém ela roda vazia a maior parte do tempo.
            // Quando BackgroundWorkerTicker_RunWorkerCompleted é executado é feita a carga do método
            // TimerAtualizarRolContas_Tick para esse Timer, que, ao executar, já o remove para que não seja 
            // executado novamente até que o BackgroundWorker termine...  Ad infinitum
            timerAtualizarRolContas.Tick -= TimerAtualizarRolContas_Tick;
            CarregarRolContas();
        }

        private void ToolStripStatusMensagem_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusMensagem.Visible = !string.IsNullOrEmpty(toolStripStatusMensagem.Text);
        }

        private void BackgroundWorkerTicker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {

                if (Geral.InternetGetConnectedState(out int desc, 0))
                {
                    using (Rotinas.AcessoHitBTC acessoHitBTC = new Rotinas.AcessoHitBTC(this, _userID))
                    {
                        // Carrega possíveis trades executadas no HitBTC
                        acessoHitBTC.CarregarTrades();
                        // Coleta o Ticker do HitBTC para registrar o valor das moedas
                        acessoHitBTC.CarregarTicker();
                    }
                    toolStripStatusMensagem.Text = string.Empty;
                    toolStripStatusMensagem.ToolTipText = string.Empty;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusMensagem.Text = "Erro na Carga de Trades";
                toolStripStatusMensagem.ToolTipText = ex.Message;
            }
        }

        private void BackgroundWorkerTicker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            // Após terminar de rodar o processo em background, habilita a execução da atualização do Rol de Contas
            timerAtualizarRolContas.Tick += TimerAtualizarRolContas_Tick;
        }

        #endregion Ticker e Trader do HitBTC

        private void statusSomatoria_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(statusSomatoria.Tag.ToString());
        }
    }
}
