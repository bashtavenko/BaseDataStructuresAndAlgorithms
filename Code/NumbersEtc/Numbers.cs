using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.NumbersEtc
{
    public class Numbers
    {
        // 1,2,3,4,5
        // 1,1,2,3,5,8,13,21,34,...  
        // Fib(n) = Fib(n-1)+Fib(n-2)
        public int Fib(int n)
        {   
            if (n <= 1) return n;
            var x = Fib(n - 1);
            var y = Fib(n - 2);
            return x + y;
        }

        // <- n2 <-n1 <-nc
        // nc = n1 + n2
        public int FibIterative(int n)
        {
            var nc = 1;  
            var n1 = 1;  
            int n2;

            for (var i = 1; i < n; i++)
            {
                n2 = n1;
                n1 = nc;
                nc = n1 + n2;
            }
            return nc;
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
    }
}
