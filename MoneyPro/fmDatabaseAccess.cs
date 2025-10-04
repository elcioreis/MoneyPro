using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MoneyPro
{
    public partial class fmDatabaseAccess : Form
    {
        private Dictionary<string, string> _acessos = null;
        public fmDatabaseAccess(ref Dictionary<string, string> acessos)
        {
            this._acessos = acessos;

            InitializeComponent();

            ExibeAcessos();
        }

        private void ExibeAcessos()
        {
            lbxAcessos.Items.Clear();
            foreach (var item in _acessos)
            {
                lbxAcessos.Items.Add(item.Key);
            }

            CorPadraoNoTextBox();
        }

        private void CorPadraoNoTextBox()
        {
            // Acerta a cor de todos os componentes textbox.
            // Processa todos os controles do tableLayoutPanel,
            // se for textbox, bota a cor SystemColors.Windows.
            foreach (var item in tableLayoutPanel.Controls)
            {
                if (item is TextBox)
                    (item as TextBox).BackColor = SystemColors.Window;
            }
        }

        private void lbxAcessos_Click(object sender, EventArgs e)
        {
            if (lbxAcessos.SelectedIndex >= 0)
            {
                CarregaCampos();
            }
        }

        private void CarregaCampos()
        {
            CorPadraoNoTextBox();

            int inicio = 0;
            int pos = 0;

            StringBuilder texto = new StringBuilder(_acessos[lbxAcessos.Text]);

            if (texto.Length > 0)
            {
                // O nome vem do list box
                txtNome.Text = lbxAcessos.Text;
                txtNome.Tag = txtNome.Text;

                //Data Source=MCFARLANE\SQL2012;
                //Initial Catalog=MoneyPro;
                //User ID=SA;
                //Password=senhaqualquer;
                //Application Name=MoneyPro;
                //MultipleActiveResultSets=True;
                //Connect Timeout=60;

                // Respeitar a ordem
                // DataSource > Initial Catalog > UserID > Password > Aplicação

                // Pega o DataSource
                inicio = texto.ToString().IndexOf("=") + 1;
                pos = texto.ToString().IndexOf(";");
                txtDataSource.Text = texto.ToString().Substring(inicio, pos - inicio);
                txtDataSource.Tag = txtDataSource.Text;
                texto.Remove(0, pos + 1);

                // Pega o Initial Catalog
                inicio = texto.ToString().IndexOf("=") + 1;
                pos = texto.ToString().IndexOf(";");
                txtInitialCatalog.Text = texto.ToString().Substring(inicio, pos - inicio);
                txtInitialCatalog.Tag = txtInitialCatalog.Text;
                texto.Remove(0, pos + 1);

                // Pega o userID
                inicio = texto.ToString().IndexOf("=") + 1;
                pos = texto.ToString().IndexOf(";");
                txtUserID.Text = texto.ToString().Substring(inicio, pos - inicio);
                txtUserID.Tag = txtUserID.Text;
                texto.Remove(0, pos + 1);

                // Pega a senha
                inicio = texto.ToString().IndexOf("=") + 1;
                pos = texto.ToString().IndexOf(";");
                txtPassword.Text = texto.ToString().Substring(inicio, pos - inicio);
                txtPassword.Tag = txtPassword.Text;
                texto.Remove(0, pos + 1);

                // Pega a aplicação
                inicio = texto.ToString().IndexOf("=") + 1;
                pos = texto.ToString().IndexOf(";");
                txtAplicacao.Text = texto.ToString().Substring(inicio, pos - inicio);
                txtAplicacao.Tag = txtAplicacao.Text;
                texto.Remove(0, pos + 1);
            }
            else
            {
                LimpaCamposTexto();
            }
        }

        private void LimpaCamposTexto(bool todos = false)
        {
            if (todos)
            {
                txtNome.Text = String.Empty;
                txtNome.Tag = null;
            }

            txtDataSource.Text = String.Empty;
            txtDataSource.Tag = null;
            txtInitialCatalog.Text = String.Empty;
            txtInitialCatalog.Tag = null;
            txtUserID.Text = String.Empty;
            txtUserID.Tag = null;
            txtPassword.Text = String.Empty;
            txtPassword.Tag = null;
            txtAplicacao.Text = String.Empty;
            txtAplicacao.Tag = null;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb != null)
            {
                string texto = tb.Text;
                string tag = null;

                if (tb.Tag != null)
                    tag = tb.Tag.ToString();
                else
                    tag = String.Empty;

                if (texto.CompareTo(tag) == 0)
                {
                    // Texto e Tag são iguais
                    tb.BackColor = SystemColors.Window;
                }
                else
                {
                    // Texto e Tag são diferentes
                    tb.BackColor = Color.Yellow;
                }

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            StringBuilder conexao = new StringBuilder();

            // Monta string no seguinte formado:

            //Data Source=MCFARLANE\SQL2012;
            //Initial Catalog=MoneyPro;
            //User ID=SA;
            //Password=senhaqualquer;
            //Application Name=MoneyPro;
            //MultipleActiveResultSets=True;
            //Connect Timeout=60;

            conexao.Append("Data Source=" + txtDataSource.Text.Trim() + ";");
            conexao.Append("Initial Catalog=" + txtInitialCatalog.Text.Trim() + ";");
            conexao.Append("User ID=" + txtUserID.Text.Trim() + ";");
            conexao.Append("Password=" + txtPassword.Text.Trim() + ";");
            conexao.Append("Application Name=" + txtAplicacao.Text.Trim() + ";");
            conexao.Append("MultipleActiveResultSets=True;");
            conexao.Append("Connect Timeout=60;");

            if (txtNome.Text == (string)txtNome.Tag)
            {
                _acessos[lbxAcessos.Text] = conexao.ToString();
            }
            else
            {
                _acessos.Remove(lbxAcessos.Text);
                _acessos.Add(txtNome.Text.Trim(), conexao.ToString());

                ExibeAcessos();
            }
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            string novo = "<novo>";
            lbxAcessos.Items.Add(novo);
            _acessos.Add(novo, "");
            txtNome.Text = novo;
            txtNome.Tag = novo;

            LimpaCamposTexto();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (lbxAcessos.SelectedIndex >= 0)
            {
                string acesso = lbxAcessos.Text;
                string msg = "Deseja excluir o acesso " + acesso + "?";

                DialogResult dr = MessageBox.Show(msg,
                                                  "Confirma",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question,
                                                  MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    // Exclui o item

                    // Remove o acesso do dicionário
                    _acessos.Remove(acesso);
                    // Remove o acesso do listbox
                    lbxAcessos.Items.RemoveAt(lbxAcessos.SelectedIndex);

                    LimpaCamposTexto(true);
                }
            }
        }
    }
}
