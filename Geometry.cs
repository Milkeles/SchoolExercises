class Geometry
{
 
    public float SquarePerimeter (float a)
    {
        return a * 4;
    }
 
    public float SquareArea(float a)
    {
        return a * a;
    }
 
    public float RectanglePerimeter(float a, float b)
    {
        return 2 * a + 2 * b;
    }
 
    public float RectangleArea(float a, float b)
    {
        return a * b;
    }
 
    public double CircleArea(double r)
    {
        return Math.PI * r * r;
    }
}
 
class Program
{
    static void Main()
    {
        Geometry geometry = new Geometry();
        Console.WriteLine("Square:");
        Console.Write("a = ");
        float sideA = Single.Parse(Console.ReadLine());
        Console.WriteLine($"Perimeter: {geometry.SquarePerimeter(sideA)}");
        Console.WriteLine($"Area: {geometry.SquareArea(sideA)}");
 
        Console.WriteLine("Rectangle:");
        Console.Write("a = ");
        float rsideA = Single.Parse(Console.ReadLine());
        Console.Write("b = ");
        float rsideB = Single.Parse(Console.ReadLine());
        Console.WriteLine($"Perimeter: {geometry.RectanglePerimeter(rsideA, rsideB)}");
        Console.WriteLine($"Area: {geometry.RectangleArea(rsideA, rsideB)}");
 
        Console.WriteLine("Circle:");
        Console.Write("r = ");
        double radius = Double.Parse(Console.ReadLine());
        Console.WriteLine($"Area: {geometry.CircleArea(radius)}");
    }
}
