using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Graphs
{
    public class BreadthFirstSearch
    {
        private bool[] _marked;
        private int[] _edgeTo;
        private int _s;

        public BreadthFirstSearch(Graph g, int s)
        {
            _marked = new bool[g.V];
            _edgeTo = new int[g.V];
            _s = s;
            Bfs(g, s);
        }

        private void Bfs(Graph g, int s)
        {
            var queue = new Queue<int>();
            _marked[s] = true;
            queue.Enqueue(s);
            while (queue.Count > 0)
            {
                int v = queue.Dequeue();
                foreach (var w in g.GetAdjList(s))
                {
                    if (!_marked[w])
                    {
                        _marked[w] = true;
                        _edgeTo[w] = v;
                        queue.Enqueue(w);
                    }
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
