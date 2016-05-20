using System;

namespace Code.Sorts
{
    public class MergeBase<T> : SortBase<T> where T : IComparable
    {
        private static T[] _aux;
        
        public override void Sort(T[] a)
        {
            _aux = new T[a.Length];            
        }

        // [...... 1 3 5 7...2 4 5 6 .....]  - a
        //        lo    mid mid+1  hi
        //        k

        //[........1 3 5 7    2 4 5 6.......]  - _aux
        //         i          j        
        // initial call: Merge(a, 0, 0, 1) - 2 car then Merge(a, 2, 2, 3) - 2 car, then 0 - 3
        protected void Merge(T[] a, int lo, int mid, int hi)
        {
            // Merge a[lo..mid] with a[mid+1, hi] (a -> aux -> a)
            int i = lo, j = mid + 1;

            for (int k = lo; k <= hi; k++)
                _aux[k] = a[k]; // copy all

            for (int k = lo; k < hi; k++) // merge back; i = left; j = high
            {
                if (i > mid)
                    a[k] = _aux[j++]; // Left exhausted, take from right
                else if (j > hi)      // Right exhaused, take from left 
                    a[k] = _aux[i++];
                else if (Less(_aux[j], _aux[i])) // Here's the compare
                    a[k] = _aux[j++]; // take from right, inrcement pointer
                else
                    a[k] = _aux[i++]; // take from left, increment pointer
            }
        }
    }
}
