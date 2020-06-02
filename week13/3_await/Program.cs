using System;
using System.Threading.Tasks;

namespace _3_await
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Program started");
            var taskA = MethodA();
            var taskB = MethodB();
            var taskC = MethodC();
            Console.WriteLine(await taskA);
            Console.WriteLine(await taskB);
            Console.WriteLine(await taskC);
            Console.WriteLine("Program Finished");
        }

        static async Task<string> MethodA()
        {
            await Task.Delay(3000);
            return "MethodA";
        }

        static async Task<string> MethodB()
        {
            await Task.Delay(1000);
            return "MethodB";
        }

        static async Task<string> MethodC()
        {
            await Task.Delay(5000);
            return "MethodC";
        }
    }
}
