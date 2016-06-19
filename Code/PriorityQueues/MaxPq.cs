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
    }
}
