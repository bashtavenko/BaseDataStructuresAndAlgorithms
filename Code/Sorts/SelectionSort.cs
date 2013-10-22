using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code;

namespace Code.Sorts
{
    public class SelectionSort<T> : SortBase<T> where T : IComparable
    {
        public override void Sort (T[] a)
        {
            var n = a.Length;
            for (var i = 0; i < n; i++)
            {
                var min = i;
                for (var j = i + 1; j < n; j++)
                {
                    if (Less(a[j], a[min]))
                        min = j;
                }
                Exchange(a, i, min);
            }
        }
    }
}
