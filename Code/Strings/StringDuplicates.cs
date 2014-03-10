using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Strings
{
    public class StringDuplicates
    {
        public static void RemoveDuplicates(char[] str)
        {
            if (str == null) return;
            int len = str.Length;
            if (len < 2) return;

            int tail = 1;
            for (int i = 1; i < len; ++i)
            {
                int j;
                for (j = 0; j < tail; ++j)
                {
                    if (str[j] == str[i]) break;
                }
                // move tail only if no dups
                if (j == tail)
                {
                    str[j] = str[i];
                    ++tail;
                }
            }
            str[tail] = '0';
        }
    }
}
