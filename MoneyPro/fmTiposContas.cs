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
    public partial class fmTiposContas : MoneyPro.Base.fmBaseTopoRodape
    {
        private int _usuarioID;
        public fmTiposContas()
        {
            InitializeComponent();
            _usuarioID = Geral.UserID;
            CarregarDados();
        }

        private void CarregarDados()
        {
            CarregarTipoConta();
            CarregarGrupoConta();
        }

        private void CarregarGrupoConta()
        {
            GrupoContaBLL grupoConta = new GrupoContaBLL();

            // Cria uma nova colluna do tipo ComboBox
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.Name = "GrupoConta";
            combo.DataSource = grupoConta.Listar(_usuarioID);
            combo.DataPropertyName = "GrupoContaID";
            combo.DisplayMember = "Apelido";
            combo.ValueMember = "GrupoContaID";
            combo.HeaderText = "Grupo de Conta";
            combo.SortMode = DataGridViewColumnSortMode.Automatic;
            // Atributos de formato
            combo.FlatStyle = FlatStyle.Flat;
            combo.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            combo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            combo.AutoComplete = true;
            combo.Width = 180;
            combo.FillWeight = 180;
            combo.MinimumWidth = 120;

            if (!tipoContaDataGridView.Columns.Contains("GrupoConta"))
            {
                // Acha a posição da coluna numérica e coloca o combobox junto, deixando a coluna numérica invisível.
                int index = tipoContaDataGridView.Columns["GrupoContaID"].Index;
                tipoContaDataGridView.Columns[index].Visible = false;
                tipoContaDataGridView.Columns.Insert(index, combo);
            }
            else
            {
                int index = tipoContaDataGridView.Columns["GrupoConta"].Index;
                tipoContaDataGridView.Columns.RemoveAt(index);
                tipoContaDataGridView.Columns.Insert(index, combo);
            }
        }

        private void RecarregaGrupoConta()
        {
            DataGridViewComboBoxColumn combo = (DataGridViewComboBoxColumn)tipoContaDataGridView.Columns["GrupoConta"];

            GrupoContaBLL bll = new GrupoContaBLL();
            combo.DataSource = bll.Listar(_usuarioID);
        }

        private void CarregarTipoConta()
        {
            tipoContaDataGridView.RowValidating -= tipoContaDataGridView_RowValidating;

            TipoContaBLL tipoConta = new TipoContaBLL();
            tipoContaBindingSource.DataSource = tipoConta.Listar(_usuarioID);

            tipoContaDataGridView.RowValidating += tipoContaDataGridView_RowValidating;
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void btnGruposContas_Click(object sender, EventArgs e)
        {
            fmGruposContas grupos = new fmGruposContas();
            grupos.ShowDialog();
            RecarregaGrupoConta();
        }

        private void buttonIncluir_Click(object sender, EventArgs e)
        {
            IncluirTipoConta();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            ExcluirTipoConta();
        }

        private void IncluirTipoConta()
        {
            // Se a linha atual não for nula
            if (tipoContaDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)tipoContaDataGridView.CurrentRow.Cells["TipoContaID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)tipoContaBindingSource.DataSource;
            DataRow row = table.NewRow();

            row["TipoContaID"] = TipoContaBLL.ProximoID;
            row["GrupoContaID"] = DBNull.Value;
            row["UsuarioID"] = _usuarioID;
            row["Apelido"] = String.Empty;
            row["Descricao"] = String.Empty;
            row["Banco"] = false;
            row["Cartao"] = false;
            row["Investimento"] = false;
            row["Poupanca"] = false;
            row["Cambio"] = false;
            row["CDB"] = false;
            row["Ativo"] = true;

            table.Rows.Add(row);

            tipoContaDataGridView.Focus();

            int lin = tipoContaDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(tipoContaDataGridView);
            tipoContaDataGridView.CurrentCell = tipoContaDataGridView.Rows[lin].Cells[col];
        }

        private void ExcluirTipoConta()
        {
            if (tipoContaDataGridView.CurrentRow != null)
            {
                string msg = String.Format("Deseja excluir o tipo de contas {0}?", (string)tipoContaDataGridView.CurrentRow.Cells["Apelido"].Value);

                DialogResult dr = MessageBox.Show(msg, "Confirma",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question,
                                                  MessageBoxDefaultButton.Button2);

                if (dr == DialogResult.Yes)
                {
                    TipoContaBLL obj = new TipoContaBLL();
                    obj.Excluir((int)tipoContaDataGridView.CurrentRow.Cells["TipoContaID"].Value);
                    CarregarTipoConta();
                }
            }
        }

        private void fmTiposContas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
            {
                // Se teclado insert chama rotina de inclusão.
                IncluirTipoConta();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
            {
                // Se teclado ctrl + delete chama rotina de exclusão.
                ExcluirTipoConta();
            }
            else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
            {
                // Se teclado Escape (sem modificadores (Alt ou Ctrl ou Shift))
                CancelarLinhaNova();
            }
        }

        private void CancelarLinhaNova()
        {
            if ((int)tipoContaDataGridView.CurrentRow.Cells["TipoContaID"].Value < 0)
            {
                tipoContaDataGridView.Rows.Remove(tipoContaDataGridView.CurrentRow);
                CarregarTipoConta();
            }
        }

        private void tipoContaDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (tipoContaDataGridView.RowCount > 0 && tipoContaDataGridView.CurrentRow != null)
            {
                if (tipoContaDataGridView.IsCurrentRowDirty || (int)tipoContaDataGridView.CurrentRow.Cells["TipoContaID"].Value < 0)
                {
                    DataGridViewRow linha = tipoContaDataGridView.CurrentRow;

                    TipoConta tipoConta = new TipoConta();

                    tipoConta.TipoContaID = (int)linha.Cells["TipoContaID"].Value;
                    if (linha.Cells["GrupoConta"].Value != DBNull.Value)
                    {
                        tipoConta.GrupoContaID = (int)linha.Cells["GrupoConta"].Value;
                    }
                    else
                    {
                        tipoConta.GrupoContaID = null;
                    }
                    tipoConta.UsuarioID = (int)linha.Cells["UsuarioID"].Value;
                    tipoConta.Apelido = (string)linha.Cells["Apelido"].Value;
                    tipoConta.Descricao = (string)linha.Cells["Descricao"].Value;
                    tipoConta.Banco = (bool)linha.Cells["Banco"].Value;
                    tipoConta.Cartao = (bool)linha.Cells["Cartao"].Value;
                    tipoConta.Investimento = (bool)linha.Cells["Investimento"].Value;
                    tipoConta.Poupanca = (bool)linha.Cells["Poupanca"].Value;
                    tipoConta.Cambio = (bool)linha.Cells["Cambio"].Value;
                    tipoConta.CDB = (bool)linha.Cells["CDB"].Value;
                    tipoConta.Ativo = (bool)linha.Cells["Ativo"].Value;

                    TipoContaBLL bll = new TipoContaBLL();

                    if (bll.Validar(tipoConta))
                    {
                        // Passou pela validação, tentará gravar
                        int registro = bll.Gravar(tipoConta);
                        CarregarTipoConta();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void tipoContaDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = tipoContaDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = tipoContaDataGridView.Columns[cell].DataPropertyName;

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

        private void tipoContaDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            tipoContaDataGridView.EditingControl.KeyPress += tipoContaDataGridView_KeyPress;
        }
    }
}
