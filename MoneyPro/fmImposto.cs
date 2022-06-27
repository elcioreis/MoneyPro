using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using Modelos;
using System.Text.RegularExpressions;

namespace MoneyPro
{
    public partial class fmImposto : MoneyPro.Base.fmBaseTopoRodape
    {

        private DataGridView ultimo = null;

        public fmImposto()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CarregarImposto();
            CarregarFaixa();
        }

        private void CarregarImposto()
        {
            impostoDataGridView.CellEnter -= impostoDataGridView_CellEnter;
            impostoDataGridView.RowValidating -= impostoDataGridView_RowValidating;

            ImpostoBLL bll = new ImpostoBLL();
            impostoBindingSource.DataSource = bll.Listar();

            impostoDataGridView.RowValidating += impostoDataGridView_RowValidating;
            impostoDataGridView.CellEnter += impostoDataGridView_CellEnter;
        }

        private void fmImposto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
            {
                // Se teclado insert chama rotina de inclusão.

                if (ultimo == impostoDataGridView)
                {
                    IncluirImposto();
                }
                else if (ultimo == impostoFaixaDataGridView)
                {
                    IncluirFaixa();
                }

            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
            {
                // Se teclado ctrl + delete chama rotina de exclusão.
                if (ultimo == impostoDataGridView)
                {
                    ExcluirImposto();
                }
                else if (ultimo == impostoFaixaDataGridView)
                {
                    ExcluirFaixa();
                }
            }
            else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
            {
                // Se teclado Escape (sem modificadores (Alt ou Ctrl ou Shift))
                if (ultimo == impostoDataGridView)
                {
                    CancelarLinhaNovaImposto();
                }
                else if (ultimo == impostoFaixaDataGridView)
                {
                    CancelarLinhaNovaFaixa();
                }
            }
        }

        private void CancelarLinhaNovaFaixa()
        {
            if (impostoFaixaDataGridView.CurrentRow != null)
            {
                if ((int)impostoFaixaDataGridView.CurrentRow.Cells["FaixaFaixaID"].Value < 0)
                {
                    impostoFaixaDataGridView.Rows.Remove(impostoFaixaDataGridView.CurrentRow);
                }
            }
        }

        private void CancelarLinhaNovaImposto()
        {
            if (impostoDataGridView.CurrentRow != null)
            {
                if ((int)impostoDataGridView.CurrentRow.Cells["ImpostoImpostoID"].Value < 0)
                {
                    impostoDataGridView.Rows.Remove(impostoDataGridView.CurrentRow);
                }
            }
        }

        private void IncluirImposto()
        {
            if (impostoDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)impostoDataGridView.CurrentRow.Cells["ImpostoImpostoID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)impostoBindingSource.DataSource;
            DataRow row = table.NewRow();

            row["ImpostoID"] = ImpostoBLL.ProximoID;
            row["Apelido"] = String.Empty;
            row["Descricao"] = String.Empty;
            row["Ativo"] = true;

            table.Rows.Add(row);

            impostoDataGridView.Focus();

            int lin = impostoDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(impostoDataGridView);
            impostoDataGridView.CurrentCell = impostoDataGridView.Rows[lin].Cells[col];
        }

        private void impostoDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (impostoDataGridView.RowCount > 0 && impostoDataGridView.CurrentRow != null)
            {
                if (impostoDataGridView.CurrentRow.Cells["ImpostoImpostoID"].Value != null)
                {
                    if (impostoDataGridView.IsCurrentRowDirty || (int)impostoDataGridView.CurrentRow.Cells["ImpostoImpostoID"].Value < 0)
                    {
                        DataGridViewRow linha = impostoDataGridView.CurrentRow;

                        Imposto modelo = new Imposto();

                        modelo.ImpostoID = (int)linha.Cells["ImpostoImpostoID"].Value;

                        if (linha.Cells["ImpostoApelido"].Value != DBNull.Value)
                            modelo.Apelido = (string)linha.Cells["ImpostoApelido"].Value;
                        else
                            modelo.Apelido = null;

                        if (linha.Cells["ImpostoDescricao"].Value != DBNull.Value)
                            modelo.Descricao = (string)linha.Cells["ImpostoDescricao"].Value;
                        else
                            modelo.Descricao = null;

                        modelo.Ativo = (bool)linha.Cells["ImpostoAtivo"].Value;

                        ImpostoBLL bll = new ImpostoBLL();

                        if (bll.Validar(modelo))
                        {
                            try
                            {
                                int registro = bll.Gravar(modelo);
                                CarregarImposto();
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

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            if (ultimo == impostoDataGridView)
            {
                IncluirImposto();
            }
            else if (ultimo == impostoFaixaDataGridView)
            {
                IncluirFaixa();
            }
        }

        private void IncluirFaixa()
        {
            // O imposto (parte superior) tem que estar selecionado para se cadastrar as faixas.
            // Não pode ser um imposto ainda não gravado no banco (id < 0).
            if (impostoDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)impostoDataGridView.CurrentRow.Cells["ImpostoImpostoID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            if (impostoFaixaDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)impostoFaixaDataGridView.CurrentRow.Cells["FaixaFaixaID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)impostoFaixaBindingSource.DataSource;
            DataRow row = table.NewRow();

            row["FaixaID"] = ImpostoFaixaBLL.ProximoID;
            row["ImpostoID"] = (int)impostoDataGridView.CurrentRow.Cells["ImpostoImpostoID"].Value;
            row["Apelido"] = String.Empty;
            row["Dias"] = DBNull.Value;
            row["Porcentagem"] = DBNull.Value;

            table.Rows.Add(row);

            impostoFaixaDataGridView.Focus();

            int lin = impostoFaixaDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(impostoFaixaDataGridView);
            impostoFaixaDataGridView.CurrentCell = impostoFaixaDataGridView.Rows[lin].Cells[col];
        }

        private void ExcluirImposto()
        {
            if (impostoDataGridView.CurrentRow != null)
            {
                string msg = string.Format("Confirma a exclusão do imposto {0}?", (string)impostoDataGridView.CurrentRow.Cells["ImpostoApelido"].Value);

                DialogResult dr = MessageBox.Show(msg, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    ImpostoBLL bll = new ImpostoBLL();
                    bll.Excluir((int)impostoDataGridView.CurrentRow.Cells["ImpostoImpostoID"].Value);
                    CarregarImposto();
                }
            }
        }

        private void impostoDataGridView_Enter(object sender, EventArgs e)
        {
            ultimo = impostoDataGridView;
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            if (ultimo == impostoDataGridView)
            {
                ExcluirImposto();
            }
            else if (ultimo == impostoFaixaDataGridView)
            {
                ExcluirFaixa();
            }
        }

        private void ExcluirFaixa()
        {
            throw new NotImplementedException();
        }

        private void impostoDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            impostoDataGridView.EditingControl.KeyPress += impostoDataGridView_KeyPress;
        }

        private void impostoDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = impostoDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = impostoDataGridView.Columns[cell].DataPropertyName;

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

        private void impostoFaixaDataGridView_Enter(object sender, EventArgs e)
        {
            ultimo = impostoFaixaDataGridView;
        }

        private void impostoDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CarregarFaixa();
        }

        private void CarregarFaixa()
        {
            impostoFaixaDataGridView.RowValidating -= impostoFaixaDataGridView_RowValidating;
            if (impostoDataGridView.CurrentRow != null)
            {
                groupBoxFaixas.Text = "Faixas de " + (string)impostoDataGridView.CurrentRow.Cells["ImpostoApelido"].Value;

                ImpostoFaixaBLL bll = new ImpostoFaixaBLL();
                impostoFaixaBindingSource.DataSource = bll.Listar((int)impostoDataGridView.CurrentRow.Cells["ImpostoImpostoID"].Value);
            }
            else
            {
                groupBoxFaixas.Text = "Faixas";

                // Carrega a tabela com imposto = 0 para ter os campos definidos.
                ImpostoFaixaBLL bll = new ImpostoFaixaBLL();
                impostoFaixaBindingSource.DataSource = bll.Listar(0);
            }
            impostoFaixaDataGridView.RowValidating += impostoFaixaDataGridView_RowValidating;
        }

        private void impostoFaixaDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (impostoFaixaDataGridView.RowCount > 0 && impostoFaixaDataGridView.CurrentRow != null)
            {
                if (impostoFaixaDataGridView.CurrentRow.Cells["FaixaFaixaID"].Value != null)
                {
                    if (impostoFaixaDataGridView.IsCurrentRowDirty || (int)impostoFaixaDataGridView.CurrentRow.Cells["FaixaFaixaID"].Value < 0)
                    {
                        DataGridViewRow linha = impostoFaixaDataGridView.CurrentRow;

                        ImpostoFaixa modelo = new ImpostoFaixa();

                        modelo.FaixaID = (int)linha.Cells["FaixaFaixaID"].Value;
                        modelo.ImpostoID = (int)linha.Cells["FaixaImpostoID"].Value;

                        if (linha.Cells["FaixaApelido"].Value != DBNull.Value)
                            modelo.Apelido = (string)linha.Cells["FaixaApelido"].Value;
                        else
                            modelo.Apelido = null;

                        if (linha.Cells["FaixaDias"].Value != DBNull.Value)
                            modelo.Dias = (int)linha.Cells["FaixaDias"].Value;
                        else
                            modelo.Dias = null;

                        if (linha.Cells["FaixaPorcentagem"].Value != DBNull.Value)
                            modelo.Porcentagem = (decimal)linha.Cells["FaixaPorcentagem"].Value;
                        else
                            modelo.Porcentagem = null;

                        ImpostoFaixaBLL bll = new ImpostoFaixaBLL();

                        if (bll.Validar(modelo))
                        {
                            try
                            {
                                int registro = bll.Gravar(modelo);
                                CarregarFaixa();
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

        private void impostoFaixaDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            impostoFaixaDataGridView.EditingControl.KeyPress += impostoFaixaDataGridView_KeyPress;

        }

        private void impostoFaixaDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = impostoFaixaDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = impostoFaixaDataGridView.Columns[cell].DataPropertyName;

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
                else if (coluna == "Dias")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer número inteiro positivo até 4 algarismos (de 0 até 9999)
                    if (!Regex.IsMatch(textbox.Text + e.KeyChar, "^[0-9]{0,4}$"))
                    {
                        e.Handled = true;    // Não passou pelo regex
                    }
                }
                else if (coluna == "Porcentagem")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer número positivo com três inteiros e dois decimais (de 0,00 até 100,00)
                    if (!Regex.IsMatch(textbox.Text + e.KeyChar, "^[0-9]{0,3}((,[0-9]{0,2})|())$"))
                    {
                        e.Handled = true;    // Não passou pelo regex
                    }

                }
            }

        }
    }
}
