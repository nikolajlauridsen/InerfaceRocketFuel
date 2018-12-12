using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InerfaceRocketFuel
{
    class CardTerminal : IObserver
    {
        private List<GasPump> unpaidPumps = new List<GasPump>();
        public void Update(ISubject subject)
        {
            GasPump pump = (GasPump)subject;
            if(pump.lastOrder != null) {
                unpaidPumps.Add(pump);
                Console.WriteLine("Card terminal:\n\tUnpaid stands:");
                foreach(GasPump unpaidPump in unpaidPumps) {
                    Order order = unpaidPump.lastOrder;
                    Console.WriteLine($"\t  Pump {unpaidPump.Identity}: {order.Quantity} liter {order.Type} for {order.Price} {order.Currency}");
                }
                Console.WriteLine("Choose pump and pay.");
            } else if(unpaidPumps.Count == 0) {
                Console.WriteLine("Everything paid");
            }
        }

        public void PayFilling(int stand)
        {
            GasPump pump = null;
            foreach(GasPump p in unpaidPumps) {
                if(p.Identity == stand) {
                    pump = p;
                    break;
                }
            }

            if (pump != null) {
                pump.lastOrder.Pay();
                unpaidPumps.Remove(pump);
            } else {
                Console.WriteLine("Pump does not exist");
            }
        }
    }
}
