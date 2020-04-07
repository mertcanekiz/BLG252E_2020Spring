using System;
using System.IO;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Deque deque = new DLinkDeque();

            var lines = File.ReadAllLines("integers.txt");
            foreach (var line in lines) {
                deque.Push(Convert.ToInt32(line));
            }

            foreach (var item in deque) {
                Console.WriteLine(item);
            }
        }
    }
}
