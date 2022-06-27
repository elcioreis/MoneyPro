using System;

namespace Modelos
{
    public class DetalhesMovimentacao
    {
        public int Detalhe { get; set; }
        public int MovimentoContaID { get; set; }
        public int ContaID { get; set; }
        public string Conta { get; set; }
        public DateTime Data { get; set; }
        public int LancamentoID { get; set; }
        public string Lancamento { get; set; }
        public string Descricao { get; set; }
        public int CategoriaID { get; set; }
        public string Categoria { get; set; }
        public int? GrupoCategoriaID { get; set; }
        public string GrupoCategoria { get; set; }
        public string CrdDeb { get; set; }
        public decimal? Credito { get; set; }
        public decimal? Debito { get; set; }
        public string Conciliacao { get; set; }
        public int? PlanejamentoID { get; set; }
        public int? PlanejamentoRepeticao { get; set; }
    }
}
