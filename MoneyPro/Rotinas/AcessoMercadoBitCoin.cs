using BLL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyPro.Rotinas
{
    public class AcessoMercadoBitCoin
    {
        public fmDownloadCotacoes form;

        public AcessoMercadoBitCoin(fmDownloadCotacoes origem)
        {
            this.form = origem;          
        }

        internal int AtualizarCotacoesMercadoBitCoin(string simboloMoeda)
        {
            CotacaoEletronicaBLL bll = new CotacaoEletronicaBLL();
            // Primeiro dia para efetuar a pesquisa de cotações
            DateTime primeira = bll.UltimaCotacaoMercadoBitCoin(simboloMoeda);

            int qtdeAtualizacoes = 0;

            if (primeira.Year != 1900)
            {
                // Último dia com cotação fechada (ontem - há mercado todos os dias, inclusive sábado, domingo e feriados)
                DateTime ultima = DateTime.Today.AddDays(-1);

                try
                {
                    for (DateTime dia = primeira; dia <= ultima; dia = dia.AddDays(1))
                    {
                        qtdeAtualizacoes += bll.AtualizarCotacaoMercadoBitCoin(simboloMoeda, dia);
                    }
                }
                catch
                {
                    form.IncluirProcessamento("Problemas ao tentar baixar cotações de moedas.");
                }
            }

            return qtdeAtualizacoes;
        }
    }
}
