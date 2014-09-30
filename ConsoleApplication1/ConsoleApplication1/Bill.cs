using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SWEvolution_lab1
{
    class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }
        public void AddGoods(Item arg)
        {
            _items.Add(arg);
        }

        public String Statement()
        {
            double totalAmount = 0;
            int totalBonus = 0;

            var result = GenerateHeader();

            foreach (var item in _items)
            {
                var discount = item.GetDiscount(_customer);
                var bonus = item.GetBonus();
                var currentTotalPrice = item.Price * item.Quantity - discount;

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

            return "\t" + item.Good.Title + "\t" +
                "\t" + item.Price + "\t" + item.Quantity +
                "\t" + (item.Price * item.Quantity).ToString() +
                "\t" + discount.ToString() +
                "\t" + (item.Price * item.Quantity - discount).ToString() +
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
