using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.LinkedListsStacksAndQueues
{
  public class QueueWithTwoStacks<T>
  {
    private Stack<T> _inbound;
    private Stack<T> _outbound;

    public QueueWithTwoStacks()
    {
      _inbound = new Stack<T>();
      _outbound = new Stack<T>();
    }

    public void Enqueue(T item)
    {
      _inbound.Push(item);
    }

    public T Dequeue()
    {
      if (_outbound.Count == 0)
      {
        while (_inbound.Count > 0)
        {
          _outbound.Push(_inbound.Pop());
        }
      }
      return _outbound.Pop();
    }
  }
}
