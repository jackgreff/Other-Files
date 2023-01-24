using System;
namespace Shapes
{
    public class Rectangle
    {
        public Rectangle(int length, int width)
        {
        string fill = "-";
        string l = "[" + string.Join(fill, new string[length + 1]) + "]";
        string w = string.Join(l+"\n", new string[width + 1]);
        Console.WriteLine(w);

        }
    }
}
