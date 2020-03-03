using System;
using System.Collections.Generic;

namespace Week4_Example_Lists_2
{
    class Program
    {
        static void PrintList(List<int> list)
        {
            Console.WriteLine(string.Join(", ", list.ToArray()));
        }

        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            
            while (true)
            {
                Console.Write("Enter a number or type q to finish: ");
                string line = Console.ReadLine();
                if (line == "q") break;
                if (int.TryParse(line, out int number) == true) {
                    numbers.Add(number);
                } else {
                    Console.WriteLine("Invalid number. Please try again.");
                }
            }
            
            PrintList(numbers);
            Console.WriteLine("===");
            numbers.Sort();
            PrintList(numbers);
        }
    }
}
