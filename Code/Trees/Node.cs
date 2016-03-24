using System;

namespace Code.Trees
{
    public class Node<TK, TV> where TK : IComparable
    {
        public TK Key { get; set; }
        public TV Value { get; set; }
        public Node<TK,TV> Left { get; set; }
        public Node<TK, TV> Right { get; set; }
        public int SubNodesCount { get; set; }


        public Node(TK key) 
            :this(key, default(TV))
        {
        }

        public Node(TK key, TV value)
            : this(key, value, 0)
        {
        }

        public Node(TK key, TV value, int subNodesCount)
        {
            this.Key = key;            
            this.Value = value;
            this.SubNodesCount = subNodesCount;
        }
    }
}
