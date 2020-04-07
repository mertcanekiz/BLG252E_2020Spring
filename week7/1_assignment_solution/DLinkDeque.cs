using System;

namespace assignment1
{
    class Node
    {
        public int data;
        public Node next;
        public Node prev;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
            this.prev = null;
        }
    }

    class DLinkDeque : Deque
    {
        public Node head;
        public Node tail;

        public DLinkDeque()
        {
            this.head = null;
            this.tail = null;
            this.Size = 0;
        }

        public override int Size { get; protected set; }

        public override void Clear()
        {
            this.head = null;
            this.tail = null;
            this.Size = 0;
        }

        public override void Unshift(int item)
        {
            Node node = new Node(item);
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

        public override void Push(int item)
        {
            Node node = new Node(item);
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

        public override int Shift()
        {
            int item;
            if (head == null) {
                throw new InvalidOperationException();
            } else {
                Node next = head.next;
                if (next.next != null) {
                    next.prev = null;
                }
                item = head.data;
                head = next;
            }
            Size--;
            return item;
        }

        public override int Pop()
        {
            int item;
            if (tail == null) {
                throw new InvalidOperationException();
            } else {
                Node prev = tail.prev;
                if (prev.prev != null) {
                    prev.next = null;
                }
                item = tail.data;
                tail = prev;
            }
            Size--;
            return item;
        }

        public override DequeEnumerator GetEnumerator()
        {
            return new DLinkDequeEnumerator(this);
        }
    }

    class DLinkDequeEnumerator : DequeEnumerator
    {
        private Node currentNode;
        private DLinkDeque deque;

        public DLinkDequeEnumerator(DLinkDeque deque)
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

        public override int Current
        {
            get
            {
                return this.currentNode.data;
            }
        }
    }

}
