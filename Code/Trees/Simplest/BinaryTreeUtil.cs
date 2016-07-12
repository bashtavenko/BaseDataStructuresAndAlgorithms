using System;
using System.Collections.Generic;

namespace Code.Trees.Simplest
{
    public class BinaryTreeUtil
    {
        public Node FindLcaInBinaryTree(Node node, int n1, int n2)
        {
            if (node == null) return null;
            if (n1 == node.Value || n2 == node.Value) return node; // Stop recursion

            // Since this returns either n1 or n2 node, we need to check both left and right
            var left = FindLcaInBinaryTree(node.Left, n1, n2);
            var right = FindLcaInBinaryTree(node.Right, n1, n2);

            if (left != null && right != null)
                return node; // n1 on one side and n2 on another
            else
                return left ?? right; // one or the other
        }

        public NodeStatus FindLcaInBinaryTreeMoreEfficient(Node node, int n1, int n2)
        {
            if (node == null) return new NodeStatus(0, null);

            var left = FindLcaInBinaryTreeMoreEfficient(node.Left, n1, n2);
            if (left.NumTargetNodes == 2)
                return left; // Don't bother with checking right

            var right = FindLcaInBinaryTreeMoreEfficient(node.Right, n1, n2);
            if (right.NumTargetNodes == 2)
                return right; // Don't bother with computing the sum

            int numTargetNodes = left.NumTargetNodes +
                                 right.NumTargetNodes +
                                 (n1 == node.Value ? 1 : 0) +
                                 (n2 == node.Value ? 1 : 0);
            return new NodeStatus(numTargetNodes, numTargetNodes == 2 ? node : null);
        }


        public class NodeStatus
        {
            public NodeStatus(int numTargetNodes, Node ancestor)
            {
                NumTargetNodes = numTargetNodes;
                Ancestor = ancestor;
            }

            public int NumTargetNodes { get; set; }
            public Node Ancestor { get; set; }
        }


        public bool IsBalanced(Node node)
        {
            return IsBalancedHelper(node).IsBalanced;
        }

        private BalanceCheckResult IsBalancedHelper(Node node)
        {
            if (node == null) return new BalanceCheckResult(true, -1);

            var leftResult = IsBalancedHelper(node.Left);
            if (!leftResult.IsBalanced)
            {
                return leftResult;
            }

            var rightResult = IsBalancedHelper(node.Right);
            if (!rightResult.IsBalanced)
            {
                return rightResult;
            }

            bool isBalanced = Math.Abs(leftResult.Height - rightResult.Height) <= 1;
            int height = Math.Max(leftResult.Height, rightResult.Height) + 1;
            return new BalanceCheckResult(isBalanced, height);
        }

        public static Node FindLcaWithParentNodeExtraStorage(Node root, int n1, int n2)
        { 
            var node1 = FindNode(root, n1);
            var node2 = FindNode(root, n2);
            var firstPath = GetPathToRoot(root, node1);
            var secondPath = GetPathToRoot(root, node2);

            Node lca = null;
            foreach (var key in secondPath)
            {
                if (firstPath.ContainsKey(key.Key))
                {
                    lca = key.Value;
                    break;
                }
            }
            return lca;
        }
        
        public static Node FindLcaWithParentNode(Node root, int n1, int n2)
        {
            var node1 = FindNode(root, n1);
            var node2 = FindNode(root, n2);
            int depth1 = GetNodeDepth(node1);
            int depth2 = GetNodeDepth(node2);

            // Get to the same level of depth on both nodes
            for (int depthDiff = Math.Abs(depth1 - depth2); depthDiff > 0; depthDiff--)
            {
                node1 = node1.Parent;
            }

            // Now go up on both until LCA
            while (node1 != node2)
            {
                node1 = node1.Parent;
                node2 = node2.Parent;
            }

            return node1;
        }

        private static Dictionary<int, Node> GetPathToRoot(Node root, Node node)
        {
            var hashTable = new Dictionary<int, Node>();
            for (Node n = node.Parent; n.Value != root.Value; n = n.Parent)
            {
                hashTable.Add(n.Value, n);
            }
            hashTable.Add(root.Value, root);
            return hashTable;
        }

        public static Node FindNode(Node n, int nodeValue)
        {
            if (n == null) return null;
            if (n.Value == nodeValue) return n;
            return FindNode(n.Left, nodeValue) ?? FindNode(n.Right, nodeValue);
        }

        private static int GetNodeDepth(Node node)
        {
            int depth = 0;
            for (Node n = node.Parent; n != null; n = n.Parent)
            {
                depth++;
            }
            return depth;
        }
    }

    class BalanceCheckResult
    {
        public bool IsBalanced { get; set; }
        public int Height { get; set; }

        public BalanceCheckResult(bool isBalanced, int height)
        {
            IsBalanced = isBalanced;
            Height = height;
        }
    }
}