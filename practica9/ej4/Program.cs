using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ej4
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaGenerica<int> lista = new ListaGenerica<int>();
            lista.AgregarAdelante(3);
            lista.AgregarAdelante(100);
            lista.AgregarAtras(10);
            lista.AgregarAtras(11);
            lista.AgregarAdelante(0);
            IEnumerator<int> enumerador = lista.GetEnumerator();
            while (enumerador.MoveNext())
            {
                int i = enumerador.Current;
                Console.Write(i + " ");
            }

            Console.ReadKey();
        }
    }

    class Nodo<T>
    {
        public T Valor { get; private set; }
        public Nodo<T> Proximo { get; set; } = null;
        public Nodo(T valor) => Valor = valor;
    }

    class ListaGenerica<T> : IEnumerable<T>
    {
        private Nodo<T> _nodo = null;

        public void AgregarAdelante(T dato)
        {
            Nodo<T> nuevoN = new Nodo<T>(dato);
            if(_nodo == null){
                _nodo = nuevoN;
            }else{
                nuevoN.Proximo = _nodo;
                _nodo = nuevoN;
            }
        }
        
        public void AgregarAtras(T dato)
        {
            Nodo<T> nuevoN = new Nodo<T>(dato);
            if(_nodo == null){
                _nodo = nuevoN;
            }else{
                Nodo<T> aux = _nodo;
                while(aux.Proximo != null){
                    aux = aux.Proximo;
                }
                aux.Proximo = nuevoN;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            
            Nodo<T> actual = _nodo;
            while(actual != null){
                yield return actual.Valor;
                actual = actual.Proximo;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


}
