using System;
using System.IO;
using System.Threading.Tasks;

namespace _6_file
{
    class Program
    {
        static async Task Main()
        {
            string path = "exampleFile.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
            }

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = await sr.ReadLineAsync()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
