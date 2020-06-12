using System;
using System.IO;
using System.Text.RegularExpressions;

namespace question1
{
    class Program
    {
        static void Main(string[] args)
        {
            var strategicRegex = new Regex(@"(development|improvement|culture)", RegexOptions.IgnoreCase);
            var tacticalRegex = new Regex(@"(process|excellence|satisfaction)", RegexOptions.IgnoreCase);
            var operationalRegex = new Regex(@"(number|waiting|time|total|income)", RegexOptions.IgnoreCase);

            int a = 3;
            int b = 4;

            string text = File.ReadAllText("words.txt");

            int strategic = 0;
            int tactical = 0;
            int operational = 0;

            strategic = strategicRegex.Matches(text).Count;
            tactical = tacticalRegex.Matches(text).Count;
            operational = operationalRegex.Matches(text).Count;

            Console.WriteLine(strategic);
            Console.WriteLine(tactical);
            Console.WriteLine(operational);
        }
    }
}
