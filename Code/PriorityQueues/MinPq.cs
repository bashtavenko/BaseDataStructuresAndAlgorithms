using System;

namespace Code.PriorityQueues
{    
    public class MinPq<T> : PqBase<T> where T : IComparable<T>
    {
        public MinPq(int maxN)
            : base(maxN)
        {
        }

        public void Insert(T key)
        {
            Pq[++N] = key;
            Swim(N);
        }

        public T DelMin()
        {
            Swap(1, N);
            T min = Pq[N--];
            Sink(1);
            Pq[N + 1] = default(T);            
            return min;
        }
    }
}
