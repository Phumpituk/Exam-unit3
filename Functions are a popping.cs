class Task1
{
    static void Main()
    {
        Console.WriteLine(SquareNumber(5));
        Console.WriteLine(InchesToMm(10));
        Console.WriteLine(CalculateRoot(25));
        Console.WriteLine(CubeNumber(3));
        Console.WriteLine(CircleArea(5));
        Console.WriteLine(Greeting("Phumpituk"));
    }

    static double SquareNumber(double num)
    {
        return num * num;
    }

    static double InchesToMm(double length)
    {
        return length * 25.4;
    }

    static double CalculateRoot(double num)
    {
        return Math.Sqrt(num);
    }

    static double CubeNumber(double num)
    {
        return Math.Pow(num, 3);
    }

    static double CircleArea(double radius)
    {
        return Math.PI * Math.Pow(radius, 2);
    }

    static string Greeting(string name)
    {
        return "Hello, " + name + "!";
    }
}
