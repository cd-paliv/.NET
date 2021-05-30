using System;

namespace ej10
{
    class Program
    {
        static void Main(string[] args)
        {
            double r1 = 2.147;
            double r2 = 5.168;
            //cadena interpolada
            Console.WriteLine($"Valor 1 = {r1:0.0}"); //2.1
            Console.WriteLine($"Valor 2 = {r1:0.00}"); //2.15
            Console.WriteLine($"Valor 1 = {r2:0.0}"); //5.1
            Console.WriteLine($"Valor 2 = {r2:0.00}"); //5.17
            //cadena de formato compuesto
            Console.WriteLine("Valor 1 = {0:0.0}", r1);
            Console.WriteLine("Valor 1 = {0:0.00}", r1);
            Console.WriteLine("Valor 1 = {0:0.0}", r2);
            Console.WriteLine("Valor 1 = {0:0.00}", r2);
        }
    }
}
