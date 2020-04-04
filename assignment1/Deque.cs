using System;
using System.Collections;

namespace assignment1
{
    abstract class Deque : IEnumerable
    {
        public abstract int Size { get; set; }
        public abstract void Clear();
        public abstract void Unshift(int item);
        public abstract int Shift();
        public abstract void Push(int item);
        public abstract int Pop();

        public abstract DequeEnumerator GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    abstract class DequeEnumerator : IEnumerator
    {
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public abstract int Current { get; }
        public abstract bool MoveNext();
        public abstract void Reset();
    }
}
