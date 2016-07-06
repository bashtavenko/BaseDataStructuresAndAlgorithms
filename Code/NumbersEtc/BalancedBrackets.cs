using System.Collections.Generic;
using System.Linq;

namespace Code.NumbersEtc
{
    public class BalancedBrackets
    {
        private readonly char[] _leftBrackets = new char[] {'[', '(', '{'};
        private readonly char[] _rightBrackets = new char[] {']', ')', '}'};

        // Crude way of checking the number of brackets, ignores the order
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

        // Enforces not only number of brackets, but it's order
        // ([]){()}
        public bool IsWellFormed(string input)
        {
            var leftBracketStack = new Stack<char>();
            foreach (var token in input.Split(','))
            {
                char c = token[0];
                if (_leftBrackets.Contains(c))
                {
                    leftBracketStack.Push(c);
                }
                else
                {
                    if (leftBracketStack.Count == 0) return false;
                    if ((c == ')' && leftBracketStack.Peek() != '(') ||
                        (c == '}' && leftBracketStack.Peek() != '{') ||
                        (c == ']' && leftBracketStack.Peek() != '['))
                    {
                        return false;
                    }
                    leftBracketStack.Pop();
                }
            }
            return leftBracketStack.Count == 0;
        }
    }
}