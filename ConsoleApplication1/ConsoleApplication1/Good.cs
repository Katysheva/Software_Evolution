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
        protected double discountValue;
        protected double bonusValue;
        protected IBonusCalcBehavior bonusCalcBehavior;
        protected IDiscountCalcBehavior discountCalcBehavior;

        public string Title { get; private set; }
        public Good(string title)
        {
            Title = title;
            bonusCalcBehavior = new DefaultBonusBehavior();
            discountCalcBehavior = new DefaultDiscountBehavior();
        }

        public double GetDiscount(Customer customer, int quantity, double price)
        {
            return discountCalcBehavior.GetDiscount(customer, quantity, price, discountValue);
        }
        public int GetBonus(int quantity, double price)
        {
            return bonusCalcBehavior.GetBonus(quantity, price, bonusValue);
        }

    }
}
