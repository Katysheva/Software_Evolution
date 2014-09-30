using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWEvolution_lab1
{
    class SpecialOfferGood : Good
    {

        public SpecialOfferGood(string title)
            : base(title) 
        {
            discountValue = 0.005;
            bonusValue = 0;

        }
    }
}
