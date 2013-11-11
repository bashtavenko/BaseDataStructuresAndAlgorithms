using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.SkipLists
{
    public class SkipList<T> : ICollection<T>  where T : IComparable<T>
    {
        private readonly Random _rand = new Random();
        private SkipListNode<T> _head = new SkipListNode<T>(default(T), 33);
        private int _levels = 1;        
        
        public void Add(T item)
        {
            int level = PickRandomLevel();
            SkipListNode<T> newNode = new SkipListNode<T>(item, level + 1);
            SkipListNode<T> current = _head;
            for (int i = _levels - 1; i >= 0; i--)
            {
                for (;current.Next[i] != null; current = current.Next[i])
                {
                    if (current.Next[i].Value.CompareTo(item) > 0) break;                    
                }
                if (i <= level)
                {
                    newNode.Next[i] = current.Next[i];                 
                    current.Next[i] = newNode;
                }
            }        
        }

        private int PickRandomLevel()
        {
            int rand = _rand.Next();
            int level = 0;
            // we're using the bit mask of a random integer to determine if the max 
            // level should bump up one or not. 
            // Say the 8 LSB of the int are 00101100. In that case when the 
            // LSB is compared against 1 it tests to 0 and the while loop is never 
            // entered so the level stays the same. That should happen 1/2 of the time.
            // Later if the _levels field is set to 3 and the rand value is 01101111,
            // this time the while loop will run 4 times and on the last iteration will
            // run 4 times creating a node with a skip list height of 4. This should 
            // only happen 1/16 of the time.
            while ((rand & 1) == 1)
            {
                if (level == _levels)
                {
                    _levels++;
                    break;
                }
                rand >>= 1;
                level++;
            }
            return level;
        }

        public bool Contains(T item)
        {
            SkipListNode<T> cur = _head;
            for (int i = _levels - 1; i >= 0; i--)
            {
                while (cur.Next[i] != null)
                {
                    int cmp = cur.Next[i].Value.CompareTo(item);
                    if (cmp > 0)
                    {
                        // the value is too large so go down one level
                        // and take smaller steps
                        break;
                    }
                    if (cmp == 0)
                    {
                        // found it!
                        return true;
                    }
                    cur = cur.Next[i];
                }
            }
            return false;
        }

        public bool Remove(T item)
        {
            SkipListNode<T> cur = _head;
            bool removed = false;
            // walk down each level in the list (make big jumps)
            for (int level = _levels - 1; level >= 0; level--)
            {
                // while we're not at the end of the list
                while (cur.Next[level] != null)
                {
                    // if we found our node
                    if (cur.Next[level].Value.CompareTo(item) == 0)
                    {
                        // remove the node
                        cur.Next[level] = cur.Next[level].Next[level];
                        removed = true;

                        // and go down to the next level (where
                        // we will find our node again if we're
                        // not at the bottom level)
                        break;
                    }
                    // if we went too far then go down a level
                    if (cur.Next[level].Value.CompareTo(item) > 0)
                    {
                        break;
                    }
                    cur = cur.Next[level];
                }
            }
            return removed;
        }

        public void Clear()
        {
            _head = new SkipListNode<T>(default(T), 32 + 1);
        }
        

        public bool IsReadOnly
        {
            get { return false; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            SkipListNode<T> cur = _head.Next[0];
            while (cur != null)
            {
                yield return cur.Value;
                cur = cur.Next[0];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }
    }
}
