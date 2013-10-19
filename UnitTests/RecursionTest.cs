using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.NumbersEtc;

namespace UnitTests
{
    [TestClass]
    public class RecursionTest
    {
        [TestMethod]
        public void RecursionEx()
        {
            var s = Numbers.Ex(6);
        }

        [TestMethod]
        public void TestFib()
        {
            var n = new Numbers();
            var i = n.Fib(3);
        }
    }
}
