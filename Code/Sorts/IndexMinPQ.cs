using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Sorts
{    
    public class IndexMinPQ<T>  where T : IComparable<T>
    {
        public bool IsEmpty { get { return _n == 0; } }
        public int Size { get { return _n; } }
        public int MinIndex { get { return _pq[1];}}
        public T MinKey { get { return _keys[1]; } }
        
        private int _n;
        private int[] _pq;
        private int[] _qp;
        private T[] _keys;

        public IndexMinPQ(int maxN)            
        {
            _pq = new int[maxN + 2];
            _qp = new int[maxN + 2];
            _keys = new T[maxN + 2];

            for (int i = 0; i <= maxN; i++)
            {
                _qp[i] = -1;
            }
        }
                
        public void Insert(int i, T key)
        {
            _n++;
            _qp[i] = _n;
            _pq[_n] = i;
            _keys[i] = key;
            Swim(_n);
        }

        public int DelMin()
        {
            int min = _pq[1];
            Swap(1, _n);            
            Sink(1);
            _qp[min] = -1;
            _keys[_pq[_n + 1]] = default(T);
            _pq[_n + 1] = -1;            
            return min;
        }

        public bool Contains(int i)
        {
            return _qp[i] != -1;
        }

        public void ChangeKey(int i, T key)
        {
            _keys[i] = key;
            Swim(_qp[i]);
            Sink(_qp[i]);
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

        private void Swap(int i, int j)
        {
            var tmp = _pq[i];
            _pq[i] = _pq[j];
            _pq[j] = tmp;
        }
    }
}
