using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ej9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task<int>> tareas = new List<Task<int>>();
            for (int n = 1; n <= 10; n++)
            {
                tareas.Add(SumatoriaAsync(n));
            }
            //Task.WaitAll(tareas.ToArray());
            foreach(Task<int> t in tareas)
            {
                Console.WriteLine(t.Result); //para imprimir el resultado espera a que termine la tarea
            }
        }
        static async Task<int> SumatoriaAsync(int n)
        {
            int suma = 0;
            Task t = Task.Run( () =>
            {
                for(int i = 1; i <= n; i++)
                {
                    suma += i;
                }
            } );
            await t;
            return suma;
        }
    }
}
