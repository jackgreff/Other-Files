using System;
namespace Shapes
{
    public class Circle2
    {
        public Circle2(int scale)
        {

            string fill = "  ";
            string fill_b = "==";

            string half_scale = string.Join(fill, new string[scale / 2 + 1]);

            Console.WriteLine(half_scale + half_scale + "^");
            for (int i = 1; i < scale; i++)
            {
                int space = half_scale.Length - i;

                string line = string.Join(fill, new string[space + 1]) + "(" + string.Join(fill_b, new string[2 * i + 1]) + ")";
                Console.WriteLine(line);

            }

            for (int i = 0; i < scale; i++)
            {
                int space = half_scale.Length - i;

                string line = string.Join(fill, new string[i + 1]) + "(" + string.Join(fill_b, new string[2 * space + 1]) + ")";
                Console.WriteLine(line);

            }
            Console.WriteLine(half_scale + half_scale + "v");

        }
    }
}