using System;

namespace Code.Strings
{
    public class Palindrome
    {
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

        // Works only for multiple digit numbers
        public static bool IsDecimalPalindrom(uint n)
        {
            // Digit reverse
            uint reverse = 0;
            uint tmp = n;
            while (tmp > 0)
            {
                reverse = reverse * 10 + tmp % 10;
                tmp /= 10;
            }
            return reverse == n;
        }
    }
}
