using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelos;
using MoneyPro.Base;
using BLL;
using System.Text.RegularExpressions;

namespace MoneyPro
{
    public partial class fmInvestimentoDespesas : MoneyPro.Base.fmBaseFerramentas
    {
        private int IDInvestimento { get; set; }
        private int IDUsuario { get; set; }
        public fmInvestimentoDespesas(int investimentoID)
        {
            InitializeComponent();
            this.IDInvestimento = investimentoID;
            this.IDUsuario = Geral.UserID;
            CarregaDados(investimentoID);
        }

        private void CarregaDados(int investimentoID)
        {
            CriaColunaCategoria();
            CriaColunaImposto();
            CarregaInvestimentoDespesas(investimentoID);
        }

        private void CriaColunaCategoria()
        {
            string nomeColuna = "Categoria";

            // Cria uma nova colluna do tipo ComboBox
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Name = nomeColuna;
            combo.DataPropertyName = "CategoriaID";
            combo.DisplayMember = "vFiltro";
            combo.ValueMember = "CategoriaID";
            combo.HeaderText = "Categoria";
            combo.SortMode = DataGridViewColumnSortMode.Automatic;
            // Atributos de formato
            combo.FlatStyle = FlatStyle.Flat;
            combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            combo.AutoComplete = true;
            combo.Width = 150;
            combo.FillWeight = 150;
            combo.MinimumWidth = 100;

            // Acha a posição da coluna numérica e coloca o combobox junto, deixando a coluna numérica invisível.
            int index = investimentoDespesaDataGridView.Columns["CategoriaID"].Index;
            investimentoDespesaDataGridView.Columns[index].Visible = false;
            investimentoDespesaDataGridView.Columns.Insert(index, combo);

            CategoriaBLL bll = new CategoriaBLL();
            combo.DataSource = bll.ListarSelecionaveis(IDUsuario, 2);
        }

        private void CriaColunaImposto()
        {
            string nomeColuna = "Imposto";

            // Cria uma nova colluna do tipo ComboBox
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Name = nomeColuna;
            combo.DataPropertyName = "ImpostoID";
            combo.DisplayMember = "Apelido";
            combo.ValueMember = "ImpostoID";
            combo.HeaderText = "Imposto";
            combo.SortMode = DataGridViewColumnSortMode.Automatic;
            // Atributos de formato
            combo.FlatStyle = FlatStyle.Flat;
            combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            combo.AutoComplete = true;
            combo.Width = 150;
            combo.FillWeight = 150;
            combo.MinimumWidth = 100;

            // Acha a posição da coluna numérica e coloca o combobox junto, deixando a coluna numérica invisível.
            int index = investimentoDespesaDataGridView.Columns["ImpostoID"].Index;
            investimentoDespesaDataGridView.Columns[index].Visible = false;
            investimentoDespesaDataGridView.Columns.Insert(index, combo);

            ImpostoBLL bll = new ImpostoBLL();
            combo.DataSource = bll.Listar();
        }

        private void CarregaInvestimentoDespesas(int investimentoID)
        {
            investimentoDespesaDataGridView.RowValidating -= investimentoDespesaDataGridView_RowValidating;

            InvestimentoDespesaBLL bll = new InvestimentoDespesaBLL();
            investimentoDespesaBindingSource.DataSource = bll.Listar(investimentoID);

            investimentoDespesaDataGridView.RowValidating += investimentoDespesaDataGridView_RowValidating;
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            IncluirInvestimentoDespesa();
        }

        private void IncluirInvestimentoDespesa()
        {
            if (investimentoDespesaDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)investimentoDespesaDataGridView.CurrentRow.Cells["InvestimentoDespesaID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)investimentoDespesaBindingSource.DataSource;
            DataRow row = table.NewRow();

            row["InvestimentoDespesaID"] = InvestimentoDespesaBLL.ProximoID;
            row["InvestimentoID"] = this.IDInvestimento;
            row["Descricao"] = string.Empty;
            row["IOF"] = false;
            row["IR"] = false;
            row["Entrada"] = false;
            row["Saida"] = true;
            row["ComeCota"] = false;
            row["Ordem"] = table.Rows.Count + 1;

            table.Rows.Add(row);

            investimentoDespesaDataGridView.Focus();

            int lin = investimentoDespesaDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(investimentoDespesaDataGridView);
            investimentoDespesaDataGridView.CurrentCell = investimentoDespesaDataGridView.Rows[lin].Cells[col];
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            ExcluirInvestimentoDespesa();
        }

        private void ExcluirInvestimentoDespesa()
        {
            if (investimentoDespesaDataGridView.CurrentRow != null)
            {
                string msg = string.Format("Confirma a exclusão da despesa de investimento?");

                DialogResult dr = MessageBox.Show(msg, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    InvestimentoDespesaBLL bll = new InvestimentoDespesaBLL();
                    bll.Excluir((int)investimentoDespesaDataGridView.CurrentRow.Cells["InvestimentoDespesaID"].Value);
                    CarregaInvestimentoDespesas(this.IDInvestimento);
                }
            }
        }

        private void fmInvestimentoDespesas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
            {
                // Se teclado insert chama rotina de inclusão.
                IncluirInvestimentoDespesa();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
            {
                // Se teclado ctrl + delete chama rotina de exclusão.
                ExcluirInvestimentoDespesa();
            }
            else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
            {
                // Se teclado Escape (sem modificadores (Alt ou Ctrl ou Shift))
                CancelarLinhaNova();
            }

        }

        private void CancelarLinhaNova()
        {
            if (investimentoDespesaDataGridView.CurrentRow != null)
            {
                if ((int)investimentoDespesaDataGridView.CurrentRow.Cells["InvestimentoDespesaID"].Value < 0)
                {
                    investimentoDespesaDataGridView.Rows.Remove(investimentoDespesaDataGridView.CurrentRow);
                }
            }
        }

        private void investimentoDespesaDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = investimentoDespesaDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = investimentoDespesaDataGridView.Columns[cell].DataPropertyName;

                if (coluna == "Descricao")
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
            }
        }

        private void investimentoDespesaDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (investimentoDespesaDataGridView.RowCount > 0 && investimentoDespesaDataGridView.CurrentRow != null)
            {
                if (investimentoDespesaDataGridView.IsCurrentRowDirty || (int)investimentoDespesaDataGridView.CurrentRow.Cells["InvestimentoDespesaID"].Value < 0)
                {
                    DataGridViewRow linha = investimentoDespesaDataGridView.CurrentRow;

                    InvestimentoDespesa modelo = new InvestimentoDespesa();

                    modelo.InvestimentoDespesaID = (int)linha.Cells["InvestimentoDespesaID"].Value;
                    modelo.InvestimentoID = (int)linha.Cells["InvestimentoID"].Value;

                    if (linha.Cells["Categoria"].Value != DBNull.Value)
                        modelo.CategoriaID = (int)linha.Cells["Categoria"].Value;
                    else
                        modelo.CategoriaID = null;

                    if (linha.Cells["Descricao"].Value != DBNull.Value)
                        modelo.Descricao = (string)linha.Cells["Descricao"].Value;
                    else
                        modelo.Descricao = null;

                    modelo.Entrada = (bool)linha.Cells["Entrada"].Value;
                    modelo.Saida = (bool)linha.Cells["Saida"].Value;
                    modelo.IR = (bool)linha.Cells["IR"].Value;
                    modelo.IOF = (bool)linha.Cells["IOF"].Value;
                    modelo.ComeCota = (bool)linha.Cells["ComeCota"].Value;

                    if (linha.Cells["Ordem"].Value != DBNull.Value)
                        modelo.Ordem = (int)linha.Cells["Ordem"].Value;
                    else
                        modelo.Ordem = null;

                    if (linha.Cells["Imposto"].Value != DBNull.Value)
                        modelo.ImpostoID = (int)linha.Cells["Imposto"].Value;
                    else
                        modelo.ImpostoID = null;

                    InvestimentoDespesaBLL bll = new InvestimentoDespesaBLL();

                    if (bll.Validar(modelo))
                    {
                        try
                        {
                            int registro = bll.Gravar(modelo);
                            CarregaInvestimentoDespesas(this.IDInvestimento);
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
