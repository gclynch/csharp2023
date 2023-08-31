// abstract property in an abstract class

using System;
namespace Geometry;
public abstract class Shape
{
    // read only abstract property - virtual implied
    // set not appropriate here since area calculated
    // Shape must be abstract, similiar syntax to auto property

    public abstract double Area { get; }
}

public class Square: Shape
{
    // auto property
    public double Side { get; set; }

    // implement Area calculation for a Square
    public override double Area => Side * Side;                     // expression bodied read-only property
    

    // default constructor
    public Square(double side)
    {
        Side = side;
    }
}


// test class
public static class Test
{
    static void Main()              // private
    {
        Square s = new(10);
        Console.WriteLine(s.Area);
    }
}
