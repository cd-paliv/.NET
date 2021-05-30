using System;
using System.Collections;

namespace ej11
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList a = new ArrayList() {1,2,3,4};
            a.Remove(5); //no hace nada xq elemento 5 no está
            //a.RemoveAt(5); fuera de rango
            for (int i = 0; i < a.Count; i++){
                Console.WriteLine(a[i]);
            }
        }
    }
}
