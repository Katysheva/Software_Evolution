using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWEvolution_lab1
{
    public enum GoodDiscount
    {
        Regular, Sale, SpecialOffer
    }
    class Good
    {
        public string Title { get; private set; }
        public GoodDiscount PriceCode { get; set; }

        public Good(String title, GoodDiscount priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

    }
}
