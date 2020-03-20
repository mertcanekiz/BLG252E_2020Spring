using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Class_Courses
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

        public void Print()
        {
            Console.WriteLine($"{id}: {name}");
        }
    }
}
