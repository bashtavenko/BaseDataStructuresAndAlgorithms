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
