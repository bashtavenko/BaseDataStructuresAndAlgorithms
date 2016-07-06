using System.Collections.Generic;
using System.Linq;
using Code.LinkedListsStacksAndQueues;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class LruCacheTests
    {
        [Test]
        public void LruCacheBasic()
        {
            var cache = new LruCache<int, string>(3);

            cache.Add(0, "A");
            cache.Add(1, "B");
            cache.Add(2, "C");

            var keyList = cache.Items().ToList();
            CollectionAssert.AreEqual(new List<int> {0, 1, 2}, keyList);

            cache.Lookup(2);
            keyList = cache.Items().ToList();
            CollectionAssert.AreEqual(new List<int> { 2, 0, 1 }, keyList);

            cache.Add(3, "D");
            keyList = cache.Items().ToList();
            CollectionAssert.AreEqual(new List<int> { 2, 0, 3 }, keyList);

            string result = cache.Lookup(42);
            Assert.IsNull(result);
        }
    }
}