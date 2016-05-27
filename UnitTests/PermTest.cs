using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.NumbersEtc;
using Code.Strings;

namespace UnitTests
{
    [TestClass]
    public class PermTest
    {
        [TestMethod]
        public void PermTestRun()
        {
            var p = new Permutations();
            p.Run("ABC".ToCharArray());
        }

        [TestMethod]
        public void Perm2TestRun()
        {
            var p = new Permutations2();
            var result = p.Permute("ABC");
        }

        [TestMethod]
      public void CombTestRun()
      {
        var c = new Combinations();
        //c.Run();
        c.Comb("", "abcde", 3);
      }
    }
}
