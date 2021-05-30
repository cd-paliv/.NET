using System;

namespace ej9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribir dos palabras separadas por un blanco");
            string st = Console.ReadLine();
            int i = 0;
            bool exito = true;
            while ((exito) && (i < (st.Length-(i+1)))){
                if (st[i] == st [st.Length-(i+1)]){
                    i++;
                }else{
                    exito = false;
                }
            }
            Console.WriteLine(exito);
            Console.ReadLine();
        }
    }
}
