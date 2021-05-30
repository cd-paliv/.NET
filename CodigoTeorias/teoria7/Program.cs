using System;
using System.Collections;

namespace teoria7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            IImprimible[] vector = new IImprimible[]{
                new Moto("Zanella"),
                new Empleado("Juan"),
                new Moto("Gilera")
            };
            foreach (IImprimible o in vector){
                o.Imprimir();
            }*/
            Empleado e1 = new Empleado("Juan") { Legajo = 79 };
            Empleado e2 = new Empleado("Adriana") { Legajo = 123 };
            Empleado e3 = new Empleado("Diego") { Legajo = 12 };
            Pyme miPyme = new Pyme(e1, e2, e3);
            foreach(Empleado e in miPyme)
            {
                e.Imprimir();
            }

            
            ArrayList lista = new ArrayList(){
                new Empleado("Juan") { Legajo = 79 },
                new Empleado("Adriana") { Legajo = 123 },
                new Empleado("Diego") { Legajo = 12 }
            };
            lista.Sort();
            foreach(Empleado e in lista)
            {
                e.Imprimir();
            }
        }
    }

    interface IImprimible{
        void Imprimir();
    }

    class Persona{
        protected String nombre;
    }
    class Empleado : Persona, IImprimible, IComparable
    {
        public int Legajo {get; set;}
        public Empleado(String nombre) => this.nombre = nombre;

        public void Imprimir()
        {
            Console.Write($"Soy el empleado {nombre}");
            Console.WriteLine($", Legajo: {Legajo}" );
        }

        public int CompareTo(object obj)
        {
            string st1 = this.nombre;
            string st2 = (obj as Empleado).nombre;
            Console.WriteLine(st1.CompareTo(st2));
            return st1.CompareTo(st2);
        }
    }

    class Automotor{
        protected String marca;
    }
    class Moto : Automotor, IImprimible{
        public Moto(String marca) => this.marca = marca;

        public void Imprimir() => Console.WriteLine($"Moto {marca}");
    }

    class ComparadorPorLegajo : IComparer
    {
        public bool Descendente { get; set; } = false;
        public int Compare(object x, object y)
        {
            Empleado e1 = x as Empleado;
            Empleado e2 = y as Empleado;
            int result = e1.Legajo.CompareTo(e2.Legajo);
            if (Descendente)
            {
                result = -result;
            }
            return result;
        }
    }

    class Pyme : IEnumerable{
        Empleado[] emp = new Empleado[3];
        public Pyme(Empleado e1, Empleado e2, Empleado e3){
            emp[0] = e1;
            emp[1] = e2;
            emp[2] = e3;
        }
        public IEnumerator GetEnumerator()
        {
            return emp.GetEnumerator();
        }
    }
}
