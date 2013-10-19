using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Sorts
{
    class Util
    {
        public static bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        public static void Exchange(IComparable[] a, int i, int j)
        {
            var tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }

        public static void Show(IComparable[] a)
        {
            foreach (var i in a)
            {
                Debug.WriteLine(i);
            }
        }

        public static bool IsSorted(IComparable[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                if (Less(a[i], a[i - 1])) return false;
            }
            return true;
        }
    }
}
