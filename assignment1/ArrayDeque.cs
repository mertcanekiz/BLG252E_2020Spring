using System;
using System.Collections.Generic;

namespace assignment1
{
    class ArrayDeque : Deque
    {
        private List<int> data;

        public override int Size { get; set; }

        public ArrayDeque()
        {
            this.data = new List<int>();
        }

        public override void Clear()
        {
            this.data.Clear();
        }

        public override void Unshift(int item)
        {
            this.data.Insert(0, item);
        }

        public override int Shift()
        {
            int item = this.data[0];
            this.data.RemoveAt(0);
            return item;
        }

        public override void Push(int item)
        {
            this.data.Add(item);
        }

        public override int Pop()
        {
            int item = this.data[this.data.Count - 1];
            this.data.RemoveAt(this.data.Count - 1);
            return item;
        }

        public override DequeEnumerator GetEnumerator()
        {
            return new ArraySeqEnumerator(this.data);
        }
    }

    class ArraySeqEnumerator : DequeEnumerator
    {
        private int position = -1;
        private List<int> data;

        public ArraySeqEnumerator(List<int> data)
        {
            this.data = data;
        }

        public override bool MoveNext()
        {
            position++;
            return (position < data.Count);
        }

        public override void Reset()
        {
            position = -1;
        }

        public override int Current
        {
            get
            {
                return data[position];
            }
        }
    }
}