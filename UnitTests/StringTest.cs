
using System;
using Code.Strings;
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
    }
}
