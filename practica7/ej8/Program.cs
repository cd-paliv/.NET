using System;
using System.Collections;

namespace ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable rango = Rango(6, 30, 3);
            IEnumerable potencias = Potencias(2, 10);
            IEnumerable divisibles = DivisiblesPor(rango, 6);
            foreach (int i in rango)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            foreach (int i in potencias)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            foreach (int i in divisibles)
            {
                Console.Write(i + " ");
            }
            Console.ReadKey();
        }

        public static IEnumerable Rango(int i, int j, int p)
        {
            for(int x = i; x <= j; x += p){
                yield return x;
            }
        }

        public static IEnumerable Potencias(int b, int k)
        {
            for(int x = 1; x <= k; x++){
                yield return (int) Math.Pow(b, x);
            }
        }

        public static IEnumerable DivisiblesPor(IEnumerable e, int i)
        {
            foreach(int dato in e){
                if(dato % i == 0){
                    yield return dato;
                }
            }
        }
    }
}
