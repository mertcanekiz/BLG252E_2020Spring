using System;
using System.Collections.Generic;

namespace _4_filter_lambda
{
    class Program
    {
        static IEnumerable<int> Filter(List<int> input, Predicate<int> predicate)
        {
            foreach (var item in input)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        static void Main()
        {
            var myList = new List<int> { 2, 3, 5, 8 };
            foreach (var item in Filter(myList, x => x > 3))
            {
                Console.WriteLine(item);
            }
        }
    }
}
