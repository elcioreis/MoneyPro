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
    public partial class fmCalendario : MoneyPro.Base.fmBaseFerramentas
    {
        private int monthValue = 0;

        public fmCalendario()
        {
            InitializeComponent();
            SincronizaGrade();
        }

        private void SincronizaGrade()
        {
            if (monthCalendar.SelectionStart.Month != monthValue)
            {
                monthValue = monthCalendar.SelectionStart.Month;

                DateTime inicio = new DateTime(monthCalendar.SelectionStart.Year, monthCalendar.SelectionStart.Month, 1);

                CalendarioBLL bll = new CalendarioBLL();
                calendarioBindingSource.DataSource = bll.Listar(dataInicio: inicio, periodos: 12);

                DataTable tabela = (DataTable)calendarioBindingSource.DataSource;

                foreach (DataRow linha in tabela.Rows)
                {
                    monthCalendar.AddBoldedDate((DateTime)linha["Data"]);
                }

            }

        }

        private void panelRodape_Paint(object sender, PaintEventArgs e)
        {

        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            SincronizaGrade();
        }

        private void calendarioDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                // pega o número da coluna corrente
                int cell = calendarioDataGridView.CurrentCell.ColumnIndex;

                // pega o campo de dados associado a coluna
                string coluna = calendarioDataGridView.Columns[cell].DataPropertyName;

                if (coluna == "Descricao")
                {
                    // Recebe o sender como TextBox
                    TextBox textbox = (TextBox)sender;
                    // Aceita qualquer texto de 0 a 100 caracters
                    if (Regex.IsMatch(textbox.Text + e.KeyChar, "^.{0,50}$"))
                    {
                        Geral.Capitaliza(textbox);                     // Capitaliza o conteúdo do textbox
                    }
                    else
                    {
                        e.Handled = true;                              // não passou pela regex
                    }
                }
                else if (coluna == "Data")
                {
                    TextBox editingControl = (TextBox)sender;

                    if ((e.KeyChar == '+') || (e.KeyChar == '='))
                    {
                        // Se + ou = (dois valores da mesma tecla, mudados pelo shift)
                        // tenta avançar um dia na data
                        e.KeyChar = (char)Keys.None;
                        DateTime dt;
                        if (DateTime.TryParse(editingControl.Text, out dt))
                        {
                            dt = dt.AddDays(1);
                            editingControl.Text = dt.ToString().Substring(0, 10);
                            //dataGridViewMovimento.CurrentRow.Cells["Alterado"].Value = 1;
                            //                                dataGridViewMovimento.NotifyCurrentCellDirty(true);
                        }
                    }
                    else if ((e.KeyChar == '_') || (e.KeyChar == '-'))
                    {
                        // Se - ou _ (dois valores da mesma tecla, mudados pelo shift)
                        // tenta retroceder um dia na data
                        e.KeyChar = (char)Keys.None;
                        DateTime dt;
                        if (DateTime.TryParse(editingControl.Text, out dt))
                        {
                            dt = dt.AddDays(-1);
                            editingControl.Text = dt.ToString().Substring(0, 10);
                            //dataGridViewMovimento.CurrentRow.Cells["Alterado"].Value = 1;
                            //                                dataGridViewMovimento.NotifyCurrentCellDirty(true);
                        }
                    }
                    else
                    {
                        if (editingControl.Text == editingControl.SelectedText)
                        {
                            editingControl.Text = string.Empty;
                            editingControl.SelectionStart = editingControl.TextLength;
                            editingControl.SelectionLength = 0;
                        }

                        // Valida a data durante a digitação
                        e.Handled = !Geral.ValidarDataNaDigitacao(editingControl.Text + e.KeyChar);
                    }
                }
            }

        }

        private void fmCalendario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None && e.KeyCode == Keys.Insert)
            {
                // Se teclado insert chama rotina de inclusão com o dia de hoje
                IncluirFeriado(DateTime.Today);
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Delete)
            {
                // Se teclado ctrl + delete chama rotina de exclusão.
                //ExcluirConta();
            }
            else if (e.Modifiers == Keys.None && e.KeyCode == Keys.Escape)
            {
                // Se teclado Escape (sem modificadores (Alt ou Ctrl ou Shift))
                //CancelarLinhaNova();
            }
        }

        private void IncluirFeriado(DateTime data)
        {
            // Se a linha atual não for nula
            if (calendarioDataGridView.CurrentRow != null)
            {
                // Se a linha atual tiver índice menor que zero, o que indica que já há uma inclusão em curso.
                if ((int)calendarioDataGridView.CurrentRow.Cells["FeriadoID"].Value < 0)
                {
                    // Cancela a inclusão, pois índices menores que zero estão em inclusão
                    return;
                }
            }

            DataTable table = (DataTable)calendarioBindingSource.DataSource;
            DataRow row = table.NewRow();

            row["FeriadoID"] = CalendarioBLL.ProximoID;
            row["Dia"] = data.Day;
            row["Mes"] = data.Month;
            row["Ano"] = data.Year;
            row["Descricao"] = String.Empty;
            row["Data"] = data;
            row["Fixo"] = true;

            table.Rows.Add(row);

            calendarioDataGridView.Focus();

            int lin = calendarioDataGridView.Rows.Count - 1;
            int col = Geral.PrimeiraColunaVisivel(calendarioDataGridView);
            calendarioDataGridView.CurrentCell = calendarioDataGridView.Rows[lin].Cells[col];

        }

        private void calendarioDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            calendarioDataGridView.EditingControl.KeyPress += calendarioDataGridView_KeyPress;
        }

        private void monthCalendar_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            SincronizaGrade();
        }

        private void calendarioDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (calendarioDataGridView.RowCount > 0 && calendarioDataGridView.CurrentRow != null)
            {
                if (calendarioDataGridView.IsCurrentRowDirty && calendarioDataGridView.CurrentRow.Cells["FeriadoID"].Value != DBNull.Value)
                {
                    DataGridViewRow linha = calendarioDataGridView.CurrentRow;

                    Calendario feriado = new Calendario();

                    feriado.FeriadoID = (int)linha.Cells["FeriadoID"].Value;
                    feriado.Dia = ((DateTime)linha.Cells["Data"].Value).Day;
                    feriado.Mes = ((DateTime)linha.Cells["Data"].Value).Month;
                    feriado.Fixo = (bool)linha.Cells["Fixo"].Value;
                    feriado.Descricao = (string)linha.Cells["Descricao"].Value;

                    if ((bool)linha.Cells["Fixo"].Value)
                    {
                        feriado.Ano = null;
                    }
                    else
                    {
                        feriado.Ano = ((DateTime)linha.Cells["Data"].Value).Year;
                    }

                    CalendarioBLL bll = new CalendarioBLL();

                    if (bll.Validar(feriado))
                    {
                        // Passou pela validação, tentará gravar
                        int registro = bll.Gravar(feriado);
                        SincronizaGrade();
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
