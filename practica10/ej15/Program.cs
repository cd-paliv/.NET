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
            string st = "";
            Console.Write("Ingrese el nombre del archivo: ");
            string nombre = Console.ReadLine();
            while(! nombre.Equals("")){
                st += nombre;
                st += ' '; //le agrego ' ' para poder pasar a array después con Split
                Console.Write("Ingrese el nombre del archivo: ");
                nombre = Console.ReadLine();
            }

            string[] nombres = st.Split(' ');
            Task<int[]> t = ContenidoAsync(nombres);

            foreach(int res in t.Result)
            {
                Console.Write($"{res} ");
            }

            Console.ReadKey();
        }

        static async Task<int[]> ContenidoAsync(string[] nombres)
        {
            int[] vectorCantPalabras = new int[nombres.Length];
            int i = 0;
            Task tAux = Task.Run( () => 
            {
                foreach(string nom in nombres){
                    try{
                        using (StreamReader sr = new StreamReader(nom))
                        {
                            int cantPalabras = 0;
                            while(! sr.EndOfStream){
                                //string[] str = sr.ReadLine().Split(' ');
                                cantPalabras += sr.ReadLine().Split(' ').Length;
                            }
                            vectorCantPalabras[i++] = cantPalabras;
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message + $" | Nombre: {nom}");
                    }
                }
                
            });
            //tAux.Start();
            await Task.WhenAll(tAux); //WhenAll crea una tarea que representa la finalización de todas las tareas
            return vectorCantPalabras;
        }
    }
}
