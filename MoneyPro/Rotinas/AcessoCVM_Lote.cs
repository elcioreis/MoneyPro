using BLL;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace MoneyPro.Rotinas
{
    class AcessoCVM_Lote
    {
        //private NumberStyles style = NumberStyles.AllowDecimalPoint;
        private CultureInfo culture = CultureInfo.CreateSpecificCulture("pt-BR");

        //private ServiceReferenceCVM.sessaoIdHeader sessaoID = null;
        private ServiceReferenceCVM.WsDownloadInfsSoapClient cliente = new ServiceReferenceCVM.WsDownloadInfsSoapClient();

        public fmDownloadCotacoes Origem;
        private bool parar = false;

        public bool Parar
        {
            get { return parar; }
            set { parar = value; }
        }

        private DateTime InicioUtilizacao { get; set; }
        private string SiteCVM_Lote { get; set; }
        private readonly DateTime UltimaAtualizacaoM02_M03;
        private readonly DateTime UltimaAtualizacaoM04_M11;
        private readonly Boolean AtualizarTudo;

        public AcessoCVM_Lote(fmDownloadCotacoes origem)
        {
            this.Origem = origem;

            ConfiguracaoBLL bll = new ConfiguracaoBLL();
            DataTable config = bll.CarregarConfiguracoes();

            DataRow linha = config.Rows[0];

            InicioUtilizacao = linha.Field<DateTime>("DtInicioUtilizacao");
            SiteCVM_Lote = linha.Field<string>("SiteCVM_Lote");
            AtualizarTudo = linha.Field<Boolean>("AtualizarTudo");
            UltimaAtualizacaoM02_M03 = linha.Field<DateTime>("AtualizacaoM02_M03");
            UltimaAtualizacaoM04_M11 = linha.Field<DateTime>("AtualizacaoM04_M11");
        }

        internal int AtualizarCotacoesCVM_Lote(bool SomenteUltimoLote)
        {
            //CotacaoEletronicaBLL cotacao = new CotacaoEletronicaBLL();

            int sucesso = 0;
            DateTime limiteInferior = PegarDataLimiteInferior();
            DateTime limiteSuperior = PegarDataLimiteCotacao();

            // Limpa o list box para começar o processamento
            Origem.listBoxDatasAtualizadas.Items.Clear();

            Origem.IncluirProcessamento("Buscando cotações de fundos de investimento na CVM.");

            short i = 0;

            if (SomenteUltimoLote)
            {
                Origem.IncluirProcessamento("Atualizando apenas o lote de " + limiteSuperior.ToString("MM-yyyy") + ".");
                // Limita o download ao último lote disponível, que é do mês corrente.
                _ = ProcessaLote(limiteSuperior, i++, false, false);
            }
            else
            {
                // Lotes do mês atual e mês anterior são atualizados diariamente

                // Lotes com 02 a 03 meses são atualizados uma vez por semana, assim, a atualização
                // da tabela CotacaoCVM não é feita com menos de 7 dias entre uma e outra atualização.
                Boolean atualizarM02_M03 = DateTime.Today.AddDays(-7) > UltimaAtualizacaoM02_M03;
                // Lotes com 04 a 11 meses são atualizados uma vez por mês, assim, a atualização
                // da tabela CotacaoCVM não é feita com menos de 1 mês entre uma e outra atualização.
                Boolean atualizarM04_M11 = DateTime.Today.AddMonths(-1) > UltimaAtualizacaoM04_M11;

                // Lotes com mais de 11 meses não são mais atualizados

                while (limiteInferior <= limiteSuperior)
                {
                    limiteSuperior = ProcessaLote(limiteSuperior, i++, atualizarM02_M03, atualizarM04_M11);
                }

                CotacaoEletronicaBLL bll = new CotacaoEletronicaBLL();
                if (atualizarM02_M03)
                {
                    // Informa a data de atualização dos lotes de 02 a 03 meses de idade
                    // Atualizados uma vez por semana
                    bll.GravarAtualizacaoM02_M03();
                }

                if (atualizarM04_M11)
                {
                    // Informa a data de atualização dos lotes de 04 a 11 meses de idade
                    // Atualizados uma vez por mês
                    bll.GravarAtualizacaoM04_M11();
                }

                if (AtualizarTudo)
                {
                    // Informa que as cotações dos fundos foram atualiada após um novo investimente ter sido cadastrado em Investimento
                    bll.InformarAtualizacao();
                }
            }
            return sucesso;
        }

        private DateTime ProcessaLote(DateTime mesProcessamento, short mesDefazagem, Boolean atualizarM02_M03, Boolean atualizarM04_M11)
        {
            // Formato esperado para a URL
            // http://dados.cvm.gov.br/dados/FI/DOC/INF_DIARIO/DADOS/inf_diario_fi_YYYYMM.csv   

            string URL = SiteCVM_Lote + "/inf_diario_fi_" + mesProcessamento.ToString("yyyyMM") + ".zip";

            // Baixa nova versão do arquivo se:
            // mês de defazagem menor que 02;
            // mês de defazagem menor que 04 e é para atualizar meses de 02 e 03
            // mês de defazagem menor que 12 e é para atualizar meses de 04 e 11
            Boolean baixarArquivo = (mesDefazagem < 2) || ((mesDefazagem < 4) && atualizarM02_M03) || ((mesDefazagem < 12) && atualizarM04_M11);

            if (AtualizarTudo || baixarArquivo)
            {
                //arquivoCSV;
                if (BaixarArquivoZIP(URL, mesProcessamento, baixarArquivo, out string arquivoZIP))
                {
                    // Necessário descompactar o arquivo zip
                    if (DescompactarArquivoZIP(arquivoZIP, out string arquivoCSV))
                    {
                        LerInformacoesArquivoCSV(arquivoCSV);
                    }
                    else
                    {
                        Origem.IncluirProcessamento("Problemas ao tentar extrair o arquivo CSV.");
                        Origem.Problemas = true;
                    }
                }
                else
                {
                    Origem.IncluirProcessamento("Problemas ao tentar baixar o arquivo ZIP.");
                    Origem.Problemas = true;
                }
                mesProcessamento = new DateTime(mesProcessamento.Year, mesProcessamento.Month, 1).AddDays(-1);
            }
            else
            {
                mesProcessamento = InicioUtilizacao;
            }

            return mesProcessamento;
        }

        private bool DescompactarArquivoZIP(string arquivoZIP, out string arquivoCSV)
        {
            string pasta = Pasta();

            arquivoCSV = arquivoZIP.Substring(0, arquivoZIP.Length - 3) + "csv";

            File.Delete(arquivoCSV);

            ZipFile.ExtractToDirectory(arquivoZIP, pasta);

            File.Delete(arquivoZIP);

            return File.Exists(arquivoCSV);
        }

        private void LerInformacoesArquivoCSV(string arquivoCSV)
        {
            var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();

            culture.NumberFormat.NumberDecimalSeparator = ".";

            // Lê o arquivo CSV e o transforma numa lista
            var comCabecalho = File.ReadLines(arquivoCSV).Select(a => a.Split(';')).ToList();
            // Remove o cabeçalho da lista
            if (comCabecalho[0].Length == 10)
            {
                comCabecalho.RemoveAt(0);

                List<CotacaoCVM> cotacaoCVM = new List<CotacaoCVM>();

                string cnpj = string.Empty;
                try
                {
                    foreach (var linha in comCabecalho)
                    {
                        // TP_FUNDO; CNPJ_FUNDO; ID_SUBCLASSE; DT_COMPTC; VL_TOTAL; VL_QUOTA; VL_PATRIM_LIQ; CAPTC_DIA; RESG_DIA; NR_COTST
                        // FI; 00.017.024/0001-53; ; 2019-06-03; 1136577.69; 26.918181500000; 1128817.89; 0.00; 0.00; 1
                        // FI; 00.017.024/0001-53; ; 2019-06-04; 1136857.45; 26.923462900000; 1129039.37; 0.00; 0.00; 1

                        cnpj = linha[1];

                        cotacaoCVM.Add(new CotacaoCVM()
                        {
                            CotacaoCVMID = 0,
                            TipoFundo = linha[0],
                            CNPJ = linha[1],
                            Data = DateTime.ParseExact(linha[3], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                            VrTotalCarteira = !string.IsNullOrEmpty(linha[4]) ? Decimal.Parse(linha[4], culture) : 0,
                            VrCotacao = Decimal.Parse(linha[5], culture),
                            VrPatrimonioLiquido = Decimal.Parse(linha[6], culture),
                            VrCaptacaoDia = Decimal.Parse(linha[7], culture),
                            VrResgateDia = Decimal.Parse(linha[8], culture),
                            NroCotistas = int.Parse(linha[9], culture)
                        });
                    }
                }
                catch (Exception ex)
                {
                    Origem.IncluirProcessamento("Erro ao processar o arquivo CSV: " + ex.Message);
                    Origem.IncluirProcessamento("CNPJ com erro: " + cnpj);
                    Origem.Problemas = true;
                    return;
                }

                //var cotacaoCVM = comCabecalho.Select(linha => new CotacaoCVM()
                //{
                //    // TP_FUNDO; CNPJ_FUNDO; ID_SUBCLASSE; DT_COMPTC; VL_TOTAL; VL_QUOTA; VL_PATRIM_LIQ; CAPTC_DIA; RESG_DIA; NR_COTST
                //    // FI; 00.017.024/0001-53; ; 2019-06-03; 1136577.69; 26.918181500000; 1128817.89; 0.00; 0.00; 1
                //    // FI; 00.017.024/0001-53; ; 2019-06-04; 1136857.45; 26.923462900000; 1129039.37; 0.00; 0.00; 1

                //    CotacaoCVMID = 0,
                //    TipoFundo = linha[0],
                //    CNPJ = linha[1],
                //    Data = DateTime.ParseExact(linha[3], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                //    VrTotalCarteira = Decimal.Parse(linha[4], culture),
                //    VrCotacao = Decimal.Parse(linha[5], culture),
                //    VrPatrimonioLiquido = Decimal.Parse(linha[6], culture),
                //    VrCaptacaoDia = Decimal.Parse(linha[7], culture),
                //    VrResgateDia = Decimal.Parse(linha[8], culture),
                //    NroCotistas = int.Parse(linha[9], culture)
                //}
                //).ToList();

                CotacaoEletronicaBLL bll = new CotacaoEletronicaBLL();

                DataTable listaCNPJFundosCVM = bll.ListarCNPJFundosCVM();
                // Cria uma chave primária para a DataTable
                DataColumn[] pk = new DataColumn[1];
                pk[0] = listaCNPJFundosCVM.Columns["CodigoCVM"];

                listaCNPJFundosCVM.PrimaryKey = pk;

                foreach (var cotacao in cotacaoCVM)
                {
                    if (listaCNPJFundosCVM.Rows.Find(cotacao.CNPJ) != null)
                    {
                        bll.InserirCotacaoCVM(cotacao);
                        Application.DoEvents();
                    }
                }
            }
            else if (comCabecalho[0].Length == 9)
            {
                comCabecalho.RemoveAt(0);

                var cotacaoCVM = comCabecalho.Select(a => new CotacaoCVM()
                {
                    // TP_FUNDO; CNPJ_FUNDO; DT_COMPTC; VL_TOTAL; VL_QUOTA; VL_PATRIM_LIQ; CAPTC_DIA; RESG_DIA; NR_COTST
                    // FI; 00.017.024/0001-53; 2019-06-03; 1136577.69; 26.918181500000; 1128817.89; 0.00; 0.00; 1
                    // FI; 00.017.024/0001-53; 2019-06-04; 1136857.45; 26.923462900000; 1129039.37; 0.00; 0.00; 1

                    CotacaoCVMID = 0,
                    TipoFundo = a[0],
                    CNPJ = a[1],
                    Data = DateTime.ParseExact(a[2], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    VrTotalCarteira = Decimal.Parse(a[3], culture),
                    VrCotacao = Decimal.Parse(a[4], culture),
                    VrPatrimonioLiquido = Decimal.Parse(a[5], culture),
                    VrCaptacaoDia = Decimal.Parse(a[6], culture),
                    VrResgateDia = Decimal.Parse(a[7], culture),
                    NroCotistas = int.Parse(a[8], culture)
                }
                ).ToList();

                CotacaoEletronicaBLL bll = new CotacaoEletronicaBLL();

                DataTable listaCNPJFundosCVM = bll.ListarCNPJFundosCVM();
                // Cria uma chave primária para a DataTable
                DataColumn[] pk = new DataColumn[1];
                pk[0] = listaCNPJFundosCVM.Columns["CodigoCVM"];

                listaCNPJFundosCVM.PrimaryKey = pk;

                foreach (var cotacao in cotacaoCVM)
                {
                    if (listaCNPJFundosCVM.Rows.Find(cotacao.CNPJ) != null)
                    {
                        bll.InserirCotacaoCVM(cotacao);
                        Application.DoEvents();
                    }
                }
            }
            else if (comCabecalho[0].Length == 8)
            {
                comCabecalho.RemoveAt(0);

                var cotacaoCVM = comCabecalho.Select(a => new CotacaoCVM()
                {
                    // CNPJ_FUNDO; DT_COMPTC; VL_TOTAL; VL_QUOTA; VL_PATRIM_LIQ; CAPTC_DIA; RESG_DIA; NR_COTST
                    // 00.017.024/0001-53; 2019-06-04; 1136857.45; 26.923462900000; 1129039.37; 0.00; 0.00; 1
                    // 00.017.024/0001-53; 2019-06-03; 1136577.69; 26.918181500000; 1128817.89; 0.00; 0.00; 1

                    CotacaoCVMID = 0,
                    TipoFundo = "NAO INFORMADO",
                    CNPJ = a[0],
                    Data = DateTime.ParseExact(a[1], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    VrTotalCarteira = Decimal.Parse(a[2], culture),
                    VrCotacao = Decimal.Parse(a[3], culture),
                    VrPatrimonioLiquido = Decimal.Parse(a[4], culture),
                    VrCaptacaoDia = Decimal.Parse(a[5], culture),
                    VrResgateDia = Decimal.Parse(a[6], culture),
                    NroCotistas = int.Parse(a[8], culture)
                }
                ).ToList();

                CotacaoEletronicaBLL bll = new CotacaoEletronicaBLL();

                DataTable listaCNPJFundosCVM = bll.ListarCNPJFundosCVM();
                // Cria uma chave primária para a DataTable
                DataColumn[] pk = new DataColumn[1];
                pk[0] = listaCNPJFundosCVM.Columns["CodigoCVM"];

                listaCNPJFundosCVM.PrimaryKey = pk;

                foreach (var cotacao in cotacaoCVM)
                {
                    if (listaCNPJFundosCVM.Rows.Find(cotacao.CNPJ) != null)
                    {
                        bll.InserirCotacaoCVM(cotacao);
                        Application.DoEvents();
                    }
                }
            }
        }

        public DateTime PegarDataLimiteInferior()
        {
            var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();

            return DateTime.ParseExact("2017-01-01", "yyyy-MM-dd", culture);
        }

        public DateTime PegarDataLimiteCotacao()
        {
            DateTime ultimaDataCotacao = DateTime.Today.AddDays(-2);

            while (ultimaDataCotacao.DayOfWeek == DayOfWeek.Saturday || ultimaDataCotacao.DayOfWeek == DayOfWeek.Sunday || Geral.Feriado(ultimaDataCotacao))
            {
                ultimaDataCotacao = ultimaDataCotacao.AddDays(-1);
            }

            return ultimaDataCotacao;
        }

        private string Pasta()
        {
            // Pasta para colocar os arquivos baixados
            StringBuilder pasta = new StringBuilder(Path.GetTempPath() + "MoneyPro");

            if (!Directory.Exists(pasta.ToString()))
            {
                Directory.CreateDirectory(pasta.ToString());
            }

            return pasta.ToString();
        }

        public bool BaixarArquivoZIP(string url, DateTime data, Boolean forcaDownload, out string arquivoZip)
        {
            string pasta = Pasta();

            if (Origem.Tag == null)
            {
                Origem.Tag = pasta;
            }

            // Receberá os nomes dos arquivos baixados
            arquivoZip = pasta + "\\inf_diario_fi_" + data.ToString("yyyyMM") + ".zip";

            if (File.Exists(arquivoZip) && forcaDownload)
            {
                File.Delete(arquivoZip);
            }

            if (!File.Exists(arquivoZip))
            {
                string mensagem = "Baixando arquivo inf_diario_fi_" + data.ToString("yyyyMM") + ".zip";

                Origem.IncluirProcessamento(mensagem);

                Stopwatch sw = new Stopwatch();
                sw.Start();

                try
                {
                    try
                    {
                        DateTime startTime = DateTime.UtcNow;
                        WebRequest request = WebRequest.Create(url);
                        request.Method = "GET";

                        WebResponse response = request.GetResponse();

                        Stream responseStream = response.GetResponseStream();
                        Stream fileStream = File.OpenWrite(arquivoZip);

                        try
                        {
                            const int tamanho = 65535;
                            byte[] buffer = new byte[tamanho];

                            int r = 0;

                            int bytesRead = responseStream.Read(buffer, 0, tamanho);

                            while (bytesRead > 0)
                            {
                                // Atualiza a linha informativa de processamento a cada 3 passos
                                switch (r++ % 12)
                                {
                                    case 0:
                                        Origem.AtualizarProcessamento(mensagem + "  -");
                                        break;
                                    case 3:
                                        Origem.AtualizarProcessamento(mensagem + "  \\");
                                        break;
                                    case 6:
                                        Origem.AtualizarProcessamento(mensagem + "  |");
                                        break;
                                    case 9:
                                        Origem.AtualizarProcessamento(mensagem + "  /");
                                        break;
                                    default:
                                        break;
                                }

                                fileStream.Write(buffer, 0, bytesRead);
                                DateTime nowTime = DateTime.UtcNow;
                                if ((nowTime - startTime).TotalMinutes > 5)
                                {
                                    throw new ApplicationException("Download timed out.");
                                }
                                bytesRead = responseStream.Read(buffer, 0, tamanho);

                                Application.DoEvents();
                            }
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                        finally
                        {
                            fileStream.Flush();
                            fileStream.Close();

                            response.Dispose();
                            response.Close();
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
                finally
                {
                    // Somente para cronometrar
                    TimeSpan ts = sw.Elapsed;
                    Origem.AtualizarProcessamento(string.Format("{0} em {1:00}:{2:00}:{3:00}.", mensagem, ts.Hours, ts.Minutes, ts.Seconds));
                    //string mensagem = string.Format("Variação acumulada de investimentos calculada em {0:00}:{1:00}:{2:00}.", ts.Hours, ts.Minutes, ts.Seconds);
                }
            }
            else
            {
                Origem.IncluirProcessamento("Usando arquivo MoneyPro_" + data.ToString("yyyyMM") + "_CVM.csv previamente baixado.");
                return true;
            }
        }
    }
}

