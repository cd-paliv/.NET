using System;

namespace ej6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresar linea de texto");
            string linea = Console.ReadLine();
            while (linea != ""){
                Console.WriteLine(linea.Length);
                Console.WriteLine("Ingresar linea de texto");
                linea = Console.ReadLine();
            }
        }
    }
}
