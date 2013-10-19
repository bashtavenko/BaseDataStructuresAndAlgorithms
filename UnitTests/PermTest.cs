using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.NumbersEtc;

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
    }
}
