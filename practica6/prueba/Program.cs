using System;

namespace prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            A p1 = new A(3);
            B p2 = new B(5);
            p2.Imprimir();
            p1.Imprimir();
        }
    }

    class A{
        protected int _id;
        public A(int id) => _id = id;
        public virtual void Imprimir() => Console.WriteLine($"A_{_id}");
    }

    class B : A
    {
        protected int _id2;
        public B(int id) : base(id) => _id2 = id;
        public override void Imprimir()
        {
            base.Imprimir();
            Console.WriteLine($"B_{_id2}");
        }

    }
}
