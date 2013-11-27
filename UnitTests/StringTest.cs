using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.Strings;

namespace UnitTests
{
    [TestClass]
    public class StringTest
    {
        [TestMethod]
        public void IsPalindrome()
        {
            Assert.IsTrue(Palindrome.IsPalindrome("1234321".ToCharArray()));
        }

        [TestMethod]
        public void RemoveDupsTest()
        {
          char[] input = "abbefeg".ToCharArray();   
          StringDuplicates.RemoveDuplicates(input);
          var resultString = new string(input);
          resultString = resultString.Substring(0, resultString.IndexOf('0'));
          Assert.AreEqual("abefg", resultString); 
        }
    }
}
