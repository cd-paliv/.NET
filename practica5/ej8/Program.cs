using System;
using System.Collections;

namespace ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class ListaDePersonas
    {
        private Hashtable ht = new Hashtable();
        public void Agregar(Persona p)
        {
            ht[p.DNI] = p;
        }
    } //LO HAGO EN EJ7
    
}
