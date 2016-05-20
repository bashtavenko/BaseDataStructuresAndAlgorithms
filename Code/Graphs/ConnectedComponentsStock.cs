namespace Code.Graphs
{
    public class ConnectedComponentsStock
    {
        private readonly bool[] _marked;

        // Each component has id. If all components are connected, they all have id of 0. If there are
        // two groups of components, there will be ids of 0 and 1.
        private int[] _id;
        private int _count;

        public ConnectedComponentsStock(Graph g, int s)
        {
            _marked = new bool[(g.V)];
            _id = new int[g.V];
            for (var x = 0; x < g.V; x++)
            {
                if (!_marked[x])
                {
                    Dfs(g, x);
                    _count++;
                }
            }
        }

        public void Dfs(Graph g, int v)
        {
            _marked[v] = true;
            _id[v] = _count;
            foreach (var w in g.GetAdjList(v))
            {
                if (!_marked[w]) Dfs(g, w);
            }
        }
    }
}