using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyPro
{
    public partial class fmPrevisaoSaldoNegativo : Form
    {
        private FmPrincipal Origem;
        private int UsuarioID;
        private int DiasPrevisao;
        private int _X;
        private int _Y;
        public fmPrevisaoSaldoNegativo(FmPrincipal origem, int usuarioID, int diasPrevisao, int X, int Y)
        {
            InitializeComponent();
            this.Origem = origem;
            this.UsuarioID = usuarioID;
            this.DiasPrevisao = diasPrevisao;
            this._X = X;
            this._Y = Y;
        }

        private void FmPrevisaoSaldoNegativo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FmPrevisaoSaldoNegativo_Load(object sender, EventArgs e)
        {
            previsaoSaldoNegativoDataGridView.DataSource = Geral.ListarPrevisaoSaldoNegativo(UsuarioID, DiasPrevisao);
        }

        private void PrevisaoSaldoNegativoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.BackColor = e.CellStyle.SelectionBackColor = Color.Tomato; // Color.LightSalmon; // Color.Khaki; // SystemColors.AppWorkspace;
            e.CellStyle.ForeColor = e.CellStyle.SelectionForeColor = Color.Black;
        }

        private void PrevisaoSaldoNegativoDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int largura = 0;

            foreach (DataGridViewColumn col in previsaoSaldoNegativoDataGridView.Columns)
            {
                if (col.Visible)
                {
                    largura += col.Width + 1;
                }
            }

            this.Width = largura;
        }

        private void FmPrevisaoSaldoNegativo_Shown(object sender, EventArgs e)
        {
            this.Height = previsaoSaldoNegativoDataGridView.Rows.Count * 21 + (previsaoSaldoNegativoDataGridView.ColumnHeadersVisible ? 25 : 0);

            this.Left = _X + 1;
            this.Top = _Y - this.Height - 1;
        }


        private void PrevisaoSaldoNegativoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int contaID = 0;

            if (e.RowIndex >= 0)
            {
                contaID = (int)previsaoSaldoNegativoDataGridView.Rows[e.RowIndex].Cells["previsao_ContaID"].Value;
            }

            if (contaID > 0)
            {
                Origem.PosicionaRolDeContas(contaID);
                this.Close();
            }
        }

        internal void Posiciona(int x, int y)
        {
            this.Height = previsaoSaldoNegativoDataGridView.Rows.Count * 21 + (previsaoSaldoNegativoDataGridView.ColumnHeadersVisible ? 25 : 0);

            this.Left = x + 1;
            this.Top = y - this.Height - 1;
        }
    }
}
