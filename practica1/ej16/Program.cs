using System;

namespace ej16
{
    class Program
    {
        static void Main(string[] args)
        {
            int a=24, b=0;
            if ((b != 0) & (a/b > 5)){ //habría que usar la secuencia de escape &&
                Console.WriteLine(a/b);
            }
            Console.ReadLine();
        }
    }
}
