using System;
using System.Collections.Generic;

namespace _1_delegate
{
    class Person
    {
        public int SomeMethod(string input)
        {
            return input.Length;
        }
    }

    class Program
    {
        delegate int MyDelegate(string s);
        static void Main()
        {
            Person p1 = new Person();
            
            // first way of calling SomeMethod
            int answer = p1.SomeMethod("Some String");

            // second way using delegate
            var d = new MyDelegate(p1.SomeMethod);
            int answer2 = d("Some String");
        }
    }
}
