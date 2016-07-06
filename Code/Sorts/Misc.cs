using System.Collections.Generic;

namespace Code.Sorts
{
    public class Misc
    {
        public static void MergeTwoSortedArraysInPlace(int[] a, int[] b)
        {
            var len = a.Length;
            if (b.Length != len * 2)
                return;

            var i = len - 1;
            var j = i;

            for(var k = b.Length - 1; k > 0; k--)
            {
                if (a[i] > b[j]) b[k] = a[i--];                    
                else if (a[i] < b[j]) b[k] = b[j--];                    
                else
                {
                    b[k] = a[i];
                    i--;
                    j--;
                }                
            }
            b[0] = a[0] > b[0] ? b[0] : a[0];
        }

        public void SortArrayWithZerosAndOnes(int[] a)
        {
            int lo = 0;
            int hi = a.Length;
            int j = lo + 1;
            for (var i = lo; i < hi; i++)
            {
                if (a[i] == 0) { Swap(a, i, j - 1); j++; }
            }
        }

        private void Swap(int[] a, int i, int j)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        // Input: two sorted arrays which may contain duplicates
        // Output: intersection
        // Example: 2,3,3,5,5,6,7,7,8,12  5,5,6,8,8,9,10,10  5,6,8
        public static List<int> IntersectTwoArraysBruteForce(int[] a, int[] b)
        {
            var intesection = new List<int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (i == 0 || a[i] != a[i - 1]) // because there can be dups
                {
                    // We can replace this with binary search Array.BinarySearch
                    foreach (var i1 in b)
                    {
                        if (a[i] == i1)
                        {
                            intesection.Add(a[i]);
                            break; // Don't want duplicates from b
                        }
                    }
                }
            }

            return intesection;
        }

        // Nice!
        // Example: 2,3,3,5,7,11  3,3,7,15,31  3,7
        public static List<int> IntersectTwoArrays(int[] a, int[] b)
        {
            var intesection = new List<int>();

            int i = 0, j = 0;
            while (i < a.Length && j < b.Length)
            {
                // Continue on both as long as they match and no duplicate
                if (a[i] == b[j] && (i == 0 || a[i] != a[i - 1]))
                {
                    intesection.Add(a[i]);
                    ++i;
                    ++j;
                }
                else if (a[i] < b[j])
                {
                    ++i;
                }
                else
                {
                    ++j;
                }

            }
            return intesection;
        }
    }
}
