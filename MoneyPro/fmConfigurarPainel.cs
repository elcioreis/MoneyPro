using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelos;

namespace MoneyPro
{
    public partial class fmConfigurarPainel : MoneyPro.Base.fmBaseTopoRodape
    {
        //        TiposPainel painel;

        public fmConfigurarPainel()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CarregarPaineisFontes();
        }

        private void CarregarPaineisFontes()
        {
            flowLayoutPanel050.Controls.Clear();
            flowLayoutPanel100.Controls.Clear();

            int larg = System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
            int largura = flowLayoutPanel100.ClientRectangle.Width - (flowLayoutPanel100.Padding.Left + flowLayoutPanel100.Padding.Right + larg + 10);
            int altura = 54;

            foreach (ePainel100 pnl in Enum.GetValues(typeof(ePainel100)))
            {
                Panel pnlX = new Panel();
                pnlX.BorderStyle = BorderStyle.FixedSingle;
                pnlX.BackColor = Color.White;
                pnlX.Height = altura;
                pnlX.Width = largura;

                Label lblX = new Label();
                lblX.Text = Painel.ToString(pnl);
                lblX.TextAlign = ContentAlignment.MiddleCenter;
                pnlX.Controls.Add(lblX);
                lblX.Dock = DockStyle.Fill;

                flowLayoutPanel100.Controls.Add(pnlX);
            }

            foreach (ePainel050 pnl in Enum.GetValues(typeof(ePainel050)))
            {
                Panel pnlX = new Panel();
                pnlX.BorderStyle = BorderStyle.FixedSingle;
                pnlX.BackColor = Color.White;
                pnlX.Height = altura;
                pnlX.Width = Convert.ToInt16(Math.Floor(largura * 0.49));

                Label lblX = new Label();
                lblX.Text = Painel.ToString(pnl);
                lblX.TextAlign = ContentAlignment.MiddleCenter;
                pnlX.Controls.Add(lblX);
                lblX.Dock = DockStyle.Fill;

                flowLayoutPanel050.Controls.Add(pnlX);
            }

        }
    }
}
