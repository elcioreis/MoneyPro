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
    public partial class fmDetalhesMovimentacao : MoneyPro.Base.fmBaseTopoRodape
    {
        private Form Origem { get; set; }

        #region Singleton

        private static fmDetalhesMovimentacao _singleton;

        private fmDetalhesMovimentacao(Form origem, string titulo, int usuarioID, int? contaID, int? lancamentoID, int? categoriaID, int? grupoCategoriaID)
        {
            InitializeComponent();
            this.Origem = origem;
            labelTopo.Text = titulo;

            CarregarDetalhesMovimentacao(usuarioID, contaID, lancamentoID, categoriaID, grupoCategoriaID);
        }

        public static fmDetalhesMovimentacao CreateInstance(Form origem, string titulo, int usuarioID, int? contaID, int? lancamentoID, int? categoriaID, int? grupoCategoriaID)
        {
            if (_singleton == null)
            {
                _singleton = new fmDetalhesMovimentacao(origem, titulo, usuarioID, contaID, lancamentoID, categoriaID, grupoCategoriaID);
            }
            return _singleton;
        }

        protected override void OnClosed(EventArgs e)
        {
            _singleton = null;
            base.OnClosed(e);
        }

        #endregion Singleton

        private void CarregarDetalhesMovimentacao(int usuarioID, int? contaID, int? lancamentoID, int? categoriaID, int? grupoCategoriaID)
        {
            DetalhesMovimentacaoBLL bll = new DetalhesMovimentacaoBLL();
            detalhesMovimentacaoBindingSource.DataSource = bll.Listar(usuarioID, contaID, lancamentoID, categoriaID, grupoCategoriaID);
        }

        private void fmDetalhes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Origem.WindowState = FormWindowState.Maximized;
        }

        private void buttonFecharDetalhes_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void detalhesMovimentacaoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (detalhesMovimentacaoDataGridView.CurrentRow != null)
            {
                if (e.Value != null)
                {
                    if (detalhesMovimentacaoDataGridView.Columns[e.ColumnIndex].Name == "Conciliacao")
                    {
                        try
                        {
                            string txt = (string)e.Value;

                            if (txt == "C")
                                e.CellStyle.ForeColor = Color.Blue;
                            else if (txt == "R")
                                e.CellStyle.ForeColor = Color.Green;

                            if (txt != " ")
                                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        }
                        catch
                        {
                            // não faz nada.
                        }
                    }
                }
            }
        }
    }
}
