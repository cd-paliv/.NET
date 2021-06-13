using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ej10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese nombre del primer archivo: ");
            String nomArchivo1 = Console.ReadLine();
            StreamReader sr1 = null;

            Console.Write("Ingrese nombre del segundo archivo: ");
            String nomArchivo2 = Console.ReadLine();
            StreamReader sr2 = null;

            Console.WriteLine("----------------------------------------------\n");
            //List<string> lista1;
            //List<string> lista2;
//HAY QUE USAR CONVERTALL
            try{
                sr1 = new StreamReader(nomArchivo1); //si no existen los archivos va a dar error
                sr2 = new StreamReader(nomArchivo2);
                List<string> lista1 = ArchivoToLista(sr1); //guardo el contenido del archivo en una lista
                List<string> lista2 = ArchivoToLista(sr2);

                IEnumerable<string> list = lista1.Intersect(lista2); //junto las dos listas en una sin repetidos
                
                List<int> posArchivo = new List<int>();
                foreach(string p in list){
                    Console.WriteLine($"Palabra \"{p}\"");
                    
                    posArchivo = GetPosiciones(p, sr1); //obtengo la posicion de la palabra p en el archivo 1
                    Console.Write("     |--Posiciones en Texto1:----->");
                    foreach(int pos in posArchivo){
                        Console.Write($" {pos}");
                    }

                    posArchivo = GetPosiciones(p, sr2);
                    Console.Write("\n     |--Posiciones en Texto2:----->");
                    foreach(int pos in posArchivo){
                        Console.Write($" {pos}");
                    }
                    
                    Console.WriteLine("\n");
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

        static List<int> GetPosiciones(string palabra, StreamReader sr)
        {
            sr.DiscardBufferedData();
            sr.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
            List<int> listaPos = new List<int>();
            int pos = 0;
            while(! sr.EndOfStream)
            {
                String linea = sr.ReadLine();
                if(linea.IndexOf(palabra) != -1){ //si la palabra se encuentra en esta linea
                    listaPos.Add(linea.IndexOf(palabra) + pos); //la agrego
                }
                pos += linea.Length;
            }
            return listaPos;
        }
    }
}
