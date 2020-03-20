using System;

namespace _5_Const
{
    static class Math
    {
        public const double PI = 3.14159;
        public const double E = 2.71828;

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
            // We don't want to have a separate instance for every
            // single time we use the Math class, so we make it static.
            Console.WriteLine(Math.Square(Math.E));
            Console.WriteLine(Math.Add(Math.E, Math.PI));
        }
    }
}
