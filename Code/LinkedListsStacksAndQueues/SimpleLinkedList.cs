using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Code.LinkedListsStacksAndQueues
{
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
    }

    public class SimpleLinkedList
    {
        public Node DeleteNth(Node head, int position)
        {
            if (position == 0)
            {
                return head.Next;
            }

            Node node = head;
            int nextPosition = 1;
            while (node.Next != null)
            {
                if (nextPosition == position)
                {
                    node.Next = node.Next.Next;
                    return head;
                }
                node = node.Next;
                nextPosition++;
            }

            return null;
        }

    public Node ReverseIteratively(Node node)
    {
        Node prev = null;

        while (node != null)
        {
            var next = node.Next;   // This is where we're going
            node.Next = prev;       // <- this does the trick
            prev = node;            // This where we've been
            node = next;            // Keep on going
        }
        return prev;
    }

    public Node ReverseRecursively(Node node)
    {
        return ReverseIteratively(node, null);
    }
        
    private Node ReverseIteratively(Node node, Node prev)
    {
        if (node == null) return prev;
            
        Node next = node.Next;   // This is where we're going
        node.Next = prev;        // <- this does the trick
        prev = node;             // This where we've been
        node = next;             // Keep on going

        return ReverseIteratively(node, prev);
    }

        public static Node FindNthToLast(Node node, int n)
        {
            var i = 0;
            return FindNthToLast(node, n, ref i);
        }

        // The reason this and other similar approaches work is that with
        // recursion once we reach the end, stack unwinds and we'll be able
        // count from the end.
        private static Node FindNthToLast(Node node, int n, ref int count)
        {
            if (node == null) return null; // reached end
            var result = FindNthToLast(node.Next, n, ref count);

            // Reach the end, either in this stack frame or before
            if (count == n)
                result = node;

            count++;
            return result;
        }
    }
}
