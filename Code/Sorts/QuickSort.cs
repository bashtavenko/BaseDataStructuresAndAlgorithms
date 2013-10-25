using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private int Partition(T[] a, int lo, int hi)
        {
            int i = lo, j = hi + 1;
            T v = a[lo];
            while (true)
            {
                while (Less(a[++i], v)) if (j == hi) break;
                while (Less(v, a[--j])) if (j == lo) break;
                if (i >= j) break;
                Exchange(a, i, j);
            }
            Exchange(a, lo, j);
            return j;
        }
    }
}
