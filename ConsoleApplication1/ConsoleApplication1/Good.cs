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
    class Good
    {
        public string Title { get; private set; }
        public GoodDiscount PriceCode { get; set; }
        public Good() { }
        public Good(String title, GoodDiscount priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        private Dictionary<GoodDiscount, double> discountDict = new Dictionary<GoodDiscount, double>()
        {
            {GoodDiscount.Regular, 0.03},
            {GoodDiscount.Sale, 0.01},
            {GoodDiscount.SpecialOffer, 0.005}
        };
        private Dictionary<GoodDiscount, double> bonusDict = new Dictionary<GoodDiscount, double>()
        {
            {GoodDiscount.Regular, 0.05},
            {GoodDiscount.Sale, 0.01},
            {GoodDiscount.SpecialOffer, 0}
        };

        public double GetDiscount(Customer customer, int quantity, double price)
        {
            var priceCode = PriceCode;
            double discount = 0;
            if (CanUseBonus(quantity))
                discount = customer.useBonus((int)(price * quantity));
            else
                discount = quantity > 2 ? price * quantity * discountDict[priceCode] : 0;
            return discount;
        }
        public int GetBonus(int quantity, double price)
        {
            var bonus = 0;
            var priceCode = PriceCode;
            bonus = quantity > 2 && quantity <= 10 ? (int)(price * quantity * bonusDict[priceCode]) : 0;
            return bonus;
        }

        public bool CanUseBonus(int quantity)
        {
            return PriceCode == GoodDiscount.SpecialOffer && quantity > 1;
        }

    }
}
