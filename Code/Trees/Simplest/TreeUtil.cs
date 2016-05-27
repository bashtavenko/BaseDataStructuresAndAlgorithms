using System.Diagnostics;

namespace Code.Trees.Simplest
{
    public class TreeUtil
    {
        // Create a copy of the tree
        public void TraversePreOrder(Node node)
        {
            if (node == null) return;

            Debug.WriteLine(node.Value);
            TraversePreOrder(node.Left);
            TraversePreOrder(node.Right);
        }

        public void TraverseInOrder(Node node)
        {
            if (node == null) return;

            TraverseInOrder(node.Left);
            Debug.WriteLine(node.Value);
            TraverseInOrder(node.Right);
        }

        // Delete tree
        public void TraversePostOrder(Node node)
        {
            if (node == null) return;

            TraversePostOrder(node.Left);
            TraversePostOrder(node.Right);
            Debug.WriteLine(node.Value);
        }
        
        public bool IsBst(Node node)
        {
            return IsSubtreeLess(node.Left, node.Value) && IsSubtreeGreater(node.Right, node.Value);
        }

        private bool IsSubtreeLess(Node node, int value)
        {
            if (node == null) return true;
            return node.Value < value && IsSubtreeLess(node.Left, value) && IsSubtreeLess(node.Right, value);
        }

        private bool IsSubtreeGreater(Node node, int value)
        {
            if (node == null) return true;
            return node.Value > value && IsSubtreeGreater(node.Left, value) && IsSubtreeGreater(node.Right, value);
        }

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

        public Node FindLcaInBinaryTree(Node node, int n1, int n2)
        {
            if (node == null) return null;
            if (n1 == node.Value || n2 == node.Value) return node; // Stop recursion

            var left = FindLcaInBinaryTree(node.Left, n1, n2);
            var right = FindLcaInBinaryTree(node.Right, n1, n2);

            if (left != null && right != null)
                return node; // n1 on one side and n2 on another
            else
                return left ?? right; // one or the other
        }
    }
}