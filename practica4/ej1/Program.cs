using System;

namespace ej1
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona[] p = new Persona[4]; //guardo la memoria para el vector
            for(int i = 0; i < p.Length; i++){
                p[i] = new Persona(); //guardo memoria para cada objeto
                
                Console.WriteLine("Ingrese nombre, edad y dni");
                string s = Console.ReadLine();
                string[] datos = s.Split(' ');

                p[i].nombre = datos[0];
                p[i].edad = int.Parse(datos[1]);
                p[i].dni = long.Parse(datos[2]);;
            }

            for (int i = 0; i < p.Length; i++){
                Console.WriteLine($"{i+1}) {p[i].nombre, -7} {p[i].edad} {p[i].dni, -7}");
            }
            Console.ReadKey();
        }
    }

    class Persona
    {
        public string nombre;
        public int edad;
        public long dni;
    }
}
