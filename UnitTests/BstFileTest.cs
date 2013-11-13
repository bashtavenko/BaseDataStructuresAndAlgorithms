using System;
using System.IO;
using Code.Trees.Simple;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
  [TestClass]
  public class BstFileTest
  {
    [TestMethod]
    public void CanSaveBstToFileAndLoad()
    {

      var tree = new Node(10) { Left = new Node(5) { Left = new Node(3), Right = new Node(7) }, Right = new Node(20) };

      using (var sw = new StreamWriter("Bst.txt"))
      {
        BstFile.Save(tree, sw);
      }

      using (var sr = new StreamReader("Bst.txt"))
      {
        Node treeRestored = BstFile.Load(sr);
      }
    }
  }
}
