using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.NumbersEtc;

namespace UnitTests
{
    [TestClass]
    public class NumTest
    {
        [TestMethod]
        public void FibTest()
        {
            var n = new Numbers();
            Assert.AreEqual(1, n.FibIterative(0));
            Assert.AreEqual(1, n.FibIterative(1));
            Assert.AreEqual(2, n.FibIterative(2));
            Assert.AreEqual(3, n.FibIterative(3));
            Assert.AreEqual(5, n.FibIterative(4));
            Assert.AreEqual(8, n.FibIterative(5));
            Assert.AreEqual(13, n.FibIterative(6));
        }

        [TestMethod]
        public void FactorialTest()
        {
            Assert.AreEqual(1, Numbers.FactorialIterative(1));
            Assert.AreEqual(2, Numbers.FactorialIterative(2));
            Assert.AreEqual(6, Numbers.FactorialIterative(3));
            Assert.AreEqual(24, Numbers.FactorialIterative(4));
        }
    }
}
