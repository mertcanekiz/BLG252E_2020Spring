using System;

namespace _10_Virtual
{

    class Base
    { 
        public virtual void Print()
        {
            Console.WriteLine("This is the base class.");
        }
    }

    class Derived1 : Base { }

    class Derived2 : Base
    {
        public override void Print()
        {
            Console.WriteLine("This is the derived class");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var derived1 = new Derived1();
            var derived2 = new Derived2();

            derived1.Print();
            derived2.Print();
        }
    }
}
