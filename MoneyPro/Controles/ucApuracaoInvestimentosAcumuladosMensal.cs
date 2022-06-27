using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;

namespace MoneyPro.Controles
{
    public partial class ucApuracaoInvestimentosAcumuladosMensal : UserControl
    {
        private Point? prevPosition = null;
        private ToolTip tooltip = new ToolTip();

        public ucApuracaoInvestimentosAcumuladosMensal(int periodos)
        {
            InitializeComponent();
            CarregarPainel(DateTime.Today, periodos);

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

        private void CarregarPainel(DateTime data, int periodos)
        {
            String[] nomeSerie = new String[99];
            int serieID = 0;
            string conta = String.Empty;

            PainelBLL bll = new PainelBLL();
            DataTable dados = bll.ApuracaoInvestimentosAcumuladosMensal(periodos);

            foreach (DataColumn col in dados.Columns)
            {
                if (col.DataType != System.Type.GetType("System.DateTime"))
                    nomeSerie[serieID++] = col.ColumnName;
            }

            // Pega as datas mínimas e máximas para definir o eixo X do gráfico
            DateTime dataMinima = DateTime.Parse("01/01/2200");
            DateTime dataMaxima = DateTime.Parse("01/01/2000");

            foreach (DataRow lin in dados.Rows)
            {
                if (lin.Field<DateTime>("Data") > dataMaxima)
                    dataMaxima = lin.Field<DateTime>("Data");
                if (lin.Field<DateTime>("Data") < dataMinima)
                    dataMinima = lin.Field<DateTime>("Data");
            }

            // Primeiro dia do mês da data mínima
            dataMinima = new DateTime(dataMinima.Year, dataMinima.Month, 1);
            // Último dia do mês da data máxima
            dataMaxima = new DateTime(dataMaxima.Year, dataMaxima.Month, 1);
            dataMaxima = dataMaxima.AddMonths(1).AddDays(-1);

            chart.DataSource = dados;

            chart.Titles.Clear();
            chart.Titles.Add("Variação Acumulada Líquida dos Investimentos");
            chart.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold | FontStyle.Underline);

            // Deixa que o chart faça o auto escalonamento do eixo Y;
            chart.ChartAreas[0].AxisY.Minimum = Double.NaN;
            chart.ChartAreas[0].AxisY.Maximum = Double.NaN;

            chart.ChartAreas[0].AxisX.Minimum = dataMinima.ToOADate();
            chart.ChartAreas[0].AxisX.Maximum = dataMaxima.ToOADate();

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

                // Define o tipo de gráfico como linha.

                if (conta != "Total")
                {
                    //chart.Series[conta].ChartType = SeriesChartType.StackedColumn;
                    chart.Series[conta].ChartType = SeriesChartType.Column;
                    chart.Series[conta].BorderWidth = 1;
                    chart.Series[conta]["PixelPointWidth"] = "20";
                }
                else
                {
                    chart.Series[conta].ChartType = SeriesChartType.Spline;
                    chart.Series[conta].BorderWidth = 2;
                    chart.Series[conta].MarkerStyle = MarkerStyle.Circle;
                    chart.Series[conta].Color = Geral.CorTotal;
                }

                chart.Series[conta].MarkerStyle = MarkerStyle.None;
                // Define o eixo X como data
                chart.Series[conta].XValueType = ChartValueType.Date;
                // Define o eixo Y como valor
                chart.Series[conta].YValueType = ChartValueType.Double;

                // Define o valores X e Y da série
                chart.Series[conta].XValueMember = "Data";
                chart.Series[conta].YValueMembers = conta;
                chart.Series[conta].LegendText = conta;
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
