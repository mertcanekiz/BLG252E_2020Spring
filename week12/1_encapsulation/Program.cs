using System;

namespace _1_encapsulation
{
    public class Student
    {
        private int id;
        public int Id {
            get {
                return id;
            }
            set {
                if (value > 0) id = value;
            }
        }

        private string name;
        public string Name {
            get {
                return name;
            }
            set {
                if (value.Length > 0) name = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            s1.Name = "Osman";
            s1.Id = 1234;
        }
    }
}
