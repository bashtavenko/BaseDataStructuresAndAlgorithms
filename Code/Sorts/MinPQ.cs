using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Sorts
{
    // TODO: not even tested
    class MinPQ<T> : PQBase<T> where T : IComparable<T>
    {
        public MinPQ(int maxN)
            : base(maxN)
        {
        }

        public void Insert(T key)
        {
            _pq[1] = key;
            _n++;
            Sink(1);
        }

        public T DelMin()
        {            
            T min = _pq[_n];
            Swap(_n--, 1);
            _pq[_n + 1] = default(T);
            Swim(_n);
            return min;
        }
    }
}
