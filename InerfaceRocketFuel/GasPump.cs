using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InerfaceRocketFuel
{
    class GasPump : IObserver
    {
        public double KeroOxy { get; private set; }
        public double AlcoOxy { get; private set; }
        public double HydroOxy { get; private set; }

        public void Update(ISubject subject)
        {
            GasStation station = (GasStation)subject;
            KeroOxy = station.KeroOxy;
            AlcoOxy = station.AlcoOxy;
            HydroOxy = station.HydroOxy;
        }
    }
}
