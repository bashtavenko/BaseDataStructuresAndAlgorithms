using System.Collections.Generic;
using Code.Strings;
using Code.Strings.Trivial;
using NUnit.Framework;


namespace UnitTests
{
    [TestFixture]
    public class StringsTest
    {
        [Test]
        public void IsPalindrome()
        {
            Assert.IsTrue(Palindrome.IsPalindrome("1234321".ToCharArray()));
        }

        [TestCase("edified", true)]
        [TestCase("ediied", false)]
        [TestCase("level", true)]
        [TestCase("rotator", true)]
        public void IsPermutablePalindrome(string input, bool expected)
        {
            Assert.IsTrue(Palindrome.CanBePermutatedToPalindrome(input));
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
            Assert.IsTrue(Palindrome.IsBinaryPalindrom(5));
            //Assert.IsTrue(Palindrome.IsBinaryPalindromWithReversal(9));
            Assert.IsTrue(Palindrome.IsDecimalPalindrom(5));
            Assert.IsTrue(Palindrome.IsDecimalPalindrom(303));
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

        [TestCase(7, true)]
        [TestCase(1, true)]
        [TestCase(11, true)]
        [TestCase(121, true)]
        [TestCase(333, true)]
        [TestCase(2147447412, true)]
        [TestCase(12, false)]
        [TestCase(12, false)]
        [TestCase(100, false)]
        public void IsDecimalPalindromeWithoutRever(int x, bool expected)
        {
            Assert.AreEqual(expected, Palindrome.IsDecimalPalindromWithoutReverse(x));
        }

        [TestCase(1132, 2311)]
        [TestCase(3, 3)]
        public void ReverseNumber(int x, int expected)
        {
            Assert.AreEqual(expected, Palindrome.ReverseDigitsOfTheNumber(x));
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

            var input = "abcdef".ToCharArray();
            result = sr.ReverseRecursively(input, 0, input.Length - 1);
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
        [TestCase("nematode", "empty", 3)]
        public void LongestCommonSubsequence(string a, string b, int expected)
        {
            var result = LongestCommonSubsequnece.FindLcsMaxLength(a, b);
            Assert.AreEqual(expected, result);
        }

        [TestCase("ACB", "ABC", 2)]
        public void LongestCommonSubsequenceDynamic(string a, string b, int expected)
        {
            var lcs = new LongestCommonSubsequnece(a, b);
            var result = lcs.Find();
            //Assert.AreEqual(expected, result);
            result = lcs.FindIterative();
        }

        [Test]
        public void PowerSets()
        {
            var result = PowerSet.Generate("abc");
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

        [Test]
        public void RunLengthEncode()
        {
            var result = RunLengthEncoding.Encode("aaaabcccaa");
            Assert.AreEqual("4a1b3c2a", result);
        }

        [Test]
        public void RunLengthDecode()
        {
            var result = RunLengthEncoding.Decode("4a1b3c2a");
            Assert.AreEqual("aaaabcccaa", result);
        }

        [Test]
        public void AnagramsTest()
        {
            var input = new List<string>
            {
                "debitcard",
                "elvis",
                "silent",
                "badcredit",
                "lives",
                "freedom",
                "listen",
                "levis",
                "money"
            };

            var expected = new List<List<string>>
            {
                new List<string>
                {
                    "debitcard",
                    "badcredit"    
                }, 
                new List<string>
                {
                    "elvis",
                    "lives",
                    "levis"
                },
                new List<string>
                {
                    "silent",
                    "listen"
                }
            };

            var result = Anagrams.FindAnagrams(input);
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void StringDistanceTest()
        {
            int result = StringDistance.Compute("Carthorse", "Orchestra");
            Assert.AreEqual(8, result); 
        }
    }
}
