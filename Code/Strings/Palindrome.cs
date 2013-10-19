using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Strings
{
    public class Palindrome
    {
        public static bool IsPalindrome(char[]input)
        {
            var i = 0;
            var j = input.Length - 1;
            while (i < j)
            {
                if (input[i++] != input[j--]) return false;
            }
            return true;
        }
    }
}
