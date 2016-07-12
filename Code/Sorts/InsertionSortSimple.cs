namespace Code.Sorts
{
    internal class InsertionSortSimple
    {
        public void InsertSort(int[] a)
        {
            // Entries to the right have not been seen yet.
            // Rearrange (order) left portion.
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


    
