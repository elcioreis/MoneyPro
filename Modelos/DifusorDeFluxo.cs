using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DifusorDeFluxo
    {
        public DateTime Quando { get; set; }
        public double Valor { get; set; }
        public double PeriodoA { get; set; }
        public double PeriodoB { get; set; }
        public double PeriodoC { get; set; }
        public double PeriodoD { get; set; }

        public double CurtoPrazo
        {
            get { return PeriodoB - PeriodoA; }
        }

        public double MedioPrazo
        {
            get { return PeriodoC; }
        }

        public double LongoPrazo
        {
            get { return PeriodoD; }
        }
    }
}
