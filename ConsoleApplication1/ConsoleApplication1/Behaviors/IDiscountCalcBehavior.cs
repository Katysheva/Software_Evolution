using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWEvolution_lab1
{
    interface IDiscountCalcBehavior
    {
        double GetDiscount(Customer customer, int quantity, double price, double discountValue);
        bool CanUseBonus(int quantity);
    }
}
