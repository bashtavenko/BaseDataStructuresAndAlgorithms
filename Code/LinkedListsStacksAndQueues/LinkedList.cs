using System.Collections.Generic;
using System.Diagnostics;

namespace Code.LinkedListsStacksAndQueues
{
    public class LinkedList
    {
        public static Node Add(Node root, int data)
        {
            Node node = new Node(data);
            node.Next = root;
            return node;
        }

        public static void BasicTraversal (Node root)
        {
            for (Node node = root; node != null; node = node.Next)
            {
                Debug.WriteLine(node.Data);
            }

            // or
            var nodeTmp = root;
            while (nodeTmp != null)
            {
                Debug.WriteLine(nodeTmp.Data);
                nodeTmp = nodeTmp.Next;
            }
        }

        public static Node DeleteNth(Node head, int position)
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

        public static Node ReverseIteratively(Node node)
        {
            Node prev = null;

            while (node != null)
            {
                var origNext = node.Next;   // This is where we're going
                node.Next = prev;           // <- this does the trick
                prev = node;                // This where we've been, save for the next loop
                node = origNext;            // Keep on going
            }
            return prev;
        }

        public static Node ReverseRecursively(Node node)
        {
            return ReverseRecursively(node, null);
        }
        
        private static Node ReverseRecursively(Node node, Node prev)
        {
            if (node == null) return prev;
            
            Node next = node.Next;   // This is where we're going
            node.Next = prev;        // <- this does the trick
            prev = node;             // This where we've been
            node = next;             // Keep on going

            return ReverseRecursively(node, prev);
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

            // Reached the end, either in this stack frame or before
            if (count == n)
                result = node;

            count++;
            return result;
        }

        // Meaning add two numbers reprsented by linked lists (each digit = node)
        // l1 365: 5->6->3              l1 64957: 7->5->9->4->6
        // l2 248: 8->4->2              l2 48:    8->4
        // Result: 613: 3->1->6         Result: 65005: 5->0->0->5->6
        public static Node AddLists(Node l1, Node l2, int carry)
        {
            if (l1 == null && l2 == null) return null;

            var result = new Node();
            var value = carry;

            if (l1 != null)
                value += l1.Data;
            if (l2 != null)
                value += l2.Data;

            result.Data = value % 10;

            var more = AddLists(l1?.Next, l2?.Next, value > 9 ? 1 : 0);
            result.Next = more;
            return result;
        }

        public static Node AddListsIteratively(Node l1, Node l2)
        {
            Node head = null;
            Node prevNode = null;
            int carry = 0;
            while (l1 != null || l2 != null)
            {
                int value = carry;

                if (l1 != null)
                    value += l1.Data;
                if (l2 != null)
                    value += l2.Data;
                
                carry = value > 9 ? 1 : 0;

                var node = new Node(value % 10);
                if (head == null)
                {
                    head = node;
                }
                else
                {
                    prevNode.Next = node;
                }
                prevNode = node;

                l1 = l1?.Next;
                l2 = l2?.Next;
            }
            return head;
        }

        public void RemoveDups(Node root)
        {
            if (root?.Next == null) return;

            var ht = new Dictionary<int, bool>();
            var nextNode = root.Next;
            while (nextNode != null)
            {
                if (ht.ContainsKey(nextNode.Data))
                {
                    nextNode.Next = nextNode.Next.Next; // skip that one
                }
                else
                {
                    ht.Add(nextNode.Data, true);
                }
                nextNode = nextNode.Next;
            }
        }

        // 1 -> 3 -> 5,  2 -> 4
        // 1 -> 2 -> 3 -> 4 -> 5
        public static Node MergeTwoSortedLinkedLists(Node l1, Node l2)
        {
            var head = new Node(0);
            var current = head;
            
            while (l1 != null && l2 != null)
            {
                // Take from whatever list has smallest node
                if (l1.Data <= l2.Data)
                {
                    current.Next = l1;
                    l1 = l1.Next;
                }
                else
                {
                    current.Next = l2;
                    l2 = l2.Next;
                }
                current = current.Next; // Keep building result 
            }
            
            current.Next = l1 ?? l2;
            return head.Next;
        }

        // 0->1->2->3->4
        // 0->2->4->1->3
        public static Node ReorderListEvenOddExtraSpace(Node node)
        {
            var evenHead = new Node(0);
            var oddHead = new Node(0);

            // Pointers to last added element, essentially a queue
            var last = new Node[] { evenHead, oddHead };

            int i = 0;
            for (var n = node; n != null; n = n.Next)
            {
                last[i].Next = new Node(n.Data);
                last[i] = last[i].Next;
                i ^= 1;
            }
            
            last[0].Next = oddHead.Next;
            return evenHead.Next;
        }

        // 0->1->2->3->4
        // 0->2->4->1->3
        public static Node ReorderListEvenOdd(Node node)
        {
            var evenHead = new Node(0);
            var oddHead = new Node(0);

            var last = new Node[] {evenHead, oddHead};

            int i = 0;
            for (var n = node; n != null; n = n.Next)
            {
                last[i].Next = n;
                last[i] = last[i].Next;
                i ^= 1;
            }

            last[1].Next = null; // Cutoff old nodes
            last[0].Next = oddHead.Next;
            return evenHead.Next;
        }

        public static bool CheckIfPalindromicBruteForce(Node list)
        {
            bool result = true;
            int i = 0;
            for (var node = list; node != null; node = node.Next)
            {
                var nthToLast = FindNthToLast(list, i);
                if (node.Data != nthToLast.Data)
                {
                    result = false;
                    break;
                }
                i++;
            }
            return result;
        }
    }
}
