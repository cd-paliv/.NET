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
            Task<int> t = ContenidoAsync(Console.ReadLine());
            
            Console.WriteLine(t.Result); //9

            Console.ReadKey();
        }

        static async Task<int> ContenidoAsync(string nombre)
        {
            int cantPalabras = 0;
            Task tAux = Task.Run( () => 
            {
                try{
                    using (StreamReader sr = new StreamReader(nombre))
                    {
                        while(! sr.EndOfStream){
                            //string[] str = sr.ReadLine().Split(' ');
                            cantPalabras += sr.ReadLine().Split(' ').Length; //spliteo porque quiero cantidad de palabras, no caracteres
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            });
            //tAux.Start();
            await tAux;
            return cantPalabras;
        }
    }
}
