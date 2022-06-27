using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.Windows.Forms.DataVisualization.Charting;

namespace MoneyPro.Controles
{
    public partial class ucApuracaoDestinoPorCategoriaAnterior : UserControl
    {
        private double outros = 0.9;
        private double percentual = 49.77D;
        private Point? prevPosition = null;
        private ToolTip tooltip = new ToolTip();

        public ucApuracaoDestinoPorCategoriaAnterior()
        {
            InitializeComponent();
            this.Tag = percentual;
            CarregarPainel();

            // Faz o tooltip dos gráficos ficarem iguais ao do restante do formulário.
            tooltip.OwnerDraw = true;
            tooltip.BackColor = Color.Gold;
            tooltip.Draw += toolTip_Draw;
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void CarregarPainel()
        {
            string conta = String.Empty;

            PainelBLL bll = new PainelBLL();

            DateTime data = DateTime.Today.AddDays(-1);

            while (data.Month == DateTime.Today.AddDays(-1).Month)
            {
                data = data.AddDays(-18);
            }

            DataTable dados = bll.ApuracaoDestinoPorCategoria(data, outros);

            chart.DataSource = dados;
            chart.ChartAreas[0].Area3DStyle.Enable3D = true;

            chart.Titles.Clear();
            chart.Titles.Add("Saídas por Categoria - Mês Anterior");
            chart.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold | FontStyle.Underline);

            // Deixa que o chart faça o auto escalonamento do eixo Y;
            chart.ChartAreas[0].AxisY.Minimum = Double.NaN;
            chart.ChartAreas[0].AxisY.Maximum = Double.NaN;

            chart.ChartAreas[0].AxisX.Interval = 7;

            chart.ChartAreas[0].AxisY.Title = "Em %";
            chart.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            // Remove qualquer série pré-existente
            chart.Series.Clear();

            conta = "Total";
            chart.Series.Add(conta);

            // Define o tipo de gráfico como pizza
            chart.Series[conta].ChartType = SeriesChartType.Pie;

            chart.Series[conta].XValueType = ChartValueType.String;
            chart.Series[conta].YValueType = ChartValueType.Double;

            // Define posição dos labels no gráfico de pizza
            chart.Series[conta]["PieLabelStyle"] = "OutSide"; // "Ellipse";
            // Define formato da legenda sobre o gráfico
            chart.Series[conta].Label = "#PERCENT{P2}";
            // Define formato da legenda ao lado
            chart.Series[0].LegendText = "#VALX";

            // Define o valores X e Y da série
            chart.Series[conta].XValueMember = "Apelido";
            chart.Series[conta].YValueMembers = conta;
        }

        private void chart_MouseMove(object sender, MouseEventArgs e)
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

                        double valor = prop.YValues[0];

                        tooltip.Show(prop.AxisLabel + ": " + valor.ToString("C2"), this.chart, pos.X, pos.Y - 15);
                    }
                }
            }
        }
    }
}
