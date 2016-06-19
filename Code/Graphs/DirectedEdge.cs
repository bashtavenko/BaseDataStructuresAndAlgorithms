namespace Code.Graphs
{
    public class DirectedEdge
    {
        public double Weight { get; }
        public int From { get; }
        public int To { get; }

        public DirectedEdge(int v, int w, double weight)
        {
            From = v;
            To = w;
            Weight = weight;
        }       
        public override string ToString()
        {
            return $"{From}->{To}";
        }
    }
}
