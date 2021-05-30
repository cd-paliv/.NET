using System;
using System.Collections;

namespace ej1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList() {
                new Persona(),
                new Auto()
            };
            foreach(IComercial c in lista)
            {
                c.Importa();
            }
            foreach(IImportante i in lista)
            {
                i.Importa();
            }
            (lista[0] as Persona).Importa();
            (lista[1] as Auto).Importa();

            Console.ReadKey();
        }
    }

    //ej3
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

    class Persona : IAtendible, IComercial, IImportante
    {
        public void SeAtiende() => Console.WriteLine("Atendiendo persona");
        void IComercial.Importa() => Console.WriteLine("Persona vendiendo al exterior");
        void IImportante.Importa() => Console.WriteLine("Persona que importa");
        public void Importa() => Console.WriteLine("Metodo Importar() de la clase Persona");
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
    
    class Perro : IVendible, IAtendible, ILavable
    {
        public void SeVendeA(Persona p) => Console.WriteLine("Vendiendo perro a persona");
        public void SeAtiende() => Console.WriteLine("Atendiendo perro");
        public void SeLava() => Console.WriteLine("Lavando perro");
        public void SeSeca() => Console.WriteLine("Secando perro");
    }
}
