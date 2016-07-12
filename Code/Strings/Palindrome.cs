using System;
using System.Collections.Generic;

namespace Code.Strings
{
    public class Palindrome
    {
        // level => level
        // rotator => rotator
        public static bool IsPalindrome(char[] input)
        {
            var i = 0;
            var j = input.Length - 1;
            while (i < j)
            {
                if (input[i++] != input[j--]) return false;
            }
            return true;
        }

        // All characters should appear in pairs, except for strings of odd length
        // edified => deified
        // e:2, f:2, i:2, d:1
        // all but one character should appear an even number of times
        public static bool CanBePermutatedToPalindrome(string s)
        {
            var charFrequencies = new Dictionary<char, int>();
            foreach (var ch in s)
            {
                if (charFrequencies.ContainsKey(ch))
                {
                    charFrequencies[ch]++;
                }
                else
                {
                    charFrequencies.Add(ch, 1);
                }
            }

            var oddCount = 0;
            foreach (var item in charFrequencies)
            {
                if ((item.Value % 2) != 0 && ++oddCount > 1)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsPalindrome(int input)
        {
            // 12 -> 0x1100
            var charBinaryArray = Convert.ToString(input, 2).ToCharArray();

            return IsPalindrome(charBinaryArray);
        }

        public static bool IsBinaryPalindrom(uint n)
        {
            // Bit reverse
            uint r = 0;
            for (uint v = n; v > 0; v >>= 1)
            {
                r = (r << 1) | (v & 1);
            }

            return r == n;
        }

        // Works with numbers, not bits (303 => yes)
        public static bool IsDecimalPalindrom(uint x)
        {
            // Digit reverse
            uint result = 0;
            uint remaining = x;
            while (remaining > 0)
            {
                result = result * 10 + remaining % 10;
                remaining /= 10;
            }
            return result == x;
        }

        public static bool IsDecimalPalindromWithoutReverse(int x)
        {
            int numDigits = (int) (Math.Floor(Math.Log10(x))) + 1;
            int msdMask = (int) Math.Pow(10, numDigits - 1);
            if (x / msdMask != x % 10)
            {
                return false;
            }
            x %= msdMask;   // chop off msd
            x /= 10;        // chop off lsd 
            msdMask /= 10;  // next mask

            return true;
        }

        // 1132 => 2311
        // 1132 % 10 = 2   0 * 10 + 2 = 2
        // 113 % 10 = 3    2 * 10 + 3 = 23
        // 11 % 10 = 1     23 * 10 + 1 = 231
        // 1 % 10 = 1      231 * 10 + 1 = 2311
        public static int ReverseDigitsOfTheNumber(int x)
        {
            var isNegative = x < 0;
            int result = 0;

            int remaining = Math.Abs(x);
            while (remaining > 0)
            {
                result = result*10 + remaining%10;
                remaining /= 10;
            }

            return isNegative ? -result : result;
        }
    }
}
