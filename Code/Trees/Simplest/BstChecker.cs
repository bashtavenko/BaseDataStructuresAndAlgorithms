using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Code.Trees.Simplest
{
    public class BstChecker
    {
        private Node _prevNode;

        // Other approaches
        // 1. Check key ranges
        // 2. In-order traversal
        // 3. BFS level traversal
        public bool IsBstBruteForce(Node node)
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

        public bool IsBstWithKeyRanges(Node node)
        {
            return CheckRanges(node, int.MinValue, int.MaxValue);
        }

        private bool CheckRanges(Node node, int min, int max)
        {
            if (node == null) return true;
            if (node.Value > max || node.Value < min) return false;

            // Nodes in lower subtree should be less than current node AND nodes in right subtree should be greater than current
            return CheckRanges(node.Left, min, node.Value) && CheckRanges(node.Right, node.Value, max);
        }

        public bool IsBstWithInOrderTraversal(Node node)
        {
            _prevNode = null;
            return CheckWithInOrderTraversal(node);
        }
        
        private bool CheckWithInOrderTraversal(Node node)
        {
            if (node == null) return true;

            if (!CheckWithInOrderTraversal(node.Left)) return false;               // check left
            if (_prevNode != null && node.Value <= _prevNode.Value) return false;  // check current
            _prevNode = node;                                                      // update prev    
            return CheckWithInOrderTraversal(node.Right);                          // check right 
        }

        public bool IsBstWithBfs(Node node)
        {
            var q = new Queue<QueueEntry>();
            q.Enqueue(new QueueEntry(node, int.MinValue, int.MaxValue));
            while (q.Count > 0)
            {
                var n = q.Dequeue();
                if (n.Node != null)
                {
                    if (n.Node.Value < n.Min || n.Node.Value > n.Max) return false;
                    q.Enqueue(new QueueEntry(n.Node.Left, n.Min, n.Node.Value));
                    q.Enqueue(new QueueEntry(n.Node.Right, n.Node.Value, n.Max));
                }
            }
            return true;
        }

        class QueueEntry
        {
            public Node Node { get; private set; }
            public int Min { get; private set; }
            public int Max { get; private set; }

            public QueueEntry(Node node, int min, int max)
            {
                Node = node;
                Min = min;
                Max = max;
            }
        }
    }
}
