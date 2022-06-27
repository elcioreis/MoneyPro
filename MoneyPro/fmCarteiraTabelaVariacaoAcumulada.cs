using BLL;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Modelos.Tipo;

namespace MoneyPro
{
    public partial class fmCarteiraTabelaVariacaoAcumulada : MoneyPro.Base.fmBaseTopoRodape
    {

        private Form Origem { get; set; }
        private TipoConsultaInvestimentoVariacao tipoConsulta = TipoConsultaInvestimentoVariacao.CompletoMensal;

        #region Singleton

        private static fmCarteiraTabelaVariacaoAcumulada _singleton;

        private fmCarteiraTabelaVariacaoAcumulada(Form origem)
        {
            InitializeComponent();
            this.Origem = origem;
            this.Visible = false;
            btnTudo.BackColor = Color.Gray;
            ExibeVariacaoAcumulada(tipoConsulta);
        }

        public static fmCarteiraTabelaVariacaoAcumulada CreateInstance(Form origem)
        {
            if (_singleton == null)
            {
                _singleton = new fmCarteiraTabelaVariacaoAcumulada(origem);
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

        private void ExibeVariacaoAcumulada(TipoConsultaInvestimentoVariacao tipoConsulta)
        {
            CarteiraBLL bll = new CarteiraBLL();
            dataGridViewVariacao.AutoGenerateColumns = true;
            dataGridViewVariacao.DataSource = variacaoBindingSource;
            variacaoBindingSource.DataSource = bll.VariacaoAcumulada(tipoConsulta);

            foreach (DataGridViewColumn item in dataGridViewVariacao.Columns)
            {
                if (item.Name == "Data")
                {
                    item.DefaultCellStyle.Format = "MMM/yyyy";
                    item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    item.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    item.MinimumWidth = 50;
                }
                else if (item.Name == "TipoDado")
                {
                    item.HeaderText = "Descrição";
                    item.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    item.MinimumWidth = 80;
                }
                else
                {
                    item.DefaultCellStyle.Format = "C2";
                    item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    item.MinimumWidth = 80;
                    item.Width = 108;
                    item.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                }
            }
        }

        private void btnMudaExibicao(object sender, EventArgs e)
        {
            bool mudou = false;

            switch (tipoConsulta)
            {
                case TipoConsultaInvestimentoVariacao.AcumuladoMensal:
                    btnAcumulado.BackColor = Color.WhiteSmoke;
                    break;
                case TipoConsultaInvestimentoVariacao.VariacaoMensal:
                    btnVariacao.BackColor = Color.WhiteSmoke;
                    break;
                case TipoConsultaInvestimentoVariacao.CompletoMensal:
                    btnTudo.BackColor = Color.WhiteSmoke;
                    break;
                default:
                    break;
            }

            if (sender == btnTudo)
            {
                mudou = (tipoConsulta != TipoConsultaInvestimentoVariacao.CompletoMensal);
                tipoConsulta = TipoConsultaInvestimentoVariacao.CompletoMensal;
            }
            else if (sender == btnAcumulado)
            {
                mudou = (tipoConsulta != TipoConsultaInvestimentoVariacao.AcumuladoMensal);
                tipoConsulta = TipoConsultaInvestimentoVariacao.AcumuladoMensal;
            }
            else if (sender == btnVariacao)
            {
                mudou = (tipoConsulta != TipoConsultaInvestimentoVariacao.VariacaoMensal);
                tipoConsulta = TipoConsultaInvestimentoVariacao.VariacaoMensal;
            }

            if (mudou)
            {
                ExibeVariacaoAcumulada(tipoConsulta);
            }

            switch (tipoConsulta)
            {
                case TipoConsultaInvestimentoVariacao.AcumuladoMensal:
                    btnAcumulado.BackColor = Color.Gray;
                    break;
                case TipoConsultaInvestimentoVariacao.VariacaoMensal:
                    btnVariacao.BackColor = Color.Gray;
                    break;
                case TipoConsultaInvestimentoVariacao.CompletoMensal:
                    btnTudo.BackColor = Color.Gray;
                    break;
                default:
                    break;
            }

        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
    }
}
