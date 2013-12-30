using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Sorts
{
    public class MaxPQ<T> : PQBase<T> where T : IComparable<T>
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
            while (2 * k <= _n)
            {
                var j = 2 * k;
                if (j < _n && Less(j, j + 1)) j++;
                if (!Less(k, j)) break;
                Swap(k, j);
                k = j;
            }
        }

        private bool Less(int i, int j)
        {
            return _pq[i].CompareTo(_pq[j]) < 0;
        }
    }
}
