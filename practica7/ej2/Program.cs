using System;
using System.Collections;

namespace ej1
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto auto = new Auto();
            Libro libro = new Libro();
            Persona persona = new Persona();
            Perro perro = new Perro();
            Pelicula pelicula = new Pelicula();
            Procesador.Alquilar(pelicula, persona);
            Procesador.Alquilar(libro, persona);
            Procesador.Atender(persona);
            Procesador.Atender(perro);
            Procesador.Devolver(pelicula, persona);
            Procesador.Devolver(libro, persona);
            Procesador.Lavar(auto);
            Procesador.Reciclar(libro);
            Procesador.Reciclar(auto);
            Procesador.Secar(auto);
            Procesador.Vender(auto, persona);
            Procesador.Vender(perro, persona);
            Procesador.Lavar(perro);
            Procesador.Secar(perro);
            PeliculaClasica peliculaClasica = new PeliculaClasica();
            Procesador.Alquilar(peliculaClasica, persona);
            Procesador.Devolver(peliculaClasica, persona);
            Procesador.Vender(peliculaClasica, persona);


            Console.ReadKey();
        }
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
    
    class Auto : IVendible, ILavable, IReciclable
    {
        public void SeVendeA(Persona p) => Console.WriteLine("Vendiendo auto a persona");
        
        public void SeLava() => Console.WriteLine("Lavando auto");
        public void SeSeca() => Console.WriteLine("Secando auto");

        public void SeRecicla() => Console.WriteLine("Reciclando auto");
    }

    class Libro : IAlquilable, IReciclable
    {
        public void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando libro a persona");
        public void SeDevuelve(Persona p) => Console.WriteLine("Libro devuelto por persona");
        public void SeRecicla() => Console.WriteLine("Reciclando libro");

    }

    class Pelicula : IAlquilable
    {
        public void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula a persona");
        public void SeDevuelve(Persona p) => Console.WriteLine("Pelicula devuelta por persona");
    }

    class PeliculaClasica : Pelicula, IAlquilable, IVendible
    {
        new public void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula clasica a persona");
        new public void SeDevuelve(Persona p) => Console.WriteLine("Pelicula clasica devuelta por persona");
        public void SeVendeA(Persona p) => Console.WriteLine("Vendiendo pelicula clasica a persona");
    }

    class Persona : IAtendible
    {
        public void SeAtiende() => Console.WriteLine("Atendiendo persona");
    }
    
    class Perro : IVendible, IAtendible, ILavable
    {
        public void SeVendeA(Persona p) => Console.WriteLine("Vendiendo perro a persona");
        public void SeAtiende() => Console.WriteLine("Atendiendo perro");
        public void SeLava() => Console.WriteLine("Lavando perro");
        public void SeSeca() => Console.WriteLine("Secando perro");
    }
}
