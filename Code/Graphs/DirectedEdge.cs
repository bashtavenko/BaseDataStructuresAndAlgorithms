using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Graphs
{
    public class DirectedEdge
    {
        public double Weight { get; private set; }
        public int From { get { return _v; } }
        public int To { get { return _w; } }
        private readonly int _v;
        private readonly int _w;        
               
        public DirectedEdge(int v, int w, double weight)
        {
            _v = v;
            _w = w;
            Weight = weight;
        }       
        public override string ToString()
        {
            return string.Format("{0}->{1} {3}", _v, _w, Weight);
        }
    }
}
