using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace question2
{
    class Program
    {
        static int Steps(int i)
        {
            int result = 0;
            while (i > 0) {
                if (i % 2 == 0) i /= 2;
                else i--;
                result++;
            }
            return result;
        }
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("nums.txt");
            // var numbers = new List<int>();
            // foreach (var s in lines) {
            //     bool valid = int.TryParse(s, out int i);
            //     if (valid && i > 0) {
            //         numbers.Add(Steps(i));
            //     } else {
            //         numbers.Add(-1);
            //     }
            // }
            var numbers = lines.Select(s => int.TryParse(s, out int i) ? Steps(i) : -1).Select(s => s.ToString()).ToArray();
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                foreach (var num in numbers) {
                    sw.WriteLine(num);
                }
            }
            // File.WriteAllLines("output.txt", numbers);
        }
    }
}
