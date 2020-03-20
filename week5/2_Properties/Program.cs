using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 2; i++)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("ID: ");
                string id = Console.ReadLine();
                students.Add(new Student(name, id));
            }

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Id}: {student.Name} -- {student.RegisterDate}");
            }
        }
    }
}
