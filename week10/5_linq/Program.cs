using System;
using System.Linq;

namespace _5_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a data source
            int[] scores = new int[] { 85, 97, 81, 60 };

            // Define the query expression
            var scoreQuery =
                from score in scores       // required
                where score > 80           // optional
                orderby score descending   // optional
                select score;              // must end with select or group

            // Execute the query
            foreach (int i in scoreQuery)
            {
                Console.WriteLine(i);
            }
        }
    }
}
