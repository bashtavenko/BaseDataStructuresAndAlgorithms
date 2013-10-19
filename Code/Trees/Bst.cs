using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Trees
{
    public class Bst<K,V> where K : IComparable
    {
        private Node<K,V> _root;

        public int Size { get { return GetSize(_root); } }

        public V Get(K key)
        {
            return Get(_root, key);
        }

        public void Put(K key, V value)
        {
            _root = Put(_root, key, value);
        }
                        
        private V Get(Node<K, V> node, K key)
        {
            if (node == null) return default(V);
            var dif = key.CompareTo(node.Key);
            if (dif < 0)
                return Get(node.Left, key);
            else if (dif > 0)
                return Get(node.Right, key);
            else
                return node.Value;            
        }

        private Node<K,V> Put(Node<K,V> node, K key, V value)
        {
            if (node == null) return new Node<K, V>(key, value, 1);

            int dif = key.CompareTo(node.Key);
            if (dif < 0)
                node.Left = Put(node.Left, key, value);
            else if (dif > 0)
                node.Right = Put(node.Right, key, value);
            else
                node.Value = value;
                
            node.SubNodesCount = GetSize(node.Left) + GetSize(node.Right) + 1;
            return node;            
        }

        private int GetSize(Node<K,V> node)
        {
            return node == null ? 0 : node.SubNodesCount;
        }
    }
}
