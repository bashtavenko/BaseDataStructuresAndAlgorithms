using System.Collections.Generic;
using System.Linq;

namespace Code.Graphs
{
    public class Digraph
    {
        public int V { get; private set; }
        public int E { get; private set; }
        private HashSet<int>[] _adj;

        public Digraph(int V)
        {
            this.V = V;
            E = 0;

            _adj = new HashSet<int>[V];

            for (var vertex = 0; vertex < V; vertex++)
                _adj[vertex] = new HashSet<int>();            
        }

        public void AddEdge(int v, int w)
        {
            _adj[v].Add(w);                        
            E++;
        }

        public IEnumerable<int> GetAdjList(int v)
        {
            return _adj[v].AsEnumerable();
        }

        public Digraph Reverse()
        {
            var r = new Digraph(V);
            for (var v = 0; v < V; v++)
                foreach (var w in GetAdjList(v))
                    r.AddEdge(w, v);

            return r;
        }

    }
}
