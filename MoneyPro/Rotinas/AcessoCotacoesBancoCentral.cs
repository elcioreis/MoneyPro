using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyPro.Rotinas
{
    class AcessoCotacoesBancoCentral
    {
        public fmDownloadCotacoes origem;

        public AcessoCotacoesBancoCentral(fmDownloadCotacoes origem)
        {
            this.origem = origem;
        }

        public void AtualizarCotacoesBancoCentral()
        {
            ConfiguracaoBLL config = new ConfiguracaoBLL();
            DataTable ultimasCotacoes = config.UltimasCotacoes();

            using (MoneyPro.ServiceBancoCentralCotacoes.FachadaWSSGSClient fachadaWSSGSClient = new ServiceBancoCentralCotacoes.FachadaWSSGSClient())
            {
                CotacaoEletronicaBLL bll = new CotacaoEletronicaBLL();

                // DeMoedaID, DeMoeda, ParaMoedaID, ParaMoeda, CodigoMoedaBancoCentral, Data
                foreach (DataRow linha in ultimasCotacoes.Rows)
                {
                    string cotacoes = "Baixando cotações de " + (string)linha["DeMoeda"] + " para " + (string)linha["ParaMoeda"] + " desde " + ((DateTime)linha["Data"]).ToString("dd/MM/yyyy") + ".";
                    origem.IncluirProcessamento(cotacoes);

                    int dias = 0;
                    decimal cotacao;

                    DateTime dia = ((DateTime)linha["Data"]).Date;

                    // TODO Verificar se pode atualizar até o dia corrente.

                    // Varia do último dia cotado (incluse fazendo a atualização daquele dia) até o "ontem".
                    // Não pega a cotação do dia corrente pois pode mudar durante o dia.
                    while (dia <= DateTime.Today)
                    {
                        try
                        {
                            // Dias que não têm cotação retornam erro
                            try
                            {
                                // utiliza WebService do Banco Central para resgatar cotações das moedas físicas
                                cotacao = fachadaWSSGSClient.getValor((int)linha["CodigoMoedaBancoCentral"], dia.ToString("dd/MM/yyyy"));
                            }
                            catch
                            {
                                // Não faz nada... haverá erro em todo dia que faltar a cotação, por exemplo: feriados e fim-de-semana
                                cotacao = 0;
                            }

                            if (cotacao != 0)
                            {
                                bll.ManterCotacaoMoedaBancoCentral((int)linha["DeMoedaID"], (int)linha["ParaMoedaID"], dia, cotacao);
                                dias++;
                            }
                        }
                        finally
                        {
                            dia = dia.AddDays(1);
                            Application.DoEvents();
                        }
                    }

                    switch (dias)
                    {
                        case 0:
                            origem.IncluirProcessamento("Nenhuma cotação baixada.");
                            break;
                        case 1:
                            origem.IncluirProcessamento("Uma cotação baixada.");
                            break;
                        default:
                            origem.IncluirProcessamento(string.Format("{0} cotações baixadas.", dias));
                            break;
                    }
                }
            }

            return;
        }
    }
}
