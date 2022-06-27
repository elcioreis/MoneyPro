using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelos;
using BLL;
using MoneyPro.Base;
using System.Text.RegularExpressions;

namespace MoneyPro
{
    public partial class fmGruposContas : MoneyPro.Base.fmBaseFerramentas
    {
        private int _usuarioID;
        public fmGruposContas()
        {
            InitializeComponent();

            _usuarioID = Geral.UserID;

            CarregaGrupoContas();
        }

        private void CarregaGrupoContas()
        {
            grupoContaDataGridView.RowValidating -= grupoContaDataGridView_RowValidating;

            GrupoContaBLL obj = new GrupoContaBLL();
            grupoContaBindingSource.DataSource = obj.ListarPorOrdem(_usuarioID);

            grupoContaDataGridView.RowValidating += grupoContaDataGridView_RowValidating;
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            IncluirGrupoConta();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            ExcluirGrupoConta();
        }

        private void IncluirGrupoConta()
        {
            // Se a linha atual não for nula
            if (grupoContaDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)grupoContaDataGridView.CurrentRow.Cells["GrupoContaID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)grupoContaBindingSource.DataSource;
            DataRow row = table.NewRow();

            row["GrupoContaID"] = GrupoContaBLL.ProximoID;
            row["UsuarioID"] = _usuarioID;
            row["Apelido"] = String.Empty;
            row["Descricao"] = String.Empty;
            row["Ordem"] = table.Rows.Count + 1;
            row["Ativo"] = true;

            table.Rows.Add(row);

            grupoContaDataGridView.Focus();

            int lin = grupoContaDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(grupoContaDataGridView);
            grupoContaDataGridView.CurrentCell = grupoContaDataGridView.Rows[lin].Cells[col];
        }

        private void ExcluirGrupoConta()
        {
            if (grupoContaDataGridView.CurrentRow != null)
            {
                string msg = String.Format("Deseja excluir o grupo de contas {0}?", (string)grupoContaDataGridView.CurrentRow.Cells["Apelido"].Value);

                DialogResult dr = MessageBox.Show(msg, "Confirma", 
                                                  MessageBoxButtons.YesNo, 
                                                  MessageBoxIcon.Question, 
                                                  MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    GrupoContaBLL obj = new GrupoContaBLL();
                    obj.Excluir((int)grupoContaDataGridView.CurrentRow.Cells["GrupoContaID"].Value);
                    CarregaGrupoContas();
                }
            }
        }

        private void fmGruposContas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
            {
                // Se teclado insert chama rotina de inclusão.
                IncluirGrupoConta();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
            {
                // Se teclado ctrl + delete chama rotina de exclusão.
                ExcluirGrupoConta();
            }
            else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
            {
                // Se teclado Escape (sem modificadores (Alt ou Ctrl ou Shift))
                CancelarLinhaNova();
            }
        }

        private void CancelarLinhaNova()
        {
            if ((int)grupoContaDataGridView.CurrentRow.Cells["GrupoContaID"].Value < 0)
            {
                grupoContaDataGridView.Rows.Remove(grupoContaDataGridView.CurrentRow);
                CarregaGrupoContas();
            }
        }

        private void grupoContaDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = grupoContaDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = grupoContaDataGridView.Columns[cell].DataPropertyName;

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

        private void grupoContaDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            grupoContaDataGridView.EditingControl.KeyPress += grupoContaDataGridView_KeyPress;
        }

        private void grupoContaDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (grupoContaDataGridView.RowCount > 0 && grupoContaDataGridView.CurrentRow != null)
            {
                if (grupoContaDataGridView.IsCurrentRowDirty || (int)grupoContaDataGridView.CurrentRow.Cells["GrupoContaID"].Value < 0)
                {
                    DataGridViewRow linha = grupoContaDataGridView.CurrentRow;

                    GrupoConta grupoConta = new GrupoConta();

                    grupoConta.GrupoContaID = (int)linha.Cells["GrupoContaID"].Value;
                    grupoConta.UsuarioID = (int)linha.Cells["UsuarioID"].Value;
                    grupoConta.Apelido = (string)linha.Cells["Apelido"].Value;
                    grupoConta.Descricao = (string)linha.Cells["Descricao"].Value;
                    grupoConta.Ordem = (int)linha.Cells["Ordem"].Value;
                    grupoConta.Ativo = (bool)linha.Cells["Ativo"].Value;

                    GrupoContaBLL bll = new GrupoContaBLL();

                    if (bll.Validar(grupoConta))
                    {
                        // Passou pela validação, tentará gravar
                        int registro = bll.Gravar(grupoConta);
                        CarregaGrupoContas();
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
