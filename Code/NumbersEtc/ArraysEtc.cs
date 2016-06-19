using System;
using System.Collections.Generic;

namespace Code.NumbersEtc
{
    public class ArraysEtc
    {
        public static int GetMaxDifBruteForce(int[] input)
        {
            var max = 0;
            for (var i = 0; i < input.Length; i++)
            {
                for (var j = i + 1; j < input.Length; j++)
                {
                    max = Math.Max(input[j] - input[i], max); // Buy happens before Sell
                }
            }
            return max;
        }

        public static int GetMaxDifOn(int[] input)
        {
            var max = 0;
            var min = int.MaxValue;

            for (int i = 0; i < input.Length; i++)
            {
                min = Math.Min(min, input[i]);
                max = Math.Max(max, input[i] - min);
            }

            return max;
        }


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
                        result.Add(new List<int> {input[i], input[j]});
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
    }
}
