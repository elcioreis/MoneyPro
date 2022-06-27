using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class InvestimentoDetalhes
    {
        public int? ContaID { get; set; }
        public int? MovimentoID { get; set; }
        public int Totalizador { get; set; }
        public int? LoteID { get; set; }
        public int? DetalheID { get; set; }
        public string Transacao { get; set; }
        public string Lote { get; set; }
        public DateTime? DtMovimento { get; set; }
        public decimal? QtCotas { get; set; }
        public decimal? SaldoCotas { get; set; }
        public decimal? VrCotacaoDia { get; set; }
        public string VrCotacaoDiaFormatado { get; set; }
        public decimal? VrCusto { get; set; }
        public string VrCustoFormatado { get; set; }
        public decimal? VrBruto { get; set; }
        public string VrBrutoFormatado { get; set; }
        public decimal? VrImpostos { get; set; }
        public string VrImpostosFormatado { get; set; }
        public decimal? VrLiquido { get; set; }
        public string VrLiquidoFormatado { get; set; }
        public decimal? VrLucroOuPerda { get; set; }
        public string VrLucroOuPerdaFormatado { get; set; }
        public decimal? PercLucroOuPerda { get; set; }
        public string PercLucroOuPerdaFormatado { get; set; }
        public string Indicador { get; set; }
    }
}
