using System;
using System.Collections.Generic;
using System.Linq;

namespace _5_CSV
{
    class Program
    {
        static void Main(string[] args)
        {

            // A List of type Person which will hold both the Student and Teacher
            // values read from the CSV files. This is possible due to polymorphism
            List<Person> people = new List<Person>();

            // Create a new CSVReader with the filename and read from it
            // into a students (which will be of type List<Dictionary<string,string>>)
            var students =  new CSVReader("students.csv").read();
            // Iterate over the students list and add a new Person with correct parameters
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

            // Exactly the same as the Student code above, except for the
            // type name (Teacher) and the parameters
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

            // Finally, iterate over the people list and print all of the
            // "Person" objects inside. Polymorphism takes care of which overriden
            // method for PrintFields needs to be invoked.
            foreach (var person in people)
            {
                person.PrintFields();
                Console.WriteLine("===");
            }
        }
    }
}
