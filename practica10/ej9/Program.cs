using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ej9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task<int>> tareasA = new List<Task<int>>();
            List<Task<int>> tareasB = new List<Task<int>>();
            for (int n = 1; n <= 10; n++)
            {
                //  a. Resolverlo utilizando un constructor de la clase Task
                Task<int> t = new Task<int>( (o) => Sumatoria((int)o) , n );
                t.Start();
                
                //  b. Resolverlo utilizando el método StartNew de una instancia de TaskFactory
                Task<int> t2 = Task.Factory.StartNew( (o) => Sumatoria((int)o) , n );
                
                tareasA.Add(t);
                tareasB.Add(t2);
            }
            //Task.WaitAll(tareas.ToArray()); no lo necesito porque el t.Result espera a que termine la tarea
            foreach(Task<int> t in tareasA)
            {
                Console.WriteLine(t.Result);
            }
            
            foreach(Task<int> t in tareasB)
            {
                Console.WriteLine(t.Result);
            }
        }
        static int Sumatoria(int n)
        {
            int suma = 0;
            for(int i = 1; i <= n; i++)
            {
                suma += i;
            }
            return suma;
        }
    }
}
