using System;

namespace _5_CSV
{
    public class Person
    {
        public string name;
        public string ssn;

        public DateTime birthDate;

        public Person(string name, string ssn, DateTime birthDate)
        {
            this.name = name;
            this.ssn = ssn;
            this.birthDate = birthDate;
        }

        public virtual void PrintFields()
        {
            Console.WriteLine($"Name: {name}, SSN: {ssn}, Birth Date: {birthDate}");
        }
    }

    public class Student : Person
    {
        public string studentId;
        public string department;
        public double GPA;

        public Student(string name, string ssn, DateTime birthDate, string studentId, string department, double gpa)
            : base(name, ssn, birthDate)
        {
            this.studentId = studentId;
            this.department = department;
            this.GPA = gpa;
        }

        public override void PrintFields()
        {
            Console.WriteLine($"Student ID: {studentId}, Department: {department}, GPA: {GPA}");
            base.PrintFields();
        }
    }

    public class Teacher : Person
    {
        public string teacherId;
        public int numCourses;

        public Teacher(string name, string ssn, DateTime birthDate, string teacherId, int numCourses)
            : base(name, ssn, birthDate)
        {
            this.teacherId = teacherId;
            this.numCourses = numCourses;
        }

        public override void PrintFields()
        {
            Console.WriteLine($"Teacher ID: {teacherId}, Courses: {numCourses}");
            base.PrintFields();
        }
    }
}