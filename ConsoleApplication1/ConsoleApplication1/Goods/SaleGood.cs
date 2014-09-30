using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWEvolution_lab1
{
    class SaleGood : Good
    {
        public SaleGood(string title)
            : base(title) 
        {
            bonusValue = 0.01;
            discountValue = 0.01;
            discountCalcBehavior = new WithoutBonusDiscountBehavior();
        }
    }
}
