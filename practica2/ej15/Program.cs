using System;

namespace ej15
{
    class Program
    {
        static void Main(string[] args)
        {
            int nro = 5;

            Console.WriteLine(Fib(nro));
            Console.WriteLine(Fib2(nro));
        }

        static int Fib (int n) => n > 2 ? (Fib(n-1) + Fib(n-2)) : 1;

        static int Fib2(int n){
            if (n <= 2){
                return 1;
            }else{
                return Fib(n-1) + Fib(n-2);
            }
        }
    }
}
