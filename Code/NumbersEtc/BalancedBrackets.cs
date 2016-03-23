using System.Linq;

namespace Code.NumbersEtc
{
    public class BalancedBrackets
    {
        private readonly char[] _leftBrackets = new char[] {'[', '(', '{', '<'};
        private readonly char[] _rightBrackets = new char[] {']', ')', '}', '>'};

        public bool IsBalanced(string input)
        {
            int count = 0;
            foreach (var character in input.ToCharArray())
            {
                if (_leftBrackets.Contains(character)) count++;
                if (_rightBrackets.Contains(character)) count--;
            }
            return count == 0;
        }
    }
}