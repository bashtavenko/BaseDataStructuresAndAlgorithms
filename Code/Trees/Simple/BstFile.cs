using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Trees.Simple
{
  public class BstFile
  {
    public static void Save(Node root, StreamWriter sw)
    {
      if (root != null)
      {        
        sw.WriteLine(root.Key);
        Save(root.Left, sw);
        Save(root.Right, sw);
      }
    }

    public static Node Load(StreamReader sr)
    {
      string nodeString;
      Node root = null;
      while ((nodeString = sr.ReadLine()) != null)
      {
        root = Put (root, Convert.ToInt32(nodeString));
      }
      return root;
    }

    private static Node Put(Node node, int key)
    {      
      if (node == null) return new Node(key);
      if (key < node.Key)
        node.Left = Put(node.Left, key);
      else if (key > node.Key)
        node.Right = Put(node.Right, key);
      return node;
    }
  }
}
