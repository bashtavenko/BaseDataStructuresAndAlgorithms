using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Sorts
{
    public class MergeSortButtomUp<T> : MergeBase<T> where T : IComparable
    {   
        public override void Sort(T[] a)
        {
            base.Sort(a);     
            var n = a.Length;
            // sz - subarray size (1, 2, 4, 8, 16, etc)
            for (var sz = 1; sz < n; sz = sz + sz)
            {
                for (var lo = 0; lo < n - sz; lo += sz + sz)
                    Merge(a, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, n - 1));
            }
        }
    }
}
