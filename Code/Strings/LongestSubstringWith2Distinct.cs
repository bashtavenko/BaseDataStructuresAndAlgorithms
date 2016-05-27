using System.Collections.Generic;
using System.Text;

namespace Code.Strings
{
    public class LongestSubstringWith2Distinct
    {
        //Given a string, find longest substring with 2 distinct characters
        public static List<string> GetSubstringDistinct(string input)
        {
            var result = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                string substring = GetSubstring(input.Substring(i));
                result.Add(substring);
            }
            return result;
        }
        
        private static string GetSubstring(string input)
        {
            var countDistinct = 0;
            var dict = new Dictionary<char, int>();
            StringBuilder sb = new StringBuilder();
            char ch ='0';
            for (int i = 0; i < input.Length; i++)
            {
                ch = input[i];
                if (!dict.ContainsKey(ch))
                {
                    countDistinct++;
                    dict.Add(ch, 1);
                }
                sb.Append(ch);
                if (countDistinct > 2) break;
            }
            return sb.ToString();
        }

        // This runs in O(n^2)
        public static string FindLongestSubstringWith2DistinctBruteForce(string input)
        {
            // 1. Generate all possible substrings
            var allSubstrings = GenerateAllSubstrings(input);

            // 2. Precompute string dictionary for each of those substrings.
            // String + number of distinct characters. I.e. "abb" - 2  
            var strings = new Dictionary<string, int>(); 
            foreach (var substring in allSubstrings)
            {
                var distinctCharacters = new Dictionary<char, object>(); // Just to determine distinct
                foreach (var character in substring)
                {
                    if (!distinctCharacters.ContainsKey(character)) distinctCharacters.Add(character, null);
                }
                if (!strings.ContainsKey(substring)) strings.Add(substring, distinctCharacters.Count);
            }

            // 3. Find the longest one with 2 distinct
            int longestStringLength = 0;
            string longestString = string.Empty;
            foreach (var s in strings)
            {
                if (s.Key.Length > longestStringLength && s.Value == 2)
                {
                    longestStringLength = s.Key.Length;
                    longestString = s.Key;
                }
            }
            return longestString;
        }

        public static List<string> GenerateAllSubstrings(string input)
        {
            List<string> result = new List<string>();
            var length = input.Length;
            for (int l = 1; l < length; l++)
            {
                for (int s = 0; s <= length - l; s++)
                {
                    result.Add(input.Substring(s, l));
                }
            }
            return result;
        }
    }
}