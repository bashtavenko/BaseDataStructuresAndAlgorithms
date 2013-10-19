using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Strings
{
    class StringReversalWithWords
    {
        // "A roza upala na lapu Azora\0...."
        // "arozA upal\0...."
        public void ReverseString(char[] input)
        {
            int length = input.Length;
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == 0)
                {
                    length = i;
                    break;
                }
            }

            Reverse(input, 0, length);

            var startPos = 0;
            var endPos = 0;
            while (input[startPos] != 0)
            {
                if (input[startPos] == ' ')
                {
                    startPos++;
                    endPos++;
                }
                if (input[endPos] == ' ' || input[endPos] == 0)
                {
                    Reverse(input, startPos, --endPos);
                    startPos = ++endPos;
                }
                else
                {
                    endPos++;
                }
            }
        }


        private void Reverse(char[] input, int start, int end)
        {
            while (start < end)
            {
                var tmp = input[start];
                input[start] = input[end];
                input[end] = tmp;
                start++;
                end++;
            }
        }

    }
}
