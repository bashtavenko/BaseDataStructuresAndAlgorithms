
using System;
using System.Collections.Generic;
using Code.Strings;
using Code.Strings.Trivial;
using NUnit.Framework;


namespace UnitTests
{
    [TestFixture]
    public class StringTest
    {
        [Test]
        public void IsPalindrome()
        {
            Assert.IsTrue(Palindrome.IsPalindrome("1234321".ToCharArray()));
        }

        [Test]
        public void IsBinaryPalindrome()
        {
            Assert.IsTrue(Palindrome.IsPalindrome(9));
            Assert.IsFalse(Palindrome.IsPalindrome(10));
        }

        [Test]
        public void IsBinaryPalindrome2()
        {
            Assert.IsFalse(Palindrome.IsBinaryPalindrom(5));
            //Assert.IsTrue(Palindrome.IsBinaryPalindromWithReversal(9));
            Assert.IsFalse(Palindrome.IsDecimalPalindrom(5));
            Assert.IsFalse(Palindrome.IsBinaryPalindrom(4562));
            Assert.IsTrue(Palindrome.IsBinaryPalindrom(3));
            Assert.IsFalse(Palindrome.IsBinaryPalindrom(4562));
            Assert.IsTrue(Palindrome.IsBinaryPalindrom(3));
            Assert.IsTrue(Palindrome.IsBinaryPalindrom(5));
            Assert.IsTrue(Palindrome.IsBinaryPalindrom(9));
            Assert.IsTrue(Palindrome.IsBinaryPalindrom(7));
            Assert.IsTrue(Palindrome.IsBinaryPalindrom(33));
            Assert.IsTrue(Palindrome.IsBinaryPalindrom(73737));
            Assert.IsFalse(Palindrome.IsBinaryPalindrom(10));
        }


        [Test]
        public void RemoveDupsTest()
        {
            char[] input = "abbefeg".ToCharArray();
            StringDuplicates.RemoveDuplicates(input);
            var resultString = new string(input);
            resultString = resultString.Substring(0, resultString.IndexOf('0'));
            Assert.AreEqual("abefg", resultString);
        }

        [Test]
        public void RemoveDupsTest2()
        {
            char[] input = "ttt".ToCharArray();
            StringDuplicates.RemoveDuplicates(input);
            var resultString = new string(input);
            resultString = resultString.Substring(0, resultString.IndexOf('0'));
            Assert.AreEqual("t", resultString);
        }

        [Test]
        public void StringReversalTest()
        {
            var sr = new StringReversalWithFor();
            var result = sr.Reverse("abcdef".ToCharArray());
            Assert.AreEqual(new string(result), "fedcba");
        }

        [TestCase("ABRA", "ABACADABRAC", 6)]
        public void Substring(string pat, string text, int expected)
        {
            var result = SubstringSearch.BruteForce(pat, text);
        }

        [TestCase("ABRA", "ABACADABRAC", 4)]
        [TestCase("acbaed", "abcadf", 4)]
        [TestCase("ACB", "ABC", 2)]
        [TestCase("12341", "341213", 3)]
        public void LongestCommonSubsequence(string a, string b, int expected)
        {
            var result = LongestCommonSubsequnece.FindExponential(a, b);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void PowerSets()
        {
            var result = PowerSet.Generate("abc");

            result = PowerSet.GenerateRecursive("abc");

            var list = PowerSet.PowerSet2<string>(new List<string> {"a", "b", "c"});
        }

        [TestCase("abbbc", new string[] {"abbb", "bbbc"})]
        [TestCase("deef", new string[] {"dee", "eef"})]
        [TestCase("aaabbcccab", new string[] {"aaabb", "bbccc"})]
        [TestCase("abbbccc", new string[] { "bbbccc"})]
        [TestCase("aabbbcc", new string[] { "aabbb", "bbbcc"})]
        public void LongestDistinct(string input, string[] expected)
        {
            var result = LongestSubstringWith2Distinct.FindLongestSubstringWith2DistinctBruteForce(input);
            CollectionAssert.Contains(expected, result);
        }

        [Test]
        public void GetAllSubstrings()
        {
            var result = AllSubstringsOfTheString.GenerateSubstrings("abc");
        }

    }
}
