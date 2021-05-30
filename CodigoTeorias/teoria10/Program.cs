using System;
using System.Threading.Tasks;

namespace teoria10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task t = new Task(ImprimirA);
            //t.Start(); //comienza la tarea

            //Task t = PrintAsync(); //main obtiene el control de tarea iniciada
            Task<double> t2 = PrintAsync(); //main obtiene el control de tarea iniciada
            for(int i = 1; i < 100; i++){
                Console.Write("-");
            }
            //t.Wait(); //espera a que termine la tarea antes de seguir
            Console.Write($"\n Tiempo transcurrido: {t2.Result}\n"); //hace la espera asincrónica a que termine la tarea
            
            Console.ReadKey();
        }

        static void ImprimirA(){ //delegado de tipo Action
            for(int i = 1; i < 1000; i++) Console.Write("A");
            Console.Write("FIN");
        }

        static async Task<double> PrintAsync() //los metodos async pueden retornar: void o Task/Task<T>
        { //por el await se debe utilizar el operador await
            Task t = new Task(ImprimirA);
            DateTime inicio = DateTime.Now;
            t.Start();
            await t; //espera asincrónica de t
            //el await hace que el código que se encuentra después se ejecute recién cuando termine la tarea
            /*
            double mlseg = (DateTime.Now - inicio).TotalMilliseconds;
            Console.Write($"\n Tiempo transcurrido: {mlseg}\n");*/
            
            return (DateTime.Now - inicio).TotalMilliseconds; //devuelve la tarea iniciada
        }
    }
}
