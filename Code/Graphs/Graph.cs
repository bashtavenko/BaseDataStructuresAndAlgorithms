using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Graphs
{
    public class Graph
    {
        public int V { get; private set; }
        public int E { get; private set; }
        private List<int>[] _adj;

        public Graph(int V)
        {
            this.V = V;
            E = 0;

            _adj = new List<int>[V];

            for (var vertex = 0; vertex < V; vertex++)
                _adj[vertex] = new List<int>();            
        }

        public void AddEdge(int v, int w)
        {
            var list = _adj[v];
            if (!list.Exists(s => s == w))
                list.Add(w);

            list = _adj[w];
            if (!list.Exists(s => s == v))
                list.Add(v);
            
            E++;
        }

        public IEnumerable<int> GetAdjList(int v)
        {
            return _adj[v].AsEnumerable();
        }
    }
}
