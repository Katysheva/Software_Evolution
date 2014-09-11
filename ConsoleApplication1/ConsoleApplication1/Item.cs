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

        public double GetDiscount(Customer customer)
        {
            var priceCode = Good.PriceCode;
            double discount = 0;
            if (CanUseBonus())
                discount = customer.useBonus((int)(Price * Quantity));
            else
                discount = Quantity > 2 ? Price * Quantity * discountDict[priceCode] : 0;
            return discount;
        }
        public int GetBonus()
        {
            var bonus = 0;
            var priceCode = Good.PriceCode;
            bonus = Quantity > 2 && Quantity <= 10 ? (int)(Price * Quantity * bonusDict[priceCode]) : 0;
            return bonus;
        }

        public bool CanUseBonus()
        {
            return Good.PriceCode == GoodDiscount.SpecialOffer && Quantity > 1;
        }
    }
}
