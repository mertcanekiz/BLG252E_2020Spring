using System;

namespace _4_throw
{
    class Program
    {
        public class Numbers
        {
            int[] numbers = { 0, 1, 2, 3, 6, 11, 23, 47, 106, 235 };

            public int GetNumber(int index)
            {
                if (index < 0 || index >= numbers.Length) {
                    throw new IndexOutOfRangeException();
                }
                return numbers[index];
            }

            public int Divide(int a, int b)
            {
                int result;
                try {
                    result = a / b;
                } catch (DivideByZeroException)
                {
                    throw;
                }
                return result;
            }
        }

        static void Main()
        {
            var num = new Numbers();
            try {
                int a = num.GetNumber(3);
                int b = num.GetNumber(1);

                // Comment the lines above and uncomment the lines below
                // to see the exceptions get thrown:
                
                // int a = num.GetNumber(10); // Causes IndexOutOfBoundsException
                // int b = num.GetNumber(0); // Causes DivideByZeroException

                int result = num.Divide(a, b);
                Console.WriteLine($"{a} / {b} = {result}");
            } catch (IndexOutOfRangeException ex) {
                Console.WriteLine(ex);
            } catch (DivideByZeroException ex) {
                Console.WriteLine(ex);
            }
        }
    }
}
