using System;
using System.Text;

namespace ej10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un nro entero");
            int nro = Convert.ToInt32(Console.ReadLine());
            binario(nro);
            binarioSB(nro);
            Console.ReadKey();


            static void binario(int n){
                DateTime inicio = DateTime.Now;
                Console.WriteLine("Nro: "+n);
                String cadena = "";
                while (n > 0){
                    cadena = (int)n % 2 + cadena;
                    n = (int)(n / 2);
                }
                Console.WriteLine(" |en binario: " +cadena);
                DateTime final = DateTime.Now;
                Console.WriteLine("TIEMPO 1: " + final.Subtract(inicio));
            }

            static void binarioSB(int n){
                DateTime inicio = DateTime.Now;
                Console.WriteLine("Nro: "+n);
                StringBuilder sb = new StringBuilder();
                while (n > 0){
                    sb.Insert(0, (n % 2).ToString());
                    n = (int)(n / 2);
                }
                Console.WriteLine(" |en binario: " +sb.ToString());
                DateTime final = DateTime.Now;
                Console.WriteLine("TIEMPO 2: " + final.Subtract(inicio));
            }
        }
    }
}
