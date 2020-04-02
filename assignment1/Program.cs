using System;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            // You must replace this with the class you create
            // that uses a doubly linked list:
            Deque deque = new ArrayDeque();
            // Deque deque = new DLinkDeque();

            foreach (var item in deque) {
                Console.WriteLine(item);
            }
        }
    }
}
