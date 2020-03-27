using System;
using System.Collections.Generic;
using System.Linq;

namespace _5_CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            CSVReader reader = new CSVReader("students.csv");
            var students = reader.read();
            foreach (var entry in students)
            {
                people.Add(new Student(
                    entry["name"],
                    entry["ssn"],
                    DateTime.ParseExact(entry["birth_date"], "dd/MM/yyyy", null),
                    entry["id"],
                    entry["department"],
                    double.Parse(entry["gpa"])
                ));
            }

            var teachers = new CSVReader("teachers.csv").read();
            foreach (var entry in teachers)
            {
                people.Add(new Teacher(
                    entry["name"],
                    entry["ssn"],
                    DateTime.ParseExact(entry["birth_date"], "dd/MM/yyyy", null),
                    entry["id"],
                    int.Parse(entry["num_courses"])
                ));
            }

            foreach (var person in people)
            {
                person.PrintFields();
                Console.WriteLine("===");
            }
        }
    }
}
