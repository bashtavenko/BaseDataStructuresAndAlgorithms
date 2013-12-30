using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Sorts
{
    public class PQBase<T> where T : IComparable<T>
    {
        public int Size { get { return _n; } }
        protected T[] _pq;
        protected int _n;
        
        public PQBase(int maxN)
        {
            _pq = new T[maxN+2];
            _n = 0;
        }

        protected void Swap(int i, int j)
        {
            var tmp = _pq[i];
            _pq[i] = _pq[j];
            _pq[j] = tmp;
        }
    }
}
