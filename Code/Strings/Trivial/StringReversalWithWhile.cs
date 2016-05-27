namespace Code.Strings.Trivial
{
    public class StringReversalWithWhile : IStringReversal
    {
        // 0 1 2 3 4
        // a b c d e
        //
        //
        //
        
        public char[] Reverse(char[] input)
        {
            var startIndex = 0;
            var endIndex = input.Length - 1;
            char tmp;
            while (startIndex < endIndex)
            {
                tmp = input[startIndex];
                input[startIndex] = input[endIndex];
                input[endIndex] = tmp;
                startIndex++;
                endIndex--;
            }
            return input;
        }
    }
}
