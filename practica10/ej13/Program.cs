using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ej13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese el nombre del archivo: ");
            Task<string> t = ContenidoAsync(Console.ReadLine());

            Console.WriteLine(t.Result); //imprime st que fue devuelto una vez terminó la tarea

            Console.ReadKey();
        }

        static async Task<string> ContenidoAsync(string nombre)
        {
            string st = "";
            Task tAux = new Task( () => 
            {
                try{
                    using (StreamReader sr = new StreamReader(nombre))
                    { //si no existe el archivo tira Exception
                        while(! sr.EndOfStream){
                            st += sr.ReadLine() + "\n";
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
            tAux.Start();
            await tAux; //espero que la tarea termine para hacer return
            return st;
        }
    }
}
