﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos;
using BLL;
using System.Windows.Forms.DataVisualization.Charting;

namespace MoneyPro.Controles
{
    public partial class ucVariacaoMensalGrupoContas : UserControl
    {
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        public ucVariacaoMensalGrupoContas(int periodos, bool ateHoje)
        {
            InitializeComponent();
            CarregarPainel(periodos, ateHoje);

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

        public void CarregarPainel(int periodos, bool ateHoje)
        {
            String[] nomeGrupo = new String[99];
            int grupoID = 0;
            string conta = String.Empty;                               

            PainelBLL bll = new PainelBLL();
            DataTable dados = bll.ApuracaoMensalPorGrupoDeContas(periodos, ateHoje);

            foreach (DataColumn col in dados.Columns)
            {
                if (col.DataType != System.Type.GetType("System.DateTime"))
                    nomeGrupo[grupoID++] = col.ColumnName;
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
            chart.Titles.Add("Variação Mensal dos Grupos de Contas");
            chart.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold | FontStyle.Underline);

            // Deixa que o chart faça o auto escalonamento do eixo Y;
            chart.ChartAreas[0].AxisY.Minimum = Double.NaN;
            chart.ChartAreas[0].AxisY.Maximum = Double.NaN;

            chart.ChartAreas[0].AxisX.Minimum = dataMinima.ToOADate();
            chart.ChartAreas[0].AxisX.Maximum = dataMaxima.ToOADate();

            chart.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yy";
            chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
            chart.ChartAreas[0].AxisX.Interval = 1;

            chart.ChartAreas[0].AxisY.Title = "Em R$";
            chart.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

            // Remove qualquer série pré-existente
            chart.Series.Clear();

            for (int i = 0; i < grupoID; i++)
            {
                conta = nomeGrupo[i];
                chart.Series.Add(conta);

                // Define o tipo de gráfico como linha.
                chart.Series[conta].ChartType = SeriesChartType.Line;
                chart.Series[conta].BorderWidth = 2;
                chart.Series[conta].MarkerStyle = MarkerStyle.Diamond;
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

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 2 &&
                            Math.Abs(pos.Y - pointYPixel) < 2)
                        {
                            DateTime data = DateTime.FromOADate(prop.XValue);

                            string identifica;
                            double valor = prop.YValues[0];

                            if (valor < 0)
                            {
                                identifica = prop.LegendText.ToString() + ": -R$ ";
                                tooltip.ForeColor = Color.Red;
                            }
                            else
                            {
                                identifica = prop.LegendText.ToString() + ": R$ ";
                                tooltip.ForeColor = Color.Blue;
                            }

                            string texto = identifica + Math.Abs(valor).ToString("N2") + " em " + data.ToShortDateString();

                            tooltip.Show(texto, this.chart, pos.X, pos.Y - 15);
                        }
                    }
                }
            }
        }
    }
}
