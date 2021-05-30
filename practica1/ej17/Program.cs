using System;

namespace ej17
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int a=rnd.Next(1, 50), b=rnd.Next(1,50);
            int x = (a<b) ? a : b; //si la condicion es verdadera se queda con la primer opción
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(x);
            Console.ReadLine();
        }
    }
}
