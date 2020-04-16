using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_fibonacci
{
    class Program
    {
        static IEnumerable<int> Fib()
        {
            // Fib(n) = Fib(n-1) + Fib(n-2);
            int previous, previousPrevious;
            int current;
            previous = 1;
            previousPrevious = 1;


            yield return previousPrevious;
            yield return previous;

            while (true)
            {
                current = previous + previousPrevious;
                yield return current;
                previousPrevious = previous;
                previous = current;
            }
        }

        static void Main(string[] args)
        {
            foreach (var element in Fib().Take(10))
            {
                Console.WriteLine(element);
            }
        }
    }
}
