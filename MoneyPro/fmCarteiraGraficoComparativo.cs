using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MoneyPro
{
    public partial class fmCarteiraGraficoComparativo : MoneyPro.Base.fmBaseTopoRodape
    {

        private Point? prevPosition = null;
        private ToolTip tooltip = new ToolTip();
        private DataGridView _fonte = null;

        private DateTime _limiteInferior;
        public DateTime limiteInferior
        {
            get
            {
                return _limiteInferior;
            }
            set
            {
                _limiteInferior = value;
                dateTimePickerInicio.Value = _limiteInferior;
            }
        }

        #region Singleton
        private Form Origem { get; set; }

        private static fmCarteiraGraficoComparativo _singleton;

        private fmCarteiraGraficoComparativo(Form origem, DataGridView fonte)
        {
            InitializeComponent();
            this.Origem = origem;
            this.Visible = false;

            // Armazena o dataGridView para poder atualizar a consulta
            _fonte = fonte;

            // Pega o último dia com cotação e volta um mês
            limiteInferior = Geral.UltimoDiaComCotacao().AddMonths(-1);

            // Faz o tooltip dos gráficos ficarem iguais ao do restante do formulário.
            tooltip.OwnerDraw = true;
            tooltip.BackColor = toolTip.BackColor;
            tooltip.Draw += toolTip_Draw;

            ExibeGraficoComparativo(fonte, limiteInferior);
        }

        public static fmCarteiraGraficoComparativo CreateInstance(Form origem, DataGridView fonte)
        {
            if (_singleton == null)
            {
                _singleton = new fmCarteiraGraficoComparativo(origem, fonte);
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

        private void ExibeGraficoComparativo(DataGridView fonte, DateTime limiteInferior)
        {
            String[] nomeFundos = new String[8];
            String investimentos = String.Empty;
            int investID;
            int contadorInvestimento = 0;

            Color[] cores = new Color[8];
            cores[0] = Color.Blue;
            cores[1] = Color.Orange;
            cores[2] = Color.Red;
            cores[3] = Color.Green;
            cores[4] = Color.Purple;
            cores[5] = Color.Navy;
            cores[6] = Color.Tomato;
            cores[7] = Color.Gainsboro;

            SortedDictionary<string, int> fundos = new SortedDictionary<string, int>();
            foreach (DataGridViewRow linhas in fonte.SelectedRows)
            {
                fundos.Add((string)linhas.Cells["Apelido"].Value, (int)linhas.Cells["InvestimentoID"].Value);
            }

            foreach (var item in fundos)
            {
                investID = item.Value;
                investimentos = investimentos + item.Value + ";";
                nomeFundos[contadorInvestimento++] = item.Key;
            }

            //panelRodape.Visible = false;
            if (fundos.Count > 1)
                labelTopo.Text = "Variação das Cotações";
            else
                labelTopo.Text = "Variação da Cotação";

            GraficosBLL dados = new GraficosBLL();
            DataTable tabela = dados.GetHistoricoCotacaoComparativo(investimentos, limiteInferior);

            chart.DataSource = tabela;

            chart.Titles.Clear();
            //chartDesempenho.Titles.Add("Comparativo de Investimentos");
            //chartDesempenho.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold | FontStyle.Underline);

            // Deixa que o chart faça o auto escalonamento
            //chart.ChartAreas[0].AxisY.Minimum = Double.NaN;
            //chart.ChartAreas[0].AxisY.Maximum = Double.NaN;

            chart.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yy";
            //chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Weeks;
            //chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

            chart.ChartAreas[0].AxisY.Title = "Em %";

            chart.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

            // Remove qualquer série pré-existente
            chart.Series.Clear();

            String nomeCampo, nomeSerie;
            for (int i = 0; i < contadorInvestimento; i++)
            {
                nomeSerie = "Serie" + i.ToString();
                nomeCampo = "Valor" + i.ToString();

                // Inclui uma série
                chart.Series.Add(nomeSerie);

                // Define o tipo de gráfico como linha.
                chart.Series[nomeSerie].ChartType = SeriesChartType.Line;
                chart.Series[nomeSerie].BorderWidth = 2;
                chart.Series[nomeSerie].MarkerStyle = MarkerStyle.Diamond;
                chart.Series[nomeSerie].MarkerSize = 4;
                chart.Series[nomeSerie].ShadowOffset = 1;

                // Define o eixo X como data
                chart.Series[nomeSerie].XValueType = ChartValueType.Date;
                // Define o eixo Y como valor
                chart.Series[nomeSerie].YValueType = ChartValueType.Double;
                // Define a cor da série
                chart.Series[nomeSerie].Color = cores[i];

                // Define o valores X e Y da série
                chart.Series[nomeSerie].XValueMember = "Data";
                chart.Series[nomeSerie].YValueMembers = nomeCampo;
                chart.Series[nomeSerie].LegendText = nomeFundos[i];
            }

            // Processa os dados para desenhar o gráfico
            chart.DataBind();

        }

        private void chartDesempenho_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;

            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart.HitTest(pos.X, pos.Y, false, ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 2 &&
                            Math.Abs(pos.Y - pointYPixel) < 2)
                        {
                            DateTime data = DateTime.FromOADate(prop.XValue);

                            String texto = prop.LegendText.ToString() + ": " +
                                           prop.YValues[0].ToString("N2") + "% em " + data.ToString("dd/MM/yyyy");

                            tooltip.Show(texto, this.chart, pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void buttonMesCorrente_Click(object sender, EventArgs e)
        {
            DateTime hoje = DateTime.Today;
            limiteInferior = new DateTime(hoje.Year, hoje.Month, 1);

            ExibeGraficoComparativo(_fonte, limiteInferior);
        }

        private void buttonUltimoInvestimento_Click(object sender, EventArgs e)
        {
            string _listaInvestimentos = GeraListaInvestimentos(_fonte);

            limiteInferior = Geral.UltimoInvestimentoFeito(_listaInvestimentos);

            ExibeGraficoComparativo(_fonte, limiteInferior);
        }

        private string GeraListaInvestimentos(DataGridView _fonte)
        {
            List<int> investimentos = new List<int>();
            foreach (DataGridViewRow linhas in _fonte.SelectedRows)
            {
                investimentos.Add((int)linhas.Cells["InvestimentoID"].Value);
            }

            return string.Join(";", investimentos.Select(n => n.ToString()).ToArray()) + ";";
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            limiteInferior = dateTimePickerInicio.Value;
            ExibeGraficoComparativo(_fonte, limiteInferior);
        }

        private void dateTimePickerInicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAtualizar_Click(sender, null);
            }
        }

    }
}
