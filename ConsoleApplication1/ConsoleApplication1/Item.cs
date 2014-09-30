using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWEvolution_lab1
{
    class Item
    {
        public int Quantity { get; private set; }
        public Good Good { get;  private set; }
        public double Price { get; private set; }

        public Item(Good good, int quantity, double price)
        {
            Good = good;
            Quantity = quantity;
            Price = price;
        }

        public double GetDiscount(Customer _customer)
        {
            return Good.GetDiscount(_customer, Quantity, Price);
        }

        public int GetBonus()
        {
            return Good.GetBonus(Quantity, Price);
        }
    }
}
