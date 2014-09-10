using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        private Dictionary<GoodsDiscount, double> discountDict = new Dictionary<GoodsDiscount, double>()
        {
            {GoodsDiscount.Regular, 0.03},
            {GoodsDiscount.Sale, 0.01},
            {GoodsDiscount.SpecialOffer, 0.005}
        };
        private Dictionary<GoodsDiscount, double> bonusDict = new Dictionary<GoodsDiscount, double>()
        {
            {GoodsDiscount.Regular, 0.05},
            {GoodsDiscount.Sale, 0.01},
            {GoodsDiscount.SpecialOffer, 0}
        };
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        public String statement()
        {
            double totalAmount = 0;
            int totalBonus = 0;

            var result = GenerateHeader();

            foreach (var item in _items)
            {
                var discount = GetDiscount(item);
                var currentTotalPrice = item.getPrice() * item.getQuantity() - discount;
                var bonus = GetBonus(item);

                totalBonus += bonus;
                totalAmount += currentTotalPrice;

                //показать результаты
                result += GenerateRow(item, discount, bonus);
            }
            _customer.receiveBonus(totalBonus);

            //добавить нижний колонтитул
            result += GenerateFooter(totalAmount, totalBonus);

            return result;
        }

        private object GetDiscount(Item item)
        {
            throw new NotImplementedException();
        }

        private object GetBonus(Item item)
        {
            throw new NotImplementedException();
        }
        public string GenerateHeader()
        {
            string header = "Счет для " + _customer.getName() + "\n";
            header += "\t" + "Название" + "\t" + "Цена" +
            "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
            "\t" + "Сумма" + "\t" + "Бонус" + "\n";
            return header;
        }
        public string GenerateRow(Item item, double discount, int bonus)
        {
            /*
             "\t" + "Название" + "\t" + "Цена" +
             "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
             "\t" + "Сумма" + "\t" + "Бонус" + "\n";
            */

            return "\t" + item.getGoods().getTitle() + "\t" +
                "\t" + item.getPrice() + "\t" + item.getQuantity() +
                "\t" + (item.getPrice() * item.getQuantity()).ToString() +
                "\t" + discount.ToString() +
                "\t" + (item.getPrice() * item.getQuantity() - discount).ToString() +
                "\t" + bonus.ToString() + "\n";
        }
        public string GenerateFooter(double totalAmount, int totalBonus)
        {
            string result = "Сумма счета составляет " + totalAmount.ToString() + "\n";
            result += "Вы заработали " + totalBonus.ToString() + " бонусных балов";
            return result;
        }

    }
}
