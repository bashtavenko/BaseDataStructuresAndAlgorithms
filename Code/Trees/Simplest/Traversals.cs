using System.Collections.Generic;
using System.Diagnostics;

namespace Code.Trees.Simplest
{
    public class Traversals
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

        public void TraverseInOrderWithoutRecursion(Node root)
        {
            Stack<Node> s = new Stack<Node>();
            Node node = root;

            while (s.Count != 0 || node != null)
            {
                if (node != null)
                {
                    // Going down (left)
                    s.Push(node);
                    node = node.Left;
                }
                else
                {
                    // Going up
                    node = s.Pop();

                    Debug.WriteLine(node.Value); // Current

                    node = node.Right;
                }
            }
        }

        // Delete tree
        public void TraversePostOrder(Node node)
        {
            if (node == null) return;

            TraversePostOrder(node.Left);
            TraversePostOrder(node.Right);
            Debug.WriteLine(node.Value);
        }

        public void TraverseWithBfs(Node node)
        {
            var q = new Queue<Node>();
            q.Enqueue(node);
            while (q.Count > 0)
            {
                var n = q.Dequeue();
                if (n != null)
                {
                    Debug.WriteLine(n.Value);
                    q.Enqueue(n.Left);
                    q.Enqueue(n.Right);
                }
            }
        }
    }
}