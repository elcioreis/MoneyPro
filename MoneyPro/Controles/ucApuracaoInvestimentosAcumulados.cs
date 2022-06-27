using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;

namespace MoneyPro.Controles
{
    public partial class ucApuracaoInvestimentosAcumulados : UserControl
    {
        private Point? prevPosition = null;
        private ToolTip tooltip = new ToolTip();

        public ucApuracaoInvestimentosAcumulados()
        {
            InitializeComponent();
            CarregarPainel(DateTime.Today, 6);

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

            try
            {
                PainelBLL bll = new PainelBLL();
                DataTable dados = bll.ApuracaoInvestimentosAcumulados();



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

                chart.DataSource = dados;

                chart.Titles.Clear();
                chart.Titles.Add("Variação Acumulada dos Investimentos");
                chart.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold | FontStyle.Underline);

                // Deixa que o chart faça o auto escalonamento do eixo Y;
                chart.ChartAreas[0].AxisY.Minimum = Double.NaN;
                chart.ChartAreas[0].AxisY.Maximum = Double.NaN;

                chart.ChartAreas[0].AxisX.Minimum = dataMinima.ToOADate();
                chart.ChartAreas[0].AxisX.Maximum = dataMaxima.ToOADate();

                chart.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yy";
                chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Weeks;
                chart.ChartAreas[0].AxisX.Interval = 1;

                chart.ChartAreas[0].AxisY.Title = "Em R$";  // \n(não descontados impostos a pagar)";
                chart.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                chart.ChartAreas[0].AxisX.Title = "(não descontados impostos a pagar)";

                // Remove qualquer série pré-existente
                chart.Series.Clear();

                for (int i = 0; i < serieID; i++)
                {
                    conta = nomeSerie[i];
                    chart.Series.Add(conta);

                    // Define o tipo de gráfico como linha.
                    chart.Series[conta].ChartType = SeriesChartType.Spline;
                    chart.Series[conta].BorderWidth = 2;
                    chart.Series[conta].MarkerStyle = MarkerStyle.Circle;
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
            finally
            {

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

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 2 &&
                            Math.Abs(pos.Y - pointYPixel) < 2)
                        {
                            DateTime data = DateTime.FromOADate(prop.XValue);
                            double valor = prop.YValues[0];

                            tooltip.Show(prop.LegendText.ToString() + ": " + valor.ToString("C2") + " em " + data.ToString("dd/MM/yy"), this.chart, pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }
    }
}
