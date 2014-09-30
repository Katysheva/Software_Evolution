using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWEvolution_lab1
{
    interface IBonusCalcBehavior
    {
        int GetBonus(int quantity, double price, double bonusValue);
    }
}
