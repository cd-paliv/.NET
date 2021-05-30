using System;
using System.Collections;

namespace teoria5
{
    class Program
    {
        static void Main(string[] args)
        {
            Cuenta.GetResumen(); //como cuenta es static se puede instanciar a través del nombre de la clase
            Cuenta c1 = new Cuenta(); //c1 es una instancia
            Cuenta c2 = new Cuenta();
            c1.Depositar(100);
            c2.Depositar(200);
            c1.Depositar(300);
            Cuenta.GetResumen();
            c1.Imprimir();
            c2.Imprimir();
            //c1.GetResumen(); no se puede invocar un metodo estatico a traves de una instancia

            Coleccion c = new Coleccion();
            c.Agregar(15);
            c.Imprimir();

            Cuadrado sqr = new Cuadrado();
            //sqr.SetLado(2.5);
            //Console.WriteLine("Lado: {0} - Area: {1}", sqr.GetLado(), sqr.GetArea());
            sqr.Lado = 2.5;
            double x = sqr.Lado; //así obtengo el valor de lado del cuadrado y lo guardo en x
            Console.WriteLine("Lado: {0} - Area: {1}", sqr.Lado, sqr.Area);


            Familia f = new Familia();
            f.Padre = new Persona("Juan", 50);
            f[1] = new Persona("Maria", 40); //f.Madre = new Persona("Maria", 40);
            f.Hijo = new Persona("Jose", 15);
            for(int i = 0; i < 3; i++) f[i].Imprimir();
            f["Maria"].Imprimir();
            ArrayList lista = f['J'];
            foreach(Persona p in lista) p.Imprimir();
        }
    }

    class Cuenta //cuenta contiene sólo los metodos y var estáticos, mientras lo demás estarían instanciados en cada objeto
    {
        public int _monto; //monto es un campo de instancia: se accede a partir de objetos
        public static int s_total; //campo estático: todos los objetos cuenta van a referenciar al mismo total

        
        public static void GetResumen() => Console.WriteLine($"Total = {Cuenta.s_total}");
        public void Depositar(int monto)
        {
            _monto += monto;
            s_total += monto; //no puedo poner this.s_total porque referiría a la instancia
        }
        public void Imprimir() => Console.WriteLine(_monto);
    }

    class Coleccion{
        private readonly ArrayList lista = new ArrayList();
        public void Agregar(object obj){
            lista.Add(obj);
        }

        public void Imprimir() => Console.WriteLine(lista);
    }

    class Cuadrado
    {
        private double _lado;
/*
        public void SetLado(double valor) => _lado = valor; //en c# los getter y setter no están recomendados
        public double GetLado() => _lado;
        public double GetArea() => _lado * _lado;
*/
        public double Lado //en c# se recomienda usar PROPIEDADES
        {
            set => _lado = value;
            get => _lado;
        }
        public double Area => _lado * _lado; //filmina 68 del pdf
        
    }

    class Persona
    {
        public int Edad {get;}
        public string Nombre {get;}
        public Persona(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }
        
        public void Imprimir() => Console.WriteLine($"{Nombre} ({Edad})");
    }
    class Familia{
        public Persona Padre;
        public Persona Madre;
        public Persona Hijo;

        public Persona this[int i]
        {
            get{
                if(i == 0) return Padre;
                else if (i == 1) return Madre;
                else if (i == 2) return Hijo;
                else return null;
            }
            set{
                if(i == 0) Padre = value;
                else if (i == 1) Madre = value;
                else if (i == 2) Hijo = value;
            }
        }
        public Persona this[string st]
        {
            get{
                if (Padre.Nombre == st) return Padre;
                else if(Madre.Nombre == st) return Madre;
                else if (Hijo.Nombre == st) return Hijo;
                else return null;
            }
        }
        public ArrayList this[char c]
        {
            get{
                ArrayList result = new ArrayList();
                if (Padre.Nombre[0] == c) result.Add(Padre);
                else if(Madre.Nombre[0] == c) result.Add(Madre);
                else if (Hijo.Nombre[0] == c) result.Add(Hijo);

                return result;
            }
        }

    }
}
