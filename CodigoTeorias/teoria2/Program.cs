using System;

namespace teoria2
{
    class Program
    {
        static void Main(string[] args)
        {
            object obj = 7.3;
            Console.WriteLine(obj.GetType()); //devuelve el tipo más exacto del objeto
            Console.WriteLine(obj);
            obj = 'A';
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj);
            obj = "Casa";
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj);
            obj = 4;
            Console.WriteLine(obj.GetType());
            Console.WriteLine(obj);
        }
    }
}
