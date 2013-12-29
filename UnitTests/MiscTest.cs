using System;
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
    }
}
