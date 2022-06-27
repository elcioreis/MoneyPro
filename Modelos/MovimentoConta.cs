using System;

namespace Modelos
{
    public class MovimentoConta
    {
        public int MovimentoContaID { get; set; }
        public int UsuarioID { get; set; }
        public int ContaID { get; set; }
        public DateTime? Data { get; set; }
        public int? LancamentoID { get; set; }
        public string Numero { get; set; }
        public string Descricao { get; set; }
        public int? CategoriaID { get; set; }
        public int? GrupoCategoriaID { get; set; }
        public string CrdDeb { get; set; }
        public decimal? Debito { get; set; }
        public decimal? Credito { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Balanco { get; set; }
        public string Conciliacao { get; set; }
        public int? DoMovimentoContaID { get; set; }
        public int? PilhaMovimentoContaID { get; set; }
        public bool Sistema { get; set; }
        public int? MovimentoInvestimentoID { get; set; }
        public int? CotacaoMoedaID { get; set; }
        public int? InvestimentoID { get; set; }
        public int? TransacaoID { get; set; }
        public int? InvestimentoCotacaoID { get; set; }
        public decimal? QtCotas { get; set; }
        public decimal? VrCotacao { get; set; }
        public decimal? VrBruto { get; set; }
        public decimal? VrLiquido { get; set; }
        public decimal? SldCotas { get; set; }
        public decimal? VrDespesa { get; set; }
        public int? PlanejamentoID { get; set; }
        public int? PlanejamentoRepeticao { get; set; }
        public long? IdentificacaoOFX { get; set; }
        public int Passo { get; set; }
        public int MovimentosAgrupados { get; set; }
        public string Observacao { get; set; }
    }
}