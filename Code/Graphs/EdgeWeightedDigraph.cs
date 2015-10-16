using System.Collections.Generic;
using System.Linq;

namespace Code.Graphs
{
    public class EdgeWeightedDigraph
    {
        public int V { get; private set; }
        public int E { get; private set; }
        private HashSet<DirectedEdge>[] _adj;

        public EdgeWeightedDigraph(int V)
        {
            this.V = V;
            E = 0;

            _adj = new HashSet<DirectedEdge>[V];

            for (var vertex = 0; vertex < V; vertex++)
                _adj[vertex] = new HashSet<DirectedEdge>();            
        }

        public void AddEdge(DirectedEdge e)
        {
            _adj[e.From].Add(e);
            E++;
        }

        public IEnumerable<DirectedEdge> GetAdjList(int v)
        {
            return _adj[v].AsEnumerable();
        }

        public IEnumerable<DirectedEdge> Edges()
        {
            List<DirectedEdge> l = new List<DirectedEdge>();
            for (int v = 0; v < V; v++)
                foreach (DirectedEdge e in GetAdjList(v))
                    l.Add(e);
            return l.AsEnumerable();
        }
    }
}
