using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace MoneyPro
{
    public partial class fmCarteiraListaMovimentosFundo : MoneyPro.Base.fmBaseTopoRodape
    {
        private Form Origem { get; set; }
        public int IdInvestimento { get; set; }
        private static fmCarteiraListaMovimentosFundo _singleton;

        #region Singleton


        private fmCarteiraListaMovimentosFundo(Form origem, int idInvestimento, string nomeInvestimento)
        {
            InitializeComponent();
            this.Origem = origem;
            this.Visible = false;

            IdInvestimento = idInvestimento;

            labelTopo.Text = "Movimentos de " + nomeInvestimento;
            ExibirMovimentosFundo(IdInvestimento);
        }

        private void ExibirMovimentosFundo(int idInvestimento)
        {
            CarteiraBLL bll = new CarteiraBLL();
            listaMovimentosFundoBindingSource.DataSource = bll.ListarMovimentosFundo(IdInvestimento);
            //investimentoDetalhesBindingSource.DataSource = bll.DetalheInvestimento(investimentoID);
        }

        public static fmCarteiraListaMovimentosFundo CreateInstance(Form origem, int idInvestimento, string nomeInvestimento)
        {
            if (_singleton == null)
            {
                _singleton = new fmCarteiraListaMovimentosFundo(origem, idInvestimento, nomeInvestimento);
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

        private void ButtonFecharDetalhes_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InvestimentoDetalhesDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                Byte tipoLinha = (Byte)investimentoDetalhesDataGridView.Rows[e.RowIndex].Cells["TipoLinha"].Value;

                if (tipoLinha == 1)
                {
                    //if (investimentoDetalhesDataGridView.Columns[e.ColumnIndex].Name == "Descricao")
                    if (investimentoDetalhesDataGridView.Columns[e.ColumnIndex].CellType == typeof(DataGridViewTextBoxCell))
                    {
                        if (investimentoDetalhesDataGridView.Columns[e.ColumnIndex].DefaultCellStyle.Alignment == DataGridViewContentAlignment.NotSet)
                        {
                            //  É uma linha de total
                            using (Font font = new Font(investimentoDetalhesDataGridView.DefaultCellStyle.Font.FontFamily, 8, FontStyle.Bold))
                            {
                                e.CellStyle.Font = font;
                            }
                        }
                    }
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Black;
                    e.CellStyle.SelectionForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.Black;
                }
            }
        }
    }
}
