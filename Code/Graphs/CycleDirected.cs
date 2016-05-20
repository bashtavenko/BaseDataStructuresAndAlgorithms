using System.Collections.Generic;

namespace Code.Graphs
{
    public class CycleDirected
    {
        public bool HasCycle => _cycle != null;

        private readonly bool[] _marked;
        private Stack<int> _cycle;
        private readonly bool[] _onStack;
        private readonly int[] _edgeTo;
        
        public CycleDirected(Digraph g, int s)
        {
            _marked = new bool[(g.V)];
            _onStack = new bool[g.V];
            _edgeTo = new int[g.V];

            for (var v = 0; v < g.V; v++)
            {
                if (!_marked[v])
                    Dfs(g, v);
            }
        }
        
        public void Dfs (Digraph g, int v)
        {
            _onStack[v] = true;
            _marked[v] = true;
                        
            foreach (var w in g.GetAdjList(v))
            {
                if (!_marked[w])
                {
                    _edgeTo[w] = v;
                    Dfs(g, w);
                }
                // Similar to undirected, but the reason for having _onStack is that
                // we need to distinguish cross-edges from back edges plus it gets reset on each Dfs call
                // https://courses.csail.mit.edu/6.006/fall11/rec/rec14.pdf
                // In digraph it is possible to come to already visited node but
                // not have a cycle
                // Example: 4 hit twice, 3 -> 4 is cross edge which is ok, no cycle here
                // 1 -> 2 -> 4
                // 1 -> 3 -> 4
                // In contrast
                // 1 -> 2 -> 3 -> 1 IS a cycle because 3 -> 1 is back edge
                else if (_onStack[w]) 
                {
                    _cycle = new Stack<int>();
                    for (var x = v; x != w; x = _edgeTo[x])
                        _cycle.Push(w);

                    _cycle.Push(w);
                    _cycle.Push(v);
                    return;
                }
            }
            _onStack[v] = false;
        }
    }
}
