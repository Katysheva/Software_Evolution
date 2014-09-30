using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWEvolution_lab1
{
    class SpecialOfferGood : Good
    {
        double discountValue = 0.005;
        int bonusValue = 0;

        public SpecialOfferGood(string title)
            : base(title) { }


        public override double GetDiscount(Customer customer, int quantity, double price)
        {
            double discount = 0;
            if (CanUseBonus(quantity))
                discount = customer.useBonus((int)(price * quantity));
            else
                discount = quantity > 2 ? price * quantity * this.discountValue : 0;
            return discount;
        }

        public override int GetBonus(int quantity, double price)
        {
            return quantity > 2 && quantity <= 10 ? (int)(price * quantity * this.bonusValue) : 0;
        }

        public override bool CanUseBonus(int quantity)
        {
            return quantity > 1;
        }
    }
}
