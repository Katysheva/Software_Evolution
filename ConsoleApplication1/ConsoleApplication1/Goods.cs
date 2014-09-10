using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public enum GoodsDiscount
    {
        Regular, Sale, SpecialOffer
    }
    class Goods
    {

        private String _title;
        private GoodsDiscount _priceCode;
        public Goods(String title, GoodsDiscount priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }
        public GoodsDiscount getPriceCode()
        {
            return _priceCode;
        }
        public void setPriceCode(GoodsDiscount arg)
        {
            _priceCode = arg;
        }
        public String getTitle()
        {
            return _title;
        }
    }
}
