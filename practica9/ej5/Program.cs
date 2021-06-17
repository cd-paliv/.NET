using System;
using System.Collections;
using System.Collections.Generic;

namespace ej7
{
    class Program
    {
        static void Main(string[] args)
        {
            Nodo<int> n = new Nodo<int>(7); //al crear Nodo<int> el compilador JIT crea el tipo real(construido)
            n.Insertar(3);
            n.Insertar(1);
            n.Insertar(5);
            n.Insertar(12);
            foreach (int elem in n.InOrder)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Altura: {n.Altura}");
            Console.WriteLine($"Cantidad: {n.CantNodos}");
            Console.WriteLine($"Mínimo: {n.ValorMinimo}");
            Console.WriteLine($"Máximo: {n.ValorMaximo}");

            Nodo<string> n2 = new Nodo<string>("hola");
            n2.Insertar("Mundo");
            n2.Insertar("XYZ");
            n2.Insertar("ABC");
            foreach (string elem in n2.InOrder)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Altura: {n2.Altura}");
            Console.WriteLine($"Cantidad: {n2.CantNodos}");
            Console.WriteLine($"Mínimo: {n2.ValorMinimo}");
            Console.WriteLine($"Máximo: {n2.ValorMaximo}");
            //Console.ReadKey();
        }

    }

    class Nodo<T> where T: IComparable<T>
    {
        private T dato;
        private Nodo<T> HI;
        private Nodo<T> HD;

        public Nodo(T valor)
        {
            dato = valor;
            HI = null;
            HD = null;
        }

        private T GetDato(){
            return dato;
        }
        
        public void Insertar(T valor)
        {
            if((this.dato).CompareTo(valor) < 0){
                if(HD == null){
                    this.HD = new Nodo<T>(valor);
                }else this.HD.Insertar(valor);
            }else if ((this.dato).CompareTo(valor) > 0){
                if(HI == null){
                    this.HI = new Nodo<T>(valor);
                }else this.HI.Insertar(valor);
            }
        }

        private void GetInorder(Nodo<T> n, ArrayList l)
        {
            if(n != null){
                GetInorder(n.HI, l);
                l.Add(n.dato);
                GetInorder(n.HD, l);
            }
        }
        public ArrayList InOrder
        {
            get{
                ArrayList l = new ArrayList();
                GetInorder(this, l);
                return l;
            }
        }


        private int calcularAltura(Nodo<T> n)
        {
            if(n != null){
                return 1 + Math.Max(calcularAltura(n.HI), calcularAltura(n.HD));
            }else return 0;
        }
        public int Altura
        {
            get => calcularAltura(this) - 1; //le resto la raíz xq tiene altura 0
        }

        
        
        private int Cantidad(Nodo<T> n, int cant)
        {
            if(n != null){
                return 1 + Cantidad(n.HI, cant) + Cantidad(n.HD, cant);
            }else return 0;
        }
        public int CantNodos
        {
            get => Cantidad(this, 0);
        }

        public T ValorMaximo
        {
            get{
                if(this != null){
                    Nodo<T> aux = this;
                    while(aux.HD != null)
                        aux = aux.HD;
                    return aux.GetDato();
                }else return this.dato;
            }
        }
/*
        public T vm()
        {
            if(HD == null) return HD.dato;
            else{
                HD.vm();
            }
        }*/
        public T ValorMinimo
        {
            get{
                if(this != null){
                    Nodo<T> aux = this;
                    while(aux.HI != null)
                        aux = aux.HI;
                    return aux.GetDato();
                }else return this.dato;
            }
        }
    }
}
