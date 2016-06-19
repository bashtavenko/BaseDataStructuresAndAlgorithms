using System.Collections.Generic;

namespace Code.Strings.Trivial
{
    public class AllSubstringsOfTheString
    {
        // m = n * (n + 1) /2, example n = 3, it should be 6 substrings 
        // abc => a, b, c, ab, bc
        public static List<string> GenerateSubstrings(string input)
        {
            List<string> result = new List<string>();
            var length = input.Length;
            for (int l = 1; l < length; l++)
            {
                for (int s = 0; s + l <= length; s++)
                {
                    result.Add(input.Substring(s, l));
                }
            }
            return result;
        }
    }
}