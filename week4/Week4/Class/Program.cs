using System;

namespace Class
{
    class Rectangle
    {
        public double width;
        public double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Area()
        {
            return width * height;
        }

        public void Print()
        {
            Console.WriteLine($"Width: {width} Height: {height} Area: {Area()}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect1 = new Rectangle(10, 5);
            rect1.Print();

            Rectangle rect2 = new Rectangle(20, 20);
            rect2.Print();
        }
    }
}
