using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class VariacaoUltimosDiasInvestimentos
    {
        public short Ordem { get; set; }
        public short TipoLinha { get; set; }
        public int InvestimentoID { get; set; }
        public int ContaID { get; set; }
        public string Tipo { get; set; }
        public string Apelido { get; set; }
        public int RiscoID { get; set; }
        public string Risco { get; set; }
        public decimal? Dia01 { get; set; }
        public decimal? VarR0102 { get; set; }
        public decimal Perc0102 { get; set; }
        public decimal? Dia02 { get; set; }
        public decimal? VarR0203 { get; set; }
        public decimal Perc0203 { get; set; }
        public decimal? Dia03 { get; set; }
        public decimal? VarR0304 { get; set; }
        public decimal Perc0304 { get; set; }
        public decimal? Dia04 { get; set; }
        public decimal? VarR0405 { get; set; }
        public decimal Perc0405 { get; set; }
        public decimal? Dia05 { get; set; }
        public string ListaDatasISO { get; set; }
    }
}
