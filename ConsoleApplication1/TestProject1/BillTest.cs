﻿using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    /// <summary>
    ///This is a test class for BillTest and is intended
    ///to contain all BillTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BillTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        /// <summary>
        ///A test for statement
        ///</summary>
        [TestMethod()]
        public void statementTest()
        {
            var customer = new Customer("Test", 10); 
            var target = new Bill(customer); 
            var actual = target.statement();
            var expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\nСумма счета составляет 0\nВы заработали 0 бонусных балов"; 
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Test1()
        {
            var customer = new Customer("Name", 0);
            var bill = new Bill(customer);
            bill.addGoods(new Item(
                new Goods("Tomato", 1),
                4,
                30));
            bill.addGoods(new Item(
                new Goods("Cucumber", 0),
                5,
                15));
            bill.addGoods(new Item(
                new Goods("Radish", 2),
                3,
                20));
            bill.addGoods(new Item(
                new Goods("Carrot", 2),
                6,
                27));
            bill.addGoods(new Item(
                new Goods("Potato", 1),
                1,
                18));
            bill.addGoods(new Item(
                new Goods("Onion", 0),
                7,
                40));
            var actual = bill.statement();
            var expected = "Счет для Name\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tTomato\t\t30\t4\t120\t1.2\t118.8\t1\n\tCucumber\t\t15\t5\t75\t2.25\t72.75\t3\n\tRadish\t\t20\t3\t60\t0\t60\t0\n\tCarrot\t\t27\t6\t162\t0\t162\t0\n\tPotato\t\t18\t1\t18\t0\t18\t0\n\tOnion\t\t40\t7\t280\t8.4\t271.6\t14\nСумма счета составляет 703.15\nВы заработали 18 бонусных балов";
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        public void Test2()
        {
            var customer = new Customer("Name", 1000);
            var bill = new Bill(customer);
            bill.addGoods(new Item(
                new Goods("Tomato", 2),
                4,
                30));
            bill.addGoods(new Item(
                new Goods("Cucumber", 2),
                5,
                15));
            bill.addGoods(new Item(
                new Goods("Radish", 2),
                3,
                20));
            var actual = bill.statement();
            var expected = "Счет для Name\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tTomato\t\t30\t4\t120\t120\t0\t0\n\tCucumber\t\t15\t5\t75\t75\t0\t0\n\tRadish\t\t20\t3\t60\t60\t0\t0\nСумма счета составляет 0\nВы заработали 0 бонусных балов";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test3()
        {
            var customer = new Customer("Name", 40);
            var bill = new Bill(customer);
            bill.addGoods(new Item(
                new Goods("Tomato", 1),
                4,
                30));
            bill.addGoods(new Item(
                new Goods("Cucumber", 1),
                5,
                15));
            bill.addGoods(new Item(
                new Goods("Radish", 2),
                3,
                20));
            var actual = bill.statement();
            var expected = "Счет для Name\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tTomato\t\t30\t4\t120\t1.2\t118.8\t1\n\tCucumber\t\t15\t5\t75\t0.75\t74.25\t0\n\tRadish\t\t20\t3\t60\t40\t20\t0\nСумма счета составляет 213.05\nВы заработали 1 бонусных балов";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Test4()
        {
            var customer = new Customer("Name", 400);
            var bill = new Bill(customer);
            bill.addGoods(new Item(
                new Goods("Tomato", 0),
                4,
                30));
            bill.addGoods(new Item(
                new Goods("Cucumber", 2),
                5,
                15));
            var actual = bill.statement();
            var expected = "Счет для Name\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tTomato\t\t30\t4\t120\t3.6\t116.4\t6\n\tCucumber\t\t15\t5\t75\t75\t0\t0\nСумма счета составляет 116.4\nВы заработали 6 бонусных балов";
            Assert.AreEqual(expected, actual);
        }
    }
}
