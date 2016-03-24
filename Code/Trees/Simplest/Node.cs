namespace Code.Trees.Simplest
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set;  }

        public Node(int value)
        {
            Left = Right = null;
            Value = value;
        }
    }
}
