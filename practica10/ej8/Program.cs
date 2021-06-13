using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tareas = new List<Task>(); //instancio una lista de tareas
            for (int a = 1; a <= 3; a++)
            {
                for (int b = a + 2; b <= a + 4; b++)
                {
                    int[] aux = {a, b}; //uso un vector de enteros para pasar por parámetro los valores de a y b
                    Task t = new Task( (o) => //un constructor de Task
                    {
                        int[] x = (int[])o; //me guardo el parámetro en una variable (porque no puedo indizar [] un tipo object)
                        Sumatoria(x[0], x[1]);
                    } ,
                    aux);
                    
                    t.Start(); //empiezo la tarea
                    tareas.Add(t);
                    
                }
            }
            Task.WaitAll(tareas.ToArray()); //espero a que terminen TODAS las tareas de la lista
        }

        static void Sumatoria(int a, int b)
        {
            int suma = 0;
            for(int i = a; i <= b; i++)
            {
                suma += i;
            }
            Console.WriteLine($"Suma desde {a} hasta {b} = {suma}");
        }
    }
}
