using System;
using System.Linq;

namespace _6_linq_method
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a data source
            int[] scores = new int[] { 85, 97, 81, 60 };

            // Define the query expression
            var scoreQuery = scores.Where(score => score > 80).OrderByDescending(score => score);

            // Execute the query
            foreach (int i in scoreQuery)
            {
                Console.WriteLine(i);
            }
        }
    }
}
