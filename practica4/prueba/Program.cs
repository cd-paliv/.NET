using System;

namespace prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Nodo newItem = new Nodo(10);
            Nodo n = new Nodo(15);
            newItem.SigNodo = n;
            Console.WriteLine("Dato: " + newItem.Dato);
            Console.WriteLine(newItem.SigNodo.Dato);
        }
    }

    class Nodo
    {
        private int dato;
        private Nodo sigNodo;

        public Nodo(int valor){
            this.dato = valor;
        }

        public int Dato {get{return dato;} set{dato = value;}}

        public Nodo SigNodo {get{return sigNodo;} set{sigNodo = value;}}
    }
}
