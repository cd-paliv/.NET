using System;
using System.Collections;

namespace ej14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese nro entero: ");
            int n = Int32.Parse(Console.ReadLine());
            Console.Write("Ingrese la base (2, 8, 16) a la que desea pasar el nro: ");
            int b = Int32.Parse(Console.ReadLine());
            
            Console.WriteLine("-----------------------------------------------");
            Console.Write($"Numero: {n} | Base {b} \nResultado: ");
            if (b == 2 || b == 8) Bases(n,b);
            else Hexa(n);

            Console.ReadKey();
        }

        static void Bases(int nro, int b)
        {
            Stack pila = new Stack();
            int resto;
            while(nro > 0){
                resto = nro % b;
                pila.Push(resto);
                nro = nro / b;
            }
            while (pila.Count > 0) Console.Write(pila.Pop());
        }

        static void Hexa(int nro)
        {
            Stack pila = new Stack();
            while(nro > 0){
                int resto = nro % 16;
                if(resto < 10) pila.Push(resto);
                else pila.Push(getValores(resto));
                nro = nro / 16;
            }
            String st = "";
            while(pila.Count > 0) st += pila.Pop();
            Console.WriteLine(st);
        }
        static String getValores(int nro)
        {
            switch (nro)
            {
                case 10: return "A";
                case 11: return "B";
                case 12: return "C";
                case 13: return "D";
                case 14: return "E";
                case 15: return "F";
                default: return "";
            }
        }

        


/*
        //LO MISMO PERO DE FORMA RECURSIVA Y SIN PILA
        
        static void Bases(int nro, int b)
        {
            if(nro < b) Console.Write(nro);
            else{
                Bases(nro / b, b); //divido sucesivamente por 2 o por 8
                Console.Write(nro % b);
            }
        }

        static String Hexa(int nro){
            if (nro < 16) return nro.ToString();
            else{
                String st = Hexa(nro / 16);
                int resto = nro % 16;
                if(resto < 10) return st + Convert.ToString(resto); //
                else return st + getValores(resto); //si el resto es >10 significa que tiene que tomar los valores A, B, C, etc
            }
            
        }
        static String getValores(int nro)
        {
            switch (nro)
            {
                case 10: return "A";
                case 11: return "B";
                case 12: return "C";
                case 13: return "D";
                case 14: return "E";
                case 15: return "F";
                default: return "";
            }
        }
*/
    }
}
