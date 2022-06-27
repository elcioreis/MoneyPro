using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class HitBTCTiposEnum
    {
        public enum side
        {
            sell = 0,
            buy = 1
        }

        public enum type
        {
            limit = 0,
            market = 1,
            stopLimit = 2,
            stopMarket = 3
        }

        public enum timeInForce
        {
            GTC = 0,
            IOC = 1,
            FOK = 2,
            Day = 3,
            GTD = 4
        }

        public enum period
        {
            M1 = 0,
            M3 = 1,
            M5 = 2,
            M15 = 3,
            M30 = 4,
            H1 = 5,
            H4 = 6,
            D1 = 7,
            D7 = 8
        }
    }
}
