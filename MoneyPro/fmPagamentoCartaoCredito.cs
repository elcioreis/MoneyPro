using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace MoneyPro
{
    public partial class fmPagamentoCartaoCredito : MoneyPro.Base.fmBaseTopoRodape
    {
        const int LarguraMinima = 70;
        private DateTime _DataReferencia;
        private DateTime _ProximaFaturaCartao;

        public DateTime ProximaFaturaCartao
        {
            get
            {
                return _ProximaFaturaCartao;
            }

            set
            {
                _ProximaFaturaCartao = value;

                if (_ProximaFaturaCartao.Year > 1900)
                {
                    labelProximaFatura.Text = "Próxima fatura em " + _ProximaFaturaCartao.ToString("dd/MM/yyyy");
                }
                else
                {
                    labelProximaFatura.Text = "Não há fatura agendada";
                }
            }
        }

        public DateTime DataReferencia
        {
            get
            {
                return _DataReferencia;
            }
            set
            {
                _DataReferencia = value.AddMonths(1);
                //.AddMonths(1)
                labelTopo.Text = "Pagamento de Cartão de Crédito até " + _DataReferencia.ToString("MM/yyyy");
                CarregarPagamentosCartaoCredito(IDUsuario, _DataReferencia);
            }
        }


        #region Singleton
        private Form Origem { get; set; }
        private int IDUsuario { get; set; }

        private static fmPagamentoCartaoCredito _singleton;

        private fmPagamentoCartaoCredito(Form origem, int usuarioID)
        {
            InitializeComponent();
            this.Origem = origem;
            this.IDUsuario = usuarioID;
            this.Visible = false;

            ProximaFaturaCartao = Geral.ProximaFaturaCartao(this.IDUsuario);

            dateTimePickerDataBase.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);

            pagamentoCartaoCreditoDataGridView.Focus();
        }

        public static fmPagamentoCartaoCredito CreateInstance(Form origem, int usuarioID)
        {
            if (_singleton == null)
            {
                _singleton = new fmPagamentoCartaoCredito(origem, usuarioID);
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


        private void ButtonFecharDetalhes_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void CarregarPagamentosCartaoCredito(int usuarioID, DateTime dataBase)
        {
            PesquisaBLL bll = new PesquisaBLL();
            pagamentoCartaoCreditoDataGridView.DataSource = bll.ListarPagamentoCartaoCredito(usuarioID, dataBase);

            for (short i = 1; i <= 12; i++)
            {
                string campo = "pagamento_Mes" + i.ToString("00");

                DateTime mes = DataReferencia.AddMonths((12 - i) * -1);

                // Encontra o primeiro dia do mês e o coloca na Tag do campo
                DateTime dia = new DateTime(mes.Year, mes.Month, 1); // DateTime.DaysInMonth(mes.Year, mes.Month));

                pagamentoCartaoCreditoDataGridView.Columns[campo].Tag = dia;
                pagamentoCartaoCreditoDataGridView.Columns[campo].HeaderText = dia.ToString("MM/yyyy");

                pagamentoCartaoCreditoDataGridView.Columns[campo].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                pagamentoCartaoCreditoDataGridView.Columns[campo].MinimumWidth = LarguraMinima;
                pagamentoCartaoCreditoDataGridView.Columns[campo].SortMode = DataGridViewColumnSortMode.NotSortable;
                pagamentoCartaoCreditoDataGridView.Columns[campo].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                pagamentoCartaoCreditoDataGridView.Columns[campo].DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N2",
                };
            }
            pagamentoCartaoCreditoDataGridView.Columns["pagamento_Total"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pagamentoCartaoCreditoDataGridView.Columns["pagamento_Total"].MinimumWidth = LarguraMinima;
            pagamentoCartaoCreditoDataGridView.Columns["pagamento_Total"].SortMode = DataGridViewColumnSortMode.NotSortable;
            pagamentoCartaoCreditoDataGridView.Columns["pagamento_Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            pagamentoCartaoCreditoDataGridView.Columns["pagamento_Total"].DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.Gainsboro,
                Alignment = DataGridViewContentAlignment.MiddleRight,
                Format = "N2",
            };

            pagamentoCartaoCreditoDataGridView.Columns["pagamento_Media"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            pagamentoCartaoCreditoDataGridView.Columns["pagamento_Media"].MinimumWidth = LarguraMinima;
            pagamentoCartaoCreditoDataGridView.Columns["pagamento_Media"].SortMode = DataGridViewColumnSortMode.NotSortable;
            pagamentoCartaoCreditoDataGridView.Columns["pagamento_Media"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            pagamentoCartaoCreditoDataGridView.Columns["pagamento_Media"].DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.Gainsboro,
                Alignment = DataGridViewContentAlignment.MiddleRight,
                Format = "N2",
            };
        }

        private void DateTimePickerDataBase_ValueChanged(object sender, EventArgs e)
        {
            DataReferencia = dateTimePickerDataBase.Value;
        }

        private void PagamentoCartaoCreditoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                short tipoLinha = (short)pagamentoCartaoCreditoDataGridView.Rows[e.RowIndex].Cells["pagamento_TipoLinha"].Value;

                if (tipoLinha == 1)
                {
                    e.CellStyle.BackColor = Color.Black;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }

        private void FmPagamentoCartaoCredito_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                ExibeMesAnterior();
            }
            else if (e.KeyCode == Keys.Right && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                ExibeMesPosterior();
            }
            else if (e.KeyCode == Keys.Up && e.Modifiers == (Keys.Control | Keys.Alt))
            {
                ExibeMesCorrente();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                ButtonFecharDetalhes_Click(sender, null);
            }
        }

        private void ExibeMesAnterior()
        {
            DateTime data = new DateTime(dateTimePickerDataBase.Value.Year, dateTimePickerDataBase.Value.Month, 15);
            dateTimePickerDataBase.Value = data.AddMonths(-1);
        }

        private void ExibeMesCorrente()
        {
            dateTimePickerDataBase.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 15);
        }

        private void ExibeMesPosterior()
        {
            DateTime data = new DateTime(dateTimePickerDataBase.Value.Year, dateTimePickerDataBase.Value.Month, 15);
            dateTimePickerDataBase.Value = data.AddMonths(1);
        }

        private void PagamentoCartaoCreditoDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Pinta os CABEÇALHOS de meses futuros ou do mês atual caso ainda haja previsão de pagamento de faturas
            if (e.RowIndex == -1)
            {
                if (pagamentoCartaoCreditoDataGridView.Columns[e.ColumnIndex].Tag != null)
                {
                    DateTime diaColuna = (DateTime)pagamentoCartaoCreditoDataGridView.Columns[e.ColumnIndex].Tag;

                    if (diaColuna > DateTime.Today ||
                        (ProximaFaturaCartao > DateTime.Today && ProximaFaturaCartao.Year == diaColuna.Year && ProximaFaturaCartao.Month == diaColuna.Month))
                    {
                        Color c1 = Color.Gold; // FromArgb(255, 54, 54, 54);
                        Color c2 = Color.Gold; // FromArgb(255, 62, 62, 62);
                        Color c3 = Color.Gold; // FromArgb(255, 98, 98, 98);

                        LinearGradientBrush br = new LinearGradientBrush(e.CellBounds, c1, c3, 90, true);
                        ColorBlend cb = new ColorBlend();
                        cb.Positions = new[] { 0, (float)0.5, 1 };
                        cb.Colors = new[] { c1, c2, c3 };
                        br.InterpolationColors = cb;

                        e.Graphics.FillRectangle(br, e.CellBounds);
                        e.PaintContent(e.ClipBounds);

                        e.Handled = true;
                    }
                }
            }
        }
    }
}
