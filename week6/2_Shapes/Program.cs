using System;

namespace _2_Shapes
{
    public class Shape
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Height { get; set; }
        public int Width { get; set; }

        // Virtual method
        public virtual void Draw()
        {
            Console.WriteLine("Base class Draw()");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle");
            base.Draw();
        }
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
            base.Draw();
        }
    }

    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a triangle");
            base.Draw();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // A Rectangle, Triangle and Circle can
            // all be used wherever a Shape is expected.
            // No cast is required because an implicit
            // conversion exists from a derived class
            // to its base class.
            var shapes = new List<Shape>
            {
                new Rectangle(),
                new Triangle(),
                new Circle()
            };

            // Although we are calling Draw() on a
            // Shape class, the overriden version in
            // the derived classes is invoked, not the
            // base class.
            foreach (var shape in shapes)
            {
                shape.draw();
            }
        }
    }
}
