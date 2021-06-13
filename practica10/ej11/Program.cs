using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ej11
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
                    tareas.Add(SumatoriaAsync(a, b));
                    
                }
            }
            Task.WaitAll(tareas.ToArray());
        }

        static async Task SumatoriaAsync(int a, int b)
        {
            int[] n = {a, b};
            Task t = new Task( (o) =>
            {
                int[] aux = (int[])o;
                int a = aux[0];
                int b = aux[1];
                int suma = 0;

                for(int i = a; i <= b; i++)
                {
                    suma += i;
                }
                Console.WriteLine($"Suma desde {a} hasta {b} = {suma}");

            }, n);
            t.Start();
            await t;
        }

    }
}
