using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code;
using Code.Trees;
using System.Diagnostics;

namespace Code.Trees
{
    class TreeTraversal<K,V> where K : IComparable
    {
        public void TraversePreOrder(Node<K,V> node)
        {
            if (node != null)
            {
                Trace.WriteLine(node.Value);
                TraversePreOrder(node.Left);
                TraversePreOrder(node.Right);
            }
        }
        
        // That's complicated
        public Node<K,V> CommonAccessor (Node<K,V> root, Node<K,V> n1, Node<K,V> n2 )
        {
            if (IsChild(root.Left, n1) && IsChild(root.Left, n2))
                return CommonAccessor(root.Left, n1, n2);
            if (IsChild(root.Right, n1) && IsChild(root.Right, n2))
                return CommonAccessor(root.Right, n1, n2);
            return root;
        }

        private bool IsChild (Node<K,V> root, Node<K,V> n)
        {
            if (root == null) return false;
            if (root.Key.CompareTo(n.Key) == 0) return true;
            return IsChild(root.Left, n) || IsChild(root.Right, n);
        }
    }
}
