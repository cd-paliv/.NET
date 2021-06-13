using System;
using System.Collections;
using System.IO;

namespace ej5
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaDeEnteros lista1 = new ListaDeEnteros();
            for (int i = 1; i <= 10; i++)
            {
                lista1.Agregar(i);
            }
            foreach (int i in lista1)
            {
                Console.Write(i + "-");
            }
            Console.WriteLine();
            ListaDeEnteros lista2 = lista1.Seleccionar(n => n % 2 == 0);
            ListaDeEnteros lista3 = lista2.Aplicar(n => n * 5);
            ListaDeEnteros lista4 = lista1.Seleccionar(n => n > 7).Aplicar(n => n + 10);
            ListaDeEnteros lista5 = ListaDeEnteros.Combinar(lista3, lista4, (x, y) => x + y);
            lista1.Imprimir();
            lista2.Imprimir();
            lista3.Imprimir();
            lista4.Imprimir();
            lista5.Imprimir();
            ListaDeEnteros.Combinar(lista5, lista3, (x, y) => x + 2 * y).Imprimir();

            Console.ReadKey();
        }
    }

    delegate bool OperacionBool(int n);
    delegate int Operacion(int n);
    delegate int OperacionDos(int x, int y);
    
    //delegate object Operacion(int n); habría que castear cada operacion
    

    class ListaDeEnteros : IEnumerable
    {
        ArrayList lista = new ArrayList();
        public void Agregar(int i) => lista.Add(i);
        public int Cantidad => lista.Count;
        public ListaDeEnteros Seleccionar(OperacionBool delegado)
        {
            ListaDeEnteros nuevaL = new ListaDeEnteros();
            foreach(int elem in this)
            {
                if(delegado(elem)){
                    nuevaL.Agregar(elem);
                }
            }
            return nuevaL;
        }
        public ListaDeEnteros Aplicar(Operacion delegado)
        {
            ListaDeEnteros nuevaL = new ListaDeEnteros();
            foreach(int elem in this)
            {
                nuevaL.Agregar(delegado(elem));
            }
            return nuevaL;
        }
        public static ListaDeEnteros Combinar(ListaDeEnteros l1, ListaDeEnteros l2, OperacionDos delegado)
        {
            ListaDeEnteros nuevaL = new ListaDeEnteros();

            if(l1.Cantidad < l2.Cantidad){
                //lista2 tiene más elementos que lista1
                IEnumerable e1 = ElementosDe(l1); //todos los elem de la l1
                IEnumerator elem1 = e1.GetEnumerator(); //enumerador para poder recorrer l1
                foreach(int elem2 in l2)
                {
                    if(elem1.MoveNext()) //si tengo elementos en l1, le aplico la operación delegado junto con su correspondiente de la l2
                        nuevaL.Agregar(delegado((int)elem1.Current, elem2));
                    else nuevaL.Agregar(elem2); //si no me quedan más elementos en l1, simplemente agrego el resto a la lista.
                }
            }else{ //lista1 tiene más elementos que lista2
                IEnumerator elem2 = ElementosDe(l2).GetEnumerator();
                foreach(int elem1 in l1)
                {
                    if(elem2.MoveNext()) nuevaL.Agregar(delegado(elem1, (int)elem2.Current));
                    else nuevaL.Agregar(elem1);
                }
            }
            return nuevaL;
        }
        private static IEnumerable ElementosDe (ListaDeEnteros lista)
        {
            foreach(int elem in lista)
            {
                yield return elem;
            }
            
        }
        public void Imprimir()
        {
            foreach(int elem in this)
            {
                Console.Write(elem + ", ");
            }
            Console.WriteLine();
        }
        public IEnumerator GetEnumerator()
        {
            return lista.GetEnumerator();
        }
    }
}
