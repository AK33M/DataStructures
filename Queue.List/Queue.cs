using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.List
{
    public class Queue<T> : IEnumerable<T>
    {
        LinkedList<T> _items = new LinkedList<T>();


        public void Enqueue(T item)
        {
            _items.AddLast(item);
        }

        public T Dequeue()
        {
            if(_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            T value = _items.First.Value;

            _items.RemoveFirst();

            return value;
        }

        public T Peek()
        {
            if(_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            return _items.First.Value;
        }

        public int Count()
        {
            return _items.Count();
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
