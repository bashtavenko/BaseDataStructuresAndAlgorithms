namespace Code.NumbersEtc
{
    public class TraverseArray
    {
        //  Ways right + ways down
        //  a[2,2] = a[1,2] + a[2,1]  2 = 1 + 1
        //  1 -> 1
        //  |
        //  1    2

        //  1   1   1   1   1
        //  1   2   3   4   5
        //  1   3   6   10  15
        //  1   4   10  20  35
        //  1   5   15  35  70

        public static int CalcNumberOfWays(int n, int m)
        {
            return Calc(n - 1, m - 1, new int[n, m]);
        }

        private static int Calc(int x, int y, int[,] matrix)
        {
            if (x == 0 || y == 0)
            {
                return 1;
            }

            if (matrix[x, y] == 0)
            {
                int waysRight = x == 0 ? 0 : Calc(x - 1, y, matrix);
                int waysDown = x == 0 ? 0 : Calc(x, y - 1, matrix);
                matrix[x, y] = waysRight + waysDown;
            }

            return matrix[x, y];
        }
    }
}
