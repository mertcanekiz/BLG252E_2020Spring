using System;

namespace _9_Abstract
{
    abstract class Shape
    {
        public int numSides;

        public abstract double GetArea();
    }

    class Square : Shape
    {
        int n;

        public Square(int n)
        {
            numSides = 4;
            this.n = n;
        }

        public override double GetArea()
        {
            return n * n;
        }
    }

    class Triangle : Shape
    {
        double width, height;

        public Triangle(double width, double height)
        {
            this.width = width;
            this.height = height;
            numSides = 3;
        }

        public override double GetArea()
        {
            return width * height / 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var square = new Square(12);
            Console.WriteLine($"Area of the square = {square.GetArea()}");
            var triangle = new Triangle(5, 2);
            Console.WriteLine($"Area of the triangle = {triangle.GetArea()}");
        }
    }
}
