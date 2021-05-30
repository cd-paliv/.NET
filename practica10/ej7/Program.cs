using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ej7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tareas = new List<Task>();
            for (int n = 1; n <= 10; n++)
            {
                tareas.Add( Task.Factory.StartNew( (o) => Sumatoria((int)o), n ) );
            }
            Task.WaitAll(tareas.ToArray());
        }

        static void Sumatoria(int n)
        {
            int suma = 0;
            for(int i = 1; i <= n; i++)
            {
                suma += i;
            }
            Console.WriteLine($"Suma desde 1 hasta {n} = {suma}");
        }
    }
}
