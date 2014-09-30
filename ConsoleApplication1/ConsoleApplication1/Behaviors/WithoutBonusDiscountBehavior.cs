using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWEvolution_lab1
{
    class WithoutBonusDiscountBehavior :IDiscountCalcBehavior
    {
        public double GetDiscount(Customer customer, int quantity, double price, double discountValue)
        {
            return quantity > 2 ? price * quantity * discountValue : 0;
        }

        public bool CanUseBonus(int quantity)
        {
            return false;
        }
    }
}
