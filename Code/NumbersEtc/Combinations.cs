using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.NumbersEtc
{
  public class Combinations
  {       
    // ths never worked
    public int NextCombination (int[] comb, int k, int n)
    {
      int i = k - 1;
      ++comb[i];
      while (i >=0 && comb[i] >= n - k + 1 + i)
      {
        --i;
        ++comb[i];
      }

      if (comb[0] > n - k)
        return 0;

      for (i = i + 1; i < k; ++i)
      {
        comb[i] = comb[i - 1] + 1;
      }

      return 1;
    }

    public void Run()
    {
      var n = 5;
      var k = 3;
      int[] comb = new int[16];
      for (int i = 0; i < k; i++)
      {
        comb[i] = i;
      }

      PrintC(comb, k);

      while (NextCombination(comb, k, n) > 0)
        PrintC(comb, k);
    }

    private void PrintC(int[] comb, int k)
    {
      var sb = new StringBuilder("{");
      for (int i = 0; i < k; i++)
      {
        sb.Append(comb[i].ToString());
        sb.Append(",");
      }
      sb.Append("}");
      Trace.WriteLine(sb.ToString());
    }

    public void Comb(string sofar, string rest, int n)
    {
      if (n == 0)
        Trace.WriteLine(sofar);
      else
      {
        for (int i = 0; i < rest.Length; i++)
        {
          Comb(sofar + rest[i], rest.Substring(i + 1), n - 1);
        }
      }
    }

  }
}
