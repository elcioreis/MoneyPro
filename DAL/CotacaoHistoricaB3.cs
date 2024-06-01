using System;

namespace DAL
{
    public class CotacaoHistoricaB3
    {
        public int Tipreg { get; set; }
        public DateTime DataPregao { get; set; }
        public string CodBDI { get; set; }
        public string CodNeg { get; set; }
        public int TpMerc { get; set; }
        public string NomRes { get; set; }
        public string Especi { get; set; }
        public string PrazoT { get; set; }
        public string ModRef { get; set; }
        public decimal PreAbe { get; set; }
        public decimal PreMax { get; set; }
        public decimal PreMin { get; set; }
        public decimal PreMed { get; set; }
        public decimal PreUlt { get; set; }
        public decimal PreOFC { get; set; }
        public decimal PreOFV { get; set; }
        public int TotNeg { get; set; }
        public decimal QuaTot { get; set; }
        public decimal VolTot { get; set; }
        public decimal PreExe { get; set; }
        public decimal IndOPC { get; set; }
        public DateTime DatVen { get; set; }
        public decimal FatCot { get; set; }
        public decimal PtoExe { get; set; }
        public string CodIsi { get; set; }
        public decimal DisMes { get; set; }
    }
}
