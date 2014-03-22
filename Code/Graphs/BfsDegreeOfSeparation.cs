using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Graphs
{
    public class BfsDegreeOfSeparation
    {
        private bool[] _marked;
        private int[] _edgeTo;
        private int[] _distTo;
        private int _s;
        
        public BfsDegreeOfSeparation(Graph g, int s)
        {
            _marked = new bool[g.V];
            _edgeTo = new int[g.V];
            _distTo = new int[g.V];
            _s = s;
            Bfs(g, s);
        }

        private void Bfs(Graph g, int s)
        {
            var queue = new Queue<int>();
            for (int v = 0; v < g.V; g++) _distTo[v] = int.MaxValue;
            _marked[s] = true;
            _distTo[s] = 0;
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
                        _distTo[w] = _distTo[0] + 1;
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

        public int GetDistance(int v)
        {
            return _distTo[v];
        }
    }
}
