using System;
using System.Collections.Generic;

namespace Week4_Example_OddInt
{
    class Program
    {
        static Dictionary<int, int> CountOcurrences(int[] sequence)
        {
            Dictionary<int, int> occurrences = new Dictionary<int, int>();
            foreach (int number in sequence)
            {
                if (occurrences.ContainsKey(number)) {
                    occurrences[number]++;
                } else {
                    occurrences[number] = 1;
                }
            }
            return occurrences;
        }

        static void PrintDictionary(Dictionary<int, int> dict)
        {
            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        static void Main(string[] args)
        {
            int[] sequence = { 1, 1, 2, 3, 5, 3, 3, 8 };
            PrintDictionary(CountOcurrences(sequence));
        }
    }
}
