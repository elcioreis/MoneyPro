using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MoneyPro.Controles;
using System.Globalization;

namespace MoneyPro
{
    public partial class fmPainel : MoneyPro.Base.fmBaseTopoRodape
    {

        #region Singleton

        private static fmPainel _singleton;

        private fmPainel()
        {
            InitializeComponent();
        }

        public static fmPainel CreateInstance()
        {
            if (_singleton == null)
            {
                _singleton = new fmPainel();
            }
            return _singleton;
        }

        protected override void OnClosed(EventArgs e)
        {
            _singleton = null;
            base.OnClosed(e);
        }

        #endregion Singleton

        protected override void OnLoad(EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                base.OnLoad(e);

                // Cria os gráficos em tempo de execução.

                const int semanas = 56;
                const int meses = 12;

                #region Variação das contas

                ucVariacaoSemanalAcumulada ucASA = new ucVariacaoSemanalAcumulada(semanas);
                flowLayoutPanel.Controls.Add(ucASA);

                ucVariacaoSemanalGrupoContas ucASPGC = new ucVariacaoSemanalGrupoContas(semanas);
                flowLayoutPanel.Controls.Add(ucASPGC);

                #endregion Variação das contas


                #region Destino do dinheiro

                ucApuracaoComparativoPorCategoria ucACC = new ucApuracaoComparativoPorCategoria();
                flowLayoutPanel.Controls.Add(ucACC);

                ucApuracaoDestinoPorCategoriaAnterior ucADC1 = new ucApuracaoDestinoPorCategoriaAnterior();
                flowLayoutPanel.Controls.Add(ucADC1);

                ucApuracaoDestinoPorCategoriaAtual ucADC2 = new ucApuracaoDestinoPorCategoriaAtual();
                flowLayoutPanel.Controls.Add(ucADC2);

                #endregion Destino do dinheiro



                #region Investimentos

                //ucVariacaoInvestimentos ucAI = new ucVariacaoInvestimentos(56);
                //flowLayoutPanel.Controls.Add(ucAI);

                ucApuracaoInvestimentosAcumuladosMensal ucAIAM = new ucApuracaoInvestimentosAcumuladosMensal(meses);
                flowLayoutPanel.Controls.Add(ucAIAM);

                /*
                                ucApuracaoInvestimentosAcumulados ucAIR = new ucApuracaoInvestimentosAcumulados();
                                flowLayoutPanel.Controls.Add(ucAIR);

                                ucApuracaoDivisaoInvestimento ucADI = new ucApuracaoDivisaoInvestimento();
                                flowLayoutPanel.Controls.Add(ucADI);

                                ucApuracaoDivisaoRisco ucADR = new ucApuracaoDivisaoRisco();
                                flowLayoutPanel.Controls.Add(ucADR);
                */

                #endregion Investimentos


                /*

                                #region Outros

                                ucVariacaoMensalGrupoContas ucAMPGC = new ucVariacaoMensalGrupoContas(periodos, true);
                                flowLayoutPanel.Controls.Add(ucAMPGC);

                                #endregion Outros

                */
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            AtualizaLargura();
        }

        private void flowLayoutPanel_Resize(object sender, EventArgs e)
        {
            AtualizaLargura();
        }

        private void AtualizaLargura()
        {
            foreach (var item in flowLayoutPanel.Controls)
            {
                if (item is UserControl)
                {
                    var tag = (item as UserControl).Tag;
                    double largura;

                    NumberStyles style;
                    CultureInfo culture;

                    string texto = tag.ToString();
                    style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
                    culture = CultureInfo.CreateSpecificCulture("pt-BR");

                    if (!Double.TryParse(texto, style, culture, out largura))
                    {
                        largura = 100;
                    }

                    (item as UserControl).Height = 276;
                    int ajustado = Convert.ToInt16(Math.Floor((flowLayoutPanel.ClientRectangle.Width - 10) * largura / 100));
                    (item as UserControl).Width = ajustado;
                }
            }
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void buttonPainel_Click(object sender, EventArgs e)
        {
            fmConfigurarPainel form = new fmConfigurarPainel();
            form.ShowDialog();
        }
    }
}
