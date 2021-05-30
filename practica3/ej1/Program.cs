using System;

namespace ej1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false; //la linea titilante que dice donde estás escribiendo, no está
            ConsoleKeyInfo k = Console.ReadKey(true); //ConsoleKeyInfo describe la tecla que se presionó
            while (k.Key != ConsoleKey.End){ //ConsoleKey.End = 1
                Console.Clear(); //mantiene la consola limpia
                Console.WriteLine($"{k.Modifiers}-{k.Key}-{k.KeyChar}"); //{shift, ctr, alt}-{tecla presionada}-{tecla presionada en modo ascii}
                k = Console.ReadKey(true);
            }
        }
    }
}
