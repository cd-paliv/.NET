using System;

namespace ej12
{
    class Program
    {
        static void Main(string[] args)
        {
            Cuenta cuenta = new Cuenta();
            cuenta.Imprimir();
            cuenta = new Cuenta(30222111);
            cuenta.Imprimir();
            cuenta = new Cuenta("José Perez");
            cuenta.Imprimir();
            cuenta = new Cuenta("Maria Diaz", 20287544);
            cuenta.Imprimir();
            cuenta.Depositar(200);
            cuenta.Imprimir();
            cuenta.Extraer(150);
            cuenta.Imprimir();
            cuenta.Extraer(1500);
        }
    }

    class Cuenta
    {
        private double _monto;
        private int _titularDNI;
        private string _titularNombre;

        public Cuenta()
        {
            _titularNombre = "No especificado";
            _titularDNI = 0;
            _monto = 0;
        }
        public Cuenta(int dni): this()
        {
            _titularDNI = dni;
        }
        public Cuenta(string nom): this()
        {
            _titularNombre = nom;
        }
        public Cuenta(string nom, int dni): this()
        {
            _titularNombre = nom;
            _titularDNI = dni;
        }

        public void Imprimir() => Console.WriteLine($"Nombre: {_titularNombre}, DNI {_titularDNI}, Monto: {_monto}");

        public void Depositar(double valor) => _monto += valor;

        public void Extraer(double valor)
        {
            if (_monto - valor < 0) Console.WriteLine("Operación cancelada: monto insuficiente.");
            else _monto -= valor;
        }
    }
}
