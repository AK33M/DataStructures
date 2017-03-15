using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Priority
{
    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        LinkedList<T> _items = new LinkedList<T>();

        public void Enqueue(T item)
        {
            //if the list is empty, just add the item
            if (_items.Count == 0)
            {
                _items.AddLast(item);
            }
            else
            {
                //find the proper insert point
                var current = _items.First;

                //while we are not at the end of the list and the current value
                // is larger than the value being inserted (higher priority?!)..
                //i.e is current more important than item? if yes carry on, NEXT!
                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }

                if (current == null)
                {
                    // we made it to the end of the list without finding a higher priority
                    _items.AddLast(item);
                }
                else
                {
                    //the current item is <= the one being added
                    //so add the item before it (a lower priority item)
                    _items.AddBefore(current, item);
                }
            }
        }

        public T Dequeue()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            T value = _items.First.Value;

            _items.RemoveFirst();

            return value;
        }
        public T Peek()
        {
            if (_items.Count == 0)
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
