using System;

namespace _4_Employee
{
    public class Person
    {
        string ssn;
        string name;

        public Person(string ssn, string name)
        {
            this.ssn = ssn;
            this.name = name;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"SSN: {ssn}");
        }
    }

    public class Employee : Person
    {
        string id;

        public Employee(string ssn, string name, string id) : base(ssn, name)
        {
            this.id = id;
        }

        public override void GetInfo()
        {
            // Calling the base class GetInfo method:
            base.GetInfo();
            Console.WriteLine($"Employee ID: {id}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee("123456", "John Doe", "369851");
            e.GetInfo();
        }
    }
}
