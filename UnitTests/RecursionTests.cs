using Code.LinkedListsStacksAndQueues;
using Code.NumbersEtc;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class RecursionTests
    {
        [Test]
        public void RecursionEx()
        {
            var s = Numbers.Ex(6);
        }

        [Test]
        public void TestFib()
        {
            var n = new Numbers();
            var i = n.Fib(3);

            i = n.FibDynamic(5);
            Assert.AreEqual(i, 5);
        }

        [TestCase(156,36, 12)]
        [TestCase(54, 24, 6)]
        [TestCase(54, 0, 54)]
        public void Gcd(long x, long y, long expected)
        {
            var result = Numbers.Gcd(x, y);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ComputeTowerOfHanoi()
        {
            TowerOfHanoi.Compute(3);
        }
    }
}
