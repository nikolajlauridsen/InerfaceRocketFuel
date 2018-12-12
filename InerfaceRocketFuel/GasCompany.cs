using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InerfaceRocketFuel
{
    public class GasCompany : ISubject
    {
        private List<GasStation> stations = new List<GasStation>();
        private double basePrice;

        public double BasePrice {
            get {
                return basePrice;
            }
            set {
                basePrice = value;
                Notify();
            }
        }

        public void Attach(IObserver observer)
        {
            stations.Add((GasStation)observer);
        }

        public void Detach(IObserver observer)
        {
            stations.Remove((GasStation)observer);
        }

        public void Notify()
        {
            foreach(GasStation station in stations) {
                station.Update(this);
            }
        }
    }
}
