using Code.Trees.Simplest;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;


namespace UnitTests
{
    [TestFixture]
    public class SimplestBstTests
    {
        private SimplestBst _bst;

        [OneTimeSetUp]
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

        [Test]
        public void Exists()
        {
            Assert.IsTrue(_bst.Exists(20));
            Assert.IsTrue(_bst.Exists(10));
            Assert.IsTrue(_bst.Exists(30));
            Assert.IsTrue(_bst.Exists(8));
            Assert.IsTrue(_bst.Exists(12));
            Assert.IsFalse(_bst.Exists(42));
        }

        [Test]
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

        [Test]
        public void IsBst()
        {
            var treeUtil = new TreeUtil();
            Assert.IsTrue(treeUtil.IsBst(_bst.Root));

            var binaryTree = new Node(10);
            binaryTree.Left = new Node(5);
            binaryTree.Right = new Node(15) {Left = new Node(6), Right = new Node(20)};
            Assert.IsFalse(treeUtil.IsBst(binaryTree));
        }

        [TestCase(8, 12, 10)]
        [TestCase(8, 25, 20)]
        [TestCase(10, 30, 20)]
        [TestCase(10, 12, 10)]
        public void FindLcaInBst(int n1, int n2, int lca)
        {
            var result = new TreeUtil().FindLcaInBst(_bst.Root, n1, n2);
            Assert.AreEqual(lca, result.Value);
        }

        [TestCase(4, 5, 2)]
        [TestCase(4, 6, 1)]
        [TestCase(3, 4, 1)]
        [TestCase(2, 4, 2)]
        public void FindLcaInBinaryTree(int n1, int n2, int lca)
        {
            var left = new Node (2) {Left = new Node(4), Right = new Node(5)};
            var right = new Node (3) {Left = new Node(6), Right = new Node(7)};
            var binaryTree = new Node(1) {Left = left, Right = right};
            var result = new TreeUtil().FindLcaInBinaryTree(binaryTree, n1, n2);
            Assert.AreEqual(lca, result.Value);
        }
    }
}