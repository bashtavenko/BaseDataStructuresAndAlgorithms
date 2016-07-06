namespace Code.Graphs
{
    // This is for undirected graph
    public class CycleUndirected
    {
        private readonly bool[] _marked;
        private bool _hasCycle;

        public CycleUndirected(Graph g)
        {
            _marked = new bool[g.V];
            for (var s = 0; s < g.V; s++)
            {
                if (!_marked[s])
                    Dfs(g, s, s);
            }
        }

        public bool HasCycle => _hasCycle;
        
        private void Dfs (Graph g, int v, int u)
        {
            _marked[v] = true;
            foreach (var w in g.GetAdjList(v))
            {
                if (!_marked[w])
                    Dfs(g, w, v);
                else if (w != u) // Just to avoid hitting source vertext u == s
                    _hasCycle = true; 
            }
        }
    }
}
