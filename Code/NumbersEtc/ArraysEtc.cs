using System;

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

        // Find maximum sum over all subarrays and return this sum
        // 904, 40, 523, 12, -335, -385, -124, 481, -32 is 0-3: = 1479
        // This is really cool - keep running min and max sums
        public static int GetMaxiumSubarray(int[] input)
        {
            int minSum = 0, sum = 0, maxSum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i];
                minSum = Math.Min(sum, minSum);
                maxSum = Math.Max(maxSum, sum - minSum);
            }
            return maxSum;
        }
    }
}
