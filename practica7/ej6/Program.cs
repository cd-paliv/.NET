using System;
using System.Collections;

namespace ej6
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList() {
                new Persona() {Nombre="Ana María"},
                new Perro() {Nombre="Sultán"},
                new Persona() {Nombre="Ana"},
                new Persona() {Nombre="José Carlos"},
                new Perro() {Nombre="Chopper"}
            };
            lista.Sort(new ComparadorLongitudNombre()); //sobrecarga del método con un objeto comparador que implementa IComparer
            foreach (INombrable n in lista)
            {
                Console.WriteLine($"{n.Nombre.Length}: {n.Nombre}");
            }
        }
    }

    //ej6
    interface INombrable
    {
        String Nombre {get; set;}
    }

    class ComparadorLongitudNombre : IComparer
    {
        public bool Descendente {get; set;} = false; //permite ordenar ascendente o descendentemente
        public int Compare(object x, object y) //método del IComparer
        {
            INombrable n1 = x as INombrable;
            INombrable n2 = y as INombrable;
            int res = n1.Nombre.Length.CompareTo(n2.Nombre.Length); //comparo longitud de nombres: si n1<n2=-1, si n1>n2=1
            if(Descendente) //si quiero de mayor a menor
                res = -res; //hago del resultado negativo, para guardar al revés los res
            return res;
        }
    }
    
    class Persona : IAtendible, IComercial, IImportante, INombrable, IComparable
    {
        public String Nombre {get; set;}
        public void SeAtiende() => Console.WriteLine("Atendiendo persona");
        void IComercial.Importa() => Console.WriteLine("Persona vendiendo al exterior");
        void IImportante.Importa() => Console.WriteLine("Persona que importa");
        public void Importa() => Console.WriteLine("Metodo Importar() de la clase Persona");
        public override string ToString(){
            return $"{Nombre} es una persona";
        }
        public int CompareTo(object obj){
            string st1 = this.GetType().ToString();
            if((obj as INombrable) == null)
                return 1; //lo pongo al final
            string st2 = (obj as INombrable).GetType().ToString();
            int res = st2.CompareTo(st1);
            if(res != 0) //si es 0 tienen la misma longitud y tengo que ordenar alfabéticamente
                return res;
            return this.Nombre.CompareTo((obj as INombrable).Nombre);
        }
    }

    class Perro : IVendible, IAtendible, ILavable, INombrable, IComparable
    {
        public String Nombre {get; set;}
        public void SeVendeA(Persona p) => Console.WriteLine("Vendiendo perro a persona");
        public void SeAtiende() => Console.WriteLine("Atendiendo perro");
        public void SeLava() => Console.WriteLine("Lavando perro");
        public void SeSeca() => Console.WriteLine("Secando perro");
        public override string ToString(){
            return $"{Nombre} es un perro";
        }
        public int CompareTo(object obj){
            string st1 = this.GetType().ToString();
            if((obj as INombrable) == null)
                return 1;
            string st2 = (obj as INombrable).GetType().ToString();
            int res = st2.CompareTo(st1);
            if(res != 0) //si es igual a 0 son del mismo tipo, hay que ordenar por nombre
                return res;
            return this.Nombre.CompareTo((obj as INombrable).Nombre);
        }
    }


    interface IComercial
    {
        public void Importa();
    }
    interface IImportante
    {
        public void Importa();
    }

    class Auto : IVendible, ILavable, IReciclable, IComercial, IImportante
    {
        public void SeVendeA(Persona p) => Console.WriteLine("Vendiendo auto a persona");
        public void SeLava() => Console.WriteLine("Lavando auto");
        public void SeSeca() => Console.WriteLine("Secando auto");
        public void SeRecicla() => Console.WriteLine("Reciclando auto");
        void IComercial.Importa() => Console.WriteLine("Auto que se vende al exterior");
        void IImportante.Importa() => Console.WriteLine("Auto que importa");
        public void Importa() => Console.WriteLine("Metodo Importar() de la clase Auto");
    }





    static class Procesador
    {
        public static void Alquilar(this IAlquilable x, Persona p) => x.SeAlquilaA(p);
        public static void Vender(this IVendible x, Persona p) => x.SeVendeA(p);
        public static void Atender(this IAtendible x) => x.SeAtiende();
        public static void Devolver(this IAlquilable x, Persona p) => x.SeDevuelve(p);
        public static void Lavar(this ILavable a) => a.SeLava();
        public static void Reciclar(this IReciclable a) => a.SeRecicla();
        public static void Secar(this ILavable a) => a.SeSeca();

    }

    interface IAlquilable
    {
        public void SeAlquilaA(Persona p);
        public void SeDevuelve(Persona p);
    }
    interface IVendible
    {
        public void SeVendeA(Persona p);
    }
    interface ILavable
    {
        public void SeLava();
        public void SeSeca();
    }
    interface IReciclable
    {
        public void SeRecicla();
    }
    interface IAtendible
    {
        public void SeAtiende();
    }

    class Libro : IAlquilable, IReciclable
    {
        public void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando libro a persona");
        public void SeDevuelve(Persona p) => Console.WriteLine("Libro devuelto por persona");
        public void SeRecicla() => Console.WriteLine("Reciclando libro");
    }

    class Pelicula : IAlquilable, IVendible
    {
        public void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula a persona");
        public void SeDevuelve(Persona p) => Console.WriteLine("Pelicula devuelta por persona");
        public void SeVendeA(Persona p) => Console.WriteLine("Vendiendo pelicula a persona");
    }

    class PeliculaClasica : Pelicula
    {
        new public void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula clasica a persona");
        new public void SeDevuelve(Persona p) => Console.WriteLine("Pelicula clasica devuelta por persona");
        new public void SeVendeA(Persona p) => Console.WriteLine("Vendiendo pelicula clasica a persona");
    }
}
