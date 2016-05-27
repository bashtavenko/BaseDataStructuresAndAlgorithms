namespace Code.Strings.Trivial
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
            var j = length - 1;
            for (var i = 0; i < length / 2; i++, j--)
            {
                char temp = input[i];
                input[i] = input[j];
                input[j] = temp;
            }
            return input;
        }
    }
}
