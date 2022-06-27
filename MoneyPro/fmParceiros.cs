using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MoneyPro.Base;
using Modelos;
using BLL;
using System.Text.RegularExpressions;

namespace MoneyPro
{
    public partial class fmParceiros : MoneyPro.Base.fmBaseTopoRodape
    {
        private int _usuarioID;

        #region Singleton

        private static fmParceiros _singleton;

        private fmParceiros()
        {
            InitializeComponent();
        }

        public static fmParceiros CreateInstance()
        {
            if (_singleton == null)
            {
                _singleton = new fmParceiros();
            }
            return _singleton;
        }

        protected override void OnClosed(EventArgs e)
        {
            _singleton = null;
            base.OnClosed(e);
        }

        #endregion Singleton

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _usuarioID = Geral.UserID;
            CarregarLancamentos(_usuarioID);
        }

        private void CarregarLancamentos(int usuarioID)
        {
            lancamentoDataGridView.RowValidating -= lancamentoDataGridView_RowValidating;

            LancamentoBLL bll = new LancamentoBLL();
            lancamentoBindingSource.DataSource = bll.Listar(usuarioID);

            lancamentoDataGridView.RowValidating += lancamentoDataGridView_RowValidating;
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            IncluirLancamento();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            ExcluirLancamento();
        }

        private void IncluirLancamento()
        {
            // Se a linha atual não for nula
            if (lancamentoDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)lancamentoDataGridView.CurrentRow.Cells["LancamentoID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)lancamentoBindingSource.DataSource;
            DataRow row = table.NewRow();

            row["LancamentoID"] = LancamentoBLL.ProximoID;
            row["UsuarioID"] = _usuarioID;
            row["Apelido"] = String.Empty;
            row["Descricao"] = String.Empty;
            row["Ativo"] = true;
            row["Sistema"] = false;

            table.Rows.Add(row);

            lancamentoDataGridView.Focus();

            int lin = lancamentoDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(lancamentoDataGridView);
            lancamentoDataGridView.CurrentCell = lancamentoDataGridView.Rows[lin].Cells[col];
        }

        private void ExcluirLancamento()
        {
            if (lancamentoDataGridView.CurrentRow != null)
            {
                if (!(bool)lancamentoDataGridView.CurrentRow.Cells["Sistema"].Value)
                {
                    string msg = String.Format("Deseja excluir o lançamento {0}?", (string)lancamentoDataGridView.CurrentRow.Cells["Apelido"].Value);

                    DialogResult dr = MessageBox.Show(msg, "Confirma",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question,
                                                      MessageBoxDefaultButton.Button2);

                    if (dr == DialogResult.Yes)
                    {
                        LancamentoBLL bll = new LancamentoBLL();
                        bll.Excluir((int)lancamentoDataGridView.CurrentRow.Cells["LancamentoID"].Value);
                        CarregarLancamentos(_usuarioID);
                    }
                }
                else
                {
                    string msg = String.Format("O lançamento {0} foi gerado pelo sistema e não pode ser excluído.", (string)lancamentoDataGridView.CurrentRow.Cells["Apelido"].Value);

                    DialogResult dr = MessageBox.Show(msg, "Atenção",
                                                      MessageBoxButtons.OK,
                                                      MessageBoxIcon.Exclamation);
                }
            }
        }

        private void fmLancamentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
            {
                // Se teclado insert chama rotina de inclusão.
                IncluirLancamento();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
            {
                // Se teclado ctrl + delete chama rotina de exclusão.
                ExcluirLancamento();
            }
            else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
            {
                // Se teclado Escape (sem modificadores (Alt ou Ctrl ou Shift))
                CancelarLinhaNova();
            }

        }

        private void CancelarLinhaNova()
        {
            if ((int)lancamentoDataGridView.CurrentRow.Cells["LancamentoID"].Value < 0)
            {
                lancamentoDataGridView.Rows.Remove(lancamentoDataGridView.CurrentRow);
                CarregarLancamentos(_usuarioID);
            }
        }

        private void lancamentoDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (lancamentoDataGridView.RowCount > 0 && lancamentoDataGridView.CurrentRow != null)
            {
                if (lancamentoDataGridView.IsCurrentRowDirty || (int)lancamentoDataGridView.CurrentRow.Cells["LancamentoID"].Value < 0)
                {
                    DataGridViewRow linha = lancamentoDataGridView.CurrentRow;

                    Lancamento modelo = new Lancamento();

                    modelo.LancamentoID = (int)linha.Cells["LancamentoID"].Value;
                    modelo.UsuarioID = (int)linha.Cells["UsuarioID"].Value;
                    modelo.Apelido = (string)linha.Cells["Apelido"].Value;
                    modelo.Descricao = (string)linha.Cells["Descricao"].Value;
                    modelo.Ativo = (bool)linha.Cells["Ativo"].Value;
                    modelo.Sistema = (bool)linha.Cells["Sistema"].Value;

                    LancamentoBLL bll = new LancamentoBLL();

                    if (bll.Validar(modelo))
                    {
                        // Passou pela validação, tentará gravar
                        int registro = bll.Gravar(modelo);
                        CarregarLancamentos(_usuarioID);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void lancamentoDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = lancamentoDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = lancamentoDataGridView.Columns[cell].DataPropertyName;

                if (coluna == "Apelido")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer texto de 0 a 40 caracters
                    if (Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,40}$"))
                    {
                        Geral.Capitaliza(textbox);                     // Capitaliza o conteúdo do textbox
                    }
                    else
                    {
                        e.Handled = true;                              // não passou pela regex
                    }
                }
                else if (coluna == "Descricao")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer texto de 0 a 10 caracters
                    if (Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,100}$"))
                    {
                        Geral.Capitaliza(textbox);                     // Capitaliza o conteúdo do textbox
                    }
                    else
                    {
                        e.Handled = true;                              // não passou pela regex
                    }
                }
            }
        }

        private void lancamentoDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            lancamentoDataGridView.EditingControl.KeyPress += lancamentoDataGridView_KeyPress;
        }

        private void lancamentoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (lancamentoDataGridView.CurrentRow != null)
            {
                if (e.Value != null)
                {
                    if ((bool)lancamentoDataGridView.Rows[e.RowIndex].Cells["Sistema"].Value)
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
