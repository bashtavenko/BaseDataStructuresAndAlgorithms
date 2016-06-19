using System;

namespace Code.Strings
{
    // https://www.ics.uci.edu/~eppstein/161/960229.html
    public class LongestCommonSubsequnece
    {
        private readonly int[,] _results;
        private readonly string _a;
        private readonly string _b;

        public LongestCommonSubsequnece(string a, string b)
        {
            _a = a;
            _b = b;
            _results = new int[_a.Length,_b.Length];
            for (int i = 0; i < _a.Length; i++)
                for (int j = 0; j < b.Length; j++)
                    _results[i, j] = -1;
        }

        public int Find()
        {
            return FindLcsMaxLengthDynamic(0, 0);
        }

        public int FindLcsMaxLengthDynamic(int i, int j)
        {
            if (_results[i, j] < 0)
            {
                if (i + 1 == _a.Length || j + 1 == _b.Length)
                    _results[i, j] = 0;
                else if (_a[i] == _b[j])
                    _results[i, j] = 1 + FindLcsMaxLengthDynamic(i + 1, j + 1);
                else
                    _results[i, j] = Math.Max(FindLcsMaxLengthDynamic(i + 1, j), FindLcsMaxLengthDynamic(i, j + 1));
            }
            return _results[i, j];
        }

        public int FindIterative()
        {
            for (int i = _a.Length - 1; i >= 0 ; i--)
                for (int j = _b.Length - 1; j >= 0; j--)
                {
                    if (i + 1 == _a.Length || j + 1 == _b.Length)
                        _results[i, j] = 0;
                    else if (_a[i] == _b[j])
                        _results[i, j] = 1 + _results[i + 1, j + 1];
                    else
                        _results[i, j] = Math.Max(_results[i + 1, j], _results[i, j + 1]);
                }

            return _results[0, 0];
        }

        // nematode        A C B
        //  empty          A B C
        //  3 (e, m, t)    2 (A C)
        public static int FindLcsMaxLength(string a, string b)
        {
            if (a.Length == 0 || b.Length == 0)
                return 0;
            else if (a[0] == b[0])
                return 1 + FindLcsMaxLength(a.Substring(1), b.Substring(1));
            else
                return Math.Max(FindLcsMaxLength(a.Substring(1), b), FindLcsMaxLength(b.Substring(1), a));
        }
    }
}