using System;
namespace Shapes
{
    public class Square
    {
        public Square(int length)
        {
        string fill = "--";
        string l = "[" + string.Join(fill, new string[(length-1) + 1]) + "]";
        string w = string.Join(l + "\n", new string[length + 1]);
        Console.WriteLine(w);
        }
    }
}
