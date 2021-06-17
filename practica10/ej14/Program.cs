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
            Task<int> t = ContenidoAsync2(Console.ReadLine());
            
            Console.WriteLine(t.Result); //9

            Console.ReadKey();
        }

        static async Task<int> ContenidoAsydnc2(string nombre)
        {
            string palabras = await ContenidoAsync(nombre);
            string[] palabrasxd = palabras.Split(' ');

            return palabrasxd.Length;
        }
    }
}
