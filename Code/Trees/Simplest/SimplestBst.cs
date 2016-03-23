namespace Code.Trees.Simplest
{
    public class SimplestBst
    {
        public static Node Insert(Node node, int data)
        {
            if (node == null)
            {
                return new Node(data);
            }
            if (data < node.Data)
            {
                node.Left = Insert(node.Left, data);
            }
            else if (data > node.Data)
            {
                node.Right = Insert(node.Right, data);
            }
            else
            {
                node.Data = data;
            }
            return node;
        }

        public static bool Exists(Node root, int data)
        {
            if (root == null)
            {
                return false;
            }
            if (data < root.Data)
            {
                return Exists(root.Left, data);
            }
            else if (data > root.Data)
            {
                return Exists(root.Right, data);
            }
            else
            {
                return true;
            }
        }
    }
}