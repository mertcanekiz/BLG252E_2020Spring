using System;

namespace _3_New
{
    class Base
    {
        public virtual void Foo() {}
        public virtual void Bar() {}
    }

    class Derived : Base
    {
        public override void Foo() {}
        public new void Bar() {}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Base b = new Derived();    // Polymorphic instantiation
            Derived d = new Derived(); // Normal object instantiation

            b.Foo(); // Calls Derived.Foo

            b.Bar(); // Calls Base.Bar
            d.Bar(); // Calls Derived.Bar
        }
    }
}
