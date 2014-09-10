using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "BillInfo.txt";
            if (args.Length == 1)
                filename = args[0];
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            // read customer
            string line = sr.ReadLine();
            string[] result = line.Split(':');
            string name = result[1].Trim();
            // read bonus
            line = sr.ReadLine();
            result = line.Split(':');
            int bonus = Convert.ToInt32(result[1].Trim());
            Customer customer = new Customer(name, bonus);
            Bill b = new Bill(customer);
            // read goods count
            line = sr.ReadLine();
            result = line.Split(':');
            int goodsQty = Convert.ToInt32(result[1].Trim());
            Goods[] g = new Goods[goodsQty];
            for (int i = 0; i < g.Length; i++)
            {
                line = sr.ReadLine();
                result = line.Split(':');
                result = result[1].Trim().Split();
                string type = result[1].Trim();
                GoodsDiscount t = GoodsDiscount.Regular;
                switch (type)
                {
                    case "REG": t = GoodsDiscount.Regular;
                        break;
                    case "SAL": t = GoodsDiscount.Sale;
                        break;
                    case "SPO": t = GoodsDiscount.SpecialOffer;
                        break;
                }
                g[i] = new Goods(result[0], t);
            }
            // read items count
            line = sr.ReadLine();
            result = line.Split(':');
            int itemsQty = Convert.ToInt32(result[1].Trim());
            for (int i = 0; i < itemsQty; i++)
            {
                line = sr.ReadLine();
                result = line.Split(':');
                result = result[1].Trim().Split();
                int gid = Convert.ToInt32(result[0].Trim());
                double price = Convert.ToDouble(result[1].Trim());
                int qty = Convert.ToInt32(result[2].Trim());
                b.addGoods(new Item(g[gid - 1], qty, price));
            }
            string bill = b.statement();
            Console.WriteLine(bill);
            Console.ReadKey();
        }
    }
}
