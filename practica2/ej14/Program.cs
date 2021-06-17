using System;

namespace ej14
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 2; i < Convert.ToInt32(args[0]); i++){
                if (esPrimo(i)){
                    Console.WriteLine(i);
                }
            }
        }

        static bool esPrimo(int n){
            bool esP = false;
            if ((n % 2 != 0) && (Math.Sqrt(n) % 2 != 0)){ //si el nro es par y tiene una raíz cuadrada par entonces es primo
                esP = true;
            }
            return esP;
        }
    }
}
