using System.Collections.Generic;

namespace Code.Strings
{
    public class Permutations
    {
        public List<string> Run (string s)
        {
            var permutations = new List<string>();
            if (s == null) return null;
            if (s.Length == 0)
            {
                permutations.Add("");
                return permutations;
            }
            char first = s[0];
            string remainder = s.Substring(1);
            List<string> combinations = Run(remainder);
            foreach (var word in combinations)
            {
                for (int j = 0; j <= word.Length; j++)
                {
                    permutations.Add(InsertCharAt(word, first, j));
                }
            }

            return permutations;
        }

        private string InsertCharAt(string word, char c, int i)
        {
            var start = word.Substring(0, i);
            var end = word.Substring(i);
            return start + c + end;
        }
    }
}