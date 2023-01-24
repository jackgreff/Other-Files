using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Original Circle------");
            Circle c = new Circle(4);
            Console.WriteLine("------Rectangle------");
            Rectangle r = new Rectangle(4,6);
            Console.WriteLine("------Square------");
            Square s = new Square(10);
            Console.WriteLine("------Triangle------");
            Triangle t = new Triangle(5);
            Console.WriteLine("------New Circle------");
            Circle2 c2 = new Circle2(10);
            Console.WriteLine("------Diamond------");
            Diamond d = new Diamond(10);


        }
    }
}
