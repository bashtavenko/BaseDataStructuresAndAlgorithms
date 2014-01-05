using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
