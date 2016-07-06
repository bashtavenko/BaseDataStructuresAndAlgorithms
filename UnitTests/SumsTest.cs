using Code.NumbersEtc;
using NUnit.Framework;

namespace UnitTests
{
    public class SumsTest
    {
        [TestCase(new int[] {11, 2, 5, 7, 3}, 21, true)]
        [TestCase(new int[] { 11, 2, 5, 7, 3 }, 22, false)]
        public void ThreeSums(int[] a, int k, bool expected)
        {
            Assert.AreEqual(expected, Sums.HasThreeSumBruteForce(a, k));
            Assert.AreEqual(expected, Sums.HasThreeSumWithHashTable(a, k));
            Assert.AreEqual(expected, Sums.HasThreeSumWithWithBinarySearch(a, k));
            Assert.AreEqual(expected, Sums.HasThreeSumWithTwoSum(a, k));
        }


        [TestCase(new int[] { 2, 3, 5, 7, 11}, 19, false)]
        [TestCase(new int[] { 2, 3, 5, 7, 11 }, 8, true)]
        public void TwoSums(int[] a, int k, bool expected)
        {
            Assert.AreEqual(expected, Sums.HasTwoSumInSortedArray(a, k));
        }
    }
}