using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Trees.Simple
{
    public class Node
    {
        public int Key { get; set; }
        public object Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int SubNodesCount { get; set; }

        public Node(int key) 
            :this(key, null)
        {
        }

        public Node(int key, object value)
            : this(key, value, 0)
        {
        }

        public Node(int key, object value, int subNodesCount)
        {
            this.Key = key;            
            this.Value = value;
            this.SubNodesCount = subNodesCount;
        }
    }
}
