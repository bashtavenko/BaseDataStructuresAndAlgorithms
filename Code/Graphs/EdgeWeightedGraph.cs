using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Graphs
{
    public class EdgeWeightedGraph
    {
        public int V { get; private set; }
        public int E { get; private set; }
        private List<Edge>[] _adj;

        public EdgeWeightedGraph(int V)
        {
            this.V = V;
            E = 0;

            _adj = new List<Edge>[V];

            for (var vertex = 0; vertex < V; vertex++)
                _adj[vertex] = new List<Edge>();            
        }

        public void AddEdge(Edge e)
        {
            int v = e.Either;
            int w = e.GetOther(v);

            // todo: may need to check dups
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
