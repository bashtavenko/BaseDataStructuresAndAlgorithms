using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code.Strings;

namespace UnitTests
{
    [TestClass]
    public class PermTest
    {
        [TestMethod]
        public void PermWithBacktracking()
        {
            var p = new PermutationsWithBacktracking();
            p.Run("ABC".ToCharArray());
        }

        [TestMethod]
        public void Permutations()
        {
            var p = new Permutations();
            var result = p.Run("ABC");
        }
    }
}
