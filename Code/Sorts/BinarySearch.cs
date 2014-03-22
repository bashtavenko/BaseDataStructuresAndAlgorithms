using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Sorts
{
    internal class BinarySearch
    {
        public static int Rank(int[] a, int key)
        {
            var lo = 0;
            var hi = a.Length - 1;

            while (lo <= hi)
            {
                var mid = lo + (hi - lo)/2;
                if (key < a[mid]) hi = mid - 1;
                else if (key > a[mid]) lo = mid + 1;
                else return mid;
            }
            return -1;
        }

        public static int RankR(int[] a, int key)
        {
            return RankR(a, key, 0, a.Length - 1);

            int i, j, m;
        }

        private static int RankR(int[] a, int key, int lo, int hi)
        {
            if (lo > hi) return -1;
            var mid = lo + (hi - lo)/2;
            if (key < a[mid]) return RankR(a, key, lo, mid - 1);
            else if (key > a[mid]) return RankR(a,  key, mid + 1, hi);
            else return mid;
        }
    }
}
