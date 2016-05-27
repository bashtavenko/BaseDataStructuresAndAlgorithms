namespace Code.NumbersEtc.PeakFinder
{
  public class PeakFinderLinear : IPeakFinder
  {
    // Find first peak (not neccessarily a maxium)
    public int Find(int[] a)
    {
      var length = a.Length;
      if (length < 3) return -1;

      var left = 0;
      var right = 0;
      var i = 1;
      var found = false;
      for (i = 1; i < a.Length - 1; i++)
      {
        left = a[i - 1];
        right = a[i + 1];
        if (a[i] > left && a[i] > right)
        {
          found = true;
          break;
        }
      }
      return found ? i : -1;
    }
  }
}
