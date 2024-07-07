using System;

namespace Modelos
{
    public class Investimento
    {
        public int InvestimentoID { get; set; }
        public int UsuarioID { get; set; }
        public string Apelido { get; set; }
        public string Descricao { get; set; }
        public int? TipoInvestimentoID { get; set; }
        public int? InstituicaoID { get; set; }
        public int? MoedaID { get; set; }
        public int? RiscoID { get; set; }
        public string Consulta { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? Ultimo { get; set; }
        public string Aplicacao { get; set; }
        public string Resgate { get; set; }
        public string Liquidacao { get; set; }
        public string CodigoAnbima { get; set; }
        public decimal? TaxaAdministracao { get; set; }
        public decimal? TaxaPerformance { get; set; }
        public decimal? InicialMinimo { get; set; }
        public decimal? MovimentoMinimo { get; set; }
        public decimal? SaldoMinimo { get; set; }
        public int? GrupoCategoriaID { get; set; }
    }
}
