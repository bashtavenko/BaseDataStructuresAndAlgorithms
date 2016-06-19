using System;

namespace Code.Sorts
{
    public class MergeSort<T> : MergeBase<T> where T : IComparable
    {   
        public override void Sort(T[] a)
        {
            base.Sort(a);
            Sort(a, 0, a.Length - 1);
        }

        private void Sort(T[] a, int lo, int hi)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo)/2;
            Sort(a, lo, mid); // sort left half
            Sort(a, mid + 1, hi); // sort right half
            Merge(a, lo, mid, hi); // Initial call: 0, 0, 1
        }        
    }
}
