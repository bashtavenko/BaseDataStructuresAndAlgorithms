using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Code.NumbersEtc
{
    public class Numbers
    {
        /// <summary>
        /// 0,1,2,3,4,5,6
        //  0,1,1,2,3,5,8,13,21,34,...  
        // Fib(n) = Fib(n-1)+Fib(n-2)
        /// </summary>
        /// <param name="index">
        /// Zero-based index of the number
        /// </param>
        /// <returns>
        ///    n-th Fibonanchi number. Fib(0) = 0, Fib(1) = 1, Fib(2) = 1, Fib(3) = 1, Fib(4) = 2, Fib(5) = 3
        /// </returns>
        public int Fib(int index)
        {   
            if (index <= 1) return index;
            var x = Fib(index - 1);
            var y = Fib(index - 2);
            return x + y;
        }

        public int FibDynamic(int index)
        {
            var f = new int[index + 1];
            f[0] = 0;
            f[1] = 1;

            for (var i = 2; i <= index; i++)
            {
                f[i] = f[i - 1] + f[i - 2];
            }
            return f[index];
        }

        
        public int FibDynamicOptimized(int n)
        {
            int a = 0, b = 1, c;
            if (n == 0) return a;
            for (var i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return b;
        }

        // Greatest common divisor
        public static long Gcd(long x, long y)
        {
            return y == 0 ? x : Gcd(y, x%y);
        }
        
        // 2 0 1
        // 2 1 2 = 2
        // 2 2 2*2 = 4
        // 2 3 2*2*2 = 8
        // 2 4 2*2*2*2 = 64 => 8 * 8 ( 8 ^ 2)
        // 2 5 2*2*2*2*2 = 128
        // 2 6 
        public int Pow (int a, int n)
        {
            var result = 1;
            for (var i = 0; i < n; i++)
            {
                result = result*a;
            }
            return result;
        }

        public int PowFast(int a, int n)
        {
            return 1;
        }

        public static long Factorial(int n)
        {
            if (n <= 1) return 1;
            else
            {
                return n * Factorial(n - 1);
            }
        }

        // 123456
        // 1  2*1=2  3*2=6 4*6 = 24 
        public static long FactorialIterative(int n)
        {
            var sum = 1;
            for (var i = 1; i <= n; i++)
            {
                sum = sum * i;
            }
            return sum;
        }

        public static string Ex(int n)
        {
            if (n <= 0) return string.Empty;
            return Ex(n - 3) + n + Ex(n - 2) + n;
        }

        public static int LonelyInteger(int[] a)
        {
            for (var i = 0; i < a.Length; i++)
            {
                var found = false;
                var j = 0;
                while (j < a.Length && !found)
                {
                    if (j != i) found = a[j] == a[i];
                    j++;
                }
                if (!found) return a[i];
            }
            return 0; // should never get here if there's at least one lonely
        }

        // Because b - (b -a) = a
        public int SwapTheNumbersInPlace(int a, int b)
        {
            a = b - a;
            b = b - a;
            a = a + b;
            return a;
        }

        public static void Shuffle(int[] a)
        {
            var n = a.Length;
            for (var i = 0; i < n; i++)
            {
                var r = i + new Random().Next(n - 1);
                var tmp = a[i];
                a[i] = a[r];
                a[r] = tmp;
            }
        }

        // 709 => {7, 0, 9} => 709
        // 7*10^2 + 0*10^1 + 9*10^0
        public static int BuildNumberFromDigits(int[] digits)
        {
            int result = 0;
            int length = digits.Length;
            for (int i = 0; i < length; i++)
            {
                result += digits[length - 1 - i] * (int) Math.Pow(10, i);
            }
            return result;
        }

        // 314
        // 0: 3
        // 1: 3 * 10 + 1 = 30 + 1 = 31
        // 2: 31 * 10 + 4 = 310 + 4 = 314
        public static int BuildNumberFromDigitsNeatWay(int[] digits)
        {
            int result = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                result = result * 10 + digits[i];
            }
            return result;
        }

        public static int ConvertBase26ToInt(string input)
        {
            int ret = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[input.Length - 1 - i];
                ret += (ch - 'A' + 1) * (int)Math.Pow(26, i);
            }

            // This is better since it doesn't need Math.Pow
            ret = 0;
            foreach (var ch in input)
            {
                ret = ret * 26 + ch - 'A' + 1;
            }

            return ret;
        }

        // Don't quite work, but close
        // Other way of finding missing number:
        // 1. Sort (obvious)
        // 2. Build array of all numbers (works only for short inputs)
        // 3. Subtract sum sum of the numbers from ((n - 1) * n) / 2;
        //    Example: 5,3,0,1,2  n = 6; 5*6 / 15 - (5+3+0+3+1+2) = 4. Works for duplicate as well
        // 4. XOR
        public static uint FindMissingInt32(IEnumerable<uint> input)
        {
            const int numBucket = 1 << 16;
            var counter = new uint[numBucket];

            // Build counter of 65536 buckets (MSBs)
            // If 42 is missing, counter[0] = 65536, while counter[1] = 65536;
            foreach (var number in input)
            {
                uint idx = number >> 16;
                ++counter[idx];
            }
            
            for (uint i = 0; i < counter.Length; i++)
            {
                if (counter[i] < numBucket)
                {
                    // Something is missing in this bucket, enumerate again
                    var bitVec = new BitArray(numBucket);

                    foreach (var number in input)
                    {
                        if (i == (number >> 16))
                        {
                            // That's our bucket
                            bitVec.Set((int)((numBucket - 1) & number), true); // Get the lower 16 bits
                        }
                    }

                    for (uint j = 0; j < (1 << 16); j++)
                    {
                        if (bitVec.Get((int)j))
                        {
                            return (i << 16) | j;
                        }
                    }

                }
            }
            
            return 0;
        }

        public static int CountNumCoinsGreedy(int cents)
        {
            var coins  = new int[] {100, 50, 25, 10, 5, 1};
            int numCoins = 0;
            for (int i = 0; i < coins.Length; i++)
            {
                numCoins += cents/coins[i];
                cents %= coins[i];
            }

            return numCoins;
        }

        // divide by 10
        public static string IntToString(int x)
        {
            var sb = new StringBuilder();
            while (x > 0)
            {
                sb.Append('0' + x%10); // + 0 to string
                x /= 10;
            }

            // Kluge way of reversing string
            return new Stack<char>(sb.ToString()).ToString();
        }

        public static int StringToInt(string s)
        {
            int result = 0;
            foreach (var ch in s)
            {
                int digit = ch - '0'; // - '0' to int
                // Normally we would start from LSD 3 * 10^2 + 1 * 10^1 + 4 * 10^0, but requires power
                // We could start from MSD
                result = result*10 + digit;
            }
            return result;
        }


        public static List<int> GeneratePrimesTrialDivision(int n)
        {
            var result = new List<int>();

            for (int i = 2; i < n; i++)
            {
                var isPrime = true;
                // No point of checking higher than square root
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i%j == 0) 
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        // If we added prime 3, then 6,9,12.. won't be primes
        public static List<int> GeneratePrimesWithSieving(int n)
        {
            var result = new List<int>();
            var primes = new bool[n + 1];
            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = true;
            }

            primes[0] = false;
            primes[1] = false;
            
            for (int p = 2; p <= n; p++)
            {
                if (primes[p])
                {
                    result.Add(p);
                    // Sieve its multiples, meaning if we add p = 3,
                    // we remove 6, 9, 12 and so on
                    for (int j = p; j <= n; j += p)
                    {
                        primes[j] = false;
                    }
                }
            }

            return result;
        }
    }
}
