using System;

namespace ej5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese su nombre");
            string nombre = Console.ReadLine();
            if (nombre == "Juan"){
                Console.WriteLine("¡Hola amigo!");
            }else if (nombre == "María"){
                Console.WriteLine("Buen día señora");
            }else if (nombre == "Alberto"){
                Console.WriteLine("Hola Alberto");
            }else if (nombre == ""){
                Console.WriteLine("Buen día mundo!");
            }else{
                Console.WriteLine("Buen día " + nombre);
            }
            Console.ReadLine();
        }
    }
}
