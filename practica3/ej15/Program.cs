using System;

namespace ej15
{
    class Program
    {
        static void Main()
        {
            int x = 0;
            try
            {
                Console.WriteLine(1.0 / x); //Da infinito
                Console.WriteLine(1 / x); //Attempted to divide by zero.
                Console.WriteLine("todo OK");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
