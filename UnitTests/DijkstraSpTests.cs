using System.Runtime.CompilerServices;
using Code.Graphs;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class DijkstraSpTests
    {
        [Test]
        public void FindShortestPath()
        {
            // Arrange (graph from THE book
            var g = new EdgeWeightedDigraph(8);
            g.AddEdge(new DirectedEdge(0, 1, 5));
            g.AddEdge(new DirectedEdge(0, 4, 9));
            g.AddEdge(new DirectedEdge(0, 7, 8));
            g.AddEdge(new DirectedEdge(1, 2, 12));
            g.AddEdge(new DirectedEdge(1, 3, 15));
            g.AddEdge(new DirectedEdge(1, 7, 4));
            g.AddEdge(new DirectedEdge(2, 3, 3));
            g.AddEdge(new DirectedEdge(2, 6, 11));
            g.AddEdge(new DirectedEdge(3, 6, 9));
            g.AddEdge(new DirectedEdge(4, 5, 4));
            g.AddEdge(new DirectedEdge(4, 6, 20));
            g.AddEdge(new DirectedEdge(4, 7, 5));
            g.AddEdge(new DirectedEdge(5, 2, 1));
            g.AddEdge(new DirectedEdge(5, 6, 13));
            g.AddEdge(new DirectedEdge(7, 5, 6));
            g.AddEdge(new DirectedEdge(7, 2, 7));

            // Act
            var d = new DijkstraSp(g, 0);

            // Assert
            var expectedDistance = new double[] { 0.0, 5.0, 14.0, 17.0, 9.0, 13.0, 25.0, 8.0};
            CollectionAssert.AreEqual(expectedDistance, d.DistTo);

            var expectedEdges = new string[] {null, "0->1", "5->2", "2->3", "0->4", "4->5", "2->6", "0->7"};
            CollectionAssert.AreEqual(expectedEdges, d.EdgeTo);
        }
    }
}