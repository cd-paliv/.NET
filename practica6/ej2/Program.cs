using System;

namespace ej1
{
    class Program
    {
        static void Main(string[] args)
        {
            A[] vector = new A[] { new C(1), new D(2), new B(3), new D(4), new B(5) };
            //2.a
            foreach (A a in vector){
                if(a is B && a is not C && a is not D){
                    a.Imprimir();
                }
            }
            //2.b
            foreach (A a in vector){
                if(a.GetType() == typeof(B)){
                    a.Imprimir();
                }
            }
        }
    }

    class A
    {
        protected int _id;
        public A(int id) => _id = id;
        public virtual void Imprimir() => Console.WriteLine($"A_{_id}");
    }
    class B : A
    {
        protected int _idB;
        public B(int id) : base(id) => _idB = id;
        public override void Imprimir()
        {
            Console.Write($"B_{_idB} --> ");
            base.Imprimir();
            
        }
    }
    class C : B
    {
        protected int _idC;
        public C(int id) : base(id) => _idC = id;
        public override void Imprimir()
        {
            Console.Write($"C_{_idC} --> ");
            base.Imprimir();
            
        }
    }
    class D : C
    {
        protected int _idD;
        public D(int id) : base(id) => _idD = id;
        public override void Imprimir()
        {
            Console.Write($"D_{_idD} --> ");
            base.Imprimir();
        }
    }
}
