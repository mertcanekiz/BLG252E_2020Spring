using System;

namespace _1_Polymorphism_Basics
{
    public class Animal
    {
        public virtual string talk()
        {
            return "Animal";
        }
    }

    public class Cat : Animal
    {
        public override string talk()
        {
            return "Meow";
        }
    }

    public class Dog : Animal
    {
        public override string talk()
        {
            return "Woof";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat();
            Animal dog = new Dog();
            Console.WriteLine(cat.talk());
            Console.WriteLine(dog.talk());
            // cat and dog are both declared as Animal types,
            // but instead of the Animal talk() method, their
            // respective overriden talk() methods get invoked
        }
    }
}
