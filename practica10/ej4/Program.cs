using System;
using System.Threading.Tasks;

namespace ej4
{
    class Program
    {
        static void Main(string[] args)
        {
            Task[] v=new Task[100];
            for(int i = 0 ; i < 100 ; i++)
            {
                v[i] = new Task(Imprimir, i); //(o) => Imprimir(o) , i
                v[i].Start();
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
