using System;
using System.Collections;

namespace teoria3
{
    class Program
    {
        static void Main(string[] args)
        {
            string marca = "Ford";
            int modelo = 2000;
            string st;
            st = string.Format("Es un {0} año {1}", marca, modelo); //vector de objetos
            string st2 = $"Es un {marca} año {modelo}"; //cadena interpolada (admiten expresiones)
            Console.WriteLine(st);
            Console.WriteLine(st2);

            Console.WriteLine($"Es un {"Nissan",8} año {2000}"); //(,nroint) indica que ese valor va a ocupar esa cant de caracteres de ancho
            Console.WriteLine($"Es un {"Nissan",-8} año {2000}"); //(,-nroint) hace la alineacion a la izquierda

            double r = 2.417;
            Console.WriteLine($"Valor = {r:0.00}"); //redondea

            //colecciones
            ArrayList a = new ArrayList() {10, 20, 30, 40};
            a.Add(55); //agrega al final
            a.Remove(30); //elimina el valor 30 del vector si existe
            a.RemoveAt(1); //elimina el elemento de la pos 1
            for (int i = 0; i < a.Count; i++){
                Console.WriteLine(a[i]);
            }
            Console.WriteLine((int)a[0] + (int)a[1]); //para hacer op hay que castear
            Console.WriteLine("----");
            ArrayList b = new ArrayList() {1,2,3};
            string[] v = new string [] {"uno", "dos"};
            a.AddRange(v);
            for (int i = 0; i < a.Count; i++){
                Console.WriteLine(a[i]);
            }
        }
    }
}
