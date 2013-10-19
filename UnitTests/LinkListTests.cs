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
        public void TestReverseLinkedList()
        {
            var list = new Node<int>(1)
                           {
                               Next = new Node<int>(5)
                                          {
                                              Next = new Node<int>(7)
                                          }

                           };
            //var result = MyLinkedList<int>.ReverseList(list);
            var result2 = MyLinkedList<int>.ReverseListRec(list);

        }

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
        public void TestNthToLast()
        {
            var list = new Node<int>(1) { Next = new Node<int>(2) { Next = new Node<int>(3) { Data = 3 } } };
            var node = MyLinkedList<int>.FindNthToLast(list, 1);
        }

    }
}
