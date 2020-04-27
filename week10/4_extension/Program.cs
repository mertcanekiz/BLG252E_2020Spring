using System;

namespace _4_extension
{
    public static class StringHelper
    {
        public static string Capitalize(this string str)
        {
            char[] arr = str.ToCharArray();
            if (arr.Length > 0)
                arr[0] = char.ToUpper(arr[0]);
            return new string(arr);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello".Capitalize());
        }
    }
}
