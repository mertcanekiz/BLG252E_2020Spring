using System;
using System.Collections.Generic;

namespace assignment1
{
    class ArrayDeque<T> : Deque<T>
    {
        private List<T> data;

        public override int Size { get; protected set; }

        public ArrayDeque()
        {
            this.data = new List<T>();
        }

        public override void Clear()
        {
            this.data.Clear();
        }

        public override void Unshift(T item)
        {
            this.data.Insert(0, item);
        }

        public override T Shift()
        {
            T item = this.data[0];
            this.data.RemoveAt(0);
            return item;
        }

        public override void Push(T item)
        {
            this.data.Add(item);
        }

        public override T Pop()
        {
            T item = this.data[this.data.Count - 1];
            this.data.RemoveAt(this.data.Count - 1);
            return item;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            int index = 0;
            while (index < this.data.Count)
            {
                yield return this.data[index];
            }
        }
    }
}