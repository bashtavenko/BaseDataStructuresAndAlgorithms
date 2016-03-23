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
        var charBinaryArray = Convert.ToString(input, 2).ToCharArray();
        return IsPalindrome(charBinaryArray);
    }
}
}
