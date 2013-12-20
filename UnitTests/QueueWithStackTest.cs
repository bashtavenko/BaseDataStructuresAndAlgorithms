using System;
using Code.LinkedListsStacksAndQueues;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
  [TestClass]
  public class QueueWithStackTest
  {
    [TestMethod]
    public void QueueWithStack()
    {
      var q = new QueueWithOneStack<int>();
      q.Enqueue(10);
      q.Enqueue(20);
      q.Enqueue(30);

      Assert.AreEqual(10, q.Dequeue());
      Assert.AreEqual(20, q.Dequeue());
      Assert.AreEqual(30, q.Dequeue());
    }
  }
}
