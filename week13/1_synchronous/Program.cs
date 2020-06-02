using System;
using System.Threading.Tasks;

namespace _1_synchronous
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started");
            MethodA();
            MethodB();
        }

        static void MethodA()
        {
            Task.Delay(3000).Wait();
            Console.WriteLine("MethodA");
        }

        static void MethodB()
        {
            Task.Delay(1000).Wait();
            Console.WriteLine("MethodB");
        }
    }
}
