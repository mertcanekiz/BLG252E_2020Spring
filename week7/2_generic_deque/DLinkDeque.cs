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
            if (head == null) {
                head = node;
                tail = node;
            } else {
                node.next = head;
                head.prev = node;
                head = node;
            }
            Size++;
        }

        public override void Push(T item)
        {
            Node<T> node = new Node<T>(item);
            if (tail == null) {
                tail = node;
                head = node;
            } else {
                node.prev = tail;
                tail.next = node;
                tail = node;
            }
            Size++;
        }

        public override T Shift()
        {
            T item;
            if (head == null) {
                throw new InvalidOperationException();
            } else {
                Node<T> next = head.next;
                if (next.next != null) {
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
            if (tail == null) {
                throw new InvalidOperationException();
            } else {
                Node<T> prev = tail.prev;
                if (prev.prev != null) {
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
            return new DLinkDequeEnumerator<T>(this);
        }
    }

    class DLinkDequeEnumerator<T> : DequeEnumerator<T>
    {
        private Node<T> currentNode;
        private DLinkDeque<T> deque;

        public DLinkDequeEnumerator(DLinkDeque<T> deque)
        {
            this.deque = deque;
            this.currentNode = null;
        }

        public override bool MoveNext()
        {
            if (this.currentNode == null) {
                this.currentNode = this.deque.head;
            } else {
                this.currentNode = this.currentNode.next;
            }
            return this.currentNode != null;
        }

        public override void Reset()
        {
            this.currentNode = null;
        }

        public override T Current
        {
            get
            {
                return this.currentNode.data;
            }
        }

        public override void Dispose()
        {
            return;
        }
    }

}
