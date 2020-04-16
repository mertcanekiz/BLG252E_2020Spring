using System;
using System.Collections.Generic;

namespace _1_filter
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new List<int>() { 2, 3, 5, 8 };
            foreach (var item in FilterYield(myList))
            {
                Console.WriteLine(item);
            }
        }

        static List<int> Filter(List<int> list)
        {
            var result = new List<int>();
            foreach (var item in list)
            {
                if (item > 3)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        static IEnumerable<int> FilterYield(List<int> list)
        {
            foreach (var item in list)
            {
                if (item > 3) {
                    yield return item;
                }
            }
        }
    }
}
