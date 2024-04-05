using System;

namespace ShapeHierarchy
{
    class Program
    {
        static void Main()
        {
            Circle circle = new Circle("Circle", 5);
            Rectangle rectangle = new Rectangle("Rectangle", 4, 6);
            Triangle triangle = new Triangle("Triangle", 3, 4);

            PrintShapeArea(circle);
            PrintShapeArea(rectangle);
            PrintShapeArea(triangle);
        }

        static void PrintShapeArea(Shape shape)
        {
            Console.WriteLine($"{shape.Name} Area: {shape.CalculateArea()}");
        }
    }

    abstract class Shape
    {
        public string Name { get; set; }

        public Shape(string name)
        {
            Name = name;
        }

        public abstract double CalculateArea();
    }

    class Circle : Shape
    {
        public double Radius { get; private set; }

        public Circle(string name, double radius) : base(name)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    class Rectangle : Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rectangle(string name, double width, double height) : base(name)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    class Triangle : Shape
    {
        public double Base { get; private set; }
        public double Height { get; private set; }

        public Triangle(string name, double baseLength, double height) : base(name)
        {
            Base = baseLength;
            Height = height;
        }

        public override double CalculateArea()
        {
            return (Base * Height) / 2;
        }
    }
}
