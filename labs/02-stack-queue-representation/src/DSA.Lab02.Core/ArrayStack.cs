using System;

namespace DSA.Lab02
{
    public sealed class ArrayStack<T>
    {
        private readonly T[] _items;
        private int _count;

        public ArrayStack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
        }

        public int Count => _count;
        public int Capacity => _items.Length;

        public void Push(T item)
        {
            // TODO: place the item at the logical top and update the state.

            if (_count == Capacity)
                throw new InvalidOperationException("Stack Overflow");
            
            _items[_count++] = item;
        }

        public T Peek()
        {
            // TODO: return the logical top without removing it.
            
            if (_count == 0)
                throw new InvalidOperationException("Stack empty");

            return _items[_count - 1];
        }

        public T Pop()
        {
            // TODO: remove and return the logical top.
            
            if (_count == 0)
                throw new InvalidOperationException("Stack Underflow");
            
            return _items[--_count];
        }
    }
}
