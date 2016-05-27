using System.Diagnostics;

namespace Code.Strings
{
    // http://www.geeksforgeeks.org/write-a-c-program-to-print-all-permutations-of-a-given-string/
    public class Permutations
    {
        public void Run(char[] a)
        {
            Permute(a, 0, a.Length-1);
        }

        // ABC => ABC, ACB, BAC, BCA, CBA, CAB
        private void Permute (char[]a, int i, int n)
        {
            if (i == n)
                Debug.WriteLine(new string(a));
            else
            {
                for (var j = i; j <= n; j++)
                {
                    Swap(a, i, j);
                    Permute(a, i+1, n);
                    Swap(a, i, j);
                }
            }
        }

        private void Swap (char[] a, int x, int y)
        {
            var tmp = a[x];
            a[x] = a[y];
            a[y] = tmp;
        }
    }
}
