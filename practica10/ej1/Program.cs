using System;
using System.Threading.Tasks;

namespace ej1
{
    class Program
    {
        private delegate void Saludo(); //d
        static void Main(string[] args)
        {
            //a.
            Task ta = new Task(Saludar);
            ta.Start();
            //b.
            Task tb = Task.Run( () => Saludar() );
            //c.
            Task tc = Task.Run( () => Console.WriteLine("c. Hello World!") );
            //d.
            Saludo s1 = new Saludo(Saludar);
            Task td = Task.Run( () => s1.Invoke() );

            Task.WaitAll(ta, tb, tc, td);
        }
        static void Saludar()
        {
            Console.WriteLine("Hello World!");
        }
    }
}
