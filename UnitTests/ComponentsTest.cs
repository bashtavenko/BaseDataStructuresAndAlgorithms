using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.Graphs;

namespace UnitTests
{
    [TestClass]
    public class ComponentsTest
    {
        [TestMethod]
        public void TestComponents()
        {        
            int[,] a = {{0, 1, 1, 0}, {0, 1, 0, 1}, {0, 0, 0, 1}, {0, 0, 0,1}};
            var c = new ConnectedComponentsPixels(a);
            c.FindComponents();
            var result = c.GetComponents();
        }
    }
}
