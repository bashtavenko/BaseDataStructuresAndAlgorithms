using System;
using System.IO;

namespace Code.Trees.Simplest
{
    public class SimplestBst
    {
        public Node Root => _root;

        private Node _root;

        public void Insert(int value)
        {
            _root = Insert(_root, value);
        }

        public bool Exists(int value)
        {
            return Exists(_root, value);
        }

        public void SaveToFile(string filePath)
        {
            using (var sw = new StreamWriter(filePath))
            {
                SaveToFile(_root, sw);
            }
        }

        public static SimplestBst LoadFromFile(string filePath)
        {
            var bstToReturn = new SimplestBst();

            using (var sr = new StreamReader(filePath))
            {
                string nodeString;
                while ((nodeString = sr.ReadLine()) != null)
                {
                    bstToReturn.Insert(Convert.ToInt32(nodeString));
                }
            }
            return bstToReturn;
        }

        ///        20
        ///   10         30
        /// 8    12   25     40
        /// 
        /// 20, 10, 8, 12, 30, 25, 40 kind of like DFS 
        private void SaveToFile(Node node, StreamWriter sw)
        {
            if (node != null)
            {
                // Pre-order traversal
                sw.WriteLine(node.Value);
                SaveToFile(node.Left, sw);
                SaveToFile(node.Right, sw);
            }
        }

        private Node Insert(Node node, int value)
        {
            if (node == null)
            {
                return new Node(value);
            }
            if (value < node.Value)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = Insert(node.Right, value);
            }
            else
            {
                // We're not supposed to update BST
            }
            return node;
        }

        private bool Exists(Node root, int data)
        {
            if (root == null)
            {
                return false;
            }

            if (data == root.Value)
            {
                return true;
            }

            return data < root.Value ? Exists(root.Left, data) : Exists(root.Right, data);
        }
    }
}