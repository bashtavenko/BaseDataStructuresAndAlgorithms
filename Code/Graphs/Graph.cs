using System.Collections.Generic;
using System.Linq;

namespace Code.Graphs
{
    public class Graph
    {
        public int V { get; private set; }
        public int E { get; private set; }
        private HashSet<int>[] _adj;

        public Graph(int V)
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
            _adj[w].Add(v);
                      
            E++;
        }

        public IEnumerable<int> GetAdjList(int v)
        {
            return _adj[v].AsEnumerable();
        }
    }
}
