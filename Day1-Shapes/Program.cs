using System;

public interface IShape 
{ 
    string Name { get; }
    double Area();
}
class Program 
{
    public class Circle : IShape 
    {
        public double Radius { get; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public string Name => "Круг";
        public double Area() => Math.PI * Radius * Radius;
    }
    public class Rectangle : IShape 
    {
        public double Width { get; }
        public double Height { get; }
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public virtual string Name => "Прямоугольник";
        public double Area() => Width * Height;
    }
    public class Triangle : IShape 
    {
        public double Base { get; }
        public double Height { get; }
        public Triangle(double baselength, double height)
        {
            Base = baselength;
            Height = height;
        }
        public string Name => "Треугольник";
        public double Area() => 0.5 * Base * Height;
    }
    public class Square : Rectangle 
    { 
        public Square(double side) : base(side, side) 
        { 

        }
        public override string Name => "Квадрат";
    }
    public static void Main(string[] args)
    {
        var shapes = new IShape[]
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 8),
            new Circle(2.5),
            new Rectangle(10, 10),
            new Square(5)
        };
        double total = 0;
        foreach (var shape in shapes) 
        {
            double area = shape.Area();
            Console.WriteLine($"{shape.Name}: площадь = {area:F2}");
            total += area;
        }
        Console.WriteLine($"---");
        Console.WriteLine($"Всего фигур: {shapes.Length}");
        Console.WriteLine($"Суммарная площадь: {total:F2}");
    }
}