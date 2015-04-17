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

            int tail = 1; // Invariant: there are no dups to the left of the tail
            for (int i = 1; i < len; ++i)
            {
                int j;
                for (j = 0; j < tail; ++j)
                {
                    if (str[j] == str[i]) break;
                }
                // move tail only if no dups (maintaining invariant)
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
