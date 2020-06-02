using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _4_whenany
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Program started");
            var taskA = MethodA();
            var taskB = MethodB();
            var taskC = MethodC();
            var tasks = new List<Task<string>> { taskA, taskB, taskC };
            while (tasks.Count > 0)
            {
                Task<string> finishedTask = await Task.WhenAny(tasks);
                Console.WriteLine(finishedTask.Result);
                tasks.Remove(finishedTask);
            }
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
            await Task.Delay(500);
            return "MethodC";
        }
    }
}
