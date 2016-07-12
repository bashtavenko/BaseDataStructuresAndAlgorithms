using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Code.Sorts;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class SortTests
    {
        private readonly char[] _a = "SORTEXAMPLE".ToCharArray();
                
        [Test]
        public void SelectionSort()
        {
            var s = new SelectionSort<char>();
            s.Sort(_a);
            Assert.IsTrue(s.IsSorted(_a));
        }

        [Test]
        public void InsertionSort()
        {
            var s = new InsertionSort<char>();
            s.Sort(_a);
            Assert.IsTrue(s.IsSorted(_a));
        }

        [Test]
        public void ShellSort()
        {
            var s = new ShellSort<char>();
            s.Sort(_a);
            Assert.IsTrue(s.IsSorted(_a));
        }

        [Test]
        public void QuickSort()
        {
            var s = new QuickSort<char>();
            s.Sort(_a);
            Assert.IsTrue(s.IsSorted(_a));
        }

        [Test]
        public void MergeSort()
        {
            var s = new MergeSort<char>();
            s.Sort(_a);
            Assert.IsTrue(s.IsSorted(_a));
        }

        [Test]
        public void BinarySearchTest()
        {
            var a = new int[] { 2, 3, 10, 15, 30, 40, 100, 120};
            var result = BinarySearch.Rank(a, 4);

            result = Array.BinarySearch(a, 4);

            var b = new int[] {1, 1, 1, 1, 1, 1};
            result = Array.BinarySearch(b, 2);

            result = BinarySearch.Rank(b, 2);
        }

        [Test]
        public void BinarySearchWithObjects()
        {
            var students = new Student[]
            {
                new Student {Id = 1, FirstName = "Joe", LastName = "Doe"},
                new Student {Id = 3, FirstName = "Washington", LastName = "Irwing"},
                new Student {Id = 7, FirstName = "Indiana", LastName = "Jones"}
            };

            var result = Array.BinarySearch(students, 3, new StudentComparer());
            Assert.AreEqual(1, result);
        }


        [Test]
        public void ArraySort()
        {
            var students = new ComparableStudent[]
            {
                new ComparableStudent { Id = 1, FirstName = "Joe", LastName = "Doe"},
                new ComparableStudent { Id = 3, FirstName = "Washington", LastName = "Irwing"},
                new ComparableStudent { Id = 7, FirstName = "Indiana", LastName = "Jones"}
            };

            Array.Sort(students);
        }

        class Student
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class ComparableStudent : IComparable
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public int CompareTo(object obj)
            {
                var otherStudent = obj as ComparableStudent;
                return Id.CompareTo(otherStudent.Id);
            }
        }

        class StudentComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                var studentX = x as Student;
                var studentY = x as Student;
                if (studentX == null || studentY == null) throw new ArgumentException();
                return studentX.Id.CompareTo(studentY.Id);
            }
        }
        
        [Test]
        public void Partion3Way()
        {
            var anotherInput = "RBWWRWBRRWBR".ToCharArray();
            var s = new QuickSort3Way<char>();
            //s.Sort(anotherInput);
            int lt = 0, gt = 0;
            s.Partition3Way(anotherInput, out lt, out gt);
        }

        [TestCase(new int[] {3, 2, 1, 5, 4}, 1, 5)]
        [TestCase(new int[] { 3, 2, 1, 5, 4 }, 2, 4)]
        [TestCase(new int[] {3, 2, 1, 5, 4}, 3, 3)]
        [TestCase(new int[] {3, 2, 1, 5, 4}, 10, -1)]
        public void FindKthLargest(int[] input, int k, int expected)
        {
            var finder = new KthLargestFinder();
            int result = finder.FindKthLargest(input, k);
            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 3, 2, 1, 5, 4 }, 1, 5)]
        [TestCase(new int[] { 3, 2, 1, 5, 4 }, 2, 4)]
        [TestCase(new int[] { 3, 2, 1, 5, 4 }, 3, 3)]
        [TestCase(new int[] { 3, 2, 1, 5, 4 }, 10, -1)]
        public void FindKthLargestWithMaxHeap(int[] input, int k, int expected)
        {
            var finder = new KthLargestFinder();
            int result = finder.FindKthLargestWithMaxHeap(input, k);
            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 3, 2, 1, 5, 4 }, 1, 5)]
        [TestCase(new int[] { 3, 2, 1, 5, 4 }, 2, 4)]
        [TestCase(new int[] { 3, 2, 1, 5, 4 }, 3, 3)]
        [TestCase(new int[] { 3, 2, 1, 5, 4 }, 10, -1)]
        public void FindKthLargestWithMinHeap(int[] input, int k, int expected)
        {
            var finder = new KthLargestFinder();
            int result = finder.FindKthLargestWithMinHeap(input, k);
            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 3, 2, 1, 5, 4 }, 1, 5)]
        [TestCase(new int[] { 3, 2, 1, 5, 4 }, 2, 4)]
        [TestCase(new int[] { 3, 2, 1, 5, 4 }, 3, 3)]
        [TestCase(new int[] { 3, 2, 1, 5, 4 }, 10, -1)]
        public void FindKthLargestWithMinHeapDeadSimple(int[] input, int k, int expected)
        {
            var finder = new KthLargestFinder();
            int result = finder.FindKthLargestWithMinHeapDeadSimple(input, k);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FindArrayIntersectionBruteForce()
        {
            var a = new int[] {2, 3, 3, 5, 5, 6, 7, 7, 8, 12};
            var b = new int[] { 5, 5, 6, 8, 8, 9, 10, 10 };
            var expected = new int[] { 5, 6, 8 };

            var result = Misc.IntersectTwoArraysBruteForce(a, b);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FindArrayIntersection()
        {
            var a = new int[] { 2, 3, 3, 5, 7, 11 };
            var b = new int[] { 3, 3, 7, 15, 31 };
            var expected = new int[] { 3, 7 };

            var result = Misc.IntersectTwoArrays(a, b);
            Assert.AreEqual(expected, result);
        }
    }
}
