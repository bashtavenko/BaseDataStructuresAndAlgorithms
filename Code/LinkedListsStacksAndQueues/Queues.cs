using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.LinkedListsStacksAndQueues
{
    public class MyQueue<T>
    {
        public int Count { get; private set; }
        public bool IsEmpty { get { return _first == null; } }

        private Node<T> _last;
        private Node<T> _first;
        
        public void Enqueue(T item)
        {            
            var lastTmp = _last;
            _last = new Node<T>(item);
            _last.Next = null;
            if (IsEmpty)
                _first = _last;
            else
                lastTmp.Next = _last;
            Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty)             
                return default(T);

            T item = _first.Data;
            _first = _first.Next;
            if (IsEmpty)
                _last = null;
            Count--;
            return item;
        }
    }
}
