using System;
using System.Threading.Tasks;

namespace ej3
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<double>[] vector = new Task<double>[4];
            for(int i = 0; i < 4; i++)
            {
                vector[i] = Task.Run( () => TaskAsync() );
            }
            Task.WaitAll(vector);
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Tarea {i} - Tiempo transcurrido {vector[i].Result}ms");
            }
        }

        static void Procesar()
        {
            for (int i = 0; i < 1000; i++)
            {
                string st = i.ToString();
            }
            Console.WriteLine("Fin del procesamiento");
        }

        static async Task<double> TaskAsync()
        {
            Task t = new Task(Procesar);
            DateTime inicio = DateTime.Now;
            t.Start();
            await t;
            return (DateTime.Now - inicio).TotalMilliseconds;
        }
    }
}
