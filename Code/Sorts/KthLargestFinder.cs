using System;
using Code.PriorityQueues;

namespace Code.Sorts
{
    public class KthLargestFinder : SortBase<int>
    {
        public override void Sort(int[] a)
        {
        }

        // a = 3, 2, 1, 5, 4, k = 2, 4 - second element
        // This is called QuickSelect (I guess)
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


        // This is called HeapSelect (I guess)
        public int FindKthLargestWithMaxHeap(int[] a, int k)
        {
            if (k > a.Length) return -1;

            var pq = new MaxPq<int>(a.Length);
            foreach (var i in a)
            {
                pq.Insert(i);
            }

            // Max is the first but the rest of PQ are in no order, they just smaller than max
            // we need to pop them one by one
            for (int i = 1; i < k; i++)
            {
                pq.DelMax();
            }

            return pq.DelMax();
        }

        // Have a MINIMUM heap with size k and our element will be at the top
        // The point of having MIN heap to kt LARGEST is that kth element will be a the top
        public int FindKthLargestWithMinHeap(int[] a, int k)
        {
            if (k > a.Length) return -1;

            var pq = new MinPq<int>(k);
            foreach (var i in a)
            {
                if (pq.Size < k)
                {
                    // Easy case
                    pq.Insert(i);
                }
                else
                {
                    var currentMin = pq.Peek();
                    if (i > currentMin)
                    {
                        pq.DelMin(); // In this PQ implementation client keeps track of it's size     
                        pq.Insert(i);
                    }
                }
            }

            return pq.DelMin();
        }

        // PQ holds k minimum elements
        public int FindKthLargestWithMinHeapDeadSimple(int[] a, int k)
        {
            if (k > a.Length) return -1;
            var pq = new MinPq<int>(k);
            foreach (var i in a)
            {
                pq.Insert(i);
                if (pq.Size == k + 1)
                {
                    pq.DelMin();
                }
            }
            return pq.DelMin();
        }
    }
}