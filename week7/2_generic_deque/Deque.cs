using System.Collections;
using System.Collections.Generic;

namespace assignment1
{
    abstract class Deque<T> : IEnumerable<T>
    {
        public abstract int Size { get; protected set; }
        public abstract void Clear();
        public abstract void Unshift(T item);
        public abstract T Shift();
        public abstract void Push(T item);
        public abstract T Pop();

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }

    abstract class DequeEnumerator<T> : IEnumerator<T>
    {
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public abstract T Current { get; }
        public abstract bool MoveNext();
        public abstract void Reset();
        public abstract void Dispose();
    }
}
