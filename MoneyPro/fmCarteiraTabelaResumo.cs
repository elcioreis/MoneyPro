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
    public partial class fmCarteiraTabelaResumo : MoneyPro.Base.fmBaseTopoRodape
    {
        private Form Origem { get; set; }
        public int IdInvestimento { get; set; }

        private const int tipoInformacao = 0;

        #region Singleton

        private static fmCarteiraTabelaResumo _singleton;

        private fmCarteiraTabelaResumo(Form origem, int idInvestimento, string nomeInvestimento)
        {
            InitializeComponent();
            this.Origem = origem;
            this.Visible = false;

            IdInvestimento = idInvestimento;
            dateTimePickerDia.Value = DateTime.Today;

            labelTopo.Text = "Resumo de " + nomeInvestimento;
            ExibirResumoFundo(IdInvestimento);
        }

        public static fmCarteiraTabelaResumo CreateInstance(Form origem, int idInvestimento, string nomeInvestimento)
        {
            if (_singleton == null)
            {
                _singleton = new fmCarteiraTabelaResumo(origem, idInvestimento, nomeInvestimento);
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

        private void buttonFecharDetalhes_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExibirResumoFundo(int idInvestimento)
        {
            CarteiraBLL bll = new CarteiraBLL();
            investimentoResumoBindingSource.DataSource = bll.ResumoInvestimento(idInvestimento, dateTimePickerDia.Value, tipoInformacao);

        }

        private void buttonDiaCorrente_Click(object sender, EventArgs e)
        {
            dateTimePickerDia.Value = DateTime.Today;

            ExibirResumoFundo(IdInvestimento);
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void investimentoResumoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                bool totalizador = (bool)investimentoResumoDataGridView.Rows[e.RowIndex].Cells["resumoTotal"].Value;

                if (totalizador)
                {
                    e.CellStyle.BackColor = Color.Black;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }

        private void investimentoResumoDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (investimentoResumoDataGridView.Rows.Count > 0)
            {
                // Última cotação
                DateTime ultimaCotacao = (DateTime)investimentoResumoDataGridView.Rows[0].Cells["resumoUltima"].Value;

                labelUltimoComeCota.Text = "Última cotação em " + ultimaCotacao.ToString("dd/MM/yyyy");

                if (investimentoResumoDataGridView.Rows[0].Cells["resumoUltimoComeCota"].Value != DBNull.Value)
                {
                    DateTime ultimoComeCota = (DateTime)investimentoResumoDataGridView.Rows[0].Cells["resumoUltimoComeCota"].Value;
                    labelUltimoComeCota.Text = labelUltimoComeCota.Text + ";  último come cotas em " + ultimoComeCota.ToString("dd/MM/yyyy");
                }
                else
                {
                    labelUltimoComeCota.Text = labelUltimoComeCota.Text + ";  não houve come cotas para este investimento.";
                }
                labelUltimoComeCota.Visible = true;
            }
            else
            {
                labelUltimoComeCota.Visible = false;
            }
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            ExibirResumoFundo(IdInvestimento);
        }
    }
}
