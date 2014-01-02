using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.NumbersEtc;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class KnapsackTest
    {
        [TestMethod]
        public void TestKnapsack()
        {
            var items = new List<Item>()
            {
                new Item { Name = "1", Value = 10, Weight = 4},
                new Item { Name = "2", Value = 4, Weight = 2},
                new Item { Name = "3", Value = 7, Weight = 3},
            };

            Assert.AreEqual(11, new Knapsack().Run(5, items));

            items = new List<Item>()
            {
                new Item { Name = "1", Value = 5, Weight = 3},
                new Item { Name = "2", Value = 3, Weight = 2},
                new Item { Name = "3", Value = 4, Weight = 1},
            };

            Assert.AreEqual(9, new Knapsack().Run(5, items));
        }
    }
}
