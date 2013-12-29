using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Sorts
{
    class PQBase<T>
    {
        public int Size { get { return _n; } }
        protected T[] _pq;
        protected int _n;
        
        public PQBase(int maxN)
        {
            _pq = new T[maxN+1];
            _n = 0;
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
            while (2 * k <= _n)
            {
                var j = 2 * k;
                if (j < _n && Less(j, j + 1)) j++;
                if (!Less(k, j)) break;
                Swap(k, j);
                k = j;
            }
        }

        protected bool Less(int i, int j)
        {
            return i.CompareTo(j) < 0;
        }

        protected void Swap(int i, int j)
        {
            var tmp = _pq[i];
            _pq[i] = _pq[j];
            _pq[j] = tmp;
        }
    }
}
