namespace Code.Sorts
{
    public class BinarySearch
    {
        // This being Rank, returns the index of the key which is the same as the number
        // of the keys smaller than key
        // If key is not found, it return the number of keys smaller than given key
        public static int Rank(int[] a, int key)
        {
            var lo = 0;
            var hi = a.Length - 1;

            while (lo <= hi)
            {
                var mid = lo + (hi - lo)/2;
                if (key < a[mid])
                    hi = mid - 1;
                else if (key > a[mid])
                    lo = mid + 1;
                else
                    return mid;
            }
            return lo; // Not found, return the lowest key
        }

        public static int RankR(int[] a, int key)
        {
            return RankR(a, key, 0, a.Length - 1);
        }

        private static int RankR(int[] a, int key, int lo, int hi)
        {
            if (lo > hi) return lo; // Not found, indexes crossed
            var mid = lo + (hi - lo)/2;
            if (key < a[mid])
                return RankR(a, key, lo, mid - 1);
            else if (key > a[mid])
                return RankR(a,  key, mid + 1, hi);
            else
                return mid;
        }
    }
}
