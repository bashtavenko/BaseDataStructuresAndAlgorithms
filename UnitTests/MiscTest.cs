using System;
using Code.NumbersEtc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.Sorts;

namespace UnitTests
{
    [TestClass]
    public class MiscTest
    {
        [TestMethod]
        public void MiscTestMergeTwoSortedArrays()
        {
            var a = new int[] { 2, 4, 7, 9 };
            var b = new int[] {3, 5, 6, 10, 0, 0, 0, 0};
            var correctResult = new int[]{2, 3, 4, 5, 6, 7, 9, 10};

            Misc.MergeTwoSortedArraysInPlace(a, b);
            CollectionAssert.AreEqual(correctResult, b);
        }

        [TestMethod]
        public void MiscTestSortArray()
        {
            var o = new Misc();
            var x = new int[] { 0, 1, 1, 0, 1 };
            var r = new int[] { 0, 0, 1, 1, 1 };
            o.SortArrayWithZerosAndOnes(x);
            CollectionAssert.AreEqual(x, r);

            x = new int[] { 1, 1, 0, 1, 0 };
            r = new int[] { 0, 0, 1, 1, 1 };
            o.SortArrayWithZerosAndOnes(x);
            CollectionAssert.AreEqual(x, r);

            x = new int[] { 1, 1, 1, 0, 1 };
            r = new int[] { 0, 1, 1, 1, 1 };
            o.SortArrayWithZerosAndOnes(x);
            CollectionAssert.AreEqual(x, r);

            x = new int[] { 0, 0, 0, 1, 0 };
            r = new int[] { 0, 0, 0, 0, 1 };
            o.SortArrayWithZerosAndOnes(x);
            CollectionAssert.AreEqual(x, r);
        }

        [TestMethod]
        public void BalancedBrackets()
        {
            var brackets = new BalancedBrackets();
            Assert.IsTrue(brackets.IsBalanced("()"));
            Assert.IsFalse(brackets.IsBalanced("("));
            Assert.IsTrue(brackets.IsBalanced("([)]"));
        }
    }
}
