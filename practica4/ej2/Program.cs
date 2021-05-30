using System;

namespace ej2
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona[] p = new Persona[2]; //guardo la memoria para el vector
            Persona menor = new Persona(" ", 999, 0);
            for(int i = 0; i < p.Length; i++){
                Console.WriteLine("Ingrese nombre, edad y dni");
                string s = Console.ReadLine();
                string[] datos = s.Split(' ');

                p[i] = new Persona(datos[0], int.Parse(datos[1]), long.Parse(datos[2]));
                
                if(! p[i].EsMayorQue(menor)){
                    menor = p[i];
                }
            }


            for (int i = 0; i < p.Length; i++){
                Console.Write($"{i+1})");
                p[i].Imprimir();
            }
            Console.Write("La persona más joven de la lista es: ");
            menor.Imprimir();
            Console.ReadKey();
        }
    }

    class Persona
    {
        private string _nombre;
        private int _edad;
        private long _dni;

        public Persona(string nombre, int edad, long dni)
        {
            _nombre = nombre;
            _edad = edad;
            _dni = dni;
        }

        public void Imprimir()
        {
            Console.WriteLine($"{_nombre, -8} {_edad} {_dni, 10}");
        }

        public bool EsMayorQue(Persona p)
        {
            return p.getEdad() < this._edad; //cómo hago?
        }

        public int getEdad()
        {
            return _edad;
        }
    }

}
