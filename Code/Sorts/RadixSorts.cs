using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Sorts
{
  public class RadixSorts
  {
    public static int[] KeyIndexCountingSort(int[] a, int r)
    {
      int n = a.Length;
      int[] count = new int[r + 1];
      int[] aux = new int[n];

      // 1. Compute frequencies counts
      for (int i = 0; i < n; i++)
      {
        count[a[i]+1]++;
      }

      // 2. Transform counts to indices
      for (int j = 0; j < r; j++)
      {
        count[j + 1] += count[j];
      }

      // 3. Distribute the data
      for (int i = 0; i < n; i++)
      {
        aux[count[a[i]]++] = a[i];
      }

      // 4. Copy back
      for (int i = 0; i < n; i++)
      {
        a[i] = aux[i];
      }

      return a;
    }
  }
}
