using System;
using System.Collections.Generic;

namespace Code.LinkedListsStacksAndQueues
{
    public class Stacks
    {
        // 3,4,+,2,x,1,+ = (3+4) x 2 + 1
        public static int EvaluateRpn(string exp)
        {
            var stack = new Stack<int>();
            var symbols = exp.Split(',');
            foreach (var symbol in symbols)
            {
                if (symbol.Length == 1 && "+-*/".Contains(symbol))
                {
                    // Must have x and y
                    int x = stack.Pop();
                    int y = stack.Pop();
                    switch (symbol[0])
                    {
                        case '+':
                            stack.Push(x + y);
                        break;
                        case '-':
                            stack.Push(x - y);
                            break;
                        case '*':
                            stack.Push(x * y);
                            break;
                        case '/':
                            stack.Push(x / y);
                            break;
                        default:
                            throw new ArgumentException();
                    }
                }
                else
                {
                    // That's a number
                    stack.Push(int.Parse(symbol));
                }
            }

            return stack.Pop(); // Nice!
        }
    }
}