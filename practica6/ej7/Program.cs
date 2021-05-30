using System;

namespace ej7
{
    class Program
    {
        static void Main(string[] args)
        {
            Imprimidor.Imprimir(new A(), new B(), new C(), new D());
        }
    }

    class A {
        protected char id;
        public A() => id = 'A';
        public A(char x) => id = x;
        public void Imprimir() => Console.WriteLine($"Soy una instancia {id}");
    }
    class B : A {
        public B() : base('B') {}
    }
    class C : A {
        public C() : base('C') {}
    }
    class D : A {
        public D() : base('D') {}
    }

    static class Imprimidor{
        public static void Imprimir(params object[] vector){
            foreach(A a in vector){
                a.Imprimir();
            }
        }
    }
}
