using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using DAL;
using System.Data;
using System.Globalization;
using System.Net;
using System.IO;

namespace BLL
{
    public class CotacaoEletronicaBLL
    {
        public void GravarAtualizacaoM02_M03()
        {
            CotacaoEletronicaDAL dal = new CotacaoEletronicaDAL();
            dal.GravarAtualizacaoM02_M03();
        }
        public void GravarAtualizacaoM04_M11()
        {
            CotacaoEletronicaDAL dal = new CotacaoEletronicaDAL();
            dal.GravarAtualizacaoM04_M11();
        }

        public void InformarAtualizacao()
        {
            CotacaoEletronicaDAL dal = new CotacaoEletronicaDAL();
            dal.InformaAtualizacao();
        }

        public bool DataExiste(DateTime data)
        {
            CotacaoEletronicaDAL dal = new CotacaoEletronicaDAL();
            return dal.DataExiste(data);
        }

        public void InserirCotacaoCVM(CotacaoCVM modelo)
        {
            CotacaoEletronicaDAL dal = new CotacaoEletronicaDAL();
            dal.InsereAtualizaCotacaoCVM(modelo);
        }

        public int AtualizaFundosCVM(DateTime data)
        {
            CotacaoEletronicaDAL dal = new CotacaoEletronicaDAL();
            return dal.AtualizaFundosCVM(data);
        }

        public bool FaltaCotacao(DateTime data)
        {
            CotacaoEletronicaDAL dal = new CotacaoEletronicaDAL();
            return dal.FaltaCotacao(data);
        }

        public DataTable ListarCodigosCVMdeInteresse()
        {
            CotacaoEletronicaDAL dal = new CotacaoEletronicaDAL();
            return dal.ListarCodigosCVMdeInteresse();
        }

        public DataTable ListarCNPJFundosCVM()
        {
            CotacaoEletronicaDAL dal = new CotacaoEletronicaDAL();
            return dal.ListarCNPJFundosCVM();
        }

        public void AtualizaAcoesB3()
        {
            CotacaoEletronicaDAL dal = new CotacaoEletronicaDAL();
            dal.AtualizaAcoesBOVESPA();
        }

        public int AtualizarCotacaoMercadoBitCoin(string simboloMoeda, DateTime dia)
        {
            CotacaoEletronicaDAL dal = new CotacaoEletronicaDAL();

            CotacaoMoedas moeda = PesquisaCotacaoMercadoBitCoin(simboloMoeda, dia);

            if (moeda.Carregou)
            {
                dal.IncluirCotacaoBTC(moeda);
            }

            return (moeda.Carregou ? 1 : 0);
        }

        private CotacaoMoedas PesquisaCotacaoMercadoBitCoin(String simboloMoeda,  DateTime dia)
        {
            //
            // Somente marca como carregado se conseguir encontrar o valor da cotação,
            // se encontra, será preenchido o campo resposta.Cotacao.
            //

            CotacaoMoedas resposta = new CotacaoMoedas();

            MoedaDAL moeda = new MoedaDAL();

            resposta.DeMoedaId = moeda.CodigoMoeda(simboloMoeda);
            resposta.ParaMoedaId = moeda.CodigoMoeda("R$");
            resposta.Negociado = false;
            resposta.Simbolo = simboloMoeda;

            if (resposta.DeMoedaId != 0 && resposta.ParaMoedaId != 0)
            {
                // Monta a URL inserindo a data no formato yyyy/mm/dd no final
                string url = String.Format(@"https://www.mercadobitcoin.net/api/{0}/day-summary/{1}/", simboloMoeda, dia.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture));

                var request = (HttpWebRequest)WebRequest.Create(url);

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    //var encoding = Encoding.GetEncoding(response.CharacterSet);

                    using (var responseStream = response.GetResponseStream())
                    using (var reader = new StreamReader(responseStream))
                    {
                        string linha = reader.ReadToEnd();

                        if (!String.IsNullOrEmpty(linha))
                        {
                            NumberStyles style;
                            style = NumberStyles.AllowDecimalPoint;

                            string linhaLimpa = linha.Replace('"', ' ').Replace('{', ' ').Replace('}', ' ').Replace(" ", "");
                            List<string> tuplas = linhaLimpa.Split(',').ToList();

                            foreach (var tupla in tuplas)
                            {
                                string nome = tupla.Split(':').First();
                                string valor = tupla.Split(':').Last();

                                switch (nome)
                                {
                                    case "lowest":
                                        resposta.Lowest = decimal.Parse(valor, style, CultureInfo.InvariantCulture);
                                        break;
                                    case "volume":
                                        resposta.Volume = decimal.Parse(valor, style, CultureInfo.InvariantCulture);
                                        break;
                                    case "amount":
                                        resposta.Amount = decimal.Parse(valor, style, CultureInfo.InvariantCulture);
                                        break;
                                    case "avg_price":
                                        resposta.AvgPrice = decimal.Parse(valor, style, CultureInfo.InvariantCulture);
                                        break;
                                    case "opening":
                                        resposta.Opening = decimal.Parse(valor, style, CultureInfo.InvariantCulture);
                                        break;
                                    case "date":
                                        resposta.Data = dia;
                                        break;
                                    case "closing":
                                        resposta.Closing = decimal.Parse(valor, style, CultureInfo.InvariantCulture);
                                        resposta.Cotacao = (decimal)resposta.Closing;
                                        resposta.Carregou = true;
                                        break;
                                    case "highest":
                                        resposta.Highest = decimal.Parse(valor, style, CultureInfo.InvariantCulture);
                                        break;
                                    case "quantity":
                                        resposta.Quantity = decimal.Parse(valor, style, CultureInfo.InvariantCulture);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            return resposta;
        }

        public DateTime UltimaCotacaoMercadoBitCoin(string moedaSimbolo)
        {
            CotacaoEletronicaDAL dal = new CotacaoEletronicaDAL();
            return dal.UltimaCotacaoMercadoBitCoin(moedaSimbolo);
        }

        public void ManterCotacaoMoedaBancoCentral(int moedaDe, int moedaPara, DateTime data, decimal cotacao)
        {
            CotacaoEletronicaDAL dal = new CotacaoEletronicaDAL();
            dal.ManterCotacaoMoedaBancoCentral(moedaDe, moedaPara, data, cotacao);
        }

    }
}
