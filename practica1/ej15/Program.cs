using System;

namespace ej15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un año");
            int ao = int.Parse(Console.ReadLine());
            if (ao % 100 == 0){
                if (ao % 400 == 0){
                    Console.WriteLine("El año es bisiesto");
                }
            }else if (ao % 4 == 0){
                Console.WriteLine("El año es bisiesto");
            }else{
                Console.WriteLine("El año no es bisiesto");
            }
            Console.ReadLine();
        }
    }
}
