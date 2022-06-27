using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class HitBTCCandles
    {
        public DateTime timestamp { get; set; }
        public double open { get; set; }
        public double close { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double volume { get; set; }
        public double volumeQuote { get; set; }
    }
}
