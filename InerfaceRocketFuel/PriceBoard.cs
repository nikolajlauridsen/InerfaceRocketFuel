using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InerfaceRocketFuel
{
    public class PriceBoard : IObserver
    {
        private int boardNo;
        public double KeroOxy { get; private set; }
        public double AlcoOxy { get; private set; }
        public double HydroOxy { get; private set; }

        public PriceBoard(int boardNo)
        {
            this.boardNo = boardNo;
        }

        public void Update(ISubject subject)
        {
            GasStation station = (GasStation)subject;
            KeroOxy = station.KeroOxy;
            AlcoOxy = station.AlcoOxy;
            HydroOxy = station.HydroOxy;
            Console.WriteLine(String.Format("Board nr. {0} recieved new prices from {1} ({2})\n\tKerosine: {3}\n\tAlcohol: {4}\n\tHydrogen: {5}\n", boardNo, station.region, station.By, KeroOxy, AlcoOxy, HydroOxy));
        }
    }
}
