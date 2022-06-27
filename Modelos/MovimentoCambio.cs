using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class MovimentoCambio
    {
        private int _decimaisOrigem = -1;
        private int _decimaisDestino = -1;
        private decimal _valorOrigem = 0;
        private decimal _valorDestino = 0;
        private Tipo.ResponsavelTaxa _respTaxa;
        public int MovimentoContaID { get; set; }
        public int UsuarioID { get; set; }
        public bool Compra { get; set; }
        public DateTime DataHora { get; set; }
        public int ContaOrigemID { get; set; }
        public int ContaDestinoID { get; set; }
        public decimal Taxa { get; set; }
        public decimal Cotacao { get; set; }
        public int ContaTaxaID { get; set; }
        public string Descricao { get; set; }
        public string Lancamento { get; set; }
        public string SimboloOrigem { get; set; }
        public string SimboloDestino { get; set; }
        public bool Padrao { get; set; }
        public decimal ValorOrigem
        {
            get
            {
                return _valorOrigem;
            }

            set
            {
                _valorOrigem = value;
                DescreverAcao();
            }
        }
        public decimal ValorDestino
        {
            get
            {
                return _valorDestino;
            }

            set
            {
                _valorDestino = value;
                DescreverAcao();
            }
        }

        private void DescreverAcao()
        {
            //if (Compra)
            //{
            //    // Gastei R$ 72,00 para comprar US$ 20,00
            //    // Compra de US$ 20,00 @ R$ 3,60

            //    if (_decimaisOrigem >= 0 && _valorOrigem > 0 && _decimaisDestino >= 0 && _valorDestino > 0)
            //    {
            //        // monta uma string no seguinte formato: "{0:#,##0.00######}", onde há ao menos duas casas decimais
            //        string fmtDestino = "{0:#,##0.00" + new string('#', Math.Max(_decimaisDestino, 2) - 2) + "}";
            //        string fmtOrigem = "{0:#,##0.00" + new string('#', Math.Max(_decimaisOrigem, 2) - 2) + "}";

            //        Cotacao = Math.Round(_valorOrigem / _valorDestino, _decimaisOrigem);

            //        Descricao = String.Format("Compra de {0} {1} @ {2} {3} ({4} {5})",
            //                                  SimboloDestino,
            //                                  String.Format(fmtDestino, _valorDestino),
            //                                  SimboloOrigem,
            //                                  String.Format(fmtOrigem, _valorOrigem),
            //                                  SimboloOrigem,
            //                                  String.Format(fmtOrigem, Cotacao));
            //    }
            //}
            //else
            {
                // Venda de BTC 0,005 por US$ 50,598 (US$ 10.119,60)
                if (_decimaisOrigem >= 0 && _valorOrigem > 0 && _decimaisDestino >= 0 && _valorDestino > 0)
                {
                    // monta uma string no seguinte formato: "{0:#,##0.00######}", onde há ao menos duas casas decimais
                    string fmtDestino = "{0:#,##0.00" + new string('#', Math.Max(_decimaisDestino, 2) - 2) + "}";
                    string fmtOrigem = "{0:#,##0.00" + new string('#', Math.Max(_decimaisOrigem, 2) - 2) + "}";

                    Cotacao = Math.Round(_valorDestino / _valorOrigem, _decimaisOrigem);

                    Descricao = string.Format("{0} de {1} {2} @ {3} {4} ({5} {6})",
                                              (Compra ? "Compra" : "Venda"),
                                              SimboloOrigem,
                                              string.Format(fmtOrigem, _valorOrigem),
                                              SimboloDestino,
                                              string.Format(fmtDestino, _valorDestino),
                                              SimboloDestino,
                                              string.Format(fmtDestino, Cotacao));

                }
            }
        }

        public Tipo.ResponsavelTaxa RespTaxa
        {
            get
            {
                return _respTaxa;
            }
            set
            {
                _respTaxa = value;
            }
        }

        public int DecimaisOrigem
        {
            get
            {
                return _decimaisOrigem;
            }

            set
            {
                _decimaisOrigem = value;
            }
        }

        public int DecimaisDestino
        {
            get
            {
                return _decimaisDestino;
            }

            set
            {
                _decimaisDestino = value;
            }
        }
    }
}
