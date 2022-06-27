using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class InvestimentoResumo
    {
        public bool Total { get; set; }
        public int? InvestimentoID { get; set; }
        public DateTime? DCompra { get; set; }
        public double SdCotas { get; set; }
        public double? CotacaoCompra { get; set; }
        public double ValorCusto { get; set; }
        public double ValorBruto { get; set; }
        public DateTime? DUltima { get; set; }
        public int? Dias { get; set; }
        public double? CotacaoVenda { get; set; }
        public double LucroBruto { get; set; }
        public double? PercIOF { get; set; }
        public double? ValorIOF { get; set; }
        public double? PercIR { get; set; }
        public double? ValorIR { get; set; }
        public DateTime? UltimoComeCota { get; set; }
        public double? ValorComeCota { get; set; }
        public double? ImpostoDevido { get; set; }
        public double LucroLiquido { get; set; }
        public double SaldoLiquido { get; set; }
        public double PercLucroLiquido { get; set; }
    }
}
