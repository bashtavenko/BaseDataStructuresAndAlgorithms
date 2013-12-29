using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Graphs
{
    public class Edge : IComparable<Edge>
    {
        private readonly int _v;
        private readonly int _w;        

        public double Weight { get; private set; }
        public int Either { get { return _v; } }
        
        public Edge(int v, int w, double weight)
        {
            _v = v;
            _w = w;
            Weight = weight;
        }

        public int GetOther(int vertex)
        {
            if (vertex == _v) return _w;
            else if (vertex == _w) return _v;
            else throw new ArgumentException("Inconsistent edge");
        }
                
        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }

        public override string ToString()
        {
            return string.Format("%d-%d %.2f", _v, _w, Weight);
        }
    }
}
