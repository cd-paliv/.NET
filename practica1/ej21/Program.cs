using System;

namespace ej21
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            if (--i == 0)
            {
                Console.WriteLine("cero");
            }
            if (i++ == 0)
            {
                Console.WriteLine("cero");
            }
            Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}
