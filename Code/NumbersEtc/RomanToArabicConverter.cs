using System.Collections.Generic;

namespace Code.NumbersEtc
{
    public class RomanToArabicConverter
    {
        private readonly Dictionary<char, int> _romans = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        // Go right to left
        // IV => 4; XC => 90; but XI => 11
        // This doesn't cover invalid numbers such as "IIII"
        public int Convert(string input)
        {
            int result = 0, prev = 0;
            for (var i = input.Length - 1; i >= 0; i--)
            {
                int temp = _romans[input[i]];
                result = temp < prev ? result - temp : result + temp;
                prev = temp;
            }
            return result;
        }
    }
}
