using System;
using System.Collections.Generic;

namespace Code.Strings
{
    public class Anagrams
    {
        // 1. Hashtable
        // 2. Sorting
        // 3. Add the whole strng into a hastable
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

        // Anagrams should be the same if sorted
        // sorted anagram -> many original strings
        public static List<List<string>> FindAnagrams(List<string> input)
        {
            var hashTable = new Dictionary<string, List<string>>();
            foreach (var str in input)
            {
                var sortedCharArray = str.ToCharArray();
                Array.Sort(sortedCharArray);
                var sortedStr = new String(sortedCharArray);
                if (!hashTable.ContainsKey(sortedStr))
                {
                    hashTable.Add(sortedStr, new List<string> { str }); // Original string
                }
                else
                {
                    hashTable[sortedStr].Add(str); // New anagram
                }
            }

            var result = new List<List<string>> ();
            foreach (var entry in hashTable)
            {
                if (entry.Value.Count >= 2)
                {
                    result.Add(entry.Value);
                }
            }

            return result;
        } 
    }
}
