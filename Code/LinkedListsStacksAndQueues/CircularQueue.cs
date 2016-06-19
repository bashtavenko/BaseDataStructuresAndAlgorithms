using System;

namespace Code.LinkedListsStacksAndQueues
{
    public class CircularQueue
    {
        public int Size { get; private set; }

        private int _head;
        private int _tail;
        private int[] _entries;

        public CircularQueue(int capacity)
        {
            _entries = new int[capacity];
        }

        public void Enqueue(int x)
        {
            if (Size == _entries.Length)
            {
                _head = 0;
                _tail = Size;
                Array.Resize(ref _entries, _entries.Length * 2);
            }

            _entries[_tail] = x;
            _tail = (_tail + 1)%_entries.Length;
            ++Size;
        }

        public int Deque()
        {
            if (Size == 0)
            {
                throw new ArgumentException();
            }
            --Size;
            int ret = _entries[_head];
            _head = (_head + 1)%_entries.Length;
            return ret;
        }
    }
}