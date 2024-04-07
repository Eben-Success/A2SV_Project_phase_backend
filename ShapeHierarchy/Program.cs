using System;

namespace ShapeHierarchy
{
    // Base class - Shape
    public abstract class Shape
    {
        public string Name { get; set; }

        public Shape(string name)
        {
            Name = name;
        }

        public abstract double CalculateArea();
    }

    // Derived class - Circle
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(string name, double radius) : base(name)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    // Derived class - Rectangle
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

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

    // Derived class - Triangle
    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

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

    // Utility method to print the shape's area
    public static class ShapePrinter
    {
        public static void PrintShapeArea(Shape shape)
        {
            Console.WriteLine($"{shape.Name} Area: {shape.CalculateArea()}");
        }
    }

    class Program
    {
        static void Main()
        {
            // Creating instances of derived classes
            Circle circle = new Circle("Circle", 5);
            Rectangle rectangle = new Rectangle("Rectangle", 4, 6);
            Triangle triangle = new Triangle("Triangle", 3, 4);

            // Demonstrating the usage of 'PrintShapeArea' method
            ShapePrinter.PrintShapeArea(circle);
            ShapePrinter.PrintShapeArea(rectangle);
            ShapePrinter.PrintShapeArea(triangle);
        }
    }
}
