using System;
using System.Collections.Generic;

namespace _3_filter_predicate
{
    class Program
    {
        // We don't need to define a delegate anymore

        static IEnumerable<int> Filter(IEnumerable<int> input, Predicate<int> condition)
        {
            foreach (var item in input)
            {
                if (condition(item))
                {
                    yield return item;
                }
            }
        }

        static bool GreaterThanThree(int item)
        {
            return item > 3;
        }

        static void Main()
        {
            var myList = new List<int> { 2, 3, 5, 8 };
            // Call the filter method with our list and predicate method.
            // Note that we do **not** invoke GreaterThanTree here, simply passing in its name:
            foreach (var item in Filter(myList, GreaterThanThree))
            {
                Console.WriteLine(item);
            }
        }
    }
}
