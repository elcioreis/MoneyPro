using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class OrcamentoMensal
    {
        public string Ordem { get; set; }
        public int TipoLinha { get; set; }
        public int CategoriaID { get; set; }
        public string Categoria { get; set; }
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
        public decimal? Mes13 { get; set; }
        public decimal? VarMedia13 { get; set; }
        public decimal? TotalCategoria { get; set; }
        public decimal? MediaCategoria { get; set; }
        public DateTime DataReferencia { get; set; }
    }
}
