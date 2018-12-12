using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InerfaceRocketFuel
{
    public enum Region
    {
        Jylland,
        Fyn,
        Sjælland
    }

    public class GasStation : IObserver, ISubject
    {
        private List<IObserver> boards = new List<IObserver>();
        public readonly Region region;
        public string By;
        public bool OnSale;

        public GasStation(Region region, string by)
        {
            this.region = region;
            this.By = by;
        }

        public double HydroOxy { get; private set; }
        public double AlcoOxy { get; private set; }

        private double keroOxy;
        public double KeroOxy { get {
                return keroOxy;
            }
            set {
                setPrices(value);   // Sets all prices, keroOxy included
                Notify();
            } }



        private void setPrices(Double _keroPrice)
        {
            // Set prices
            keroOxy = _keroPrice;
            HydroOxy = keroOxy * 1.1;
            AlcoOxy = keroOxy * 0.9;

            // Apply regional price changes
            double multiplier = 1;
            if (region == Region.Sjælland) multiplier = 1.05;
            else if (region == Region.Fyn) multiplier = 0.95;

            keroOxy = keroOxy * multiplier;
            HydroOxy = HydroOxy * multiplier;
            AlcoOxy = AlcoOxy * multiplier;

            // Apply discount if the fuel is on sale
            if (OnSale) {
                multiplier = 0.9;
                keroOxy = keroOxy * multiplier;
                HydroOxy = HydroOxy * multiplier;
                AlcoOxy = AlcoOxy * multiplier;
            }
        }

        public void Attach(IObserver observer)
        {
            boards.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            boards.Remove(observer);
        }

        public void Notify()
        {
            foreach(IObserver board in boards) {
                board.Update(this);
            }
        }

        public void Update(ISubject subject)
        {
            Console.WriteLine(String.Format("Station {0} ({1}) recieved new prices, relaying to boards...", region, By));
            this.KeroOxy = ((GasCompany)subject).BasePrice;
        }
    }
}
