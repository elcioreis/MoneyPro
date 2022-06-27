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
using static Modelos.Tipo;

namespace MoneyPro
{
    public partial class fmCarteiraGraficoRendimentoDiario : MoneyPro.Base.fmBaseTopoRodape
    {
        private Point? prevPosition = null;
        private string _listaInvestimentos = "";
        private TipoConsultaInvestimentoVariacao _tipoConsulta = TipoConsultaInvestimentoVariacao.AcumuladoDiario;

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
        private Form _origem { get; set; }

        private static fmCarteiraGraficoRendimentoDiario _singleton;
        private static bool _permiteIstanciar = true;

        private fmCarteiraGraficoRendimentoDiario(Form origem, DataGridView fonte, TipoConsultaInvestimentoVariacao tipoConsulta)
        {
            InitializeComponent();
            _origem = origem;
            this.Visible = false;

            _listaInvestimentos = Geral.ListaDeInvestimento(fonte);
            _tipoConsulta = tipoConsulta;

            // Pega o último dia com cotação e volta um mês
            limiteInferior = Geral.UltimoDiaComCotacao().AddMonths(-1);

            switch (tipoConsulta)
            {
                case TipoConsultaInvestimentoVariacao.VariacaoDiaria:
                    labelTopo.Text = "Variação Diária dos Investimentos";
                    break;
                case TipoConsultaInvestimentoVariacao.AcumuladoDiario:
                    labelTopo.Text = "Rendimento Diário Acumulado";
                    break;
                default:
                    break;
            }

            if (!String.IsNullOrEmpty(_listaInvestimentos))
            {
                _permiteIstanciar = CarregarGraficoRendimentoDiario(_listaInvestimentos, limiteInferior, tipoConsulta);
            }
        }

        public static fmCarteiraGraficoRendimentoDiario CreateInstance(Form origem, DataGridView fonte, TipoConsultaInvestimentoVariacao tipoConsulta)
        {
            if (_singleton == null)
            {
                _singleton = new fmCarteiraGraficoRendimentoDiario(origem, fonte, tipoConsulta);
                if (!_permiteIstanciar)
                {
                    _singleton = null;
                }
            }
            return _singleton;
        }

        protected override void OnClosed(EventArgs e)
        {
            _singleton = null;
            base.OnClosed(e);
            _origem.WindowState = FormWindowState.Maximized;
        }

        #endregion Singleton

        private void buttonFecharDetalhes_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool CarregarGraficoRendimentoDiario(string investimentos, DateTime dtInicio, TipoConsultaInvestimentoVariacao tipoConsulta)
        {
            List<string> nomeSeries = new List<string>();

            GraficosBLL grafico = new GraficosBLL();

            try
            {
                DataTable dados = grafico.InvestimentosLiquidosAcumulados(investimentos, dtInicio, tipoConsulta);

                foreach (DataColumn col in dados.Columns)
                {
                    if (col.DataType != System.Type.GetType("System.DateTime"))
                    {

                        if (col.ColumnName.ToUpper() == "TOTAL")
                        {
                            // Ordena decrescentemente antes de incluir o total
                            nomeSeries.Reverse();
                        }

                        if (col.ColumnName.ToUpper() != "TIPODADO")
                        {
                            nomeSeries.Add(col.ColumnName);
                        }
                    }
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

                //chart.Titles.Clear();
                //chart.Titles.Add("Variação Acumulada Líquida dos Investimentos");
                //chart.Titles[0].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold | FontStyle.Underline);

                // Deixa que o chart faça o auto escalonamento do eixo Y;
                //chart.ChartAreas[0].AxisY.Minimum = Double.NaN;
                //chart.ChartAreas[0].AxisY.Maximum = Double.NaN;

                //chart.ChartAreas[0].AxisX.Minimum = dataMinima.ToOADate();
                //chart.ChartAreas[0].AxisX.Maximum = dataMaxima.ToOADate();

                chart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                chart.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MMM/yy";
                chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;
                chart.ChartAreas[0].AxisX.Interval = 1;

                chart.ChartAreas[0].AxisY.Title = "Em R$";
                chart.ChartAreas[0].AxisY.TitleFont = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                // Remove qualquer série pré-existente
                chart.Series.Clear();

                foreach (string conta in nomeSeries)
                {
                    chart.Series.Add(conta);

                    // Define o tipo de gráfico como linha.

                    if (conta != "Total")
                    {
                        chart.Series[conta].ChartType = SeriesChartType.StackedColumn;
                        chart.Series[conta].BorderWidth = 1;
                        chart.Series[conta]["PixelPointWidth"] = "20";
                    }
                    else
                    {
                        chart.Series[conta].ChartType = SeriesChartType.Spline;
                        chart.Series[conta].Color = Geral.CorTotal;
                        chart.Series[conta].BorderWidth = 2;
                        chart.Series[conta].MarkerStyle = MarkerStyle.Circle;
                        chart.Series[conta].MarkerSize = 4;
                        chart.Series[conta].ShadowOffset = 1;
                    }

                    // Define o eixo X como data
                    chart.Series[conta].XValueType = ChartValueType.Date;
                    // Define o eixo Y como valor
                    chart.Series[conta].YValueType = ChartValueType.Double;

                    // Define o valores X e Y da série
                    chart.Series[conta].XValueMember = "Data";
                    chart.Series[conta].YValueMembers = conta;
                    chart.Series[conta].LegendText = conta;
                }
                return true;
            }
            catch
            {
                // Se não houver dados na procedure executada, retornará erro
                return false;
            }
        }

        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;

            toolTipGrafico.RemoveAll();

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

                        String texto = prop.LegendText.ToString() + ": " +
                                       prop.YValues[0].ToString("C2") + " em " + data.ToString("dd/MM/yyyy");

                        toolTipGrafico.Show(texto, this.chart, pos.X, pos.Y - 15);
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

        private void toolTipGrafico_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            limiteInferior = dateTimePickerInicio.Value;

            if (!CarregarGraficoRendimentoDiario(_listaInvestimentos, limiteInferior, _tipoConsulta))
            {
                MessageBox.Show("Não há informações a serem exibidas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
        }

        private void buttonMesCorrente_Click(object sender, EventArgs e)
        {
            DateTime hoje = DateTime.Today;
            limiteInferior = new DateTime(hoje.Year, hoje.Month, 1);

            if (!CarregarGraficoRendimentoDiario(_listaInvestimentos, limiteInferior, _tipoConsulta))
            {
                MessageBox.Show("Não há informações a serem exibidas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
        }

        private void buttonUltimoInvestimento_Click(object sender, EventArgs e)
        {
            limiteInferior = Geral.UltimoInvestimentoFeito(_listaInvestimentos);

            if (!CarregarGraficoRendimentoDiario(_listaInvestimentos, limiteInferior, _tipoConsulta))
            {
                MessageBox.Show("Não há informações a serem exibidas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
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
