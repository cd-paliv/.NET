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

            Console.WriteLine("----------------------------------------------\n");
            List<string> lista1;
            List<string> lista2;
//HAY QUE USAR CONVERTALL
            try{
                sr1 = new StreamReader(nomArchivo1);
                sr2 = new StreamReader(nomArchivo2);
                lista1 = ArchivoToLista(sr1);
                lista2 = ArchivoToLista(sr2);

                IEnumerable<string> list = lista1.Intersect(lista2);
                List<int> posArchivo = new List<int>();
                foreach(string p in list)
                {
                    posArchivo = GetPosiciones(p, sr1);
                    posArchivo = GetPosiciones(p, sr2);
                }

                List<PalabraPosiciones> final = posArchivo.ConvertAll(new Converter<string, PalabraPosiciones>(StringToPalabraPosiciones));

                //List<int> posArchivo = new List<int>();
                foreach(string p in list){
                    Console.WriteLine($"Palabra \"{p}\"");
                    
                    posArchivo = GetPosiciones(p, sr1);
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

        class StringToPalabraPosiciones
        {
            return 
        }
/*
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
    }*/

    class PalabraPosiciones
    {
        public string Palabra { private set; get; }
        public List<List<int>> Posiciones { private set; get; } = new List<List<int>>();

        public PalabraPosiciones(string palabra)
        {
            this.Palabra = palabra;
        }

        public List<int> GetPosiciones(StreamReader sr1, StreamReader sr2)
        {
            this.Posiciones.Add(GetPosiciones());
        }
        private List<int> GetPosiciones(string palabra, StreamReader sr)
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
            
        }
    }
}
