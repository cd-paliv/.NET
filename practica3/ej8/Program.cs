using System;

namespace ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 3L;
            dynamic b = 32;
            object obj = 3;
            a = a * 2.0; //long es int64, no le puedo multiplicar double, debería hacer Convert.ToInt64(2.0) para hacer la operación
            b = b * 2.0;
            b = "hola";
            obj = b;
            b = b + 11;
            obj = obj + 11; //no se puede sumar objetos e int
            var c = new { Nombre = "Juan" };
            var d = new { Nombre = "María" };
            var e = new { Nombre = "Maria", Edad = 20 };
            var f = new { Edad = 20, Nombre = "Maria" };
            f.Edad = 22; //los tipos anónimos son de sólo lectura
            d = c; //a un tipo anónimo le asigno el mismo tipo anónimo pero con otro valor, por lo visto vale
            e = d; //anónimo sólo lecutra
            f = e; //anónimo sólo lectura
            }

    }
}
