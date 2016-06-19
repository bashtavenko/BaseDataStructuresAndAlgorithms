using System;
using System.Text;

namespace Code.Strings
{
    public class RunLengthEncoding
    {
        // Assuming string has just letters and no digits
        // aaaabcccaa => 4a1b3c2a
        public static string Encode(string input)
        {
            var sb = new StringBuilder();
            int count = 1;
            for (int i = 1; i <= input.Length; i++)
            {
                if (i != input.Length && input[i] == input[i - 1])
                {
                    count++;
                }
                else
                {
                    sb.Append(count);
                    sb.Append(input[i - 1]);
                    count = 1;
                }
            }

            return sb.ToString();
        }

        // 4a1b3c2a
        public static string Decode(string input)
        {
            int count = 0;
            var result = new StringBuilder();
            foreach (char c in input)
            {
                if (Char.IsDigit(c))
                {
                    count = c - '0';
                }
                else
                {
                    for(;count > 0; count--)
                    {
                        result.Append(c);
                    }
                }
            }

            return result.ToString();
        }
    }
}