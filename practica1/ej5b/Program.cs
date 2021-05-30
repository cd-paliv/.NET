using System;

namespace ej5b
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese su nombre");
            string nombre = Console.ReadLine();
            switch (nombre){
                case "Juan":
                    Console.WriteLine("¡Hola amigo!");
                    break;
                case "María":
                    Console.WriteLine("Buen día señora");
                    break;
                case "Alberto":
                    Console.WriteLine("Hola Alberto");
                    break;
                case "":
                    Console.WriteLine("Buen día mundo!");
                    break;
                default:
                    Console.WriteLine("Buen día " + nombre);
                    break;
            }
            Console.ReadLine();
        }
    }
}
