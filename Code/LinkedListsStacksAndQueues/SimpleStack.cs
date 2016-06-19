using System.Collections.Generic;

namespace Code.LinkedListsStacksAndQueues
{
    class SimpleStack
    {
        private Node _first; // most recently added node
        
        public void Push(int item)
        {
            var newNode = new Node(item);
            newNode.Next = _first;
            _first = newNode;
        }
        
        public int Pop()
        {
            if (_first != null)
            {
                int item = _first.Data;
                _first = _first.Next;
                return item;
            }
            else
                return default(int);
        }
    }

    public class StackSort
    {
        public static Stack<int> Sort(Stack<int> s)
        {
            var r = new Stack<int>();
            while (s.Count > 0)
            {
                var tmp = s.Pop();
                while (r.Count > 0 && r.Peek() > tmp)
                    s.Push(r.Pop());
                r.Push(tmp);
            }
            return r;
        }
    }

}


