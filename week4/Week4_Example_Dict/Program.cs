using System;
using System.Collections.Generic;

namespace Week4_Example_Dict
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating a dictionary
            Dictionary<int, string> courses = new Dictionary<int, string>();

            // Adding items to a dictionary
            courses.Add(11090, "Kontrol ve Otomasyon Muh. Etik");
            courses.Add(11092, "Cont. & Automation Eng. Ethics");

            // Accessing a value by its key (index)
            int CRN = 11090;
            if (courses.ContainsKey(CRN)) {
                string name = courses[CRN];
                Console.WriteLine(name);
            } else {
                Console.WriteLine("No course found with CRN given");
            }

            // Or, more efficiently:
            if (courses.TryGetValue(11090, out string value)) {
                Console.WriteLine(value);
            } else {
                Console.WriteLine("No course found with CRN given.");
            }

            // Iterating & printing a dictionary
            foreach (var pair in courses)
            {
                Console.WriteLine($"CRN: {pair.Key} \t Name: {pair.Value}");
            }
            
        }
    }
}
