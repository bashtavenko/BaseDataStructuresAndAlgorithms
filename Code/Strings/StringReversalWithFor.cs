using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Strings
{
    public class StringReversalWithFor : IStringReversal
    {
        // 0 1 2 3 4
        // a b c d e
        //
        //
        //
        
        public char[] Reverse(char[] input)
        {
            int length = input.Length;
            for (int index = 0; index < length / 2; index++)
            {
                int endIndex = length - 1 - index;
                char temp = input[index];
                input[index] = input[endIndex];
                input[endIndex] = temp;
            }
            return input;
        }
    }
}
