using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Strings
{
    public class SubstringSearch
    {
        public static int BruteForce(string pat, string txt)
        {
            int m = pat.Length;
            int n = txt.Length;

            for (int i = 0; i < n - m; i++)
            {
                int j;
                for (j = 0; j < m; j++)                
                    if (txt[i+j] != pat[j]) break;
                if (j == m) return i;
            }
            return n;
        }
    }
}
