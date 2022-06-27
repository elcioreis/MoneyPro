using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class PagamentoCartaoCredito
    {
        public short TipoLinha { get; set; }
        public int ContaID { get; set; }
        public string Conta { get; set; }
        public decimal? Mes01 { get; set; }
        public decimal? Mes02 { get; set; }
        public decimal? Mes03 { get; set; }
        public decimal? Mes04 { get; set; }
        public decimal? Mes05 { get; set; }
        public decimal? Mes06 { get; set; }
        public decimal? Mes07 { get; set; }
        public decimal? Mes08 { get; set; }
        public decimal? Mes09 { get; set; }
        public decimal? Mes10 { get; set; }
        public decimal? Mes11 { get; set; }
        public decimal? Mes12 { get; set; }
        public decimal Total { get; set; }
        public decimal Media { get; set; }
        public DateTime DataReferencia { get; set; }
    }
}
