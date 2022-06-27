using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MoneyPro.Base;
using BLL;
using Modelos;
using System.Text.RegularExpressions;

namespace MoneyPro
{
    public partial class fmTiposInstituicoes : MoneyPro.Base.fmBaseFerramentas
    {
        private int _usuarioID;
        public fmTiposInstituicoes()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _usuarioID = Geral.UserID;
            CarregaTipoInstituicao();
        }

        private void CarregaTipoInstituicao()
        {
            tipoInstituicaoDataGridView.RowValidating -= tipoInstituicaoDataGridView_RowValidating;
            TipoInstituicaoBLL obj = new TipoInstituicaoBLL();
            tipoInstituicaoBindingSource.DataSource = obj.Listar(_usuarioID);
            tipoInstituicaoDataGridView.RowValidating += tipoInstituicaoDataGridView_RowValidating;
        }

        private void fmTipoInstituicoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
            {
                // Se teclado insert chama rotina de inclusão.
                IncluirTipoInstituicao();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
            {
                // Se teclado ctrl + delete chama rotina de exclusão.
                ExcluirTipoInstituicao();
            }
            else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
            {
                 // Se teclado Escape (sem modificadores (Alt ou Ctrl ou Shift))
                 CancelarLinhaNova();
            }
        }

        private void CancelarLinhaNova()
        {
            if (tipoInstituicaoDataGridView.CurrentRow != null)
            {
                if ((int)tipoInstituicaoDataGridView.CurrentRow.Cells["TipoInstituicaoID"].Value < 0)
                {
                    tipoInstituicaoDataGridView.Rows.Remove(tipoInstituicaoDataGridView.CurrentRow);
                    CarregaTipoInstituicao();
                }
            }
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            IncluirTipoInstituicao();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            ExcluirTipoInstituicao();
        }

        private void IncluirTipoInstituicao()
        {
            // Se a linha atual não for nula
            if (tipoInstituicaoDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)tipoInstituicaoDataGridView.CurrentRow.Cells["TipoInstituicaoID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)tipoInstituicaoBindingSource.DataSource;
            DataRow row = table.NewRow();

            row["TipoInstituicaoID"] = TipoInstituicaoBLL.ProximoID;
            row["UsuarioID"] = _usuarioID;
            row["Apelido"] = String.Empty;
            row["Descricao"] = String.Empty;
            row["Ativo"] = true;

            table.Rows.Add(row);

            tipoInstituicaoDataGridView.Focus();

            int lin = tipoInstituicaoDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(tipoInstituicaoDataGridView);
            tipoInstituicaoDataGridView.CurrentCell = tipoInstituicaoDataGridView.Rows[lin].Cells[col];
        }

        private void ExcluirTipoInstituicao()
        {
            if (tipoInstituicaoDataGridView.CurrentRow != null)
            {
                string msg = string.Format("Confirma a exclusão do tipo de instituição {0}?", (string)tipoInstituicaoDataGridView.CurrentRow.Cells["Apelido"].Value);

                DialogResult dr = MessageBox.Show(msg, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    TipoInstituicaoBLL bll = new TipoInstituicaoBLL();
                    bll.Excluir((int)tipoInstituicaoDataGridView.CurrentRow.Cells["TipoInstituicaoID"].Value);
                    CarregaTipoInstituicao();
                }
            }
        }

        private void tipoInstituicaoDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = tipoInstituicaoDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = tipoInstituicaoDataGridView.Columns[cell].DataPropertyName;

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
            }
        }

        private void tipoInstituicaoDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            tipoInstituicaoDataGridView.EditingControl.KeyPress += tipoInstituicaoDataGridView_KeyPress;
        }

        private void tipoInstituicaoDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (tipoInstituicaoDataGridView.RowCount > 0 && tipoInstituicaoDataGridView.CurrentRow != null)
            {
                if (tipoInstituicaoDataGridView.IsCurrentRowDirty || (int)tipoInstituicaoDataGridView.CurrentRow.Cells["TipoInstituicaoID"].Value < 0)
                {
                    DataGridViewRow linha = tipoInstituicaoDataGridView.CurrentRow;

                    TipoInstituicao modelo = new TipoInstituicao();

                    modelo.TipoInstituicaoID = (int)linha.Cells["TipoInstituicaoID"].Value;
                    modelo.UsuarioID = (int)linha.Cells["UsuarioID"].Value;
                    modelo.Apelido = (string)linha.Cells["Apelido"].Value;
                    modelo.Descricao = (string)linha.Cells["Descricao"].Value;
                    modelo.Ativo = (bool)linha.Cells["Ativo"].Value;

                    TipoInstituicaoBLL bll = new TipoInstituicaoBLL();

                    if (bll.Validar(modelo))
                    {
                        try
                        {
                            int registro = bll.Gravar(modelo);
                            CarregaTipoInstituicao();
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show(ex.ParamName, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Cancel = true;
                        }
                    }
                    else
                    {
                        // Não passou pela validação.
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}
