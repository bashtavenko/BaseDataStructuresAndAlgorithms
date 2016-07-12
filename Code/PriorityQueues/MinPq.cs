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

        public T Peek()
        {
            return Pq[1];
        }

        private void Swim(int k)
        {
            while (k > 1 && Greater(k / 2, k))
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
                if (j < N && Greater(j, j + 1)) j++;
                if (!Greater(k, j)) break;
                Swap(k, j);
                k = j;
            }
        }

    }
}
