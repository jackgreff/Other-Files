using System;
namespace Shapes
{
    public class Circle
    {
        public Circle(int scale)
        {
         string fill_space = "  ";
        string fill_b = "==";
       	string half_scale = string.Join(fill_space, new string[scale/2 + 1]);

        string top = half_scale + "^"+ half_scale;
        string between = string.Join("\n", new string[scale/2 + 1]);
        string middle = "(" + half_scale + half_scale + ")";
        string bottom = half_scale + "V"+ half_scale;
        string return_option = top + "\n" + between + "\n" + middle + "\n"+ between + "\n" + bottom;
        Console.WriteLine(return_option);

        //int full 

        //    for (int i = 0; i < scale; i++)
        //    {
        //    string leg = (i / scale) / 4;



            //}
        }
    }
}
