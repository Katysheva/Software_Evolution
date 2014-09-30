using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWEvolution_lab1
{
    class SaleGood : Good
    {
        private double bonusValue = 0.01;
        private double discountValue = 0.01;
        public SaleGood(string title)
            : base(title) { }

        public override double GetDiscount(Customer customer, int quantity, double price)
        {
            return quantity > 2 ? price * quantity * this.discountValue : 0;
        }

        public override int GetBonus(int quantity, double price)
        {
            return quantity > 2 && quantity <= 10 ? (int)(price * quantity * this.bonusValue) : 0;
        }

        public override bool CanUseBonus(int quantity)
        {
            return false;
        }
    }
}
