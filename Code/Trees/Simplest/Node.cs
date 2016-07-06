namespace Code.Trees.Simplest
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set;  }

        // Some trees can have one
        public Node Parent { get; set; }

        public Node(int value)
        {
            Left = Right = null;
            Value = value;
        }
    }
}
