using System;

namespace teoria4
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto a = new Auto("Nissan", 2017);
            a.Imprimir();
            //a.Imprimir("IMPRESION");
            Auto b = new Auto("Ford", 2015);
            b.Imprimir();
            //b.Imprimir(2);
            Auto c = new Auto();
            c.Imprimir();
            Auto d = new Auto("Renault");
            d.Imprimir();

        }
    }

    class Auto
    {
        //si no les pongo public, son privados por defecto
        private string _marca; //convención: utilizar _x al comienzo del identificador de un campo privado
        private int _modelo;

        public Auto(string marca, int modelo)
        {
            _marca = marca;
            _modelo = modelo;
        }
        public Auto() //sobrecarga de constructores
        {
            _marca = "Fiat";
            _modelo = DateTime.Now.Year;
        }
        public Auto(string marca): this()
        { //this() ejecuta otro constructor antes de su propio codigo
            _marca = marca;
        }
        public Auto(int modelo): this("Volskwagen", modelo)
        {
            //también se puede usar así, si está vacío todo se resuelve en la invocación al otro constructor
        }

        public void Imprimir() =>
            Console.WriteLine($"Auto {_marca} - {_modelo}");
        public void Imprimir(string encabezado)
        {
            Console.WriteLine(encabezado);
            Imprimir();
        }
        public void Imprimir(int repetir)
        {
            for (int i = 0; i < repetir; i++){
                Imprimir();
            }
        }
    }
}
