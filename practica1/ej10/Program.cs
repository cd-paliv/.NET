using System;

namespace ej10
{
    class Program
    {
        static void Main(string[] args)
        {
            const int fin = 1000;
            for (int i = 1; i <= fin; i++){
                if (i % 17 == 0){
                    Console.WriteLine(i + " es múltiplo de 17");
                }
                if (i % 29 == 0){
                    Console.WriteLine(i + " es múltiplo de 29");
                }
                i++;
            }
        }
    }
}
