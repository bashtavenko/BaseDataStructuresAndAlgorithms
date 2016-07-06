using System;

namespace Code.PriorityQueues
{
    public class MaxPq<T> : PqBase<T> where T : IComparable<T>
    {
        public MaxPq(int maxN)
            : base(maxN)
        {
        }

        public void Insert(T key)
        {
            Pq[++N] = key;
            Swim(N);
        }

        public T DelMax()
        {
            T max = Pq[1];
            Swap(1, N--);
            Pq[N + 1] = default(T);
            Sink(1);
            return max;
        }

        private void Swim(int k)
        {
            while (k > 1 && Less(k / 2, k))
            {
                Swap(k / 2, k);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2 * k <= N)
            {
                var j = 2 * k;
                if (j < N && Less(j, j + 1)) j++;
                if (!Less(k, j)) break;
                Swap(k, j);
                k = j;
            }
        }

    }
}
