using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese nombre del primer archivo: ");
            String nomArchivo1 = Console.ReadLine();
            StreamReader sr1 = null;

            Console.Write("Ingrese nombre del primer archivo: ");
            String nomArchivo2 = Console.ReadLine();
            StreamReader sr2 = null;

            List<string> lista1;
            List<string> lista2;

            try{
                sr1 = new StreamReader(nomArchivo1);
                sr2 = new StreamReader(nomArchivo2);
                lista1 = ArchivoToLista(sr1);
                lista2 = ArchivoToLista(sr2);

                IEnumerable<string> list = lista1.Intersect(lista2);
                foreach(string p in list){
                    Console.Write($"{p} - ");
                }
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
                if(sr1 != null){
                    sr1.Dispose();
                }
                if(sr2 != null){
                    sr2.Dispose();
                }
            }
            Console.ReadKey();
        }

        static List<string> ArchivoToLista(StreamReader ar)
        {
            List<string> lista = new List<string>();
            while(! ar.EndOfStream)
            {
                String linea = ar.ReadLine();
                string[] vString = linea.Split(' ');
                foreach(string palabra in vString){
                    if(palabra != ""){
                        lista.Add(palabra);
                    }
                }
            }
            lista.Sort();
            return lista;
        }
    }
}
