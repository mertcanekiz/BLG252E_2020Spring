using System;
using System.Collections.Generic;

namespace _1_Class_Basics
{
    class Program
    {
        class Student
        {
            public int id;
            public string name;
            public DateTime registerDate;

            public Student(string name, int id)
            {
                this.id = id;
                this.name = name;
                this.registerDate = DateTime.Now;
            }

            // public void Print();
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());
                students.Add(new Student(name, id));
            }

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.id}: {student.name} -- {student.registerDate}");
            }
        }
    }
}
