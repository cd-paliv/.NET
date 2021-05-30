using System;

namespace ej16
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sigue = true;
            int tot = 0;
            while(sigue){
                try
                {
                    Console.WriteLine("Ingrese un numero entero");
                    string entrada = Console.ReadLine();
                    if(entrada.Length == 0) sigue = false;
                    else{
                        tot += Int32.Parse(entrada);
                        Console.WriteLine($"Numero ingresado: {entrada} | Suma: {tot}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ERROR: Ingrese un valor numerico entero. (Error: {e.Message})");
                }
            }
        }
    }
}
