using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code.Strings
{
    public class Trie<T>
    {
        private const int _R = 256;
        private Node<T> _root;

        private class Node<T>
        {   
            public T Val;
            public Node<T>[] Next = new Node<T>[_R];
        }

        public IEnumerable<string> Keys
        {
            get { return KeysWithPrefix(""); }
        }

        public T Get (string key)
        {
            Node<T> x = Get(_root, key, 0);
            return x != null ? x.Val : default(T);
        }

        public void Put(string key, T val)
        {
            _root = Put(_root, key, val, 0);
        }

        public IEnumerable<string>  KeysWithPrefix(string pre)
        {
            var q = new List<string>();
            Collect(Get(_root, pre, 0), pre, q);
            return q.AsEnumerable();
        }

        private void Collect(Node<T> x, string pre, List<string> l)
        {
            int d = pre.Length;
            if (x == null) return;
            if (x.Val.Equals(default(T))) l.Add(pre);
            for (var c = (char)0; c < _R; c++)
                Collect(x.Next[c], pre + c, l);
        }

        private Node<T> Get(Node<T> x, string key, int d)
        {
            if (x == null) return null;
            if (d == key.Length) return x; // value is stored at the end of the key
            char c = key[d];
            return Get(x.Next[c], key, d + 1);
        }

        private Node<T> Put(Node<T> x, string key, T val, int d)
        {
            if (x == null) x = new Node<T>();
            if (d == key.Length) //end of key?
            {
                x.Val = val;
                return x;
            }
            char c = key[d];
            x.Next[c] = Put(x.Next[c], key, val, d + 1);
            return x;
        }
    }
}
