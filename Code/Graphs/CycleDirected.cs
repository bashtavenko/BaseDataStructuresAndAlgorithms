using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Graphs
{
    public class CycleDirected
    {

        public bool HasCycle { get { return _cycle != null; } }

        private bool[] _marked;
        private Stack<int> _cycle;
        private bool[] _onStack;
        private int[] _edgeTo;
        
        public CycleDirected(Digraph g, int s)
        {
            _marked = new bool[(g.V)];
            _onStack = new bool[g.V];
            _edgeTo = new int[g.V];

            for (var v = 0; v < g.V; v++)
            {
                if (!_marked[v]) Dfs(g, v);
            }
        }
        
        public void Dfs (Digraph g, int v)
        {
            _onStack[v] = true;
            _marked[v] = true;
                        
            foreach (var w in g.GetAdjList(v))
            {
                if (HasCycle)
                    return;
                else if (!_marked[w])
                {
                    _edgeTo[w] = v;
                    Dfs(g, w);
                }
                else if (_onStack[w])
                {
                    _cycle = new Stack<int>();
                    for (var x = v; x != w; x = _edgeTo[x])
                        _cycle.Push(w);

                    _cycle.Push(w);
                    _cycle.Push(v);
                }
            }
            _onStack[v] = false;
        }
        


    }
}
