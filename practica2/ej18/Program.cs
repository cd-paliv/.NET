using System;

namespace ej18
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5, m = 10;
            swap(ref n, ref m);
            Console.WriteLine(n +" "+ m);
        }

        static void swap(ref int x, ref int y){
            int tmp = x;
            x = y;
            y = tmp;

        }
    }
}
