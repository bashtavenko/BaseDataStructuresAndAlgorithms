using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.Sorts;

namespace UnitTests
{
    [TestClass]
    public class SortTests
    {
        private char[] _a = "SORTEXAMPLE".ToCharArray();
                
        [TestMethod]
        public void SelectionSort()
        {
            var s = new SelectionSort<char>();
            s.Sort(_a);
            Assert.IsTrue(s.IsSorted(_a));
        }

        [TestMethod]
        public void InsertionSort()
        {
            var s = new InsertionSort<char>();
            s.Sort(_a);
            Assert.IsTrue(s.IsSorted(_a));
        }

        [TestMethod]
        public void ShellSort()
        {
            var s = new ShellSort<char>();
            s.Sort(_a);
            Assert.IsTrue(s.IsSorted(_a));
        }
    }
}
