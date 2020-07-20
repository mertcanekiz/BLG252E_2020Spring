using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace question1
{
    class Program
    {
        static int FindDuplicate(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j]) {
                        return i;
                    }
                }
            }
            return -1;
        }

        static int FindDuplicateDict(int[] arr)
        {
            // A dictionary that holds (element: index) pairs.
            // We can also use a HashSet here, but then we wouldn't
            // be able to return the first index, but the second index.
            var results = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (results.ContainsKey(arr[i])) {
                    return results[arr[i]];
                }
                results[arr[i]] = i;
            }
            return -1;
        }
        

        // The methods below return the duplicate element rather than the index
        static int FindDuplicateHashSet(int[] arr)
        {
            var results = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (results.Contains(arr[i]))
                {
                    return arr[i];
                }
                results.Add(arr[i]);
            }
            throw new Exception("No duplicate found");
        }

        static int FindDuplicateSort(int[] arr)
        {
            Array.Sort(arr);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i+1])
                {
                    return arr[i];
                }
            }
            throw new Exception("No duplicate found");
        }

        static int FindDuplicateLinq(int[] arr)
        {
            return arr.GroupBy(s => s).SelectMany(g => g.Skip(1)).First();
        }

        static double Test(Func<int[], int> func, List<int[]> arrays, int numTests = 100)
        {
            Stopwatch sw = new Stopwatch();
            TimeSpan ts = new TimeSpan();
            for (int i = 0; i < numTests; i++)
            {
                foreach (var arr in arrays)
                {
                    sw.Start();
                    int result = func(arr);
                    ts += sw.Elapsed;
                    sw.Stop();
                    sw.Reset();
                }
            }
            return (double)ts.Ticks / Stopwatch.Frequency / numTests * 1000;
        }

        static void Main(string[] args)
        {
            // Read the file and store in int arrays
            string[] lines = File.ReadAllLines("numbers.txt");
            var arrays = new List<int[]>();
            foreach (var line in lines) {
                arrays.Add(Array.ConvertAll(line.Split(' '), int.Parse));
            }

            // Compare results
            double test1 = Test(FindDuplicate, arrays);
            Console.WriteLine($"Two for loops: {test1,10:F4} ms");
            double test2 = Test(FindDuplicateDict, arrays);
            Console.WriteLine($"Dictionary:    {test2,10:F4} ms");
            double test3 = Test(FindDuplicateHashSet, arrays);
            Console.WriteLine($"HashSet:       {test3,10:F4} ms");
            double test4 = Test(FindDuplicateSort, arrays);
            Console.WriteLine($"Sorted Array:  {test4,10:F4} ms");
            double test5 = Test(FindDuplicateLinq, arrays);
            Console.WriteLine($"LINQ:          {test5,10:F4} ms");
        }
    }
}
