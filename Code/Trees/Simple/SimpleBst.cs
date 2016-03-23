namespace Code.Trees.Simple
{
    public class SimpleBst
    {
        public static Node LowestCommonAncesstor(Node node, int key1, int key2)
        {
            while (node != null)
            {
                var key = node.Key;

                if (key > key1 && key > key2)
                    node = node.Left;
                else if (key < key1 && key < key2)
                    node = node.Right;
                else
                    return node;
            }
            return null;
        }
    }
}
