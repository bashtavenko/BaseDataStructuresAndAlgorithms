using System;
using System.Collections.Generic;

namespace Code.NumbersEtc
{
    public class Sums
    {
        // Returns all unique pairs that sum to a gvien number
        // Example: input = [1,2,3,4,5,6,7], number = 7, result {1,6},{2,5},{3,4}
        public static List<int>[] GetAllPairsThatSumToNumberBruteForce(int[] input, int sum)
        {
            List<List<int>> result = new List<List<int>>();
            var dict = new Dictionary<int, object>();
            for (int i = 0; i < input.Length; i++)
                for (int j = 1; j < input.Length; j++)
                {
                    var x = input[i];
                    var y = input[j];
                    if (x + y == sum && !dict.ContainsKey(x) && !dict.ContainsKey(y))
                    {
                        result.Add(new List<int> { input[i], input[j] });
                        dict.Add(x, null);
                        dict.Add(y, null);
                    }
                }

            return result.ToArray();
        }

        // http://www.geeksforgeeks.org/write-a-c-program-that-given-a-set-a-of-n-numbers-and-another-number-x-determines-whether-or-not-there-exist-two-elements-in-s-whose-sum-is-exactly-x/
        public static List<int>[] GetAllPairsThatSumToNumberOn(int[] input, int sum)
        {
            List<List<int>> result = new List<List<int>>();

            // Idea: Have we seen the number that would sum up with the current number? If so, we've got a pair.
            bool[] map = new bool[1000];

            for (int i = 0; i < input.Length; i++)
            {
                int x = input[i];
                int y = sum - input[i];
                if (y >= 0 && map[y])
                {
                    result.Add(new List<int> { y, x });
                }
                map[input[i]] = true;
            }

            return result.ToArray();
        }

        // Array is sorted assending
        public static bool HasTwoSumInSortedArray(int[] a, int t)
        {
            int i = 0, j = a.Length - 1;
            while (i <= j)
            {
                if (a[i] + a[j] == t)
                {
                    return true;
                }
                else if (a[i] + a[j] < t)
                {
                    i++; // we need a larger number, increase i
                }
                else
                {
                    j--; // we need smaller number, decrease j
                }
            }
            return false;
        }

        public static bool HasThreeSumBruteForce(int[] a, int t)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i; j < a.Length; j++)
                {
                    for (int k = j; k < a.Length; k++)
                    {
                        if (a[i] + a[j] + a[k] == t) return true;
                    }
                }
            }
            return false;
        }

        public static bool HasThreeSumWithHashTable(int[] a, int t)
        {
            // Step 1 - put to hashtable in order to lookup later
            var ht = new Dictionary<int, object>();
            foreach (var key in a)
            {
                if (!ht.ContainsKey(key))
                {
                    ht.Add(key, null);
                }
            }
            
            // Step 2 - Do we have third? (Similar to all pairs problem)
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i; j < a.Length; j++)
                {
                    var twoSum = a[i] + a[j];
                    var neededThirdOne = t - twoSum;
                    if (ht.ContainsKey(neededThirdOne)) return true;
                }
            }

            return false;
        }

        // Just like with hashtable but has sort / binary search
        public static bool HasThreeSumWithWithBinarySearch(int[] a, int t)
        {
            // 1. Sort
            Array.Sort(a);

            // 2. Run through all pairs and check for third
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i; j < a.Length; j++)
                {
                    var twoSum = a[i] + a[j];
                    var neededThirdOne = t - twoSum;
                    if (Array.BinarySearch(a, neededThirdOne) > 0) return true;
                }
            }
            
            return false;
        }

        public static bool HasThreeSumWithTwoSum(int[] a, int t)
        {
            // 1. Sort
            Array.Sort(a);

            // 2. Walk and check for third
            foreach (var i in a)
            {
                if (HasTwoSumInSortedArray(a, t - i))
                {
                    return true;
                }
            }
            return false;
        }
    }
}