using System;

namespace _8_Inheritance
{
    class Base
    {
        public string text = "Some text";

        public Base()
        {
            Console.WriteLine("Base class");
        }

        public void SayHello()
        {
            Console.WriteLine("Greetings from base class!");
        }
    }

    class Derived : Base
    {
        public Derived()
        {
            Console.WriteLine("Derived class");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Derived derived = new Derived();

            // You can use the methods and members from the base class
            derived.SayHello();
            Console.WriteLine(derived.text);
        }
    }
}
