using System;
using System.Threading.Tasks;

namespace ej2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task[] vector = new Task[100];
            for(int i = 0; i < 100; i++)
            {
                vector[i] = Task.Run( () => Imprimir() );
            }
            Task.WaitAll(vector);
        }

        static void Imprimir()
        {
            int idThread = System.Threading.Thread.CurrentThread.ManagedThreadId;
            int? idTarea = Task.CurrentId;
            Console.WriteLine($"Tarea: {idTarea} Thread: {idThread}");
        }

    }
}
