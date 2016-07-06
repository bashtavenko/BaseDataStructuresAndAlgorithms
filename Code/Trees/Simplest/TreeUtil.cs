using System.Collections.Generic;

namespace Code.Trees.Simplest
{
    public class TreeUtil
    {
        private Stack<Node> _nodes;

        //  n1 n2 Result
        //  <  >  Found
        //  <  <  Go left
        //  >  >  Go right
        //  >  <  Outside
        public Node FindLcaInBst(Node node, int n1, int n2)
        {
            if (node == null) return null;

            if (n1 < node.Value && n2 < node.Value)
                node = FindLcaInBst(node.Left, n1, n2);
            else if (n1 > node.Value && n2 > node.Value)
                node = FindLcaInBst(node.Right, n1, n2);
            
            return node; // Meaning left is less and right is greater - we found it.
                         // This also takes care of just two nodes scenario 1 -> 2
        }

        //  n1 n2 Result
        //  <  >  Found
        //  <  <  Go left
        //  >  >  Go right
        //  >  <  Outside
        public Node FindLcaInBstIterative(Node root, int n1, int n2)
        {
            var node = root;

            while (node.Value < n1 || node.Value > n2)
            {
                while (node.Value < n1) node = node.Right;
                while (node.Value > n2) node = node.Left;
            }
            return node;
        }

        public static Node FindFirstGreaterThan(Node root, int k)
        {
            Node result = null;
            Node n = root;

            while (n != null)
            {
                if (k < n.Value)
                {
                    result = n;
                    n = n.Left;
                }
                else
                {
                    n = n.Right;
                }
            }

            return result;
        }

        public Node FindKthLargestInOrder(Node root, int k)
        {
            _nodes = new Stack<Node>();
            TraverseInOrder(root);
            Node result = null;

            for (;k > 0; k--)
            {
                result = _nodes.Count > 0 ? _nodes.Pop() : null;
            }

            return result;
        }

        private void TraverseInOrder(Node n)
        {
            if (n == null) return;
            TraverseInOrder(n.Left);
            _nodes.Push(n);
            TraverseInOrder(n.Right);
        }

        public Node FindKthLargestReverseInOrder(Node root, int k)
        {
            int order = 0;
            Node result = null;
            TraverseReverseInOrder(root, ref order, k, ref result);
            return result;
        }
        
        // Alternative to these messy parameters can be return a class with order and result
        private void TraverseReverseInOrder(Node n, ref int order, int k, ref Node result)
        {
            if (n == null) return;
            TraverseReverseInOrder(n.Right, ref order, k, ref result);
            order++;
            if (k == order)
            {
                result = n;
            }
            TraverseReverseInOrder(n.Left, ref order, k, ref result);
        }
    }
}