using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.LinkedListsStacksAndQueues
{
  public class QueueWithOneStack<T>
  {
    private readonly Stack<T> _stack;

    public QueueWithOneStack()
    {
      _stack = new Stack<T>();
    }

    public void Enqueue(T item)
    {
      _stack.Push(item);
    }

    public T Dequeue()
    {
      T x, res;

      if (_stack.Count == 1)
        return _stack.Pop();
      else
      {
        x = _stack.Pop();
        res = Dequeue();
        _stack.Push(x);
        return res;
      }
    }    
  }
}
