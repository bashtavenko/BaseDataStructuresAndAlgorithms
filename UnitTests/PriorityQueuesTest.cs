using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Code.PriorityQueues;

namespace UnitTests
{    
    [TestClass]
    public class PriorityQueuesTest
    {
        private List<Transition> _transitions = new List<Transition>
        {
            new Transition{ Src = "Home", Dst= "About", Frequency = 10},
            new Transition{ Src = "Home", Dst= "Products", Frequency = 2},
            new Transition{ Src = "Products", Dst= "Details", Frequency = 1},
            new Transition{ Src = "Home", Dst= "Search", Frequency = 200},
            new Transition{ Src = "Home", Dst= "Services", Frequency = 3},
            new Transition{ Src = "Service", Dst= "Home", Frequency = 25},
        };
        
        [TestMethod]
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

        [TestMethod]
        public void MinPQTest()
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
