using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Class_Courses
{
    class Course
    {
        public int crn;
        public string name;

        public List<Student> students;

        public Course(int crn, string name)
        {
            this.crn = crn;
            this.name = name;
            this.students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }
    }
}
