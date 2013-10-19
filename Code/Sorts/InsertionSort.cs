using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code;

namespace Code.Sorts
{
    class InsertionSort
    {
        public static void Sort (IComparable[]a)
        {
            var n = a.Length;
            for (var i = 1; i < n; i++)
            {
                for (var j = i; j > 0 && Util.Less(a[j], a[j - 1]); j--)
                    Util.Exchange(a, j, j -1);
            }
        }
    }
}
