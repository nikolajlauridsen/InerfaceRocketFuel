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

        private FuelType selectedType;
        public Order lastOrder { get; private set; }
        private static int IdentityTracker = 0;
        public int Identity { get; }

        public GasPump()
        {
            this.Identity = ++IdentityTracker;
        }

        public void SelectFuel(FuelType type)
        {
            selectedType = type;
        }

        public void Pump(double quantity)
        {
            if(lastOrder == null) {
                double unitPrice, total;
                switch (selectedType) {
                    case FuelType.KeroOxy:
                        unitPrice = KeroOxy;
                        break;
                    case FuelType.HydroOxy:
                        unitPrice = HydroOxy;
                        break;
                    case FuelType.AlcoOxy:
                        unitPrice = AlcoOxy;
                        break;
                    default:
                        throw new Exception("No fuel type selected on stand nr. " + Identity);
                }

                total = unitPrice * quantity;
                lastOrder = new Order(selectedType, quantity, total);
                Console.WriteLine(String.Format("Someone pumped fuel at stand {0}\n{1}", Identity, lastOrder.ToString()));
            } else {
                Console.WriteLine("This stand is closed untill payment is recieved ");
            }

        }

        public void Update(ISubject subject)
        {
            GasStation station = (GasStation)subject;
            KeroOxy = station.KeroOxy;
            AlcoOxy = station.AlcoOxy;
            HydroOxy = station.HydroOxy;
            Console.WriteLine(String.Format("Stand {0} at {1} ({2}) recieved new prices", Identity, station.region, station.By));
        }
    }
}
