using System;

namespace Code.Sorts
{
    public class QuickSort3Way<T> : SortBase<T> where T : IComparable
    {   
        public override void Sort(T[] a)
        {   
            // shuffle   
            Sort(a, 0, a.Length - 1);
        }

        private void Sort(T[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int lt = lo, i = lo + 1, gt = hi;
            T v = a[lo];
            while (i < gt)
            {
                int cmp = a[i].CompareTo(v);
                if (cmp < 0) Exchange(a, lt++, i++);
                else if (cmp > 0) Exchange(a, i, gt--);
                else i++;
            }
            Sort(a, lo, lt - 1);
            Sort(a, gt + 1, hi);
        }

        // Similar to two-way partition, 
        // but we run three pointers as opposed to two.
        // lt and gt will be the boundary of "equal" area.
        // Nothing to the left of lt is greater than pivot, nothing to the right of gt is less
        // Pivot is first element of the array
        public void Partition3Way(T[] a, out int lt, out int gt)
        {
            int lo = 0;
            int hi = a.Length - 1;

            lt = lo;
            gt = hi;

            int i = lo + 1;
            T v = a[lo];
            while (i < gt)
            {
                int cmp = a[i].CompareTo(v);
                if (cmp < 0) Exchange(a, lt++, i++);
                else if (cmp > 0) Exchange(a, i, gt--);
                else i++;
            }
        }
    }
}
