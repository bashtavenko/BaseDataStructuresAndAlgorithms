using System;
using Code.Sorts.PeakFinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
  [TestClass]
  public class PeakFinderTest
  {
    private int[] _onePeak = new int[] { 2, 20, 17, 12, 10, 8 };
    private int[] _onePeak2 = new int[] { 1, 2, 3, 5, 20, 17 };
    private int[] _shortOnePeak = new int[] { 2, 20, 3 };
    private IPeakFinder _finder;

    [TestInitialize]
    public void Init()
    {
      //_finder = new PeakFinderLinear();
      _finder = new PeakFinderLogN();
    }

    [TestMethod]
    public void Find()
    {      
      Assert.AreEqual(1, _finder.Find(_onePeak));
      Assert.AreEqual(4, _finder.Find(_onePeak2));
      Assert.AreEqual(1, _finder.Find(_shortOnePeak));
    }
  }
}
