namespace Modelos
{
    public class SaldoInvestimento
    {
        public int Ordem { get; set; }
        public int TipoLinha { get; set; }
        public string Titulo { get; set; }
        public string Consulta { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal Entradas { get; set; }
        public decimal Saidas { get; set; }
        public decimal SaldoFinal { get; set; }
        public decimal? Proventos { get; set; }
        public decimal LucroPrejuizo { get; set; }
        public decimal LucroPrejuizoPerc { get; set; }
        public decimal PercTotal { get; set; }
        public int RiscoID { get; set; }
        public string Risco { get; set; }
        public decimal? QtCotas { get; set; }
    }
}
