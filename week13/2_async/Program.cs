using System;
using System.Threading.Tasks;

namespace _2_async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Program started");
            MethodA();
            MethodB();
            MethodC();
            Console.ReadKey();
            Console.WriteLine("Program Finished");
        }

        static async Task MethodA()
        {
            await Task.Delay(3000);
            Console.WriteLine("MethodA");
        }

        static async Task MethodB()
        {
            await Task.Delay(1000);
            Console.WriteLine("MethodB");
        }

        static async Task MethodC()
        {
            await Task.Delay(5000);
            Console.WriteLine("MethodC");
        }
    }
}
