using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ListaMovimentosFundo
    {
        public Int16 TipoLinha {get;set;}
        public int MovimentoContaID { get; set; }
        public string Conta { get; set; }
        public DateTime Data {get;set;}
        public string Lancamento { get; set; }
        public string Transacao { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public decimal QtCotas { get; set; }
        public decimal? QtCotasAcumulado { get; set; }
        public decimal? Debito { get; set; }
        public decimal? Credito { get; set; }
        public decimal? TotalAplicacao { get; set; }
    }
}
