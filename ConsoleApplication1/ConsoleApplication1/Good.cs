using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWEvolution_lab1
{
    public enum GoodDiscount
    {
        Regular, Sale, SpecialOffer
    }
    abstract class Good
    {
        public string Title { get; private set; }
        public Good(string title)
        {
            Title = title;
        }

        public abstract double GetDiscount(Customer customer, int quantity, double price);
        public abstract int GetBonus(int quantity, double price);


        public abstract bool CanUseBonus(int quantity);

    }
}
