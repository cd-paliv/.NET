﻿using System;

namespace ej11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("10/3 = " + 10 / 3); //3
            Console.WriteLine("10.0/3 = " + 10.0 / 3); //3,33333...
            Console.WriteLine("10/3.0 = " + 10 / 3.0); //idem
            int a = 10, b = 3;
            Console.WriteLine("Si a y b son variables enteras, si a=10 y b=3");
            Console.WriteLine("entonces a/b = " + a / b); //3
            double c = 3;
            Console.WriteLine("Si c es una variable double, c=3");
            Console.WriteLine("entonces a/c = " + a / c);
            Console.ReadLine();
        }
    }
}
