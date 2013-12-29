using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Sorts
{
    class MaxPQ<T> : PQBase<T> where T : IComparable<T>
    {
        public MaxPQ(int maxN)
            : base(maxN)
        {
        }

        public void Insert(T key)
        {
            _pq[++_n] = key;
            Swim(_n);
        }

        public T DelMax()
        {
            T max = _pq[1];
            Swap(1, _n--);
            _pq[_n + 1] = default(T);
            Sink(1);
            return max;
        }
    }
}
