using System;

namespace ej11
{
    class Program
    {
        static void Main(string[] args)
        {
            object o = 5;
            Procesar(o, o); //dynaic dynamic
            Procesar((dynamic)o, o); //entero objeto
            Procesar((dynamic)o, (dynamic)o); //entero objeto
            Procesar(o, (dynamic)o); //dynamic dynamic
            Procesar(5, 5); //entero objeto
        }
        static void Procesar(int i, object o) {
            Console.WriteLine($"entero: {i} objeto:{o}");
        }
        static void Procesar(dynamic d1, dynamic d2) {
            Console.WriteLine($"dynamic d1: {d1} dynamic d2:{d2}");
        }
    }
}
