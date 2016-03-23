namespace Code.Trees.Simplest
{
    public class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Data { get; set;  }

        public Node(int newData)
        {
            Left = Right = null;
            Data = newData;
        }
    }
}
