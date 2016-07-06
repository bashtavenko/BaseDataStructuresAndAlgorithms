using System;

namespace Code.Sorts
{
    public class KthLargestFinder : SortBase<int>
    {
        public override void Sort(int[] a)
        {
        }

        // a = 3, 2, 1, 5, 4, k = 2, 4 - second element
        public int FindKthLargest(int[] a, int k)
        {
            int i = 0;
            int j = a.Length - 1;
            var r = new Random();

            while (i <= j)
            {
                int pivot = (int) r.Next(j + 1);

                // Nothing to the left is LESS, nothing to the right is GREATER
                int newPivot = ReversePartitioning(a, i, j, pivot);
                if (newPivot == k - 1)
                    return a[newPivot];
                else if (newPivot > k - 1)
                    j = newPivot - 1;
                else
                    i = newPivot + 1;
            }

            return -1;
        }
    }
}