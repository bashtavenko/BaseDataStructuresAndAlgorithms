using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.LinkedListsStacksAndQueues;


namespace UnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class LinkListTests
    {
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
            
        [TestMethod]
        public void TestQueue()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(5);
            queue.Enqueue(7);
            Assert.IsTrue(queue.Count == 3);
            int val = queue.Dequeue();
            Assert.IsTrue(val == 1);
            Assert.IsTrue(queue.Count == 2);
        }

        [TestMethod]
        public void TestLinkedList()
        {
            var list = new MyLinkedList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);
        }

        [TestMethod]
        public void DeleteNth()
        {
            var ll = new SimpleLinkedList();
            var node = new Node {Data = 1, Next = new Node { Data = 2, Next = new Node { Data = 3 }}};
        
            // First node
            node = new Node { Data = 1, Next = new Node { Data = 2, Next = new Node { Data = 3 } } };
            var test = ll.DeleteNth(node, 0);
            Assert.AreEqual(2, test.Data);

            // Second node
            node = new Node { Data = 1, Next = new Node { Data = 2, Next = new Node { Data = 3 } } };
            test = ll.DeleteNth(node, 1);
            var count = 0;
            for (var n = test; n != null; n = n.Next, count++)
            {
            }
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void Reverse()
        {
            var ll = new SimpleLinkedList();
            var node = new Node { Data = 1, Next = new Node { Data = 2, Next = new Node { Data = 3 } } };
            var result = ll.ReverseIteratively(node);

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

        [TestMethod]
        public void Reverse2()
        {
            var ll = new SimpleLinkedList();
            var node = new Node { Data = 1, Next = new Node { Data = 2, Next = new Node { Data = 3 } } };
            var result = ll.ReverseRecursively(node);
        }
    }
}
