using System;

namespace Code.Sorts
{
    public class QuickSort<T> : SortBase<T> where T : IComparable
    {   
        public override void Sort(T[] a)
        {   
            // shuffle   
            Sort(a, 0, a.Length - 1);
        }

        private void Sort(T[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            var j = Partition(a, lo, hi);
            Sort(a, lo, j - 1);
            Sort(a, j + 1, hi);
        }

        // Nothing to the left is greater
        // Nothing to the right is less
        private int Partition(T[] a, int lo, int hi)
        {
            // j is pivot. At the end everthing to the left is less (but may not sorted), 
            // everything to the right is greater (but may not be sorted)
            int i = lo, j = hi + 1;
            T v = a[lo];
            while (true)
            {
                while (Less(a[++i], v)) if (i == hi) break; // Find first index of lowest
                while (Less(v, a[--j])) if (j == lo) break; // .. and highest
                // If we're here, some elements are out of place
                if (i >= j) break; // Are we done?
                Exchange(a, i, j); // Not yet
            }
            Exchange(a, lo, j); // Indexes crossed, final exchange
            return j; 
        }
    }
}
