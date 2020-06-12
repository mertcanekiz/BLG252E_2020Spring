using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace question1
{
    class Program
    {
        static int wordSum(string s)
        {
            int result = 0;
            foreach (char c in s)
            {
                result += c - 'A' + 1;
            }
            return result;
        }
        static void Main(string[] args)
        {
            string[] names = File.ReadAllText("names.txt").Trim().Replace("\"", "").Split(",").OrderBy(w => w).ToArray();
            // long result = 0;
            // for (int i = 0; i < names.Length; i++) {
            //     result += wordSum(names[i]) * (i + 1);
            // }
            long result = File.ReadAllText("names.txt").Trim()
                                .Replace("\"", "")
                                .Split(",")
                                .OrderBy(w => w)
                                .Select((name, i) => new {name, i})
                                .Sum(w => w.name.Sum(c => c - 'A' + 1) * (w.i + 1));
            Console.WriteLine(result);
        }
    }
}
