using System.Diagnostics;

namespace Code.Strings
{
    // http://www.geeksforgeeks.org/write-a-c-program-to-print-all-permutations-of-a-given-string/
    public class PermutationsWithBacktracking
    {
        public void Run(char[] a)
        {
            Permute(a, 0);
        }

        // ABC => ABC, ACB, BAC, BCA, CBA, CAB
        private void Permute (char[]a, int i)
        {
            int len = a.Length;

            if (i == len)
                Debug.WriteLine(new string(a));
            else
            {
                for (var j = i; j < len; j++)
                {
                    Swap(a, i, j);
                    Permute(a, i + 1);
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
