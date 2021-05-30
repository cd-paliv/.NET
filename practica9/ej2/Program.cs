using System;
using System.Collections;
using System.Collections.Generic;

namespace ej2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ej1
            ArrayList lista=new ArrayList() {"hola",7,'A'};
            string st = Get<string>(lista,0);
            int i = Get<int>(lista,1);
            char c = Get<char>(lista,2);
            Console.WriteLine($"{st} {i} {c}");

            //Ej2
            int[] vector1 = new int[] { 1, 2, 3 };
            bool[] vector2 = new bool[] { true, true, true };
            string[] vector3= new string[] { "uno", "dos", "tres" };
            Set<int>(vector1, 110, 2);
            Set<bool>(vector2, false, 1);
            Set<string>(vector3, "Hola Mundo!", 0);
            Imprimir(vector1);
            Imprimir(vector2);
            Imprimir(vector3);
        }

        //Ej1
        static T Get<T>(ArrayList l, int pos)
        {
            return (T)l[pos];
        }

        //Ej2
        static T[] Set<T>(T[] v, T dato, int pos)
        {
            v[pos] = dato;
            return v;
        }
        static void Imprimir<T>(T[] vector)
        {
            Console.WriteLine($"{vector[0]} {vector[1]} {vector[2]}");
        }
    }
}
