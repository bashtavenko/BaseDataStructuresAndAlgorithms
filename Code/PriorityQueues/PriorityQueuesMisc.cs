using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.PriorityQueues
{
    public class PriorityQueuesMisc
    {
        public static List<int> MergeSortedArrays(List<int>[] sortedArrays)
        {
            var pq = new MinPq<ArrayEntry>(15);

            // We need to keep track the index of each element we took from an array
            var heads = new List<int>(); 

            // Add first element from each array to pq
            for (int i = 0; i < sortedArrays.Length; i++)
            {
                pq.Insert(new ArrayEntry(sortedArrays[i][0], i));
                heads.Add(1); // First element
            }

            var result = new List<int>();
            ArrayEntry headEntry;

            // The whole point of having PQ here is to find minium element and its index efficiently, that is O(lg(n)) as opposed to O(n)
            // If we were to merge two arrays, it could simply be if. If number of arrays > 2, we would need linear search twice
            // once to find minimum element and second to find index it came from.
            while ((headEntry = pq.DelMin()) != null)                       // That does the trick 
            {
                result.Add(headEntry.Value);
                List<int> smallestArray = sortedArrays[headEntry.ArrayId]; // Which array it came from?
                int smallestArrayHead = heads[headEntry.ArrayId];          // What was an array index in that array?
                if (smallestArrayHead < smallestArray.Count)               // Is there more in that array? 
                {
                    pq.Insert(new ArrayEntry(smallestArray[smallestArrayHead], headEntry.ArrayId));
                    heads[headEntry.ArrayId]++;                            // Moving to the next element in the array  
                }
            }
            return result;
        }

        // That's it - quick and easy
        public static List<int> FindKSmallestFromStream(IEnumerable<int> input, int k)
        {
            var pq = new MaxPq<int>(k);

            foreach (var i in input)
            {
                pq.Insert(i);

                if (pq.Size == k + 1)
                {
                    pq.DelMax();
                }
            }
            
            return pq.Items.ToList();
        }
    }

    // We need to know not only array value but an array it came from
    class ArrayEntry : IComparable<ArrayEntry>
    {
        public int Value { get; set; }
        public int ArrayId { get; set; }

        public ArrayEntry(int value, int arrayId)
        {
            Value = value;
            ArrayId = arrayId;
        }

        public int CompareTo(ArrayEntry other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}