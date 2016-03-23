using System.IO;
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
            _root = SimplestBst.Insert(null, 20);
           SimplestBst.Insert(_root, 10);
           SimplestBst.Insert(_root, 30);
           SimplestBst.Insert(_root, 8);
           SimplestBst.Insert(_root, 12);
           SimplestBst.Insert(_root, 25);
           SimplestBst.Insert(_root, 40);
        }

        [TestMethod]
        public void Exists()
        {
            Assert.IsTrue (SimplestBst.Exists(_root, 20));
            Assert.IsTrue (SimplestBst.Exists(_root, 10));
            Assert.IsTrue (SimplestBst.Exists(_root, 30));
            Assert.IsTrue (SimplestBst.Exists(_root, 8));
            Assert.IsTrue (SimplestBst.Exists(_root, 12));
            Assert.IsFalse(SimplestBst.Exists(_root, 42));
            Assert.IsFalse(SimplestBst.Exists(null, 42));
        }
    }
}