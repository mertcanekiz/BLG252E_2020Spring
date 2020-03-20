using System;

namespace _2_Class_Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Student osman = new Student("Osman", 123456);
            Course myCourse = new Course(21734, "Object Oriented Programming");

            myCourse.AddStudent(osman);

            Console.WriteLine($"{myCourse.crn}: {myCourse.name}");
            Console.WriteLine("====================");
            foreach (var student in myCourse.students)
            {
                student.Print();
            }
        }
    }
}
