using System.Collections.Generic;
using System.Linq;

namespace Code.Graphs
{
    public class EdgeWeightedGraph
    {
        public int V { get; private set; }
        public int E { get; private set; }
        private HashSet<Edge>[] _adj;

        public EdgeWeightedGraph(int V)
        {
            this.V = V;
            E = 0;

            _adj = new HashSet<Edge>[V];

            for (var vertex = 0; vertex < V; vertex++)
                _adj[vertex] = new HashSet<Edge>();            
        }

        public void AddEdge(Edge e)
        {
            int v = e.Either;
            int w = e.GetOther(v);

            _adj[v].Add(e);
            _adj[w].Add(e);
            
            E++;
        }

        public IEnumerable<Edge> GetAdjList(int v)
        {
            return _adj[v].AsEnumerable();
        }

        public IEnumerable<Edge> Edges()
        {
            List<Edge> l = new List<Edge>();
            for (int v = 0; v < V; v++)
                foreach (Edge e in GetAdjList(v))
                    if (e.GetOther(v) > v) l.Add(e);

            return l.AsEnumerable();
        }
    }
}
