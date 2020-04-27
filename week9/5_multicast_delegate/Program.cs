using System;

namespace _5_multicast_delegate
{
    class Program
    {
        delegate void CustomDel(string s);

        static void Hello(string s)
        {
            Console.WriteLine($"Hello, {s}");
        }

        static void Goodbye(string s)
        {
            Console.WriteLine($"Goodbye, {s}");
        }

        static void Main(string[] args)
        {
            CustomDel hiDel, byeDel, multiDel;

            hiDel = Hello;
            byeDel = Goodbye;
            multiDel = hiDel + byeDel;

            hiDel("A");
            byeDel("B");
            multiDel("C");
            multiDel -= hiDel;
            multiDel("D");
        }
    }
}
