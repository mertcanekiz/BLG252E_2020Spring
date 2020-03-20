using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Properties
{
    class Student
    {
        // Auto-implemented property
        public string Name { get; set; }

        // Custom "set"
        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                // Try to parse this as an integer
                int.TryParse(value, out int result);

                // If successful, set the value
                if (result != 0)
                {
                    _id = value;
                }
                // else, print error to console
                else
                {
                    Console.WriteLine($"Invalid student ID: {value}");
                }
            }
        }

        public DateTime RegisterDate { get; set; }

        public Student(string name, string id)
        {
            Name = name;
            Id = id;
            RegisterDate = DateTime.Now;
        }
    }
}
