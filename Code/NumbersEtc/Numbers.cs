using System;
using System.Collections.Generic;
using System.Linq;
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

        public int CountOnes(int x)
        {
            var count = 0;
            while (x > 0)
            {
                x = TurnOffRightMostBit(x);
                count++;
            }
            return count;
        }

        // (7)      0111
	    // (6)      0110
        // x & (x-1) 0110    
        private static int TurnOffRightMostBit(int x)
        {
            return x & (x - 1);
        }
        
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
    }
}
