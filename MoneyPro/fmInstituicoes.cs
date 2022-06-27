using MoneyPro.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelos;
using BLL;
using System.Text.RegularExpressions;

namespace MoneyPro
{
    public partial class fmInstituicoes : MoneyPro.Base.fmBaseFerramentas
    {
        private int _usuarioID;

        public fmInstituicoes()
        {
            InitializeComponent();
            _usuarioID = Geral.UserID;
            CarregarDados(_usuarioID);
        }

        private void CarregarDados(int usuarioID)
        {
            CarregarTipoInstituicao(usuarioID);
            CarregarInstituicoes(usuarioID);
        }

        private void CarregarTipoInstituicao(int usuarioID)
        {
            string nomeColuna = "TipoInstituicao";
            TipoInstituicaoBLL tipoInstituicao = new TipoInstituicaoBLL();

            // Cria uma nova coluna do tipo ComboBox
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Name = nomeColuna;
            combo.DataSource = tipoInstituicao.Listar(usuarioID);
            combo.DataPropertyName = "TipoInstituicaoID";
            combo.DisplayMember = "Apelido";
            combo.ValueMember = "TipoInstituicaoID";
            combo.HeaderText = "Tipo de Instituição";
            combo.SortMode = DataGridViewColumnSortMode.Automatic;
            // Atributos de formato
            combo.FlatStyle = FlatStyle.Flat;
            combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            combo.AutoComplete = true;
            combo.Width = 180;
            combo.FillWeight = 180;
            combo.MinimumWidth = 120;

            if (!instituicaoDataGridView.Columns.Contains(nomeColuna))
            {
                // Acha a posição da coluna numérica e coloca o combobox junto, deixando a coluna numérica invisível.
                int index = instituicaoDataGridView.Columns["TipoInstituicaoID"].Index;
                instituicaoDataGridView.Columns[index].Visible = false;
                instituicaoDataGridView.Columns.Insert(index, combo);
            }
            else
            {
                int index = instituicaoDataGridView.Columns[nomeColuna].Index;
                instituicaoDataGridView.Columns.RemoveAt(index);
                instituicaoDataGridView.Columns.Insert(index, combo);
            }
        }

        private void RecarregaTipoInstituicao(int usuarioID)
        {
            DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)instituicaoDataGridView.Columns["TipoInstituicao"];

            TipoInstituicaoBLL bll = new TipoInstituicaoBLL();
            combo.DataSource = bll.Listar(usuarioID);
        }

        private void CarregarInstituicoes(int usuarioID)
        {
            instituicaoDataGridView.RowValidating -= instituicaoDataGridView_RowValidating;

            InstituicaoBLL bll = new InstituicaoBLL();
            instituicaoBindingSource.DataSource = bll.Listar(usuarioID);

            instituicaoDataGridView.RowValidating += instituicaoDataGridView_RowValidating;
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            IncluirInstituicao();
        }

        private void IncluirInstituicao()
        {
            // Se a linha atual não for nula
            if (instituicaoDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)instituicaoDataGridView.CurrentRow.Cells["InstituicaoID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)instituicaoBindingSource.DataSource;
            DataRow row = table.NewRow();

            row["InstituicaoID"] = InstituicaoBLL.ProximoID;
            row["UsuarioID"] = _usuarioID;
            row["TipoInstituicaoID"] = DBNull.Value;
            row["Apelido"] = String.Empty;
            row["Descricao"] = String.Empty;
            row["Banco"] = DBNull.Value;
            row["Ativo"] = true;

            table.Rows.Add(row);

            instituicaoDataGridView.Focus();

            int lin = instituicaoDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(instituicaoDataGridView);
            instituicaoDataGridView.CurrentCell = instituicaoDataGridView.Rows[lin].Cells[col];
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            ExcluirInstituicao();
        }

        private void ExcluirInstituicao()
        {
            if (instituicaoDataGridView.CurrentRow != null)
            {
                string msg = String.Format("Deseja excluir a instituição {0}?", (string)instituicaoDataGridView.CurrentRow.Cells["Apelido"].Value);

                DialogResult dr = MessageBox.Show(msg, "Confirma",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question,
                                                  MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    InstituicaoBLL bll = new InstituicaoBLL();
                    bll.Excluir((int)instituicaoDataGridView.CurrentRow.Cells["InstituicaoID"].Value);
                    CarregarInstituicoes(_usuarioID);
                }
            }
        }

        private void btnTipoInstituicao_Click(object sender, EventArgs e)
        {
            fmTiposInstituicoes form = new fmTiposInstituicoes();
            form.ShowDialog();
            RecarregaTipoInstituicao(_usuarioID);
        }

        private void CancelarLinhaNova()
        {
            if ((int)instituicaoDataGridView.CurrentRow.Cells["InstituicaoID"].Value < 0)
            {
                instituicaoDataGridView.Rows.Remove(instituicaoDataGridView.CurrentRow);
                CarregarInstituicoes(_usuarioID);
            }
        }

        private void instituicaoDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = instituicaoDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = instituicaoDataGridView.Columns[cell].DataPropertyName;

                if (coluna == "Apelido")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer texto de 0 a 100 caracters
                    if (!Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,25}$"))
                    {
                        e.Handled = true;                              // não passou pela regex
                    }
                    //else
                    //{
                    //    Geral.Capitaliza(textbox);                     // Capitaliza o conteúdo do textbox
                    //}
                }
                else if (coluna == "Descricao")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer texto de 0 a 10 caracters
                    if (!Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,100}$"))
                    {
                        e.Handled = true;                              // não passou pela regex
                    }
                    //else
                    //{
                    //    Geral.Capitaliza(textbox);                     // Capitaliza o conteúdo do textbox
                    //}
                }
            }
        }

        private void fmInstituicoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
            {
                // Se teclado insert chama rotina de inclusão.
                IncluirInstituicao();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
            {
                // Se teclado ctrl + delete chama rotina de exclusão.
                ExcluirInstituicao();
            }
            else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
            {
                // Se teclado Escape (sem modificadores (Alt ou Ctrl ou Shift))
                CancelarLinhaNova();
            }
        }

        private void instituicaoDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            instituicaoDataGridView.EditingControl.KeyPress += instituicaoDataGridView_KeyPress;
        }

        private void instituicaoDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (instituicaoDataGridView.RowCount > 0 && instituicaoDataGridView.CurrentRow != null)
            {
                if (instituicaoDataGridView.IsCurrentRowDirty || (int)instituicaoDataGridView.CurrentRow.Cells["InstituicaoID"].Value < 0)
                {
                    DataGridViewRow linha = instituicaoDataGridView.CurrentRow;

                    Instituicao instituicao = new Instituicao();

                    instituicao.InstituicaoID = (int)linha.Cells["InstituicaoID"].Value;
                    if (linha.Cells["TipoInstituicao"].Value != DBNull.Value)
                    {
                        instituicao.TipoInstituicaoID = (int)linha.Cells["TipoInstituicao"].Value;
                    }
                    else
                    {
                        instituicao.TipoInstituicaoID = null;
                    }
                    instituicao.UsuarioID = (int)linha.Cells["UsuarioID"].Value;
                    instituicao.Apelido = (string)linha.Cells["Apelido"].Value;
                    instituicao.Descricao = (string)linha.Cells["Descricao"].Value;
                    if (linha.Cells["Banco"].Value != DBNull.Value)
                    {
                        instituicao.Banco = (int)linha.Cells["Banco"].Value;
                    }
                    else
                    {
                        instituicao.Banco = null;
                    }
                    instituicao.Ativo = (bool)linha.Cells["Ativo"].Value;

                    InstituicaoBLL bll = new InstituicaoBLL();

                    if (bll.Validar(instituicao))
                    {
                        // Passou pela validação, tentará gravar
                        int registro = bll.Gravar(instituicao);
                        CarregarInstituicoes(_usuarioID);
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
