using System;
using System.Collections.Generic;

namespace Code.Strings.Trivial
{
    public class StringReversalWithStack : IStringReversal
    {
        // 0 1 2 3 4
        // a b c d e
        //
        //
        //
        
        public char[] Reverse(char[] input)
        {
            return new Stack<char>(input).ToArray();
        }
    }
}
