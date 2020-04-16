using System;

namespace _3_trycatch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num1 = 13;
                int num2 = 0;
                int result = num1 / num2;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Exception caught: {ex}");
            }
            finally
            {
                Console.WriteLine("This always gets executed");
            }
        }
    }
}
