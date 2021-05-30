using System;

namespace ej13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresar un nro real");
            double nro = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar otro nro real");
            double nro2 = double.Parse(Console.ReadLine());
            Console.WriteLine("La suma de los nros "+nro+" y "+nro2+" es:");
            Console.WriteLine(nro + nro2);
            Console.ReadLine();
        }
    }
}
