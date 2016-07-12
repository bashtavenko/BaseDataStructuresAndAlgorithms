using System;
using System.Collections.Generic;
using System.Linq;
using Code.PriorityQueues;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class PriorityQueuesTest
    {
        private readonly List<Transition> _transitions = new List<Transition>
        {
            new Transition {Src = "Home", Dst = "About", Frequency = 10},
            new Transition {Src = "Home", Dst = "Products", Frequency = 2},
            new Transition {Src = "Products", Dst = "Details", Frequency = 1},
            new Transition {Src = "Home", Dst = "Search", Frequency = 200},
            new Transition {Src = "Home", Dst = "Services", Frequency = 3},
            new Transition {Src = "Service", Dst = "Home", Frequency = 25},
        };

        [Test]
        public void MaxPQTest()
        {
            const int size = 3;
            var pq = new MaxPq<Transition>(size);
            foreach (var tran in _transitions)
            {
                pq.Insert(tran);
                if (pq.Size > size)
                    pq.DelMax();
            }

            var stack = new Stack<Transition>();
            while (pq.Size > 0)
            {
                stack.Push(pq.DelMax());
            }
        }

        [Test]
        public void MinPqTest()
        {
            const int size = 3;
            var pq = new MinPq<Transition>(size);
            foreach (var tran in _transitions)
            {
                pq.Insert(tran);
                if (pq.Size > size)
                    pq.DelMin();
            }

            var stack = new Stack<Transition>();
            while (pq.Size > 0)
            {
                stack.Push(pq.DelMin());
            }
        }

        [Test]
        public void MergeSortedArrays()
        {
            var input = new List<int>[]
            {
                new List<int> {3, 5, 7},
                new List<int> {0, 6},
                new List<int> {0, 6, 28},
            };

            var expected = new List<int> {0, 0, 3, 5, 6, 6, 7, 28};
            var result = PriorityQueuesMisc.MergeSortedArrays(input);
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void RawPriorityQueueTest()
        {
            var pq = new MinPq<int>(10);
            pq.Insert(5);
            pq.Insert(1);
            pq.Insert(9);
            pq.Insert(7);

            var min = pq.DelMin();

            Assert.AreEqual(1, min);
        }

        [TestCase(new int[] {3, 0, 2, 10, 12, 20, 9, 50, 3}, 2, new int[] {0, 2})]
        [TestCase(new int[] {3, 0, 2, 10, 12, 20, 9, 50, 3}, 3, new int[] {0, 2, 3})]
        public void FindKSmallestFromStream(int[] input, int k, int[] expected)
        {
            var result = PriorityQueuesMisc.FindKSmallestFromStream(input.AsEnumerable(), k);
            CollectionAssert.AreEquivalent(expected, result);
        }
    }

    class Transition : IComparable<Transition>
    {
        public string Src { get; set; }
        public string Dst { get; set; }
        public int Frequency { get; set; }
        
        public int CompareTo(Transition other)
        {
            return Frequency.CompareTo(other.Frequency);
        }
    }
}
