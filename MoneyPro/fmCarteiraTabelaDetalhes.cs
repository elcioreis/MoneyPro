using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MoneyPro
{
    public partial class fmCarteiraTabelaDetalhes : MoneyPro.Base.fmBaseTopoRodape
    {
        private Form Origem { get; set; }
        public int IdInvestimento { get; set; }

        private int apurado = 0;

        #region Singleton

        private static fmCarteiraTabelaDetalhes _singleton;

        private fmCarteiraTabelaDetalhes(Form origem, int idInvestimento, string nomeInvestimento)
        {
            InitializeComponent();
            this.Origem = origem;
            this.Visible = false;

            IdInvestimento = idInvestimento;

            labelTopo.Text = "Detalhes de " + nomeInvestimento;
            ExibirDetalhesFundo(IdInvestimento);
        }

        public static fmCarteiraTabelaDetalhes CreateInstance(Form origem, int idInvestimento, string nomeInvestimento)
        {
            if (_singleton == null)
            {
                _singleton = new fmCarteiraTabelaDetalhes(origem, idInvestimento, nomeInvestimento);
            }
            return _singleton;
        }

        protected override void OnClosed(EventArgs e)
        {
            _singleton = null;
            base.OnClosed(e);
            Origem.WindowState = FormWindowState.Maximized;
        }

        #endregion Singleton

        #region Comportamental

        private void buttonFecharDetalhes_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Comportamental

        private void ExibirDetalhesFundo(int investimentoID)
        {
            CarteiraBLL bll = new CarteiraBLL();
            investimentoDetalhesBindingSource.DataSource = bll.DetalheInvestimento(investimentoID);
        }

        private void investimentoDetalhesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                // O campo total tem valor ZERO para não totais e UM para total (como se fosse boolean)
                Byte totalizador = (Byte)investimentoDetalhesDataGridView.Rows[e.RowIndex].Cells["Totalizador"].Value;

                // Totalizador == 0: Compra e venda de lotes
                // Totalizador == 1: Perda/Lucro apurado
                // Totalizador == 2: Saldo dos lotes disponíveis
                // Totalizador == 3: Total dos lotes disponíveis

                if (totalizador == 0)
                {
                    if (investimentoDetalhesDataGridView.Columns[e.ColumnIndex].Name == "VrLucroOuPerdaFormatado" ||
                        investimentoDetalhesDataGridView.Columns[e.ColumnIndex].Name == "PercLucroOuPerdaFormatado")
                    {
                        // usa a coluna VrLucroOuPerda pra saber a cor a pintar
                        Double? sinal = null;

                        if (investimentoDetalhesDataGridView.Rows[e.RowIndex].Cells["VrLucroOuPerda"].Value != DBNull.Value)
                        {
                            sinal = (Double)investimentoDetalhesDataGridView.Rows[e.RowIndex].Cells["VrLucroOuPerda"].Value;
                        }

                        if (sinal < 0)
                            e.CellStyle.ForeColor = Color.Red;
                        else
                            e.CellStyle.ForeColor = Color.Black;
                    }

                }
                if (totalizador == 1 || totalizador == 3)
                {

                    if (totalizador == 1)
                    {
                        apurado = e.RowIndex % 2 + 1;
                    }

                    if (investimentoDetalhesDataGridView.Columns[e.ColumnIndex].Name == "Transacao")
                    {
                        //  É uma linha de total
                        using (Font font = new Font(investimentoDetalhesDataGridView.DefaultCellStyle.Font.FontFamily, 8, FontStyle.Bold))
                        {
                            e.CellStyle.Font = font;
                        }
                    }

                    e.CellStyle.BackColor = Color.Black;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (totalizador == 2)
                {
                    Boolean positivo = ((Double)investimentoDetalhesDataGridView.Rows[e.RowIndex].Cells["VrLucroOuPerda"].Value >= 0);

                    if ((e.RowIndex + apurado) % 2 == 0)
                        e.CellStyle.BackColor = Color.WhiteSmoke;
                    else
                        e.CellStyle.BackColor = Color.Gainsboro;

                    if (positivo)
                    {
                        e.CellStyle.ForeColor = Color.Green;
                        e.CellStyle.SelectionForeColor = Color.Lime;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Tomato;
                    }
                }

                if (investimentoDetalhesDataGridView.Columns[e.ColumnIndex].Name == "Indicador")
                {
                    // usa a coluna VrLucroOuPerda pra saber a cor a pintar
                    Double? sinal = null;

                    if (investimentoDetalhesDataGridView.Rows[e.RowIndex].Cells["VrLucroOuPerda"].Value != DBNull.Value)
                    {
                        sinal = (Double)investimentoDetalhesDataGridView.Rows[e.RowIndex].Cells["VrLucroOuPerda"].Value;
                    }

                    if (sinal == null)
                        e.CellStyle.ForeColor = Color.Black;
                    else if (sinal > 0)
                        e.CellStyle.ForeColor = Color.LimeGreen;
                    else if (sinal < 0)
                        e.CellStyle.ForeColor = Color.Red;
                    else
                        e.CellStyle.ForeColor = Color.Blue;
                }
            }
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
    }
}
