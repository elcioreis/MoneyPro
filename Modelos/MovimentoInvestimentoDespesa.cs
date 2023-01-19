namespace Modelos
{
    public class MovimentoInvestimentoDespesa
    {
        public int MovimentoInvestimentoDespesaID { get; set; }
        public int MovimentoInvestimentoID { get; set; }
        public string Parceiro { get; set; }
        public string Despesa { get; set; }
        public int CategoriaID { get; set; }
        public int Ordem { get; set; }
        public decimal Valor { get; set; }
        public decimal LancamentoId { get; set; }
    }
}
