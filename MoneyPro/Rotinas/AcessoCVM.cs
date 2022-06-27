using BLL;
using Modelos;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace MoneyPro.Rotinas
{
    enum TipoDocumento : int
    {
        Diario = 209,
        Balancete = 50
    }

    public class AcessoCVM
    {
        private NumberStyles style = NumberStyles.AllowDecimalPoint;
        private CultureInfo culture = CultureInfo.CreateSpecificCulture("pt-BR");

        private ServiceReferenceCVM.sessaoIdHeader sessaoID = null;
        private ServiceReferenceCVM.WsDownloadInfsSoapClient cliente = new ServiceReferenceCVM.WsDownloadInfsSoapClient();

        public fmDownloadCotacoes form;
        private bool parar = false;

        public bool Parar
        {
            get { return parar; }
            set { parar = value; }
        }

        private string CMV_NomeSistemaCliente { get; set; }
        private string CMV_CPFResponsavelSC { get; set; }
        private string CMV_NomeResponsavelSC { get; set; }
        private int CMV_IdentificacaoSC { get; set; }
        private string CMV_SenhaSC { get; set; }
        private DateTime InicioUtilizacao { get; set; }
        private string SiteCVM { get; set; }

        public AcessoCVM(fmDownloadCotacoes origem)
        {
            this.form = origem;

            ConfiguracaoBLL bll = new ConfiguracaoBLL();
            DataTable config = bll.CarregarConfiguracoes();

            DataRow linha = config.Rows[0];

            CMV_NomeSistemaCliente = linha.Field<string>("CMV_NomeSistemaCliente");
            CMV_CPFResponsavelSC = linha.Field<string>("CMV_CPFResponsavelSC");
            CMV_NomeResponsavelSC = linha.Field<string>("CMV_NomeResponsavelSC");
            CMV_IdentificacaoSC = linha.Field<int>("CMV_IdentificacaoSC");
            CMV_SenhaSC = linha.Field<string>("CMV_SenhaSC");
            InicioUtilizacao = linha.Field<DateTime>("DtInicioUtilizacao");
            SiteCVM = linha.Field<string>("SiteCVM");

            sessaoID = Login(CMV_IdentificacaoSC, CMV_SenhaSC);
        }

        public int AtualizarCotacoesCVM()
        {
            CotacaoEletronicaBLL cotacao = new CotacaoEletronicaBLL();

            DialogResult dr = DialogResult.Yes;

            int N = 10;
            int sucesso = 0;
            DateTime limiteInferior = PegarDataLimiteInferior();
            DateTime limiteSuperior = PegarDataLimiteCotacao();

            if (limiteSuperior == DateTime.MinValue)
            {
                return 0;
            }

            string url = String.Empty;
            string arquivoZip;
            string arquivoXML;

            while (limiteInferior.DayOfWeek == DayOfWeek.Saturday || limiteInferior.DayOfWeek == DayOfWeek.Sunday || Geral.Feriado(limiteInferior))
            {
                limiteInferior = limiteInferior.AddDays(-1);
            }

            // Limpa o list box para começar o processamento
            form.listBoxDatasAtualizadas.Items.Clear();

            form.IncluirProcessamento("Buscando cotações de fundos de investimento na CVM.");

            // Somente é permitido pegar 10 cotações por dia.
            while (limiteInferior <= limiteSuperior && !parar && N > 0 && dr != DialogResult.No)
            {
                // Se não for sábado nem domingo
                if (limiteSuperior.DayOfWeek != DayOfWeek.Saturday && limiteSuperior.DayOfWeek != DayOfWeek.Sunday && !parar)
                {
                    // Se não é feriado
                    if (!Geral.Feriado(limiteSuperior))
                    {
                        // Se falta cotação para algum dos fundos nesta data
                        if (cotacao.FaltaCotacao(limiteSuperior))
                        {
                            // Primeiro tenta baixar as cotações novas, depois 
                            // tenta continuar com os arquivo já existentes.
                            if (!ExisteArquivo(limiteSuperior))
                            {

                                form.IncluirProcessamento(String.Format("Procurando cotação de {0}...", limiteSuperior.ToString("dd/MM/yyyy")));

                                // Tenta resgatar a URL para download
                                url = URLArquivoCompactado(limiteSuperior);

                                // Se a URL não for vazia
                                if (url != String.Empty)
                                {
                                    // Faz o download do arquivo
                                    form.AtualizarProcessamento(String.Format("Download de cotação de {0}...", limiteSuperior.ToString("dd/MM/yyyy")));
                                    arquivoZip = GravarArquivo(url, limiteSuperior);

                                    // se arquivoZip for diferente de String.Empty, há um arquivo zipado a ser processado.
                                    if (arquivoZip != String.Empty)
                                    {
                                        // Tenta extrair o arquivo
                                        if (AbrirArquivoZip(arquivoZip, limiteSuperior, out arquivoXML))
                                        {
                                            if (arquivoXML != String.Empty)
                                            {
                                                parar = form.AtualizarProcessamento(String.Format("Processando {0}...", limiteSuperior.ToString("dd/MM/yyyy")));
                                                // Processa o arquivo.
                                                ProcessaArquivoXml(arquivoXML, limiteSuperior.ToString("dd/MM/yyyy"));

                                                if (!parar)
                                                {
                                                    // Atualiza fundos.
                                                    AtualizaFundos(limiteSuperior);
                                                    sucesso++;
                                                }

                                                // Apaga o XML, mas deixa o ZIP
                                                if (File.Exists(arquivoXML))
                                                {
                                                    File.Delete(arquivoXML);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            string mensagem = String.Format("Problemas na extração do arquivo XML do dia {0}.\nDeseja continuar o processamento?", limiteSuperior.ToString("dd/MM/yyyy"));
                                            dr = MessageBox.Show(mensagem, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        }

                                        // Diminui em um os downloads possíveis.
                                        N--;

                                        if (cotacao.FaltaCotacao(limiteSuperior))
                                        {
                                            // Verifica se ainda falta alguma cotação
                                            // Se falta, apaga o arquivo para que seja feito o download em outro dia
                                            // (as vezes acontece de um fundo não entrar no arquivo do dia e em período posterior ser colocado)
                                            if (File.Exists(arquivoZip))
                                            {
                                                File.Delete(arquivoZip);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        form.IncluirProcessamento(String.Format("Não foi possível download da cotação de {0}.", limiteSuperior.ToString("dd/MM/yyyy")));
                                    }

                                }
                                else
                                {
                                    form.AtualizarProcessamento(String.Format("Cotação de {0} não disponível.", limiteSuperior.ToString("dd/MM/yyyy")));
                                }
                            }
                            else
                            {
                                if (ExisteArquivo(limiteSuperior))
                                {
                                    form.IncluirProcessamento(String.Format("Utilizando arquivo de cotação de {0}.", limiteSuperior.ToString("dd/MM/yyyy")));

                                    // O arquivo já existe
                                    arquivoZip = NomeArquivoZip(limiteSuperior);

                                    // Tenta extrair o arquivo
                                    if (AbrirArquivoZip(arquivoZip, limiteSuperior, out arquivoXML))
                                    {
                                        if (arquivoXML != String.Empty)
                                        {
                                            parar = form.IncluirProcessamento(String.Format("Processando {0}", limiteSuperior.ToString("dd/MM/yyyy")));
                                            // Processa o arquivo.
                                            ProcessaArquivoXml(arquivoXML, limiteSuperior.ToString("dd/MM/yyyy"));

                                            if (!parar)
                                            {
                                                // Atualiza fundos.
                                                AtualizaFundos(limiteSuperior);
                                                sucesso++;
                                            }

                                            // Apaga o XML, mas deixa o ZIP
                                            if (File.Exists(arquivoXML))
                                            {
                                                File.Delete(arquivoXML);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string mensagem = String.Format("Problemas na extração do arquivo XML do dia {0}.\nDeseja continuar o processamento?", limiteSuperior.ToString("dd/MM/yyyy"));
                                        dr = MessageBox.Show(mensagem, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    }
                                }
                                else
                                {
                                    form.IncluirProcessamento(String.Format("Arquivo de cotação de {0} não encontrado.", limiteSuperior.ToString("dd/MM/yyyy")));
                                }
                            }
                        }
                    }
                }
                limiteSuperior = limiteSuperior.AddDays(-1);
            }

            return sucesso;
        }

        private void AtualizaFundos(DateTime data)
        {
            form.IncluirProcessamento(String.Format("Atualizando fundos com cotação do dia {0}.", data.ToString("dd/MM/yyyy")));
            CotacaoEletronicaBLL bll = new CotacaoEletronicaBLL();
            int registros = bll.AtualizaFundosCVM(data);
            string msg;

            if (registros > 1)
                msg = String.Format("Atualizados {0} fundos com cotação do dia {1}.", registros, data.ToString("dd/MM/yyyy"));
            else
                msg = String.Format("Atualizado um fundo com cotação do dia {0}.", data.ToString("dd/MM/yyyy"));

            form.AtualizarProcessamento(msg);
        }

        public DateTime PegarDataLimiteInferior()
        {
            return InicioUtilizacao;
        }

        public ServiceReferenceCVM.sessaoIdHeader Login(int idSistema, String senha)
        {
            try
            {
                // Tenta efetuar o login no WebService da CVM
                cliente.Login(ref sessaoID, idSistema, senha);
                return sessaoID;
            }
            catch (Exception)
            {
                MessageBox.Show("Problemas ao acessar o WebService da CVM");
                ServiceReferenceCVM.sessaoIdHeader x = null;

                return x;
            }
        }

        public DateTime PegarDataLimiteCotacao()
        {
            try
            {
                // Consulta qual é a data máxima disponível para download de cotações.
                String dataEmTexto = cliente.retornaDtLmtEntrDocsArqsDisp(ref sessaoID, (int)TipoDocumento.Diario);
                return DateTime.ParseExact(dataEmTexto, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                // Limpa o list box para colocar a mensagem de erro.
                form.listBoxDatasAtualizadas.Items.Clear();
                form.IncluirProcessamento("Impossível adquirir informações de investimento no site da CVM.");
                return DateTime.MinValue;
            }
        }

        public string URLArquivoCompactado(DateTime data)
        {
            // Executa método do WebService que recupera a url para download do arquivo de cotações
            try
            {
                return cliente.solicAutorizDownloadArqComptc(ref sessaoID, (int)TipoDocumento.Diario, data.ToString("yyyy-MM-dd"), "Consulta");
            }
            catch (Exception)
            {
                return String.Empty;
            }
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

        public Boolean ExisteArquivo(DateTime data)
        {
            string pasta = Pasta();

            // Receberá os nomes dos arquivos baixados
            String arquivoZIP = pasta + "\\MoneyPro" + data.ToString("yyMMdd") + "CVM.zip";

            return (File.Exists(arquivoZIP));
        }

        public string NomeArquivoZip(DateTime data)
        {
            string pasta = Pasta();

            // Receberá os nomes dos arquivos baixados
            return pasta + "\\MoneyPro" + data.ToString("yyMMdd") + "CVM.zip";

        }

        public string GravarArquivo(string url, DateTime data)
        {
            string pasta = Pasta();

            // Receberá os nomes dos arquivos baixados
            String arquivoZIP = pasta + "\\MoneyPro" + data.ToString("yyMMdd") + "CVM.zip";

            if (File.Exists(arquivoZIP))
            {
                File.Delete(arquivoZIP);
            }

            try
            {
                DateTime startTime = DateTime.UtcNow;
                WebRequest request = WebRequest.Create(url);
                request.Method = "GET";

                WebResponse response = request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                Stream fileStream = File.OpenWrite(arquivoZIP);

                try
                {
                    byte[] buffer = new byte[4096];

                    int bytesRead = responseStream.Read(buffer, 0, 4096);

                    while (bytesRead > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                        DateTime nowTime = DateTime.UtcNow;
                        if ((nowTime - startTime).TotalMinutes > 5)
                        {
                            throw new ApplicationException("Download timed out");
                        }
                        bytesRead = responseStream.Read(buffer, 0, 4096);
                    }
                    return arquivoZIP;
                }
                catch
                {
                    return arquivoZIP;
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
                return String.Empty;
            }
        }

        internal bool AbrirArquivoZip(string arquivoZip, DateTime data, out string arquivoXML)
        {
            string pasta = Pasta();

            string arquivoXMLold = pasta + "\\" +
                                   data.Year.ToString() +
                                   data.Month.ToString() +
                                   data.Day.ToString() + ".xml";

            string arquivoXMLnew = pasta + "\\" + data.ToString("yyyyMMdd") + ".xml";

            if (File.Exists(arquivoXMLold))
            {
                File.Delete(arquivoXMLold);
            }

            if (File.Exists(arquivoXMLnew))
            {
                File.Delete(arquivoXMLnew);
            }

            try
            {
                // Tenta extrair o arquivo ZIP na pasta especificada; o caminho completo do arquivo será o mesmo que o contido na variável arquivoXML
                ZipFile.ExtractToDirectory(arquivoZip, pasta);
                // Retorna verdadeiro caso o arquivo exista
                if (File.Exists(arquivoXMLold))
                {
                    arquivoXML = arquivoXMLold;
                    return true;
                }
                else if (File.Exists(arquivoXMLnew))
                {
                    arquivoXML = arquivoXMLnew;
                    return true;
                }
                else
                {
                    arquivoXML = "";
                    return false;
                }
            }
            catch (Exception)
            {
                // Remove o arquivo XML formato antigo, caso exista.
                if (File.Exists(arquivoXMLold))
                {
                    File.Delete(arquivoXMLold);
                }

                // Remove o arquivo XML formato novo, caso exista.
                if (File.Exists(arquivoXMLnew))
                {
                    File.Delete(arquivoXMLnew);
                }

                // Remove o arquivo ZIP problemático
                if (File.Exists(arquivoZip))
                {
                    File.Delete(arquivoZip);
                }

                arquivoXML = "";
                // Retorna falso por não ter obtido sucesso na abertura do arquivo ZIP
                return false;
            }
        }

        internal void ProcessaArquivoXml(string arquivoXML, string textoData)
        {
            CotacaoEletronicaBLL bll = new CotacaoEletronicaBLL();

            DataTable codigosDeInteresse = bll.ListarCodigosCVMdeInteresse();
            // Cria uma chave primária para a DataTable
            DataColumn[] pk = new DataColumn[1];
            pk[0] = codigosDeInteresse.Columns["CodigoCVM"];

            codigosDeInteresse.PrimaryKey = pk;

            CotacaoCVM modelo = new CotacaoCVM();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(arquivoXML);

            //Pegando elemento pelo nome da TAG
            XmlNodeList xnInformes = xmlDoc.GetElementsByTagName("INFORME_DIARIO");

            DateTime data;
            decimal valor;
            Int64 cnpj;
            int qtde;
            string conteudo;

            int registros = 1;

            foreach (XmlNode xn in xnInformes)
            {
                // CNPJ, Data e Cotação são campos obrigatórios, sem eles, o registro não será gravado no SQL Server.

                // Tenta recuperar o CNPJ
                conteudo = xn["CNPJ_FDO"].InnerText;

                if (!Int64.TryParse(conteudo, out cnpj))
                    cnpj = 0;

                // Verifica se o CNPJ do fundo está na lista de interesse.
                DataRow linha = codigosDeInteresse.Rows.Find(cnpj.ToString("00000000000000"));
                if (linha != null)
                {
                    // Se o CNPJ não for nulo e não for fazio.
                    modelo.CNPJ = conteudo;

                    conteudo = xn["DT_COMPTC"].InnerText;

                    if (DateTime.TryParseExact(conteudo, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
                    {
                        // Se a data for válida
                        modelo.Data = data;

                        conteudo = xn["VL_QUOTA"].InnerText;

                        if (Decimal.TryParse(conteudo, style, culture, out valor))
                        {
                            // Se a cotação for válida
                            modelo.VrCotacao = valor;

                            // Valor da carteira
                            conteudo = xn["VL_TOTAL"].InnerText;
                            if (Decimal.TryParse(conteudo, style, culture, out valor))
                                modelo.VrTotalCarteira = valor;
                            else
                                modelo.VrTotalCarteira = null;

                            // Valor do patrimônio líquido
                            conteudo = xn["PATRIM_LIQ"].InnerText;
                            if (Decimal.TryParse(conteudo, style, culture, out valor))
                                modelo.VrPatrimonioLiquido = valor;
                            else
                                modelo.VrPatrimonioLiquido = null;

                            // Total de captação do dia
                            conteudo = xn["CAPTC_DIA"].InnerText;
                            if (Decimal.TryParse(conteudo, style, culture, out valor))
                                modelo.VrCaptacaoDia = valor;
                            else
                                modelo.VrCaptacaoDia = null;

                            // Total de resgate do dia
                            conteudo = xn["RESG_DIA"].InnerText;
                            if (Decimal.TryParse(conteudo, style, culture, out valor))
                                modelo.VrResgateDia = valor;
                            else
                                modelo.VrResgateDia = null;

                            // Número de cotistas
                            conteudo = xn["NR_COTST"].InnerText;
                            if (Int32.TryParse(conteudo, out qtde))
                                modelo.NroCotistas = qtde;
                            else
                                modelo.NroCotistas = null;

                            bll.InserirCotacaoCVM(modelo);
                        }
                    }
                }

                string mensagem;

                if (registros++ > 1)
                    mensagem = String.Format("Processando {0}  ({1} registros processados)", textoData, registros);
                else
                    mensagem = String.Format("Processando {0}  (1 registro processado)", textoData);

                parar = form.AtualizarProcessamento(mensagem);

                if (parar)
                {
                    break;
                }
            }

            if (!parar)
            {
                if (registros++ > 1)
                    parar = form.AtualizarProcessamento(String.Format("Processado {0}  ({1} registros)", textoData, registros));
                else
                    parar = form.AtualizarProcessamento(String.Format("Processado {0}  (1 registro)", textoData));
            }
            else
            {
                form.IncluirProcessamento(String.Format("Processamento {0}  Interrompido", textoData));
            }
        }
    }
}
