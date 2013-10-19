using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Graphs
{
    public class DepthFirstPath
    {   
        private bool[] _marked;
        private int[] _edgeTo;
        private int _s;

        public DepthFirstPath(Graph g, int s)
        {
            _marked = new bool[(g.E)];
            _s = s;
            Dfs(g, s);
        }
        
        public void Dfs (Graph g, int v)
        {            
            _marked[v] = true;            
            foreach (var w in g.GetAdjList(v))
            {
                if (!_marked[w])
                {
                    _edgeTo[w] = v;
                    Dfs(g, w);
                }
            }
        }
        public bool HasPathTo(int v)
        {
            return _marked[v];
        }

        // 0
        // 1 2 
        // 2 0
        // 3 2
        // 4 3
        // 5 3
        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v)) return null;

            var path = new Stack<int>();
            for (var x = v; x != _s; x = _edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(_s);
            return path.AsEnumerable();
        }
    }
}
