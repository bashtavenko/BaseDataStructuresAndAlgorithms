using Code.NumbersEtc;
using Code.Sorts;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class MiscTest
    {
        [Test]
        public void MiscTestMergeTwoSortedArrays()
        {
            var a = new int[] { 2, 4, 7, 9 };
            var b = new int[] {3, 5, 6, 10, 0, 0, 0, 0};
            var correctResult = new int[]{2, 3, 4, 5, 6, 7, 9, 10};

            Misc.MergeTwoSortedArraysInPlace(a, b);
            CollectionAssert.AreEqual(correctResult, b);
        }

        [Test]
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

        [Test]
        public void BalancedBrackets()
        {
            var brackets = new BalancedBrackets();
            Assert.IsTrue(brackets.IsBalanced("()"));
            Assert.IsFalse(brackets.IsBalanced("("));
            Assert.IsTrue(brackets.IsBalanced("([)]"));
        }

        [TestCase("(,[,],),{,(,),}", true)]
        [TestCase("[,(,),[,],{,(,),(,),},]", true)]
        [TestCase("{,)", false)]
        [TestCase("[,(,),[,],{,(,),(,)", false)]
        public void WellFormedBrackets (string input, bool expected)
        {
            var brackets = new BalancedBrackets();
            Assert.AreEqual(expected, brackets.IsWellFormed(input));
        }
    }
}
