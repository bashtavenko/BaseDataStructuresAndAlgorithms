using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Strings
{
    public class Anagrams
    {        
        public static bool IsAnagram(string s1, string s2)
        {   
            if (s1.Length != s2.Length) return false;
            var letters = new int[256];
            int numUniqueChars = 0;
            int numCompleted = 0;
            var s1Array = s1.ToCharArray();
            foreach (var c in s1Array)
            {
                if (letters[c] == 0) numUniqueChars++;
                letters[c]++;
            }

            for (int i = 0; i < s2.Length; i++)
            {
                int c = (int)s2[i];
                if (letters[c] == 0) return false;

                letters[c]--;

                if (letters[c] == 0)
                {
                    numCompleted++;
                    if (numCompleted == numUniqueChars)
                    {
                        return i == s2.Length - 1;
                    }
                }
            }

            return false;
        }
    }
}
