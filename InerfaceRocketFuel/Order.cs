using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InerfaceRocketFuel
{
    public class Order
    {
        public FuelType Type;
        public double Quantity;
        public double Price;
        public string Currency = "kr";
        public bool Paid { get; private set; }

        public Order(FuelType fuelType, double quanitiy, double price)
        {
            Type = fuelType;
            Quantity = quanitiy;
            Price = price;
            Paid = false;
        }

        public void Pay()
        {
            Paid = true;
        }

        public override string ToString()
        {
            return $"Oder:\tType: {Type}\tQuantity: {Quantity}\tTotal: {Price}";
        }
    }
}
