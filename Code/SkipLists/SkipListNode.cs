using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.SkipLists
{
    internal class SkipListNode<T>
    {
        public T Value { get; private set; }
        public SkipListNode<T>[] Next { get; private set;  }
        
        public SkipListNode(T value, int height)
        {
            Value = value;
            Next = new SkipListNode<T>[height];
        }
    }
}
