using System;
using System.Collections.Generic;

namespace assignment1
{
    class Node<T>
    {
        public T data;
        public Node<T> next;
        public Node<T> prev;

        public Node(T data)
        {
            this.data = data;
            this.next = null;
            this.prev = null;
        }
    }

    class DLinkDeque<T> : Deque<T>
    {
        public Node<T> head;
        public Node<T> tail;

        public DLinkDeque()
        {
            this.head = null;
            this.tail = null;
        }

        public override int Size { get; protected set; }

        public override void Clear()
        {
            this.head = null;
            this.tail = null;
            this.Size = 0;
        }

        public override void Unshift(T item)
        {
            Node<T> node = new Node<T>(item);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.next = head;
                head.prev = node;
                head = node;
            }
            Size++;
        }

        public override void Push(T item)
        {
            Node<T> node = new Node<T>(item);
            if (tail == null)
            {
                tail = node;
                head = node;
            }
            else
            {
                node.prev = tail;
                tail.next = node;
                tail = node;
            }
            Size++;
        }

        public override T Shift()
        {
            T item;
            if (head == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Node<T> next = head.next;
                if (next.next != null)
                {
                    next.prev = null;
                }
                item = head.data;
                head = next;
            }
            Size--;
            return item;
        }

        public override T Pop()
        {
            T item;
            if (tail == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Node<T> prev = tail.prev;
                if (prev.prev != null)
                {
                    prev.next = null;
                }
                item = tail.data;
                tail = prev;
            }
            Size--;
            return item;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.data;
                current = current.next;
            }
        }
    }
}
