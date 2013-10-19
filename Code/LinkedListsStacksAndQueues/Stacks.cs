using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Code.LinkedListsStacksAndQueues
{
    class MyStack<T>
    {
        private Node<T> _first; // most recently added node
        
        public void Push(T item)
        {
            var newNode = new Node<T>(item);
            newNode.Next = _first;
            _first = newNode;
        }
        
        public T Pop()
        {
            if (_first != null)
            {
                T item = _first.Data;
                _first = _first.Next;
                return item;
            }
            else
                return default(T);
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


