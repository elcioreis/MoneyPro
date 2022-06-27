using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Pesquisa
    {
        public string Descricao { get; set; }
        public DateTime? DataDe { get; set; }
        public DateTime? DataAte { get; set; }
        public decimal? ValorDe { get; set; }
        public decimal? ValorAte { get; set; }
        public int? ParceiroID { get; set; }
        public int? CategoriaID { get; set; }
        public int? GrupoID { get; set; }
        public int? GrupoContaID { get; set; }
        public int? TipoContaID { get; set; }
        public int? ContaID { get; set; }
        public Tipo.FiltroTransferencia Transferencia { get; set; }

        public Boolean Vazia()
        {
            // Retorna verdadeiro se todos as propriedades estiverem nulas
            return (String.IsNullOrWhiteSpace(Descricao) &&
                    DataDe == null && DataAte == null &&
                    ValorDe == null && ValorAte == null &&
                    ParceiroID == null &&
                    CategoriaID == null &&
                    GrupoID == null &&
                    GrupoContaID == null &&
                    TipoContaID == null &&
                    ContaID == null);
        }

        public void Clear()
        {
            Descricao = null;
            DataDe = null;
            DataAte = null;
            ValorDe = null;
            ValorAte = null;
            ParceiroID = null;
            GrupoID = null;
            GrupoContaID = null;
            TipoContaID = null;
            ContaID = null;
            Transferencia = Tipo.FiltroTransferencia.Todas;
        }

    }
}
