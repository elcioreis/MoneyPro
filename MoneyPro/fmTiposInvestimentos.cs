using BLL;
using Modelos;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MoneyPro
{
    public partial class fmTiposInvestimentos : MoneyPro.Base.fmBaseFerramentas
    {
        private int IDUsuario { get; set; }
        public fmTiposInvestimentos()
        {
            InitializeComponent();
            IDUsuario = Geral.UserID;
            CarregarTipoInvestimento();
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            IncluirTipoInvestimento();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            ExcluirTipoInvestimento();
        }

        private void IncluirTipoInvestimento()
        {
            if (tipoInvestimentoDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)tipoInvestimentoDataGridView.CurrentRow.Cells["TipoInvestimentoID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)tipoInvestimentoBindingSource.DataSource;
            DataRow row = table.NewRow();

            row["TipoInvestimentoID"] = TipoInvestimentoBLL.ProximoID;
            row["UsuarioID"] = IDUsuario;
            row["Apelido"] = String.Empty;
            row["Descricao"] = String.Empty;
            row["Ativo"] = true;
            row["Acao"] = false;
            row["Fundo"] = false;
            row["ComeCota"] = false;

            table.Rows.Add(row);

            tipoInvestimentoDataGridView.Focus();

            int lin = tipoInvestimentoDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(tipoInvestimentoDataGridView);
            tipoInvestimentoDataGridView.CurrentCell = tipoInvestimentoDataGridView.Rows[lin].Cells[col];
        }

        private void ExcluirTipoInvestimento()
        {
            if (tipoInvestimentoDataGridView.CurrentRow != null)
            {
                string msg = string.Format("Confirma a exclusão do tipo de investimento {0}?", (string)tipoInvestimentoDataGridView.CurrentRow.Cells["Apelido"].Value);

                DialogResult dr = MessageBox.Show(msg, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    TipoInvestimentoBLL bll = new TipoInvestimentoBLL();
                    bll.Excluir((int)tipoInvestimentoDataGridView.CurrentRow.Cells["TipoInvestimentoID"].Value);
                    CarregarTipoInvestimento();
                }
            }
        }

        private void fmTiposInvestimentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
            {
                // Se teclado insert chama rotina de inclusão.
                IncluirTipoInvestimento();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
            {
                // Se teclado ctrl + delete chama rotina de exclusão.
                ExcluirTipoInvestimento();
            }
            else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
            {
                // Se teclado Escape (sem modificadores (Alt ou Ctrl ou Shift))
                CancelarLinhaNova();
            }
        }

        private void CancelarLinhaNova()
        {
            if (tipoInvestimentoDataGridView.CurrentRow != null)
            {
                if ((int)tipoInvestimentoDataGridView.CurrentRow.Cells["TipoInvestimentoID"].Value < 0)
                {
                    tipoInvestimentoDataGridView.Rows.Remove(tipoInvestimentoDataGridView.CurrentRow);
                    CarregarTipoInvestimento();
                }
            }
        }

        private void CarregarTipoInvestimento()
        {
            tipoInvestimentoDataGridView.RowValidating -= tipoInvestimentoDataGridView_RowValidating;

            TipoInvestimentoBLL bll = new TipoInvestimentoBLL();
            tipoInvestimentoBindingSource.DataSource = bll.Listar(IDUsuario);

            tipoInvestimentoDataGridView.RowValidating += tipoInvestimentoDataGridView_RowValidating;
        }

        private void tipoInvestimentoDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = tipoInvestimentoDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = tipoInvestimentoDataGridView.Columns[cell].DataPropertyName;

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

        private void tipoInvestimentoDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (tipoInvestimentoDataGridView.RowCount > 0 && tipoInvestimentoDataGridView.CurrentRow != null)
            {
                if (tipoInvestimentoDataGridView.IsCurrentRowDirty || (int)tipoInvestimentoDataGridView.CurrentRow.Cells["TipoInvestimentoID"].Value < 0)
                {
                    DataGridViewRow linha = tipoInvestimentoDataGridView.CurrentRow;

                    TipoInvestimento modelo = new TipoInvestimento();

                    modelo.TipoInvestimentoID = (int)linha.Cells["TipoInvestimentoID"].Value;
                    modelo.UsuarioID = (int)linha.Cells["UsuarioID"].Value;
                    modelo.Apelido = (string)linha.Cells["Apelido"].Value;
                    modelo.Descricao = (string)linha.Cells["Descricao"].Value;
                    modelo.Ativo = (bool)linha.Cells["Ativo"].Value;
                    modelo.Acao = (bool)linha.Cells["Acao"].Value;
                    modelo.Fundo = (bool)linha.Cells["Fundo"].Value;
                    modelo.ComeCota = (bool)linha.Cells["ComeCota"].Value;

                    TipoInvestimentoBLL bll = new TipoInvestimentoBLL();

                    if (bll.Validar(modelo))
                    {
                        try
                        {
                            int registro = bll.Gravar(modelo);
                            CarregarTipoInvestimento();
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

        private void tipoInvestimentoDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            tipoInvestimentoDataGridView.EditingControl.KeyPress += tipoInvestimentoDataGridView_KeyPress;
        }

        private void buttonDespesas_Click(object sender, EventArgs e)
        {
            if (tipoInvestimentoDataGridView.CurrentRow == null)
            {
                return;
            }

            int tipoInvestimentoID = (int)tipoInvestimentoDataGridView.CurrentRow.Cells["TipoInvestimentoID"].Value;

            fmTipoInvestimentoDespesas form = new fmTipoInvestimentoDespesas(tipoInvestimentoID);
            form.ShowDialog();
        }
    }
}
