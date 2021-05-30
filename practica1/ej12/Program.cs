using System;

namespace ej12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresar un nro entero");
            int nro = int.Parse(Console.ReadLine());
            if (nro > 0){
                Console.WriteLine("Los divisores del nro "+nro+" son:");
                for (int i = 1; i <= nro; i++){
                    if (nro % i == 0){
                        Console.WriteLine(i);
                    }
                }
            }else{
                Console.WriteLine("El nro debe ser mayor a cero");
            }
            Console.ReadLine();
        }
    }
}
