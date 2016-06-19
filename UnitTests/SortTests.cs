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

    }
}
