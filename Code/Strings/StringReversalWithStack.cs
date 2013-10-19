using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Strings
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
