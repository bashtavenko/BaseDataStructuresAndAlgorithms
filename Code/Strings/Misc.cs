using System;

namespace Code.Strings
{
    public class Misc
    {
        // That works in suffix array solution, meaning there is a SORTED array of all possible substrings
        // a c a a g c
        // a c a a g c t t a
        public static int LongestCommonString(string s, string t)
        {
            var n = Math.Min(s.Length, t.Length);
            for (var i = 0; i < n; i++)
            {
                if (s[i] != t[i]) return i;
            }
            return n;
        }
    }
}
