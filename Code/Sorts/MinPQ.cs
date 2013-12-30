using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Sorts
{    
    public class MinPQ<T> : PQBase<T> where T : IComparable<T>
    {
        public MinPQ(int maxN)
            : base(maxN)
        {
        }

        public void Insert(T key)
        {
            _pq[++_n] = key;
            Swim(_n);
        }

        public T DelMin()
        {
            Swap(1, _n);
            T min = _pq[_n--];
            Sink(1);
            _pq[_n + 1] = default(T);            
            return min;
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
            while (2 * k <= _n)
            {
                var j = 2 * k;
                if (j < _n && Greater(j, j + 1)) j++;
                if (!Greater(k, j)) break;
                Swap(k, j);
                k = j;
            }
        }

        private bool Greater(int i, int j)
        {
            return _pq[i].CompareTo(_pq[j]) > 0;
        }
    }
}
