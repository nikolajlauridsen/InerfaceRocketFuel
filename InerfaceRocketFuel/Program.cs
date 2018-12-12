using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InerfaceRocketFuel
{
    class Program
    {
        static void Main(string[] args)
        {
            GasCompany rocketFuel = new GasCompany { BasePrice = 90 };

            GasStation gs1 = new GasStation(Region.Sjælland, "København");
            GasStation gs2 = new GasStation(Region.Fyn, "Odense");
            GasStation gs3 = new GasStation(Region.Jylland, "Århus");

            rocketFuel.Attach(gs1);
            rocketFuel.Attach(gs2);
            rocketFuel.Attach(gs3);

            PriceBoard pb1 = new PriceBoard(1);
            gs1.Attach(pb1);

            PriceBoard pb2 = new PriceBoard(2);
            gs2.Attach(pb2);

            PriceBoard pb3 = new PriceBoard(3);
            gs3.Attach(pb2);

            GasPump p1 = new GasPump();
            GasPump p2 = new GasPump();
            gs1.Attach(p1);
            gs1.Attach(p2);
            CardTerminal terminal = new CardTerminal();
            p1.Attach(terminal);
            p2.Attach(terminal);

            Console.WriteLine("Opdatere selskabets basispris til 100 kr\n");
            rocketFuel.BasePrice = 100;
            Console.WriteLine();

            Console.WriteLine("Pumper gas ved stand 1 i københavn");
            p1.Pump(10);
            p2.Pump(20);
            Console.WriteLine("Prøver igen");
            p1.Pump(100);
            Console.WriteLine("Betaler og prøver igen");
            terminal.PayFilling(1);
            p1.SelectFuel(FuelType.HydroOxy);
            p1.Pump(20);
            p2.Pump(50);
            Console.WriteLine();

            Console.WriteLine($"Opdatér selskabets basispris til {105} kr:\n");
            rocketFuel.BasePrice = 105;

            Console.ReadKey(true);

        }
    }
}
