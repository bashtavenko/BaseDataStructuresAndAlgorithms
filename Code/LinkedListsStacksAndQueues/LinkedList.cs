using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.LinkedListsStacksAndQueues
{
    public class Node<T> 
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            this.Data = data;            
        }
    }

    public class MyLinkedList<T>
    {
        private Node<T> _first;

        // stack essentially
        public void Add(T item)
        {
            var node = new Node<T>(item);
            node.Next = _first;
            _first = node;
        }

        public void AddToTail(T item)
        {
            var newNode = new Node<T>(item);
            var nodeTmp = _first;
            while (nodeTmp.Next != null)
            {
                nodeTmp = nodeTmp.Next;
            }
            nodeTmp.Next = newNode;
        }

        public void Delete(T item)
        {
            var node = _first;
            while (node.Next != null)
            {
                if (node.Next.Data.Equals(item))
                {
                    node.Next = node.Next.Next;
                }
                node = node.Next;
            }
        }

        public void RemoveDups()
        {
            if (_first == null) return;
            if (_first.Next == null) return;
            var ht = new Dictionary<T, bool>();
            var nextNode = _first.Next;
            while (nextNode != null)
            {
                if (ht.ContainsKey(nextNode.Data))
                {
                    nextNode.Next = nextNode.Next.Next;
                }
                else
                {
                    ht.Add(nextNode.Data, true);
                }
                nextNode = nextNode.Next;
            }
        }

        public void PrintNodes()
        {
            for (Node<T> node = _first; node != null; node = node.Next)
            {
                Console.WriteLine(node.Data);
            }

            // or
            var nodeTmp = _first;
            while (nodeTmp.Next != null)
            {
                nodeTmp = nodeTmp.Next;
            }
        }
        
        private Node<int> AddLists(Node<int> l1, Node<int> l2, int overflow)
        {
            if (l1 == null && l2 == null) return null;
            var value = overflow;
            if (l1 != null)
                value += l1.Data;
            if (l2 != null)
                value += l2.Data;
            var roundedValue = value%10;
            var result = new Node<int>(roundedValue);

            var more = AddLists(l1 == null ? null : l1.Next,
                                l2 == null ? null : l2.Next, overflow);
            result.Next = more;
            return result;
        }

        private Node<int> AddLists(Node<int> l1, Node<int> l2)
        {
            if (l1 == null && l2 == null) return null;

            var node = l1;
            var node2 = l2;
            var overflow = 0;
            var previousNode = new Node<int>(0);
            while (node != null)
            {
                var value = node.Data + node2.Data + overflow;
                var roundedValue = value%10;
                var result = new Node<int>(roundedValue);
                previousNode.Next = result;

                overflow = value > 10 ? 1 : 0;

                node = node.Next;
                node2 = node2.Next;
            }

            return previousNode;
        }

        public static Node<T> ReverseList(Node<T> l)
        {
            if (l == null) return null;
            Node<T> previousNode = null;
            Node<T> tmp = null;

            while (l != null)
            {
                tmp = l.Next;
                l.Next = previousNode;
                previousNode = l;
                l = tmp;
            }
            return previousNode;
        }

        public static Node<T> ReverseListRec(Node<T> l)
        {
            return ReverseList(l, null);
        }

        // doesn't work
        private static Node<T> ReverseList(Node<T> l, Node<T> prev)
        {
            if (l.Next == null)
            {
                // Done
                l.Next = prev;
                return l;
            }
            else
            {
                Node<T> temp = ReverseList(l.Next, l);
                l.Next = prev;
                return temp;
            }
        }

        public static Node<T> FindNthToLast(Node<T> node, int n)
        {
            var i = 0;
            return FindNthToLast(node, n, ref i);
        }

        private static Node<T> FindNthToLast(Node<T> node, int n, ref int count)
        {
            if (node == null) return null; // reached end
            var result = FindNthToLast(node.Next, n, ref count);
            if (count == n)
                result = node;

            count++;
            return result;
        }
    }
}
