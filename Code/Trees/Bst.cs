using System;

namespace Code.Trees
{
    public class Bst<TK,TV> where TK : IComparable
    {
        private Node<TK,TV> _root;

        public int Size => GetSize(_root);

        public TV Get(TK key)
        {
            return Get(_root, key);
        }

        public void Put(TK key, TV value)
        {
            // Since we alway starts from the root, every time the root is returned. In an empty tree it would be a new root,
            // in the existing it will be existing one.
            _root = Put(_root, key, value);
        }
                        
        private TV Get(Node<TK, TV> node, TK key)
        {
            if (node == null) return default(TV);
            var dif = key.CompareTo(node.Key);
            if (dif < 0)
                return Get(node.Left, key);
            else if (dif > 0)
                return Get(node.Right, key);
            else
                return node.Value;            
        }

        private Node<TK,TV> Put(Node<TK,TV> node, TK key, TV value)
        {
            // 1. Create root; 2. Create child node 
            if (node == null) return new Node<TK, TV>(key, value, 1);

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

        private int GetSize(Node<TK,TV> node)
        {
            return node?.SubNodesCount ?? 0;
        }
    }
}
