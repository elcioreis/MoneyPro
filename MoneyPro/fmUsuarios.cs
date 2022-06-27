using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Modelos;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MoneyPro
{
    public partial class fmUsuarios : Form
    {
        private BindingList<Usuario> usuarios = new BindingList<Usuario>();

        #region Singleton

        private static fmUsuarios _singleton;

        private fmUsuarios()
        {
            InitializeComponent();
        }

        public static fmUsuarios CreateInstance()
        {
            if (_singleton == null)
            {
                _singleton = new fmUsuarios();
            }
            return _singleton;
        }

        protected override void OnClosed(EventArgs e)
        {
            _singleton = null;
            base.OnClosed(e);
        }

        #endregion Singleton

        #region Eventos

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            usuarioDataGridView.RowValidating -= gridUsuarios_RowValidating;

            UsuarioBLL obj = new UsuarioBLL();
            usuariosBindingSource.DataSource = obj.Listagem();

            usuarioDataGridView.RowValidating += gridUsuarios_RowValidating;
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            IncluirUsuario();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            ExcluirUsuario();
        }

        private void gridUsuarios_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            usuarioDataGridView.EditingControl.KeyPress += gridUsuarios_KeyPress;
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void gridUsuarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = usuarioDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = usuarioDataGridView.Columns[cell].DataPropertyName;

                if (coluna == "Apelido")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer texto de 0 a 100 caracters
                    if (Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,25}$"))
                    {
                        Geral.Capitaliza(textbox);                     // Capitaliza o conteúdo do textbox
                    }
                    else
                    {
                        e.Handled = true;                              // não passou pela regex
                    }
                }
                else if (coluna == "Nome")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer texto de 0 a 100 caracters
                    if (Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,100}$"))
                    {
                        Geral.Capitaliza(textbox);                     // Capitaliza o conteúdo do textbox
                    }
                    else
                    {
                        e.Handled = true;                              // não passou pela regex
                    }
                }
                else if (coluna == "Email")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer texto de 0 a 100 caracters
                    if (Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,100}$"))
                    {
                        textbox.Text = textbox.Text.ToLower();
                    }
                    else
                    {
                        e.Handled = true;                              // não passou pela regex
                    }
                }
            }
        }

        private void buttonResetaSenha_Click(object sender, EventArgs e)
        {
            if (usuarioDataGridView.CurrentRow != null && (int)usuarioDataGridView.CurrentRow.Cells["UsuarioID"].Value > 0)
            {
                string msg = String.Format("Deseja recolocar a senha padrão para o usuário {0}?", usuarioDataGridView.CurrentRow.Cells["Apelido"].Value);
                DialogResult dr = MessageBox.Show(msg, "Atenção",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question,
                                                  MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    // Recoloca a senha padrão (123)
                    usuarioDataGridView.CurrentRow.Cells["Senha"].Value = Geral.CriptografaSenha("123");
                    usuarioDataGridView.EndEdit();
                    // Executa a validação da linha, que é reponsável por fazer a gravação do registro.
                    gridUsuarios_RowValidating(usuarioDataGridView, null);
                }
            }
        }

        #endregion Eventos
        private void IncluirUsuario()
        {
            // Se a linha atual não for nula
            if (usuarioDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero
                if ((int)usuarioDataGridView.CurrentRow.Cells["UsuarioID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)(usuariosBindingSource.DataSource);
            DataRow row = table.NewRow();

            row["UsuarioID"] = UsuarioBLL.ProximoID;
            row["Apelido"] = String.Empty;
            row["Nome"] = String.Empty;
            row["Senha"] = Geral.CriptografaSenha("123");
            row["Email"] = "";
            row["Ativo"] = true;
            row["Sistema"] = false;

            table.Rows.Add(row);

            usuarioDataGridView.Focus();

            int lin = usuarioDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(usuarioDataGridView);
            usuarioDataGridView.CurrentCell = usuarioDataGridView.Rows[lin].Cells[col];
        }

        private void CancelarLinhaNova()
        {
            if ((int)usuarioDataGridView.CurrentRow.Cells["UsuarioID"].Value < 0)
            {
                usuarioDataGridView.Rows.Remove(usuarioDataGridView.CurrentRow);
                AtualizaGrid();
            }
        }

        private void ExcluirUsuario()
        {
            if (usuarioDataGridView.CurrentRow != null)
            {
                // Usuário marcado como "Sistema" não pode ser excluído
                if (!(bool)usuarioDataGridView.CurrentRow.Cells["Sistema"].Value)
                {
                    string msg = String.Format("Deseja excluir o usuário {0}?", usuarioDataGridView.CurrentRow.Cells["Apelido"].Value);
                    DialogResult dr = MessageBox.Show(msg, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (dr == DialogResult.Yes)
                    {
                        try
                        {
                            UsuarioBLL obj = new UsuarioBLL();
                            obj.Excluir((int)usuarioDataGridView.CurrentRow.Cells["UsuarioID"].Value);

                            AtualizaGrid();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    string msg = String.Format("O usuário {0} foi criado pelo sistema e não pode ser excluído.", (string)usuarioDataGridView.CurrentRow.Cells["Apelido"].Value);
                    MessageBox.Show(msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void gridUsuarios_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (usuarioDataGridView.RowCount > 0 && usuarioDataGridView.CurrentRow != null)
            {
                if (usuarioDataGridView.IsCurrentRowDirty || (int)usuarioDataGridView.CurrentRow.Cells["UsuarioID"].Value < 0)
                {
                    DataGridViewRow linha = usuarioDataGridView.CurrentRow;

                    Usuario atual = new Usuario();

                    atual.UsuarioID = (int)linha.Cells["UsuarioID"].Value;

                    if (linha.Cells["Apelido"].Value != DBNull.Value)
                        atual.Apelido = (string)linha.Cells["Apelido"].Value;
                    else
                        atual.Apelido = String.Empty;

                    if (linha.Cells["Nome"].Value != DBNull.Value)
                        atual.Nome = (string)linha.Cells["Nome"].Value;
                    else
                        atual.Nome = String.Empty;

                    if (linha.Cells["Senha"].Value != DBNull.Value)
                        atual.Senha = (string)linha.Cells["Senha"].Value;
                    else
                        atual.Senha = String.Empty;

                    if (linha.Cells["Email"].Value != DBNull.Value)
                        atual.Email = (string)linha.Cells["Email"].Value;
                    else
                        atual.Email = String.Empty;

                    if (linha.Cells["Ativo"].Value != DBNull.Value)
                        atual.Ativo = (bool)linha.Cells["Ativo"].Value;
                    else
                        atual.Ativo = true;

                    if (linha.Cells["Sistema"].Value != DBNull.Value)
                        atual.Sistema = (bool)linha.Cells["Sistema"].Value;
                    else
                        atual.Sistema = false;

                    UsuarioBLL usuario = new UsuarioBLL();

                    try
                    {
                        // Ao forçar o reset da senha, o RowValidating passando o parâmetro e como nulo.
                        if (e != null)
                        {
                            e.Cancel = !usuario.AtualizaSeValido(atual);

                            if (!e.Cancel)
                            {
                                AtualizaGrid();
                            }
                        }
                        else
                        {
                            // Somente passa por aqui se for para resetar a senha
                            if (usuario.AtualizaSeValido(atual))
                            {
                                string msg = String.Format("A senha padrão foi recolocada para o usuário {0}.", usuarioDataGridView.CurrentRow.Cells["Apelido"].Value);
                                MessageBox.Show(msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            }
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.ParamName, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void fmUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (!usuarioDataGridView.IsCurrentCellInEditMode)
            {
                // Se teclado Insert (sem modificadores (Alt ou Ctrl ou Shif))
                if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
                {
                    IncluirUsuario();
                }
                // Se teclado Ctrl + Delete
                else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
                {
                    ExcluirUsuario();
                }
                // Se teclado Escape (sem modificadores (Alt ou Ctrl ou Shift))
                else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
                {
                    CancelarLinhaNova();
                }
            }
        }

        private void gridUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (usuarioDataGridView.CurrentRow != null)
            {
                if (e.Value != null)
                {
                    if ((bool)usuarioDataGridView.Rows[e.RowIndex].Cells["Sistema"].Value)
                    {
                        // É um lançamento criado pelo sistema.
                        // Coloca o fonte em vermelho
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
            }

        }
    }
}
