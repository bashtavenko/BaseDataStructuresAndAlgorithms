using System;

namespace Code.Trees
{
    public class TreeUtil<K,V> where K : IComparable
    {
        public static bool IsBstBruteForce(Node<K, V> node)
        {
            if (node == null) return true;
            return IsSubtreeLessBruteForce(node.Left, node.Key) &&
                   IsSubtreeGreaterBruteForce(node.Right, node.Key) &&
                   IsBstBruteForce(node.Left) &&
                   IsBstBruteForce(node.Right);
        }

        public static bool IsBst(Node<K,V> node, K lo, K hi)
        {
            return IsBstHelper(node, lo, hi);
        }

        private static bool IsSubtreeLessBruteForce(Node<K, V> node, K key)
        {
            if (node == null) return true;
            return node.Key.CompareTo(key) < 0 &&
                    IsSubtreeLessBruteForce(node.Left, key) &&
                    IsSubtreeLessBruteForce(node.Right, key);            
        }

        private static bool IsSubtreeGreaterBruteForce(Node<K, V> node, K key)
        {
            if (node == null) return true;
            return node.Key.CompareTo(key) > 0 &&
                    IsSubtreeGreaterBruteForce(node.Left, key) &&
                    IsSubtreeGreaterBruteForce(node.Right, key);
        }

        // this is the right way to do it
        private static bool IsBstHelper(Node<K, V> node, K lo, K hi)
        {
            if (node == null) return true;
            if (node.Key.CompareTo(lo) > 0 && node.Key.CompareTo(hi) < 0)
                return IsBstHelper(node.Left, lo, node.Key) &&
                       IsBstHelper(node.Right, node.Key, hi);
            else
                return false;
        }
    }
}
