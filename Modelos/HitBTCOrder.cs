using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class HitBTCOrder
    {
        //public int OrderID { get; set; }
        public int id { get; set; }
        public string clientOrderId { get; set; }
        public string symbol { get; set; }
        public string side { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string timeInForce { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public bool postOnly { get; set; }
        public decimal cumQuantity { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }
    }
}
