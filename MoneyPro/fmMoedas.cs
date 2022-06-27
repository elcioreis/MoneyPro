using MoneyPro.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using System.Text.RegularExpressions;
using Modelos;

namespace MoneyPro
{
    public partial class fmMoedas : MoneyPro.Base.fmBaseFerramentas
    {
        public fmMoedas()
        {
            InitializeComponent();
            CarregaMoedas();
        }

        private void CarregaMoedas()
        {
            moedaDataGridView.RowValidating -= moedaDataGridView_RowValidating;

            MoedaBLL moeda = new MoedaBLL();
            moedaBindingSource.DataSource = moeda.ListarMoedas();

            // Troca todos os espaços dos cabeçalhos das colunas visíveis por espaços inseparáveis
            foreach (DataGridViewColumn col in moedaDataGridView.Columns)
            {
                if (col.Visible)
                {
                    col.MinimumWidth = 10;
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    col.HeaderText = col.HeaderText.Trim().Replace(' ', '\u00A0');
                }
            }

            // Faz com que a altura da linha do cabeçalho seja igual ao das linhas do grid
            moedaDataGridView.ColumnHeadersHeight = moedaDataGridView.RowTemplate.Height;

            moedaDataGridView.RowValidating += moedaDataGridView_RowValidating;
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            IncluirMoeda();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            ExcluirMoeda();
        }

        private void IncluirMoeda()
        {
            // Se a linha atual não for nula
            if (moedaDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)moedaDataGridView.CurrentRow.Cells["MoedaID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)moedaBindingSource.DataSource;
            DataRow row = table.NewRow();

            row["MoedaID"] = UsuarioBLL.ProximoID;
            row["Apelido"] = String.Empty;
            row["Simbolo"] = String.Empty;
            row["Padrao"] = (moedaDataGridView.Rows.Count == 0);
            row["Virtual"] = false;
            row["PadraoVirtual"] = false;
            row["MercadoBitCoin"] = false;
            table.Rows.Add(row);

            moedaDataGridView.Focus();

            int lin = moedaDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(moedaDataGridView);
            moedaDataGridView.CurrentCell = moedaDataGridView.Rows[lin].Cells[col];
        }

        private void ExcluirMoeda()
        {
            if (moedaDataGridView.CurrentRow != null)
            {
                // Não pode excluir a moeda padrão
                if (!(bool)moedaDataGridView.CurrentRow.Cells["Padrao"].Value)
                {

                    string msg = string.Format("Confirma a exclusão da moeda {0}?", (string)moedaDataGridView.CurrentRow.Cells["Apelido"].Value);

                    DialogResult dr = MessageBox.Show(msg, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (dr == DialogResult.Yes)
                    {
                        MoedaBLL obj = new MoedaBLL();
                        if (obj.ExcluirMoeda((int)moedaDataGridView.CurrentRow.Cells["MoedaID"].Value))
                        {
                            CarregaMoedas();
                        }
                    }
                }
                else
                {
                    string msg = string.Format("A moeda padrão não pode ser excluída.", (string)moedaDataGridView.CurrentRow.Cells["Apelido"].Value);

                    DialogResult dr = MessageBox.Show(msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void moedaDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = moedaDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = moedaDataGridView.Columns[cell].DataPropertyName;

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
                else if (coluna == "Simbolo")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer texto de 0 a 10 caracters
                    if (!Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,10}$"))
                    {
                        e.Handled = true;                              // não passou pela regex
                    }
                }
            }
        }

        private void moedaDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            moedaDataGridView.EditingControl.KeyPress += moedaDataGridView_KeyPress;
        }

        private void moedaDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (moedaDataGridView.RowCount > 0 && moedaDataGridView.CurrentRow != null)
            {
                if (moedaDataGridView.CurrentRow.Cells["MoedaID"].Value != null)
                {
                    if (moedaDataGridView.IsCurrentRowDirty || (int)moedaDataGridView.CurrentRow.Cells["MoedaID"].Value < 0)
                    {
                        DataGridViewRow linha = moedaDataGridView.CurrentRow;

                        MoedaBLL bll = new MoedaBLL();

                        Moeda moeda = new Moeda();

                        moeda.MoedaID = (int)linha.Cells["MoedaID"].Value;
                        moeda.Apelido = (string)linha.Cells["Apelido"].Value;
                        moeda.Simbolo = (string)linha.Cells["Simbolo"].Value;

                        if (linha.Cells["Eletronica"].Value != DBNull.Value)
                        {
                            moeda.Eletronica = (string)linha.Cells["Eletronica"].Value;
                        }
                        else
                        {
                            moeda.Eletronica = null;
                        }

                        if (linha.Cells["CodigoMoedaBancoCentral"].Value != DBNull.Value)
                        {
                            moeda.CodigoMoedaBancoCentral = (string)linha.Cells["CodigoMoedaBancoCentral"].Value;
                        }
                        else
                        {
                            moeda.CodigoMoedaBancoCentral = null;
                        }
                        moeda.Padrao = (bool)linha.Cells["Padrao"].Value;
                        moeda.Virtual = (bool)linha.Cells["Virtual"].Value;
                        moeda.PadraoVirtual = (bool)linha.Cells["PadraoVirtual"].Value;
                        moeda.MercadoBitCoin = (bool)linha.Cells["MercadoBitCoin"].Value;

                        if (bll.ValidaEntrada(moeda))
                        {

                            try
                            {
                                int registro = bll.GravarMoeda(moeda);

                                CarregaMoedas();

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

        private void moedaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == moedaDataGridView.CurrentRow.Cells["Padrao"].ColumnIndex)
                {
                    bool antigo = (bool)moedaDataGridView.CurrentRow.Cells["Padrao"].FormattedValue;

                    if (antigo)
                    {
                        // Cancela a edição
                        moedaDataGridView.CancelEdit();
                    }
                    else
                    {
                        // Grava a edição
                        moedaDataGridView.EndEdit();
                        // Commita a linha (força a execução do RowValidating)
                        moedaDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    }
                }
            }
        }

        private void fmMoedas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
            {
                // Se Insert sem modificadores
                IncluirMoeda();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
            {
                // Se Ctrl + Delete
                ExcluirMoeda();
            }
            else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
            {
                // Se teclado Escape (sem modificadores (Alt ou Ctrl ou Shift))
                CancelarLinhaNova();
            }

        }

        private void CancelarLinhaNova()
        {
            if ((int)moedaDataGridView.CurrentRow.Cells["MoedaID"].Value < 0)
            {
                moedaDataGridView.Rows.Remove(moedaDataGridView.CurrentRow);
                CarregaMoedas();
            }
        }
    }
}
