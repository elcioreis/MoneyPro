using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelos;
using BLL;

namespace MoneyPro
{
    public partial class fmSaldoFuturo : MoneyPro.Base.fmBaseTopoRodape
    {
        private int UsuarioID { get; set; }

        #region Singleton

        private static fmSaldoFuturo _singleton;

        private fmSaldoFuturo(int usuarioID)
        {
            InitializeComponent();
            this.UsuarioID = usuarioID;
        }

        public static fmSaldoFuturo CreateInstance(int usuarioID)
        {
            if (_singleton == null)
            {
                _singleton = new fmSaldoFuturo(usuarioID);
            }
            return _singleton;
        }

        protected override void OnClosed(EventArgs e)
        {
            _singleton = null;
            base.OnClosed(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CarregaDados(UsuarioID);
        }

        #endregion Singleton

        private void CarregaDados(int usuarioID)
        {
            //saldoFuturoDataGridView.RowValidating -= SaldoFuturoDataGridView_RowValidating;

            SaldoFuturoBLL bll = new SaldoFuturoBLL();
            saldoFuturoDataGridView.DataSource = bll.Listar(usuarioID);

            //saldoFuturoDataGridView.RowValidating += SaldoFuturoDataGridView_RowValidating;
        }

        private void SaldoFuturoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                // Lê o nível da linha
                //   0 detalhe da conta
                //   1 cabeçalho com total do grupo de contas
                // 999 total geral
                int nivel = (int)saldoFuturoDataGridView.Rows[e.RowIndex].Cells["Nivel"].Value;

                if (nivel == 0)
                {
                    //   0 detalhe da conta                   

                    bool Positivo = true;

                    string Campo = saldoFuturoDataGridView.Columns[e.ColumnIndex].Name;

                    if ((Campo == "SaldoAtual") || (Campo == "DebitosFuturos") ||
                        (Campo == "CreditosFuturos") || (Campo == "SaldoPrevisto"))
                    {
                        Positivo = (decimal)saldoFuturoDataGridView.Rows[e.RowIndex].Cells[Campo].Value >= 0;
                    }

                    e.CellStyle.ForeColor = Positivo ? Color.Black : Color.Red;
                    e.CellStyle.SelectionForeColor = Positivo ? Color.Black : Color.Red;

                }
                else if (nivel == 1)
                {
                    //   1 cabeçalho com total do grupo de contas

                    if ((saldoFuturoDataGridView.Columns[e.ColumnIndex].Name == "Tipo") ||
                        (saldoFuturoDataGridView.Columns[e.ColumnIndex].Name == "Descricao"))
                    {
                        using (Font font = new Font(saldoFuturoDataGridView.DefaultCellStyle.Font.FontFamily, 8, FontStyle.Bold))
                        {
                            e.CellStyle.Font = font;
                        }
                    }

                    bool Positivo = true;

                    string Campo = saldoFuturoDataGridView.Columns[e.ColumnIndex].Name;

                    if ((Campo == "SaldoAtual") || (Campo == "DebitosFuturos") ||
                        (Campo == "CreditosFuturos") || (Campo == "SaldoPrevisto"))
                    {
                        Positivo = (decimal)saldoFuturoDataGridView.Rows[e.RowIndex].Cells[Campo].Value >= 0;
                    }

                    e.CellStyle.ForeColor = Positivo ? Color.Black : Color.Red;
                    e.CellStyle.BackColor = Color.DarkGray;
                    e.CellStyle.SelectionForeColor = Positivo ? Color.Black : Color.Red;
                    e.CellStyle.SelectionBackColor = Color.DarkGray;
                }
                else
                {
                    // 999 total geral

                    if (saldoFuturoDataGridView.Columns[e.ColumnIndex].Name == "Tipo")
                    {
                        using (Font font = new Font(saldoFuturoDataGridView.DefaultCellStyle.Font.FontFamily, 8, FontStyle.Bold))
                        {
                            e.CellStyle.Font = font;
                        }
                    }

                    bool Positivo = true;

                    string Campo = saldoFuturoDataGridView.Columns[e.ColumnIndex].Name;

                    if ((Campo == "SaldoAtual") || (Campo == "DebitosFuturos") ||
                        (Campo == "CreditosFuturos") || (Campo == "SaldoPrevisto"))
                    {
                        Positivo = (decimal)saldoFuturoDataGridView.Rows[e.RowIndex].Cells[Campo].Value >= 0;
                    }

                    e.CellStyle.ForeColor = Positivo ? Color.White : Color.Gold;
                    e.CellStyle.BackColor = Color.Black;
                    e.CellStyle.SelectionForeColor = Positivo ? Color.White : Color.Gold;
                    e.CellStyle.SelectionBackColor = Color.Black;
                }
            }
        }
    }
}
