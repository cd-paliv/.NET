using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

namespace ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese nombre del archivo: ");
            String nomArchivo = Console.ReadLine();
            StreamReader sr = null;

            try{
                sr = new StreamReader(nomArchivo);
                SortedDictionary<string, int> dic = new SortedDictionary<string, int>();
                while(! sr.EndOfStream)
                {
                    String linea = sr.ReadLine();
                    string[] vString = linea.Split(' ');
                    foreach(string palabra in vString){
                        if(palabra != ""){
                            if(dic.ContainsKey(palabra)){
                                dic[palabra]++;
                            }else{
                                dic.Add(palabra, 1); //agrego la palabra con la cantidad de ocurrencias (1) al diccionario
                            }
                        }
                    }
                    
                }
                foreach(KeyValuePair<string, int> clave in dic){
                    Console.WriteLine($"{clave.Key}: {clave.Value}");
                }
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
            finally{
                if(sr != null){
                    sr.Dispose();
                }
            }
            Console.ReadKey();
        }
    }
}
