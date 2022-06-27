using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class HitBTCTicker
    {
        public HitBTCTicker(string symbol, DateTime timeStamp, 
            decimal ask, decimal bid, 
            decimal last, decimal open, 
            decimal low, decimal high, 
            decimal volume, decimal volumeQuote)
        {
            this.Symbol = symbol;
            this.TimeStamp = timeStamp;
            this.Ask = ask;
            this.Bid = bid;
            this.Last = last;
            this.Open = open;
            this.Low = low;
            this.High = high;
            this.Volume = volume;
            this.VolumeQuote = volumeQuote;
        }

        public int TickerID { get; set; }
        public string Symbol { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Ask { get; set; }
        public decimal Bid { get; set; }
        public decimal Last { get; set; }
        public decimal Open { get; set; }
        public decimal Low { get; set; }
        public decimal High { get; set; }
        public decimal Volume { get; set; }
        public decimal VolumeQuote { get; set; }
    }
}
