using System;

namespace ej4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese su nombre");
            string nombre = Console.ReadLine();
            if (nombre != ""){
                Console.WriteLine("Hola " + nombre);
            }else{
                Console.WriteLine("Hello World!");
            }
            Console.ReadLine();
        }
    }
}
