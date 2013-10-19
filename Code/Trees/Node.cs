using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Trees
{
    class Node<K, V> where K : IComparable
    {
        public K Key { get; set; }
        public V Value { get; set; }
        public Node<K,V> Left { get; set; }
        public Node<K, V> Right { get; set; }
        public int SubNodesCount { get; set; }

        public Node(K key, V value, int subNodesCount)
        {
            this.Key = key;            
            this.Value = value;
            this.SubNodesCount = subNodesCount;
        }
    }
}
