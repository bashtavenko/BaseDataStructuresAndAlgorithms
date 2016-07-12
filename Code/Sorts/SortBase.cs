using System;
using System.Diagnostics;

namespace Code.Sorts
{
    public abstract class SortBase<T> where T : IComparable
    {   
        public abstract void Sort(T[] a);

        public bool IsSorted(T[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                if (Less(a[i], a[i - 1])) return false;
            }
            return true;
        }

        public void Show(T[] a)
        {
            foreach (var i in a)
            {
                Debug.WriteLine(i);
            }
        }        
        
        protected bool Less(T v, T w)
        {
            return v.CompareTo(w) < 0;
        }

        protected bool Greater(T v, T w)
        {
            return v.CompareTo(w) > 0;
        }

        protected void Exchange(T[] a, int i, int j)
        {
            var tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }

        // Nothing to the left is greater
        // Nothing to the right is less
        // j is pivot. At the end everthing to the left is less (but may not sorted), 
        // everything to the right is greater (but may not be sorted)
        protected int Partition(T[] a, int lo, int hi, int j)
        {
            int i = lo;
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

        // Nothing to the left is LESS, nothing to the right is GREATER
        // Similar to the two pointers version, but simpler, run one pointer left to right
        protected int ReversePartitioning(T[] a, int lo, int hi, int startingPivot)
        {
            T pivotValue = a[startingPivot];
            int newPivot = lo;

            Exchange(a, startingPivot, hi);
            for (int i = lo; i < hi; i++)
            {
                if (Greater(a[i], pivotValue))
                {
                    Exchange(a, i, newPivot++);
                }
            }
            Exchange(a, hi, newPivot); // Restore pivot value
            return newPivot;
        }

        protected int Partition(T[] a, int lo, int hi)
        {
            return Partition(a, lo, hi, hi + 1);
        }
    }
}
