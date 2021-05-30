using System;

namespace ej9
{
    class Program
    {
        static void Main(string[] args)
        {
            object obj = new int[10];
            dynamic dyn = 13;
            Console.WriteLine(obj.Length); //el objeto no tiene definición para length
            Console.WriteLine(dyn.Length); //al imprimir es un int, que no tiene length
        }
    }
}
