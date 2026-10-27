using System;

namespace DSA.Lab02
{
    public sealed class RingQueue<T>
    {
        private readonly T[] _items;
        private int _head;
        private int _tail;
        private int _count;

        public RingQueue(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
        }

        public int Count => _count;
        public int Capacity => _items.Length;
        
        // Insert element at the rear (tail)
        public void Enqueue(T item)
        {
            // TODO: write at tail, advance tail with wrap-around, update count.
            
            if (Count == Capacity)
            {
                throw new  InvalidOperationException("Queue is full");
            }

            _tail = (_head + Count) % Capacity;
            _items[_tail] = item;
            _count++;
        }
        
        // Get the front (head) element
        public T Peek()
        {
            // TODO: return the item at head without removing it.

            if (Count == 0)
                throw new  InvalidOperationException("Queue is empty");
            
            return _items[_head];
        }
        
        // Remove an element from the front (head)
        public T Dequeue()
        {
            // TODO: read/clear at head, advance head with wrap-around, update count.

            if (Count == 0)
                throw new  InvalidOperationException("Queue is empty");

            T res = _items[_head];
            _head = (_head + 1) % Capacity;
            _count--;
            return res;
        }
    }
}
