using BLL;
using Modelos;
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MoneyPro
{
    public partial class fmDownloadCotacoes : Form
    {
        Rotinas.AcessoCVM_Lote atualizaCVM_Lote = null;
        Rotinas.AcessoMercadoBitCoin atualizaBTC = null;
        Rotinas.AcessoCotacoesBancoCentral atualizaCBC = null;

        FmPrincipal Origem;

        Stopwatch stopWatch = new Stopwatch();

        private bool SomenteUltimoLote { get; set; }

        public bool Problemas { get; set; }

        int arbitrario = 0;

        public fmDownloadCotacoes(FmPrincipal origem, bool ctrl_ligado = false)
        {
            this.SomenteUltimoLote = !ctrl_ligado;
            this.Origem = origem;
            this.Problemas = false;

            InitializeComponent();
        }

        #region Cotacoes Bovespa

        private void ProcessaCotacoesBovespa()
        {
            AcaoCotacaoBLL bll = new AcaoCotacaoBLL();
            DataTable acoes = bll.BuscarCotacoes();

            if (acoes.Rows.Count > 0)
            {
                IncluirProcessamento("Buscando cotação de ações na BOVESPA.");
            }

            foreach (DataRow linha in acoes.Rows)
            {
                IncluirProcessamento("Buscando cotação de " + (string)linha["Consulta"] + ".");

                AcaoCotacao modelo = CarregaCotacao((string)linha["Consulta"]);

                if (modelo.InvestimentoID > 0)
                {
                    modelo.InvestimentoID = (int)linha["InvestimentoID"];
                    modelo.AcaoCotacaoID = bll.ExisteCotacao(modelo.InvestimentoID, modelo.Data);

                    if (modelo.AcaoCotacaoID == 0)
                    {
                        // Inclui cotação
                        bll.Incluir(modelo);
                        AtualizarProcessamento("Cotação de " + modelo.Codigo + " de " + modelo.Data.ToString("dd/MM/yyyy") + " incluída.");
                    }
                    else
                    {
                        // Atualiza cotação;
                        bll.Alterar(modelo);
                        AtualizarProcessamento("Cotação de " + modelo.Codigo + " de " + modelo.Data.ToString("dd/MM/yyyy") + " atualizada.");
                    }
                }
                else
                {
                    AtualizarProcessamento("Cotação de " + modelo.Codigo + " falhou na atualização.");
                }
            }

            CotacaoEletronicaBLL cota = new CotacaoEletronicaBLL();
            cota.AtualizaAcoesBOVESPA();
        }

        private AcaoCotacao CarregaCotacao(string codigoPapel)
        {
            NumberStyles style = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("pt-BR");

            AcaoCotacao modelo = new AcaoCotacao();

            string url = @"http://www.bmfbovespa.com.br/Pregao-Online/ExecutaAcaoAjax.asp?CodigoPapel=" + codigoPapel;

            string xml;
            try
            {
                using (var webClient = new WebClient())
                {
                    xml = webClient.DownloadString(url);
                }
            }
            catch
            {
                xml = String.Empty;
                modelo.InvestimentoID = -1;
                modelo.Codigo = codigoPapel;
            }

            if (xml != String.Empty)
            {
                XDocument xDoc = XDocument.Parse(xml);

                foreach (XElement item in xDoc.Root.Nodes())
                {
                    if (item.NodeType == XmlNodeType.Element)
                    {
                        modelo.Codigo = item.Attribute("Codigo").Value;
                        modelo.Nome = item.Attribute("Nome").Value;
                        modelo.Ibovespa = item.Attribute("Ibovespa").Value;

                        DateTime data;

                        if (!DateTime.TryParseExact(item.Attribute("Data").Value, "dd/MM/yyyyHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
                        {
                            if (!DateTime.TryParseExact(item.Attribute("Data").Value, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
                            {
                                data = DateTime.Parse("01/01/1900");
                            }
                        }
                        modelo.Data = data;

                        decimal valor;

                        if (!Decimal.TryParse(item.Attribute("Abertura").Value, style, culture, out valor))
                        {
                            valor = 0;
                        }
                        modelo.Abertura = valor;

                        if (!Decimal.TryParse(item.Attribute("Minimo").Value, style, culture, out valor))
                        {
                            valor = 0;
                        }
                        modelo.Minimo = valor;

                        if (!Decimal.TryParse(item.Attribute("Maximo").Value, style, culture, out valor))
                        {
                            valor = 0;
                        }
                        modelo.Maximo = valor;

                        if (!Decimal.TryParse(item.Attribute("Medio").Value, style, culture, out valor))
                        {
                            valor = 0;
                        }
                        modelo.Medio = valor;

                        if (!Decimal.TryParse(item.Attribute("Ultimo").Value, style, culture, out valor))
                        {
                            valor = 0;
                        }
                        modelo.Ultimo = valor;

                        if (!Decimal.TryParse(item.Attribute("Oscilacao").Value, style, culture, out valor))
                        {
                            valor = 0;
                        }
                        modelo.Oscilacao = valor;
                    }
                }
            }
            return modelo;
        }

        #endregion Cotacoes Bovespa

        #region Cotacoes CVM

        private void ProcessaCotacoesCVM()
        {
            Update();
            Application.DoEvents();

            atualizaCVM_Lote = new Rotinas.AcessoCVM_Lote(this);
            _ = atualizaCVM_Lote.AtualizarCotacoesCVM_Lote(SomenteUltimoLote);
        }

        public bool IncluirProcessamento(string texto)
        {
            arbitrario = 0;
            listBoxDatasAtualizadas.Items.Add(" " + texto);

            // na listbox cabem 13 linhas na horizontal, antes de iniciar o 
            // scroll, se for maior que 13, liga o scroll definitivamente. 
            // (diminui flic na janela e melhora performance)
            if (!listBoxDatasAtualizadas.ScrollAlwaysVisible)
            {
                if (listBoxDatasAtualizadas.Items.Count > 13)
                {
                    listBoxDatasAtualizadas.ScrollAlwaysVisible = true;
                }
            }

            AtualizarJanela();

            if (atualizaCVM_Lote != null)
                return atualizaCVM_Lote.Parar;
            else
                return true;
        }

        public bool AtualizarProcessamento(string texto)
        {
            listBoxDatasAtualizadas.Items[listBoxDatasAtualizadas.Items.Count - 1] = " " + texto;
            AtualizarJanela();

            if (atualizaCVM_Lote != null)
                return atualizaCVM_Lote.Parar;
            else
                return true;
        }

        public void Finalizou()
        {
            TimeSpan ts = stopWatch.Elapsed;
            IncluirProcessamento(string.Format("Processamento de cotações finalizado em {0:00}:{1:00}:{2:00}.", ts.Hours, ts.Minutes, ts.Seconds));
            buttonInterromper.Text = "Fechar";
        }

        #endregion Cotacoes CVM

        private void AtualizarJanela()
        {
            if (arbitrario-- == 0)
            {
                this.Update();
                listBoxDatasAtualizadas.SelectedIndex = listBoxDatasAtualizadas.Items.Count - 1;
                Application.DoEvents();
                arbitrario = 29;
            }
        }

        private void fmProcessamentoCVM_Shown(object sender, EventArgs e)
        {
            // Inicia o cronômetro para saber o tempo de download das cotações
            stopWatch.Start();

            using (Rotinas.AcessoHitBTC acessoHitBTC = new Rotinas.AcessoHitBTC(this.Origem, this.Origem.UserID))
            {
                acessoHitBTC.CarregarCandlesHorario();
            }

            try
            {
                ProcessaCotacoesCVM();
            }
            catch (ArgumentException)
            {
                IncluirProcessamento("Erro ao atualizar cotações da CVM (argumentos):");
                IncluirProcessamento(string.Format(" - {0}", e));
            }
            catch (Exception)
            {
                //IncluirProcessamento(ex.InnerException.ToString());
                IncluirProcessamento("Erro ao atualizar cotações da CVM:");
                IncluirProcessamento(string.Format(" - {0}", e));
            }

            try
            {
                ProcessaCotacoesBancoCentral();
            }
            catch (ArgumentException)
            {
                IncluirProcessamento("Erro ao atualizar cotações do Banco Central (argumentos):");
                IncluirProcessamento(string.Format(" - {0}", e));
            }
            catch (Exception)
            {
                IncluirProcessamento("Erro ao atualizar cotações do Banco Central:");
                IncluirProcessamento(string.Format(" - {0}", e));
            }

            try
            {
                // TODO Retirar comentário ao finalizar o desenvolvimento
                //ProcessaCotacoesBovespa();
            }
            catch
            {
                // Não dá mensagem de erro.
            }

            if (!Problemas)
            {
                try
                {
                    AtualizaInvestimentoVariacao();
                }
                catch (Exception)
                {
                    IncluirProcessamento("Erro ao atualizar variação de investimentos:");
                    IncluirProcessamento(string.Format(" - {0}", e));
                }
            }
            else
            {
                IncluirProcessamento("Os investimentos não foram atualizados.");
            }

            // Faz com que o rol de contas à esquerda da tela seja atualizado
            Origem.CarregarRolContas();

            // Finaliza o cronômetro
            stopWatch.Stop();

            Finalizou();
            listBoxDatasAtualizadas.SelectedIndex = listBoxDatasAtualizadas.Items.Count - 1;
        }

        private void ProcessaCotacoesBancoCentral()
        {
            Update();
            Application.DoEvents();

            atualizaCBC = new Rotinas.AcessoCotacoesBancoCentral(this);
            atualizaCBC.AtualizarCotacoesBancoCentral();
        }

        private void ProcessaCotacoesMercadoBitCoin()
        {
            this.Update();
            Application.DoEvents();

            MovimentoCambioBLL bll = new MovimentoCambioBLL();
            DataTable moedasCotacao = bll.MoedasMercadoBitCoin();

            foreach (DataRow linha in moedasCotacao.Rows)
            {
                string apelido = linha.Field<String>("Apelido");
                string simbolo = linha.Field<String>("Simbolo");

                atualizaBTC = new Rotinas.AcessoMercadoBitCoin(this);

                int sucesso = atualizaBTC.AtualizarCotacoesMercadoBitCoin(simbolo);

                switch (sucesso)
                {
                    case 0:
                        IncluirProcessamento(String.Format("Nenhuma cotação de {0} atualizada.", apelido));
                        break;
                    case 1:
                        IncluirProcessamento(String.Format("Uma cotação de {0} atualizada.", apelido));
                        break;
                    default:
                        IncluirProcessamento(String.Format("{0} cotações de {1} atualizadas.", sucesso, apelido));
                        break;
                }
            }
        }

        private void AtualizaInvestimentoVariacao()
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            this.Update();
            Application.DoEvents();

            //IncluirProcessamento();

            Geral.AtualizarCotacoesCVM(this, "Calculando variação acumulada de investimentos");
            Geral.AtualizarInvestimentoVariacao(this, "Calculando variação acumulada de investimentos");

            TimeSpan ts = sw.Elapsed;
            string mensagem = string.Format("Variação acumulada de investimentos calculada em {0:00}:{1:00}:{2:00}.", ts.Hours, ts.Minutes, ts.Seconds);
            AtualizarProcessamento(mensagem);

            Origem.CarregarRolContas();
        }

        private void buttonInterromper_Click(object sender, EventArgs e)
        {
            if (atualizaCVM_Lote != null)
            {
                atualizaCVM_Lote.Parar = true;
            }

            if (buttonInterromper.Text == "Interromper")
            {
                buttonInterromper.Text = "Fechar";
            }
            else
            {
                this.Close();
            }
        }

        private void PanelTopo_DoubleClick(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                System.Diagnostics.Process.Start("Explorer", (string)Tag);
            }
        }
    }
}
