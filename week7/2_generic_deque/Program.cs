using System;
using System.IO;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Deque<int> intDeque = new DLinkDeque<int>();
            Deque<string> stringDeque = new DLinkDeque<string>();

            intDeque.Push(1);
            intDeque.Push(2);
            intDeque.Push(3);

            stringDeque.Push("Hello");
            stringDeque.Push("World");

            foreach (var item in intDeque) {
                Console.WriteLine(item);
            }

            foreach (var item in stringDeque) {
                Console.WriteLine(item);
            }
        }
    }
}
