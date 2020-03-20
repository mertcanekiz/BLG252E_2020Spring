using System;

namespace _7_Static_Constructor
{
    class SampleClass
    {
        public static int staticValue = 5;
        public int value = 1;

        static SampleClass()
        {
            Console.WriteLine("Static constructor is called.");
        }

        public SampleClass()
        {
            Console.WriteLine("Instance constructor is called.");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            SampleClass obj1 = new SampleClass();
            SampleClass obj2 = new SampleClass();

            Console.WriteLine(SampleClass.staticValue);
            Console.WriteLine(obj1.value);
        }
    }
}
