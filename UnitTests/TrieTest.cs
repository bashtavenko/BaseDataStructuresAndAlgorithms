using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Code.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TrieTest
    {
        [TestMethod]
        public void TriePut()
        {
            var t = new Trie<int>();
            t.Put("by", 4);
            t.Put("sea", 2);
            t.Put("sells", 1);
            t.Put("shells", 3);
            t.Put("the", 5);

            Assert.AreEqual(3, t.Get("shells"));
            Assert.AreEqual(default(int), t.Get("abc"));
            var keyList = t.Keys.ToList();
            
            keyList = t.KeysWithPrefix("sh").ToList();
        }
    }
}
