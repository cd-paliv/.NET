using System;

namespace teoria8
{
    delegate int FuncionEntera(int n);
    delegate void Accion();
    class Program
    {
        static void Main(string[] args)
        {
            //f(10)  =  f.Invoke(10)
            //[f = SumaUno] = [f = new FuncionEntera(SumaUno)]
            
            int[] v = new int[] { 11, 5, 90 };
            //Aplicar(v, SumaDos); //pasa SumaDos en una variable de tipo delegado
            FuncionEntera f = delegate(int n){
                return n * 2;
            };
            //Eso ^ es igual a [f = (int n) => {return n*2};] = [f = n => n * 2;]
            Aplicar(v, f);
            foreach (int i in v) Console.Write(i + " ");

            //Aplicar(v, SumaUno);
            //Aplicar(v, delegate(int n) { return n + 10; } );
            Aplicar(v, n => n+10);
            Console.WriteLine();
            foreach (int i in v) Console.Write(i + " ");
            
            Console.WriteLine("\n---------------------");

            Accion a;
            a = Metodo1;
            a = a + Metodo2; //se encolan los métodos en a
            a += () => Console.WriteLine("Expresión lambda"); //delegate anónimo sin parámetros
            a(); //un delegado puede llamar a más métodos cuando se invoca = MULTIDIFUSIÓN
            a -= Metodo2; //desencolar
            Delegate[] encolados = a.GetInvocationList(); //devuelve lista de delegados encolados
            for(int i = encolados.Length - 1; i >= 0; i--)
            {
                (encolados[i] as Accion)();
            }

            Console.ReadKey();

        }

        static int SumaUno(int n) => n + 1;
        static int SumaDos(int n) => n + 2;

        static void Aplicar(int[] v, FuncionEntera f)
        {
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = f(v[i]);
            }
        }

        static void Metodo1() => Console.WriteLine("Ejecutando Método1");
        static void Metodo2() => Console.WriteLine("Ejecutando Método2");


    }
}
