using System;

namespace Code.Trees
{
    public class Node<K, V> where K : IComparable
    {
        public K Key { get; set; }
        public V Value { get; set; }
        public Node<K,V> Left { get; set; }
        public Node<K, V> Right { get; set; }
        public int SubNodesCount { get; set; }


        public Node(K key) 
            :this(key, default(V))
        {
        }

        public Node(K key, V value)
            : this(key, value, 0)
        {
        }

        public Node(K key, V value, int subNodesCount)
        {
            this.Key = key;            
            this.Value = value;
            this.SubNodesCount = subNodesCount;
        }
    }
}
