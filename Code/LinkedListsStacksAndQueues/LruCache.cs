using System.Collections.Generic;
using System.Linq;

namespace Code.LinkedListsStacksAndQueues
{
    // Due to lack of LinkedHashMap in .net
    // OrderedDictionary is NOT what we need
    public class LruCache<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _hashTable;
        private readonly LinkedList<TKey> _linkedList;
        private readonly int _capacity;

        public LruCache(int capacity)
        {
            _capacity = capacity;
            _hashTable = new Dictionary<TKey, TValue>();
            _linkedList = new LinkedList<TKey>();
        }

        public TValue Lookup(TKey key)
        {
            if (!_hashTable.ContainsKey(key))
            {
                return default(TValue);
            }

            _linkedList.Remove(key);
            _linkedList.AddFirst(key);
            return _hashTable[key];
        }

        public void Add(TKey key, TValue value)
        {
            while (_linkedList.Count + 1 > _capacity)
            {
                TKey keyToDelete = _linkedList.Last.Value;
                _linkedList.RemoveLast();
                _hashTable.Remove(keyToDelete);
            }
            _hashTable.Add(key, value);
            _linkedList.AddLast(key);
        }

        public IEnumerable<TKey> Items()
        {
            return _linkedList.AsEnumerable();
        }
    }
}
