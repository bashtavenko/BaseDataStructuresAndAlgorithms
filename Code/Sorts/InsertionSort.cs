using System;

namespace Code.Sorts
{
    public class InsertionSort<T> : SortBase<T> where T : IComparable
    {
        public override void Sort (T[]a)
        {
            var n = a.Length;
            for (var i = 1; i < n; i++)
            {
                for (var j = i; j > 0 && Less(a[j], a[j - 1]); j--)
                    Exchange(a, j, j -1);
            }
        }
    }
}
