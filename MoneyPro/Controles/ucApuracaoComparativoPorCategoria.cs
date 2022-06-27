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
    public partial class ucApuracaoComparativoPorCategoria : UserControl
    {
        private double outros = 0.9;
        private Point? prevPosition = null;
        private ToolTip tooltip = new ToolTip();

        public ucApuracaoComparativoPorCategoria()
        {
            InitializeComponent();
            CarregarPainel(DateTime.Today.AddDays(-2), 6, outros);

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

        private void CarregarPainel(DateTime data, int periodos, double perc)
        {
            String[] nomeSerie = new String[99];
            int serieID = 0;
            string conta = String.Empty;

            PainelBLL bll = new PainelBLL();
            DataTable dados = bll.ApuracaoComparativoPorCategoria(data, periodos, perc);

            foreach (DataColumn col in dados.Columns)
            {
                if (col.DataType != System.Type.GetType("System.DateTime"))
                {
                    nomeSerie[serieID++] = col.ColumnName;
                }
            }

            chart.DataSource = dados;

            chart.Titles.Clear();
            chart.Titles.Add("Comparativo de Consumo por Categoria");
            chart.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold | FontStyle.Underline);

            chart.ChartAreas[0].AxisX.LabelStyle.Format = "MMM/yy";
            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
            chart.ChartAreas[0].AxisX.Interval = 1;

            chart.ChartAreas[0].AxisY.Title = "Em R$";
            chart.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

            // Remove qualquer série pré-existente
            chart.Series.Clear();

            for (int i = 0; i < serieID; i++)
            {
                conta = nomeSerie[i];
                chart.Series.Add(conta);

                // Define o tipo de gráfico como coluna
                chart.Series[conta].ChartType = SeriesChartType.Column;
                chart.Series[conta].BorderWidth = 20;

                // Define o eixo X como data
                chart.Series[conta].XValueType = ChartValueType.Date;
                // Define o eixo Y como valor
                chart.Series[conta].YValueType = ChartValueType.Double;

                // Define o valores X e Y da série
                chart.Series[conta].XValueMember = "Data";

                chart.Series[conta].YValueMembers = conta;

                if (!conta.Contains('?'))
                {
                    // Colunas comuns
                    chart.Series[conta].LegendText = conta;
                }
                else
                {
                    // Coluna de "Outros"
                    chart.Series[conta].LegendText = "Outros (\u2211<" + ((1 - outros) * 100).ToString("N1") + "%)";
                }
            }
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

                        DateTime data = DateTime.FromOADate(prop.XValue);

                        double valor = prop.YValues[0];

                        tooltip.Show(prop.LegendText.ToString() + ": " + valor.ToString("C2"), this.chart, pos.X, pos.Y - 15);

                    }
                }
            }
        }
    }
}
