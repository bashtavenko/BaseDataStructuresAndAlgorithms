using Code.Trees.Simplest;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class SimplestBstTests
    {
        private SimplestBst _bst;
        private Node _binaryTree;

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

            _binaryTree = CreateBinaryTree();
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
            var checker = new BstChecker();
            Assert.IsTrue(checker.IsBstBruteForce(_bst.Root));
            Assert.IsFalse(checker.IsBstBruteForce(_binaryTree));
        }

        [Test]
        public void IsBstWithRanges()
        {
            var checker = new BstChecker();
            Assert.IsTrue(checker.IsBstWithKeyRanges(_bst.Root));
            Assert.IsFalse(checker.IsBstWithKeyRanges(_binaryTree));
        }

        [Test]
        public void IsBstWithInOrderTraversal()
        {
            var checker = new BstChecker();
            Assert.IsTrue(checker.IsBstWithInOrderTraversal(_bst.Root));
            Assert.IsFalse(checker.IsBstWithInOrderTraversal(_binaryTree));
        }

        [Test]
        public void IsBstWithBfs()
        {
            var checker = new BstChecker();
            Assert.IsTrue(checker.IsBstWithBfs(_bst.Root));
            Assert.IsFalse(checker.IsBstWithBfs(_binaryTree));
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

        [TestCase(8, 12, 10)]
        [TestCase(8, 25, 20)]
        [TestCase(10, 30, 20)]
        [TestCase(10, 12, 10)]
        public void FindLcaInBstIterative(int n1, int n2, int lca)
        {
            var result = new TreeUtil().FindLcaInBstIterative(_bst.Root, n1, n2);
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
            var result = new BinaryTreeUtil().FindLcaInBinaryTree(binaryTree, n1, n2);
            Assert.AreEqual(lca, result.Value);

            var nodeResult = new BinaryTreeUtil().FindLcaInBinaryTreeMoreEfficient(binaryTree, n1, n2);
            Assert.AreEqual(lca, nodeResult.Ancestor.Value);
        }

        
        [TestCase(4, 5, 3)]
        [TestCase(3, 2, 0)]
        [TestCase(1, 2, 0)]
        [TestCase(4, 2, 0)]
        [TestCase(5, 2, 0)]
        public void FindLcaWithParents(int n1, int n2, int lca)
        {
            var tree = CreateBinaryTree();
            var result = BinaryTreeUtil.FindLcaWithParentNodeExtraStorage(tree, n1, n2);
            Assert.AreEqual(result.Value, lca);

            result = BinaryTreeUtil.FindLcaWithParentNode(tree, n1, n2);
            Assert.AreEqual(result.Value, lca);
        }

        [TestCase(4, true)]
        [TestCase(5, true)]
        [TestCase(3, true)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        [TestCase(0, true)]
        [TestCase(10, false)]
        public void FindNode(int n, bool expected)
        {
            var tree = CreateBinaryTree();
            var result = BinaryTreeUtil.FindNode(tree, n);
            Assert.AreEqual(result != null, expected);
        }

        [Test]
        public void TraverseWithBfs()
        {
            var t = new Traversals();
            t.TraverseWithBfs(_bst.Root);
        }

        [TestCase(8, 10)]
        [TestCase(10, 12)]
        [TestCase(12, 20)]
        [TestCase(25, 30)]
        [TestCase(50, null)]
        public void FindFirstGeaterThan(int k, int? expected)
        {
            var result = TreeUtil.FindFirstGreaterThan(_bst.Root, k);
            Assert.AreEqual(expected, result?.Value);
        }

        [TestCase(2, 30)]
        [TestCase(1, 40)]
        [TestCase(3, 25)]
        [TestCase(4, 20)]
        [TestCase(10, null)]
        public void FindKthLargest(int k, int? expected)
        {
            var result = new TreeUtil().FindKthLargestInOrder(_bst.Root, k);
            Assert.AreEqual(expected, result?.Value);
        }

        [TestCase(2, 30)]
        [TestCase(1, 40)]
        [TestCase(3, 25)]
        [TestCase(4, 20)]
        [TestCase(10, null)]
        public void FindKthLargest2(int k, int? expected)
        {
            var result = new TreeUtil().FindKthLargestReverseInOrder(_bst.Root, k);
            Assert.AreEqual(expected, result?.Value);
        }


        //             0
        //          1     2
        //       3   
        //    5     4
        private Node CreateBinaryTree()
        {
            var four = new Node(4);
            var five = new Node(5);
            var three = new Node(3) { Left = five, Right = four };
            four.Parent = three;
            five.Parent = three;
            var one = new Node(1) { Left = three };
            three.Parent = one;
            var two = new Node(2);
            var root = new Node(0) { Left = one, Right = two };
            one.Parent = root;
            two.Parent = root;
            return root;
        }
    }
}