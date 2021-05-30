using System;

namespace ej7
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 10;
            var x = i * 1.0; //x = double
            var y = 1f; //y = single
            var z = i * y; //z = single
            Console.WriteLine(x.GetType());
            Console.WriteLine(y.GetType());
            Console.WriteLine(z.GetType());
            //The Single value type represents a single-precision 32-bit number with
            //values ranging from negative 3.402823e38 to positive 3.402823e38, as
            //well as positive or negative zero
        }
    }
}
