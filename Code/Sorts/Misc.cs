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

        public void SortArrayWithZerosAndOnes(int[] a)
        {
            int lo = 0;
            int hi = a.Length;
            int j = lo + 1;
            for (var i = lo; i < hi; i++)
            {
                if (a[i] == 0) { Swap(a, i, j - 1); j++; }
            }
        }

        private void Swap(int[] a, int i, int j)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

    }
}
