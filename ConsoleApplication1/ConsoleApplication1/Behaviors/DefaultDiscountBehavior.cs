using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWEvolution_lab1
{
    class DefaultDiscountBehavior : IDiscountCalcBehavior
    {
        public double GetDiscount(Customer customer, int quantity, double price, double discountValue)
        {
            double discount = 0;
            if (CanUseBonus(quantity))
                discount = customer.useBonus((int)(price * quantity));
            else
                discount = quantity > 2 ? price * quantity * discountValue : 0;
            return discount;
        }

        public bool CanUseBonus(int quantity)
        {
            return quantity > 1;
        }
    }
}
