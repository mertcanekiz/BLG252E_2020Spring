using System;

namespace _4_Static
{
    static class Math
    {
        public static double Square(double x)
        {
            return x * x;
        }

        public static double Add(double a, double b)
        {
            return a + b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Square(2.71));
            Console.WriteLine(Math.Add(2, 3));
        }
    }
}
