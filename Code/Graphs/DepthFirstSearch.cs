using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Graphs
{
    public class DepthFirstSearch
    {
        private readonly bool[] _marked;
        public int EdgeCount { get; private set; }

        public DepthFirstSearch(Graph g, int s)
        {
            _marked = new bool[(g.E)];
            Dfs(g, s);
        }
        
        public void Dfs (Graph g, int v)
        {            
            _marked[v] = true;
            EdgeCount++;
            foreach (var w in g.GetAdjList(v))
            {
                if (!_marked[w]) Dfs(g, w);
            }
        }
        public bool IsMarked(int v)
        {
            return _marked[v];
        }
    }
}
