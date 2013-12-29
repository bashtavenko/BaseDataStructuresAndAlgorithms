using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Sorts
{
    public class Misc
    {
        public static void MergeTwoSortedArraysInPlace(int[] a, int[] b)
        {
            var len = a.Length;
            if (b.Length != len * 2)
                return;

            var i = len - 1;
            var j = i;

            for(var k = b.Length - 1; k > 0; k--)
            {
                if (a[i] > b[j]) b[k] = a[i--];                    
                else if (a[i] < b[j]) b[k] = b[j--];                    
                else
                {
                    b[k] = a[i];
                    i--;
                    j--;
                }                
            }
            b[0] = a[0] > b[0] ? b[0] : a[0];
        }
    }
}
