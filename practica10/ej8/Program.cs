using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tareas = new List<Task>();
            for (int a = 1; a <= 3; a++)
            {
                for (int b = a + 2; b <= a + 4; b++)
                {
                    tareas.Add( () => SumatoriaAsync(a, b) );
                    
                }
            }
            Task.WaitAll(tareas.ToArray());
        }

        static int Sumatoria(int a, int b)
        {
            int suma = 0;
            for(int i = a; i <= b; i++)
            {
                suma += i;
            }
        }

        static async Task SumatoriaAsync(int a, int b)
        {
            Task<int> t = new Task<int>(Sumatoria);
            t.Start();
            await t;
            Console.WriteLine($"Suma desde {a} hasta {b} = {t.Result}");
        }
    }
}
