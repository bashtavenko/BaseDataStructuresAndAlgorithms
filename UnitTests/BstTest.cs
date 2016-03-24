using Code.Trees;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BstTest
    {
        [TestMethod]
        public void SmokeTest()
        {
            var bst = new Bst<string, int>();
            bst.Put("S", 8);
            bst.Put("E", 6);
            bst.Put("X", 1);
            bst.Put("A", 2);
            bst.Put("R", 3);
            bst.Put("C", 1); // Values can be duplicated
            bst.Put("H", 2); 
            bst.Put("M", 1);

            Assert.IsTrue(bst.Get("A") == 2);
        }
    }
}
