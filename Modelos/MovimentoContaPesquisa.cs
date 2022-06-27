using System;

namespace Modelos
{
    public class MovimentoContaPesquisa
    {
        public string Descricao { get; set; }
        public DateTime? DataDe { get; set; }
        public DateTime? DataAte { get; set; }
        public decimal? ValorDe { get; set; }
        public decimal? ValorAte { get; set; }
        public int? ParceiroID { get; set; }
        public int? CategoriaID { get; set; }
        public int? GrupoID { get; set; }
        public bool Subjacente { get; set; }
        public bool Filtrado { get; set; }

        public Boolean Vazia()
        {
            // Retorna verdadeiro se todos as propriedades estiverem nulas
            return string.IsNullOrWhiteSpace(Descricao) &&
                    DataDe == null && DataAte == null &&
                    ValorDe == null && ValorAte == null &&
                    ParceiroID == null &&
                    CategoriaID == null &&
                    GrupoID == null;
        }

        public void Clear()
        {
            Descricao = null;
            DataDe = null;
            DataAte = null;
            ValorDe = null;
            ValorAte = null;
            ParceiroID = null;
            CategoriaID = null;
            GrupoID = null;
            Filtrado = false;
        }
    }
}
