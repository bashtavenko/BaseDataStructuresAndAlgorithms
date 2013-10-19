using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Graphs
{
    public class Person
    {
        public int Id { get; set; }
        public List<Person> Friends { get; set; }
        public Person()
        {
            Friends = new List<Person>();
        }
    }

    public class Finder
    {
        private int _n;
        public Finder(int n)
        {
            _n = n;
        }
        public int FindDegree(Person from, int to)
        {
            var marked = new bool[_n];
            var edgeTo = new int[_n];
            var q = new Queue<Person>();
            marked[from.Id] = true;
            q.Enqueue(from);
            while (q.Any())
            {
                var p = q.Dequeue();
                foreach (var f in p.Friends)
                {
                    if (!marked[f.Id])
                    {
                        marked[f.Id] = true;
                        edgeTo[f.Id] = p.Id;
                        q.Enqueue(f);
                    }
                }
            }

            var path = new Stack<int>();
            for (var x = to; x != 0; x = edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(0);
            return path.Count-1;
        }
    }
}
