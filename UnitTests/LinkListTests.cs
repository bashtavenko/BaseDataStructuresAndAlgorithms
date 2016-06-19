using System.Collections.Generic;
using Code.LinkedListsStacksAndQueues;
using NUnit.Framework;


namespace UnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class LinkListTests
    {
        [Test]
        public void TestQueue()
        {
            var queue = new SimpleQueue();
            queue.Enqueue(1);
            queue.Enqueue(5);
            queue.Enqueue(7);
            Assert.IsTrue(queue.Count == 3);
            int val = queue.Dequeue();
            Assert.IsTrue(val == 1);
            Assert.IsTrue(queue.Count == 2);
        }

        [Test]
        public void TestLinkedList()
        {
            var root = new Node(10);
            LinkedList.Add(root, 20);
            LinkedList.Add(root, 30);
            LinkedList.Add(root, 40);
        }

        [Test]
        public void DeleteNth()
        {
            var node = new Node {Data = 1, Next = new Node { Data = 2, Next = new Node { Data = 3 }}};
        
            // First node
            node = new Node { Data = 1, Next = new Node { Data = 2, Next = new Node { Data = 3 } } };
            var test = LinkedList.DeleteNth(node, 0);
            Assert.AreEqual(2, test.Data);

            // Second node
            node = new Node { Data = 1, Next = new Node { Data = 2, Next = new Node { Data = 3 } } };
            test = LinkedList.DeleteNth(node, 1);
            var count = 0;
            for (var n = test; n != null; n = n.Next, count++)
            {
            }
            Assert.AreEqual(2, count);
        }

        [Test]
        public void Reverse()
        {
            var ll = new LinkedList();
            var node = new Node { Data = 1, Next = new Node { Data = 2, Next = new Node { Data = 3 } } };
            var result = LinkedList.ReverseIteratively(node);

            var i = 0;
            for (var n = result; n != null; n = n.Next, i++)
            {
                switch (i)
                {
                    case 0:
                        Assert.AreEqual(3, n.Data);
                        break;
                    case 1:
                        Assert.AreEqual(2, n.Data);
                        break;
                    case 2:
                        Assert.AreEqual(1, n.Data);
                        break;
                }
            }
        }

        [Test]
        public void Reverse2()
        {
            var ll = new LinkedList();
            var node = new Node { Data = 1, Next = new Node { Data = 2, Next = new Node { Data = 3 } } };
            var result = LinkedList.ReverseRecursively(node);
        }

        [TestCase(new int[] {3, 6, 5}, new int[] { 2, 4, 8 }, new int[] { 6, 1, 3 } )]
        [TestCase(new int[] { 6, 4, 9, 5, 7 }, new int[] { 4, 8 }, new int[] { 6, 5, 0, 0, 5 })]
        public void AddLists(int[] first, int[] second, int[] expected)
        {
            Node l1 = CreateList(first);
            Node l2 = CreateList(second);
            Node result = LinkedList.AddListsIteratively(l1, l2);
            var resultArray = ConvertListToArray(result);
            CollectionAssert.AreEqual(expected, resultArray);

            result = LinkedList.AddLists(l1, l2, 0);
            resultArray = ConvertListToArray(result);
            CollectionAssert.AreEqual(expected, resultArray);
        }

        [TestCase(new int[] { 5, 3, 1 }, new int[] { 4, 2}, new int[] { 5, 4, 3, 2, 1 })]
        public void MergeSortedList(int[] first, int[] second, int[] expected)
        {
            Node l1 = CreateList(first);
            Node l2 = CreateList(second);
            Node result = LinkedList.MergeTwoSortedLinkedLists(l1, l2);
            var resultArray = ConvertListToArray(result);
            CollectionAssert.AreEqual(expected, resultArray);
        }

        [TestCase(new int[] { 4, 3, 2, 1, 0 }, new int[] { 3, 1, 4, 2, 0 })]
        public void ReorderListEvenOddBruteForce(int[] first, int[] expected)
        {
            Node l = CreateList(first);
            Node result = LinkedList.ReorderListEvenOddExtraSpace(l);
            var resultArray = ConvertListToArray(result);
            CollectionAssert.AreEqual(expected, resultArray);
        }

        [TestCase(new int[] { 4, 3, 2, 1, 0 }, new int[] { 3, 1, 4, 2, 0 })]
        public void ReorderListEvenOdd(int[] first, int[] expected)
        {
            Node l = CreateList(first);
            Node result = LinkedList.ReorderListEvenOdd(l);
            var resultArray = ConvertListToArray(result);
            CollectionAssert.AreEqual(expected, resultArray);
        }

        private Node CreateList(int[] numbers)
        {
            Node node = null;
            foreach (var number in numbers)
            {
                node = LinkedList.Add(node, number);
            }
            return node;
        }

        private int[] ConvertListToArray(Node root)
        {
            var resultArray = new List<int>();
            for (Node node = root; node != null; node = node.Next)
            {
                resultArray.Insert(0, node.Data);
            }
            return resultArray.ToArray();
        }

        [TestCase(new int[] { 2, 3, 5, 3, 2 }, true)]
        public void CheckIfListIsPalindromic(int[] list, bool expected)
        {
            Node l = CreateList(list);
            var result = LinkedList.CheckIfPalindromicBruteForce(l);
            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 2, 3, 5, 3, 2 }, 0, 2)]
        [TestCase(new int[] { 2, 3, 5, 3, 2 }, 1, 3)]
        [TestCase(new int[] { 2, 3, 5, 3, 2 }, 2, 5)]
        [TestCase(new int[] { 2, 3, 5, 3, 2 }, 3, 3)]
        [TestCase(new int[] { 2, 3, 5, 3, 2 }, 4, 2)]
        public void FindNthToLastNode(int[] list, int n, int expected)
        {
            Node l = CreateList(list);
            var result = LinkedList.FindNthToLast(l, n);
            Assert.AreEqual(expected, result.Data);
        }
    }
}
