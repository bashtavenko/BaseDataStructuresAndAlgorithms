using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Sorts
{
    public class ShellSort<T> : SortBase<T> where T : IComparable
    {
        public override void Sort(T[] a)
        {
            int n = a.Length;
            int h = 1;
            while (h < n / 3) h = 3 * h + 1;
            while (h >= 1)
            {
                for (var i = h; i < n; i++)
                {
                    for (var j = i; j >= h && Less(a[j], a[j - h]); j -= h)
                        Exchange(a, j, j - h);
                }
                h = h / 3;
            }
        }
    }
}
