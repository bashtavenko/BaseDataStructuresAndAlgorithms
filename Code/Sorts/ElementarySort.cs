using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Sorts
{
    internal class ElementarySort
    {
        public void InsertSort(int[] a)
        {
            for (var i = 0; i < a.Length; i++)
            {
                var k = i;
                while (k > 0 && a[k] < a[k - 1])
                {
                    Swap(a, k, k - 1);
                    k--;
                }
            }
        }

        private void Swap(int[] a, int i, int j)
        {
            var tmp = a[i];
            a[i] = a[j];
            a[j] = tmp;
        }
    }
}


    
