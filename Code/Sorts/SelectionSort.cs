using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code;

namespace Code.Sorts
{
    class SelectionSort
    {
        public void Sort (IComparable[] a)
        {
            var n = a.Length;
            for (var i = 0; i < n; i++)
            {
                var min = i;
                for (var j = i + 1; j < n; j++)
                {
                    if (Util.Less(a[j], a[min]))
                        min = j;
                }
                Util.Exchange(a, i, min);
            }
        }
    }
}
