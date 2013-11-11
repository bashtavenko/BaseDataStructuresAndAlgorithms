using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.Trees;

namespace UnitTests
{
    [TestClass]
    public class TreeTest
    {
        [TestMethod]
        public void IsBst()
        {
            var bst = new Node<int, string>(10)
            {
                Left = new Node<int, string>(5),
                Right = new Node<int, string>(15)
                    {
                        Left = new Node<int, string>(13),
                        Right = new Node<int, string>(25)
                    }
            };

            var nonBst = new Node<int, string>(10)
            {
                Left = new Node<int, string>(5),
                Right = new Node<int, string>(15)
                {
                    Left = new Node<int, string>(5),
                    Right = new Node<int, string>(25)
                }
            };

            Assert.IsTrue(TreeUtil<int, string>.IsBstBruteForce(bst));
            Assert.IsFalse(TreeUtil<int, string>.IsBstBruteForce(nonBst));

            Assert.IsTrue(TreeUtil<int, string>.IsBst(bst, int.MinValue, int.MaxValue));
            Assert.IsFalse(TreeUtil<int, string>.IsBst(nonBst, int.MinValue, int.MaxValue));
        }
    }
}
