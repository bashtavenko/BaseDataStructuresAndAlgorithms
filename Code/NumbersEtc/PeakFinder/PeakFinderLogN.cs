using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.NumbersEtc.PeakFinder
{
  public class PeakFinderLogN : IPeakFinder 
  {
    public int Find(int[] a)
    {
      return Find(a, 0, a.Length - 1);
    }

    private int Find(int[] a, int i, int j)
    {
      int m = (i + j) / 2;
      var leftIndex = m > 1 ? m - 1 : 0;
      var rightIndex = m < a.Length - 2 ? m + 1 : a.Length - 1;
      if (a[leftIndex] <= a[m] && a[m] >= a[rightIndex])
        return m;
      else if (a[leftIndex] > a[m])
        return Find(a, i, m); // move to the left, ignore right part
      else
        return Find(a, rightIndex, j); // move to the right, ignore left part
    }
  }
}
