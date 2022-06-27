using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class VariacaoMensalInvestimentos
    {
        public short Ordem { get; set; }
        public short TipoLinha { get; set; }
        public int InvestimentoID { get; set; }
        public int ContaID { get; set; }
        public string Apelido { get; set; }
        public int? RiscoID { get; set; }
        public string Risco { get; set; }
        public decimal? Mes01 { get; set; }
        public short Var0102 { get; set; }
        public decimal? Mes02 { get; set; }
        public short Var0203 { get; set; }
        public decimal? Mes03 { get; set; }
        public short Var0304 { get; set; }
        public decimal? Mes04 { get; set; }
        public short Var0405 { get; set; }
        public decimal? Mes05 { get; set; }
        public short Var0506 { get; set; }
        public decimal? Mes06 { get; set; }
        public short Var0607 { get; set; }
        public decimal? Mes07 { get; set; }
        public short Var0708 { get; set; }
        public decimal? Mes08 { get; set; }
        public short Var0809 { get; set; }
        public decimal? Mes09 { get; set; }
        public short Var0910 { get; set; }
        public decimal? Mes10 { get; set; }
        public short Var1011 { get; set; }
        public decimal? Mes11 { get; set; }
        public short Var1112 { get; set; }
        public decimal? Mes12 { get; set; }
        public short Var1213 { get; set; }
        public decimal? Mes13 { get; set; }
        public decimal? Perc1213 { get; set; }
        public DateTime DataReferencia { get; set; }
    }
}
