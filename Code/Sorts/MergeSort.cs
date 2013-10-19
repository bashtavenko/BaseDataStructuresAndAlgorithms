using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Sorts
{
    public class MergeSort<T> where T : IComparable
    {
        private static T[] _aux;
        
        public static void Sort(T[] a)
        {
            _aux = new T[a.Length];
            Sort(a, 0, a.Length - 1);
        }

        private static void Sort(T[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo)/2;
            Sort(a, lo, mid); // sort left half
            Sort(a, mid + 1, hi); // sort right half
            Merge(a, lo, mid, hi);
        }

        // [...... /1 3 5 7/ / 2 4 5 6/ .....]  - a
        // low   mid mid+1   hi
        // k

        //[........1 3 5 7    2 4 5 6.......]  - _aux
        // i          j


        // initial call: Merge(a, 0, 0, 1) - 2 car then Merge(a, 2, 2, 3) - 2 car, then 0 - 3
        public static void Merge(T[] a, int lo, int mid, int hi)
        {
            // Merge a[lo..mid] with a[mid+1, hi]
            int i = lo, j = mid + 1;

            for (int k = lo; k <= hi; k++)
                _aux[k] = a[k]; // copy all

            for (int k = lo; k < hi; k++) // merge back
            {
                if (i > mid)
                    a[k] = _aux[j++];
                else if (j > hi)
                    a[k] = _aux[i++];
                else if (Util.Less(_aux[j], _aux[i]))
                    a[k] = _aux[j++]; // take from right
                else
                    a[k] = _aux[i++];
            }
        }
    }
}
