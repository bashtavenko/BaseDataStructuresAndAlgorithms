using Code.NumbersEtc;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture()]
    public class NumTest
    {
        [Test]
        public void FibTest()
        {
            var n = new Numbers();
            Assert.AreEqual(1, n.FibDynamicOptimized(0));
            Assert.AreEqual(1, n.FibDynamicOptimized(1));
            Assert.AreEqual(2, n.FibDynamicOptimized(2));
            Assert.AreEqual(3, n.FibDynamicOptimized(3));
            Assert.AreEqual(5, n.FibDynamicOptimized(4));
            Assert.AreEqual(8, n.FibDynamicOptimized(5));
            Assert.AreEqual(13, n.FibDynamicOptimized(6));
        }

        [Test]
        public void FactorialTest()
        {
            Assert.AreEqual(1, Numbers.FactorialIterative(1));
            Assert.AreEqual(2, Numbers.FactorialIterative(2));
            Assert.AreEqual(6, Numbers.FactorialIterative(3));
            Assert.AreEqual(24, Numbers.FactorialIterative(4));
        }

        [Test]
        public void LonelyNumberTest()
        {
            var input = new int[] { 0, 0, 1, 2, 1};
            int result = Numbers.LonelyInteger(input);
            Assert.AreEqual(2, result);

            input = new int[] { 1, 1, 2};
            Assert.AreEqual(2, Numbers.LonelyInteger(input));

            input = new int[] {1};
            Assert.AreEqual(1, Numbers.LonelyInteger(input));
        }

        [TestCase("III", 3)]
        [TestCase("IV", 4)]
        [TestCase("IX", 9)]
        [TestCase("XI", 11)]
        [TestCase("CCCXCVII", 397)]
        public void RomanNumbers(string input, int expected)
        {
            var converter = new RomanToArabicConverter();
            var result = converter.Convert(input);
            Assert.AreEqual(expected, result);
        }
    }
}
