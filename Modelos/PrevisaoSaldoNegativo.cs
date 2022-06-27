using System;

namespace Modelos
{
    public class PrevisaoSaldoNegativo
    {
        public int ContaID { get; set; }
        public DateTime Dia { get; set; }
        public string Conta { get; set; }
        public decimal Saldo { get; set; }
    }
}
