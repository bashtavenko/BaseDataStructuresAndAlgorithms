using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Sorts
{
    class MaxPQ<T> where T : IComparable
    {
        public int Size { get { return _n; }}
        private T[] _pq;
        private int _n;
        
        public MaxPQ(int maxN)
        {
            _pq = new T[maxN+1];
            _n = 0;
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

        // because it's binary heap
        private void Swim (int k)
        {
            while (k > 1 && Less(k / 2, k))
            {
                Swap(k /2, k);
                k = k/2;
            }
        }

        private void Sink (int k)
        {
            while (2 * k <= _n)
            {
                var j = 2*k;
                if (j < _n && Less(j, j + 1)) j++;
                if (!Less(k, j)) break;
                Swap(k, j);
                k = j;
            }
        }

        private bool Less(int i, int j)
        {
            return _pq[i].CompareTo(j) < 0;
        }

        private void Swap(int i, int j)
        {
            var tmp = _pq[i];
            _pq[i] = _pq[j];
            _pq[j] = tmp;
        }
    }
}
