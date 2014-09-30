using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWEvolution_lab1
{
    class RegularGood : Good
    {
        public RegularGood(string title)
            : base(title) 
        {
            bonusValue = 0.05;
            discountValue = 0.03;
            discountCalcBehavior = new WithoutBonusDiscountBehavior();
        }

    }
}
