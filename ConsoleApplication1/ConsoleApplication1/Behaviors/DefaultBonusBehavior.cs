using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWEvolution_lab1
{
    class DefaultBonusBehavior : IBonusCalcBehavior
    {
        public int GetBonus(int quantity, double price, double bonusValue)
        {
            return quantity > 2 && quantity <= 10 ? (int)(price * quantity * bonusValue) : 0;
        }
    }
}
