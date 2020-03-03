using System;
using System.Collections.Generic;

namespace _7_Class_User
{
    class Program
    {
        class User
        {
            public string email;
            public string password;

            public User(string email, string password)
            {
                this.email = email;
                this.password = password;
            }

            public void Print()
            {
                Console.WriteLine($"{email}: {password}");
            }
        }
        static void Main(string[] args)
        {
            List<User> users = new List<User>();

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                users.Add(new User(email, password));
            }

            foreach (User user in users)
            {
                user.Print();
            }

            users.RemoveAt(0);
        }
    }
}
