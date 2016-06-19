using System;

namespace Code.PriorityQueues
{
    public class PqBase<T> where T : IComparable<T>
    {
        public int Size => N;
        protected T[] Pq;
        protected int N;
        
        public PqBase(int maxN)
        {
            Pq = new T[maxN+2];
            N = 0;
        }

        protected void Swim(int k)
        {
            while (k > 1 && Less(k / 2, k))
            {
                Swap(k / 2, k);
                k = k / 2;
            }
        }

        protected void Sink(int k)
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

        protected void Swap(int i, int j)
        {
            var tmp = Pq[i];
            Pq[i] = Pq[j];
            Pq[j] = tmp;
        }

        protected bool Greater(int i, int j)
        {
            return Pq[i].CompareTo(Pq[j]) > 0;
        }

        protected bool Less(int i, int j)
        {
            return Pq[i].CompareTo(Pq[j]) < 0;
        }
    }
}
