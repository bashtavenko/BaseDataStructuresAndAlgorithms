using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.Sorts;

namespace UnitTests
{
  [TestClass]
  public class RadixSortsTest
  {
    [TestMethod]
    public void KeyIndexCounting()
    {
      int[] input = FromCharToInt(new int[]{ 'd', 'a', 'c', 'f', 'f', 'b', 'd', 'b', 'f', 'b', 'e', 'a' });
      int[] output = FromCharToInt(new int[] { 'a', 'a', 'b', 'b', 'b', 'c', 'd', 'd', 'e', 'f', 'f', 'f' });
      int radix = 6;
      int[] result = RadixSorts.KeyIndexCountingSort (input, radix);
      CollectionAssert.AreEqual(result, output);
    }

    private static int[] FromCharToInt(int[] a)
    {
      return a.Select(s => s - 97).ToArray();
    }    
  }
}
