using Code.Trees.Simplest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class SimplestBstTests
    {
        Node _root;
        SimplestBst _bst;

        [TestInitialize]
        public void TestInit()
        {
            _bst = new SimplestBst();
            _bst.Insert(20);
            _bst.Insert(10);
            _bst.Insert(30);
            _bst.Insert(8);
            _bst.Insert(12);
            _bst.Insert(25);
            _bst.Insert(40);
        }

        [TestMethod]
        public void Exists()
        {
            Assert.IsTrue(_bst.Exists(20));
            Assert.IsTrue(_bst.Exists(10));
            Assert.IsTrue(_bst.Exists(30));
            Assert.IsTrue(_bst.Exists(8));
            Assert.IsTrue(_bst.Exists(12));
            Assert.IsFalse(_bst.Exists(42));
        }

        [TestMethod]
        public void SaveToFile()
        {
            const string fileName = "bst.txt";
            _bst.SaveToFile(fileName);
            SimplestBst newBst = SimplestBst.LoadFromFile(fileName);

            Assert.IsTrue(_bst.Exists(20));
            Assert.IsTrue(_bst.Exists(10));
            Assert.IsTrue(_bst.Exists(30));
            Assert.IsTrue(_bst.Exists(8));
            Assert.IsTrue(_bst.Exists(12));
            Assert.IsFalse(_bst.Exists(42));
        }
    }
}