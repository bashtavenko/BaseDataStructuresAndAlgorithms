using System;
using System.Collections.Generic;
using Code.NumbersEtc;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ArraysEtcTests
    {
        [TestCase(new int[] {2, 3, 10, 6, 4, 8, 1}, 8)]
        [TestCase(new int[] {7, 9, 5, 6, 3, 2 }, 2)]
        [TestCase(new int[] { 2, 3, 1, 4, 7, 8 }, 7)]
        [TestCase(new int[] { 8, 1, 3, 4, 7, 5 }, 6)]
        public void GetMaxDif(int[] input, int expected)
        {
            var result = ArraysEtc.GetMaxDifBruteForce(input);
            Assert.AreEqual(expected, result);

            result = ArraysEtc.GetMaxDifOn(input);
            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 904, 40, 523, 12, -335, -385, -124, 481, -32 }, 1479)]
        public void GetMaxiumSubarray(int[] input, int expected)
        {
            var result = ArraysEtc.GetMaxiumSubarray(input);
            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 7, "{1,6},{2,5},{3,4}")]
        public void GetAllPairsThatSumToNumber(int[] input, int number, string expected)
        {
            var a = new int[,] {{1,6}, {2,5}, {3,4}};
            var result = Sums.GetAllPairsThatSumToNumberBruteForce(input, number);
            string resultAsString = GetValues(result);
            Assert.AreEqual(expected, resultAsString);

            result = Sums.GetAllPairsThatSumToNumberOn(input, number);
            resultAsString = GetValues(result);
            Assert.AreEqual(expected, resultAsString);

        }

        private string GetValues(List<int>[] input)
        {
            var pairStrings = new List<string>();
            foreach (var pair in input)
            {
                pairStrings.Add($"{{{pair[0]},{pair[1]}}}");
            }
            return String.Join(",", pairStrings);
        }

        [Test]
        public void GenerateScoreCombinations()
        {
            var points = new int[3] { 2, 3, 7 };
            int number = 9;
            var result = Scores.GenerateScoreCombinations(number, points);
            var numberOfCombinations = Scores.ScoreCombinationCountDp(number, points);
            var anotherOne = Scores.ScoreCombinationCountSimpleDp(number, points);
        }
    }
}