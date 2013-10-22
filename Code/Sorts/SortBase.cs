using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Sorts
{
    public abstract class SortBase<T> where T : IComparable
    {   
        public abstract void Sort(T[] a);

        public bool IsSorted(T[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                if (Less(a[i], a[i - 1])) return false;
            }
            return true;
        }

        public void Show(T[] a)
        {
            foreach (var i in a)
            {
                Debug.WriteLine(i);
            }
        }        
        
        protected bool Less(T v, T w)
        {
            return v.CompareTo(w) < 0;
        }

        protected void Exchange(T[] a, int i, int j)
        {
            var tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }
    }
}
