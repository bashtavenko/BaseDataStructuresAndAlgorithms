using System;

namespace Code.Strings
{
    public class StringDistance
    {
        public static int Compute(string a, string b)
        {
            var distance = new int[a.Length, b.Length];
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    distance[i, j] = -1;
                }
            }

            return ComputeHelper(a, a.Length -1, b, b.Length - 1, distance);
        }

        private static int ComputeHelper(string a, int aIndex, string b, int bIndex, int[,] distance)
        {
            if (aIndex < 0)
            {
                return bIndex + 1;
            }
            else if (bIndex < 0)
            {
                return aIndex + 1;
            }

            if (distance[aIndex, bIndex] == -1)
            {
                if (a[aIndex] == b[bIndex])
                {
                    distance[aIndex, bIndex] = ComputeHelper(a, aIndex - 1, b, bIndex - 1, distance); // Last char is the same, move on
                }
                else
                {
                    int substituteLast = ComputeHelper(a, aIndex - 1, b, bIndex - 1, distance);
                    int addLast = ComputeHelper(a, aIndex, b, bIndex - 1, distance);
                    int deleteLast = ComputeHelper(a, aIndex - 1, b, bIndex, distance);
                    distance[aIndex, bIndex] = 1 + Math.Min(substituteLast, Math.Min(addLast, deleteLast));
                }
            }

            return distance[aIndex, bIndex];
        }
    }
}