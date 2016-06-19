using System;

namespace Code.LinkedListsStacksAndQueues
{
    public class SimpleQueue
    {
        public int Count { get; private set; }
        public bool IsEmpty => _first == _last;

        private Node _last;
        private Node _first;

        public SimpleQueue()
        {
            _last = new Node(0); // Dummy tail simplifies enqueue 
            _first = _last;
        }
        
        public void Enqueue(int item)
        {   
            _last.Next = new Node(item);
            _last = _last.Next;
            Count++;
        }

        public int Dequeue()
        {
            if (IsEmpty)             
                throw new ArgumentException("Queue is empty");

            int item = _first.Next.Data;
            _first = _first.Next.Next;
            Count--;
            return item;
        }
    }
}
