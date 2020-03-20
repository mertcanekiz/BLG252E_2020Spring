using System;

namespace _6_Access_Modifiers
{
    class SampleClass
    {
        private int privateValue = 123;
        public int otherValue = 456;

        public static int publicStaticValue = 0;
        private static int privateStaticValue = 1;
    }

    class Program
    {
        static void Main(string[] args)
        {
            SampleClass obj = new SampleClass();

            Console.WriteLine(obj.otherValue);
            Console.WriteLine(obj.privateValue); // Error

            Console.WriteLine(SampleClass.publicStaticValue);
            Console.WriteLine(SampleClass.privateStaticValue); // Error
        }
    }
}
