using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.Graphs;

namespace UnitTests
{
    [TestClass]
    public class FriendsTest
    {
        private Person _root;
        private Finder _finder;
        
        [TestInitialize]
        public void Init()
        {
            _root = new Person
            {
                Id = 0,
                Friends = new List<Person>
                              {
                                  new Person { Id = 1, Friends = new List<Person>
                                        {
                                            new Person { Id = 3},
                                            new Person { Id = 2},
                                            new Person { Id = 4, Friends = new List<Person>{new Person{Id = 5}}}
                                        }
                                  } 
                              }
            };
            _finder = new Finder(6);
        }

        [TestMethod]
        public void Run()
        {
            Assert.AreEqual(1, _finder.FindDegree(_root, 1));
            Assert.AreEqual(2, _finder.FindDegree(_root, 2));
            Assert.AreEqual(2, _finder.FindDegree(_root, 4));
            Assert.AreEqual(3, _finder.FindDegree(_root, 5));
        }
    }
}
