using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class HitBTCTrade
    {
        private string _instrument;

        public DateTime Date { get; set; }
        public string Instrument
        {
            get
            {
                return _instrument;
            }

            set
            {
                _instrument = value;
                Principal = _instrument.Split('/').First();
                Secundaria = _instrument.Split('/').Last();
            }
        }
        public long TradeID { get; set; }
        public long OrderID { get; set; }
        public string Side { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Volume { get; set; }
        public decimal Fee { get; set; }
        public decimal Rebate { get; set; }
        public decimal Total { get; set; }
        public string Principal { get; set; }
        public string Secundaria { get; set; }
    }
}
