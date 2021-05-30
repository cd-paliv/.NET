using System;
using System.Threading.Tasks;

namespace ej4
{
    class Program
    {
        private delegate void Imp(object o);
        static void Main(string[] args)
        {
            //Imp i1 = new Imp(Imprimir);

            Task[] v = new Task[100];
            //Imp i1 = new Imp( () => Imprimir(v.Length) );
            for(int i = 0; i < 100 ; i++)
            {
                v[i] = Task.Factory.StartNew( () => new Imp(Imprimir) );
            }
            
            Task.WaitAll(v);
            Console.ReadKey();
        }

        static void Imprimir(object o)
        {
            Console.Write($"{o} - ");
        }
    }
}
