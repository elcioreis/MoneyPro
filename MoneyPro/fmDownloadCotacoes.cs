using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace MoneyPro
{
    public partial class fmDownloadCotacoes : Form
    {
        AcaoCotacaoBLL bll = new AcaoCotacaoBLL();

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

        #region Cotacoes B3

        private void ProcessaCotacoesB3()
        {
            DataTable acoes = bll.BuscarCotacoes();

            if (acoes.Rows.Count > 0)
            {
                IncluirProcessamento("Buscando cotação de ações em arquivo B3.");
                ProcurarArquivosB3(acoes);
            }

            CotacaoEletronicaBLL cota = new CotacaoEletronicaBLL();
            cota.AtualizaAcoesB3();
        }

        private void ProcurarArquivosB3(DataTable acoes)
        {
            // Pega a pasta de downloads, que sempre fica abaixo da pasta do usuário corrente
            string pastaDownload = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\Downloads";
            // Procura todos arquivos de cotação histórica diária da Bolsa de Valores de São Paulo (B3) que seguem o padrão
            // COTAHIST_Dddmmaaaa.ZIP onde ddmmaaaa é o dia da cotação histórica

            string pasta = Geral.PastaTemporariaMoneyPro();

            var arquivosZIP = Directory
                .GetFiles(pastaDownload, "COTAHIST_*.ZIP")
                .Select(fn => new FileInfo(fn))
                .OrderBy(f => f.Name);

            foreach (var arquivoZIP in arquivosZIP)
            {
                int ponto = arquivoZIP.Name.IndexOf('.');
                string fileName = $"{pasta}\\{arquivoZIP.Name.Substring(0, ponto)}.TXT";
                if (File.Exists(fileName))
                    File.Delete(fileName);
                ZipFile.ExtractToDirectory(arquivoZIP.FullName, pasta);
            }

            var arquivos = Directory
                .GetFiles(pasta, "COTAHIST_*.txt")
                .Select(fn => new FileInfo(fn))
                .OrderBy(f => f.Name);

            if (arquivos.Count() > 0)
            {

                for (int i = 0; i < arquivos.Count(); i++)
                {
                    var arquivo = arquivos.ElementAt(i).Name;
                    IncluirProcessamento($"Processando arquivo {arquivo}");
                    if (ProcessarArquivoB3(arquivos.ElementAt(i).FullName, acoes))
                    {
                        //int ponto = arquivos.ElementAt(i).FullName.IndexOf('.');
                        //string userdFileName = arquivos.ElementAt(i).FullName;
                        //string newFileName = arquivos.ElementAt(i).FullName.Substring(0, ponto) + ".ok";

                        if (File.Exists(arquivos.ElementAt(i).FullName))
                            File.Delete(arquivos.ElementAt(i).FullName);
                    }
                }
            }
            else
            {
                IncluirProcessamento("Não foram encontrados arquivos ");
            }
        }

        private bool ProcessarArquivoB3(string arquivoB3, DataTable acoes)
        {
            List<DataRow> rows = acoes.AsEnumerable().ToList();

            using (var file = new StreamReader(arquivoB3))
            {
                string line = string.Empty;

                try
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.StartsWith("01"))
                        {
                            var CotacaoB3 = new CotacaoHistoricaB3
                            {
                                Tipreg = Convert.ToInt32(line.Substring(0, 2)),
                                DataPregao = DateTime.ParseExact(line.Substring(2, 8), "yyyyMMdd", CultureInfo.InvariantCulture),
                                CodBDI = line.Substring(10, 2),
                                CodNeg = line.Substring(12, 12).Trim(), // Código da ação na B3
                                TpMerc = Convert.ToInt32(line.Substring(24, 3)),
                                NomRes = line.Substring(27, 12).Trim(),
                                Especi = line.Substring(39, 10).Trim(),
                                PrazoT = line.Substring(49, 3).Trim(),
                                ModRef = line.Substring(52, 4).Trim(),
                                PreAbe = Convert.ToDecimal(line.Substring(56, 13)) / 100,
                                PreMax = Convert.ToDecimal(line.Substring(69, 13)) / 100,
                                PreMin = Convert.ToDecimal(line.Substring(82, 13)) / 100,
                                PreMed = Convert.ToDecimal(line.Substring(95, 13)) / 100,
                                PreUlt = Convert.ToDecimal(line.Substring(108, 13)) / 100,
                                PreOFC = Convert.ToDecimal(line.Substring(121, 13)) / 100,
                                PreOFV = Convert.ToDecimal(line.Substring(134, 13)) / 100,
                                TotNeg = Convert.ToInt32(line.Substring(147, 5)),
                                QuaTot = Convert.ToDecimal(line.Substring(152, 18)),
                                VolTot = Convert.ToDecimal(line.Substring(170, 18)) / 100,
                                PreExe = Convert.ToDecimal(line.Substring(188, 13)) / 100,
                                IndOPC = Convert.ToDecimal(line.Substring(201, 1)),
                                DatVen = DateTime.ParseExact(line.Substring(202, 8), "yyyyMMdd", CultureInfo.InvariantCulture),
                                FatCot = Convert.ToDecimal(line.Substring(210, 7)),
                                PtoExe = Convert.ToDecimal(line.Substring(217, 13)) / 1000000,
                                CodIsi = line.Substring(230, 12).Trim(),
                                DisMes = Convert.ToDecimal(line.Substring(242, 3))
                            };

                            var acaoProcurada = rows.Find(x => x.Field<String>("Consulta") == CotacaoB3.CodNeg);

                            if (acaoProcurada != null)
                            {
                                bll.AtualizarCotacaoB3(CotacaoB3, acaoProcurada.Field<int>("InvestimentoID"));
                            }
                        }
                    }

                    file.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
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

            try
            {
                ProcessaCotacoesCVM();
            }
            catch (ArgumentException)
            {
                IncluirProcessamento("Erro ao atualizar cotações da CVM (argumentos):");
                IncluirProcessamento(string.Format(" - {0}", e));
            }
            catch (Exception ex)
            {
                //IncluirProcessamento(ex.InnerException.ToString());
                IncluirProcessamento("Erro ao atualizar cotações da CVM:");
                IncluirProcessamento(string.Format(" - {0}", e));
                IncluirProcessamento(ex.Message);
            }

            try
            {
                ProcessaCotacoesB3();
            }
            catch (Exception ex)
            {
                IncluirProcessamento("Erro ao atualizar cotações B3");
                IncluirProcessamento(ex.Message);
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

            using (Rotinas.AcessoHitBTC acessoHitBTC = new Rotinas.AcessoHitBTC(this.Origem, this.Origem.UserID))
            {
                acessoHitBTC.CarregarCandlesHorario();
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
                IncluirProcessamento("Os investimentos foram atualizados.");
            }

            // Faz com que o rol de contas à esquerda da tela seja atualizado
            Origem.CarregarRolContasAsync();

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
            IncluirProcessamento(mensagem);

            Origem.CarregarRolContasAsync();
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
