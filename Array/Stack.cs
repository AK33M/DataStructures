﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    public class Stack<T> : IEnumerable<T>
    {
        T[] _items = new T[0];

        int _size;

        public void Push(T item)
        {
            if (_size == _items.Length)
            {
                int newLength = _size == 0 ? 4 : _size * 2;

                T[] newArray = new T[newLength];
                _items.CopyTo(newArray, 0);
                _items = newArray;
            }

            _items[_size] = item;
            _size++;
        }

        public T Pop()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            _size--;

            return _items[_size];
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return _items[_size - 1];
        }

        public int Count { get { return _size; } }

        public void Clear()
        {
            _size = 0;
        }

        /// <summary>
        /// Enumerates each item in the stack in LIFO order. The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _size; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
