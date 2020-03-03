using System;
using System.Collections.Generic;
using System.Linq;

namespace Week4_Example_Students
{
    struct Student
    {
        public string name;
        public string id;
        public DateTime registrationDate;
    };

    class Program
    {
        static Student NewStudent()
        {
            Student student = new Student();
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            student.name = name;
            Console.Write("Enter student ID: ");
            string id = Console.ReadLine();
            student.id = id;
            student.registrationDate = DateTime.Now;
            return student;
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 3; i++) {
                students.Add(NewStudent());
            }
            students = students.OrderBy(s => s.name).ToList();
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.id}: {student.name} - {student.registrationDate}");
            }
        }
    }
}
