using System;
using System.Collections.Generic;

namespace _2_filter_delegate
{
    class Program
    {
        // Create a delegate that takes in an integer, and returns a bool
        // This delegate is going to be a template for our filter method's parameter
        delegate bool MyDelegate(int item);

        // Take in an enumerable and a delegate
        static IEnumerable<int> Filter(IEnumerable<int> input, MyDelegate condition)
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
