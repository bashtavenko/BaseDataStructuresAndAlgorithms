using System;

namespace Code.Strings
{
    public class LongestCommonSubsequnece
    {
        // Just like Knapsack
        // Returns the MAXIMUM length of longest common substring, there can be multiple
        public static int FindExponential(string a, string b)
        {
            if (a.Length == 0 || b.Length == 0) return 0;
            var lenA = a.Length;
            var lenB = b.Length;
            if (a[lenA - 1] == b[lenB - 1])
            {
                return 1 + FindExponential(a.Substring(0, lenA - 1), b.Substring(0, lenB - 1));
            }
            else
            {
                return Math.Max(
                    FindExponential(a.Substring(0, lenA - 1), b.Substring(0, lenB)),
                    FindExponential(a.Substring(0, lenA), b.Substring(0, lenB - 1)));
            }
        }
    }
}