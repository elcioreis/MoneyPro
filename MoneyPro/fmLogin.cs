using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MoneyPro.Properties;
using MoneyPro.Rotinas;
using DAL;

namespace MoneyPro
{
    public partial class fmLogin : Form
    {
        private string _arquivo;
        private Dictionary<string, string> _acessos = new Dictionary<string,string>();
        public fmLogin()
        {
            InitializeComponent();

            lblIdentificacao.Text = Geral.Sistema(true);

            // O arquivo será procurado na mesma pasta do executável.
            _arquivo = Geral.LocalArquivo("DBA");

            CarregaAcessos();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            // Desistiu de entrar
            Application.Exit();
        }

        private void CarregaAcessos()
        {
            // Lê o arquivo MoneyPro.dba e popula o combobox com os possíveis acessos já criados.
            // (dba - data base access)

            // Remove todos os itens do dicionário de acessos
            _acessos.Clear();

            // Remove qualquer item previamente existido;
            comboAcesso.Items.Clear();

            if (File.Exists(_arquivo))
            {
                using (StreamReader sr = new StreamReader(_arquivo))
                {
                    string linha = sr.ReadLine();
                    string nome = String.Empty;
                    string conexao = String.Empty;
                    int pos = -1;

                    while (linha != null)
                    {
                        // Linhas em branco serão ignoradas
                        // Linhas iniciadas com // serão ignoradas
                        if (linha.Length > 2 && linha.Substring(0, 2) != @"//")
                        {
                            pos = linha.IndexOf(":");

                            // Somente serão tratadas as linha iniciadas por "Nome=" e que tem 'dois pontos'
                            if (linha.IndexOf("Nome=") == 0 && pos >= 0)
                            {
                                nome = linha.Substring(5, pos - 5);

                                conexao = linha.Substring(pos + 1, linha.Length - (pos + 1));

                                _acessos.Add(nome, Dados.CriptografaConexao(conexao));
                                comboAcesso.Items.Add(nome);
                            }
                        }

                        linha = sr.ReadLine();
                    }
                };
            }
            else
            {
                MessageBox.Show("Arquivo de configurações de conexões não encontrado.\n"+
                                "("+_arquivo+")",
                                "Erro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (comboAcesso.SelectedIndex >= 0)
            {
                string item = (string)comboAcesso.SelectedItem;
                // Armazena a string de conexão na propriedade estática, assim todas conexões poderão usar.
                Dados.Conexao = _acessos[item];

                int userID = Geral.NumeroUsuario(txtUsuario.Text, Geral.CriptografaSenha(txtSenha.Text));

                if (userID > 0)
                {
                    string _usuario = txtUsuario.Text;
                    string _acesso = comboAcesso.Text;
                    bool _producao = Geral.BaseTrabalho();
                    DateTime _ultimoBackup = Geral.UltimoBackupEfetuado();

                    // Avisa se estiver usando o ambiente de produção dentro do Visual Studio ou
                    // Avisa se estiver usando o ambiente de desenvolvimento fora do Visual Studio.

                    bool ExecutandoNaIDE = false; ///  System.Diagnostics.Debugger.IsAttached;

                    if (ExecutandoNaIDE && _producao)
                    {
                        MessageBox.Show("Usando base de produção no ambiente de desenvolvimento.", "Atenção",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    if (!ExecutandoNaIDE && !_producao)
                    {
                        MessageBox.Show("Usando base de desenvolvimento.", "Atenção", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    ((FmPrincipal)this.Owner).UserID = userID;
                    ((FmPrincipal)this.Owner).Usuario = _usuario;
                    ((FmPrincipal)this.Owner).NomeAcesso = _acesso;
                    ((FmPrincipal)this.Owner).Producao = _producao;
                    ((FmPrincipal)this.Owner).DataUltimoBackup = _ultimoBackup;

                    // Se não é para gravar os campos da tela de login
                    if (!chkLembrarUsuario.Checked)
                    {
                        Settings.Default.Reset();
                    }
                    else
                    {
                        //Settings.Default.Reset();
                        Settings.Default.txtUsuario = _usuario;
                        Settings.Default.comboAcesso = _acesso;
                        Settings.Default.chkLembrarUsuario = true;
                        Settings.Default.Save();
                    }
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show("Selecione o acesso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboAcesso.Focus();
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnAcessos_Click(object sender, EventArgs e)
        {
            fmDatabaseAccess databaseAccess = new fmDatabaseAccess(ref _acessos);

            DialogResult rd = databaseAccess.ShowDialog();

            if (rd == DialogResult.OK)
            {
                //StringBuilder linha = new StringBuilder();
                string linha = null;

                // DONE Gravar arquivo de acessos (MoneyPro.DBA)
                using (StreamWriter sr = new StreamWriter(_arquivo))
                {
                    sr.WriteLine("// Strings de conexão do Money Pro");
                    sr.WriteLine("// Não altere este arquivo manualmente");        
                    sr.WriteLine();
                    
                    foreach (var item in _acessos)
                    {
                        linha = "Nome=" + item.Key + ":" + Dados.CriptografaConexao(item.Value);
                        sr.WriteLine(linha);
                    }
                }
            }

            // Se o arquivo foi regravado é necessário recarregar o contéudo.
            // Se o arquivo não foi regravado, recarrega pra evitar utilizar alterações não gravadas.
            CarregaAcessos();
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            Geral.Capitaliza(txtUsuario);
        }

        private void tableLayoutPanel_Enter(object sender, EventArgs e)
        {
            // Se o nome já vier carregado (opção salvar ligada)
            // coloca o foco diretamente na senha.
            if (!String.IsNullOrEmpty(txtUsuario.Text))
            {
                txtSenha.Focus();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            VerificarInstanciaSQL assinc = new VerificarInstanciaSQL();

            AsyncMethodCaller chamador = new AsyncMethodCaller(assinc.Verificar);

            string mensagem = (string)chamador.DynamicInvoke();
            
            if (!string.IsNullOrEmpty(mensagem))
            {
                MessageBox.Show(mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Application.Exit();
            }
        }
    }
}

