using System;
using System.Collections;

namespace ej3
{
    class Program
    {
        static void Main(string[] args)
        {
            Cuenta c1 = new Cuenta();
            c1.Depositar(100).Depositar(50).Extraer(120).Extraer(50);
            Cuenta c2 = new Cuenta();
            c2.Depositar(200).Depositar(800);
            new Cuenta().Depositar(20).Extraer(20);
            c2.Extraer(1000).Extraer(1);

            Console.WriteLine("\nDETALLE");
            Cuenta.ImprimirDetalle();

            Console.WriteLine("\n-------------------------------------------------");

            ArrayList cuentas = Cuenta.GetCuentas();
            (cuentas[0] as Cuenta).Depositar(50);
            cuentas.RemoveAt(0);
            Console.WriteLine(cuentas.Count); //tengo tres, elimine uno debería ser 2
            cuentas = Cuenta.GetCuentas();
            Console.WriteLine(cuentas.Count); //vuelve a tener las 3 cuentas
            (cuentas[0] as Cuenta).Extraer(30);
        }
    }
    
    class Cuenta
    {
        private static int IDTot = 0;
        private static int cantDep = 0; //depositos
        private static double totDep = 0;
        private static int cantExt = 0; //extracciones
        private static double totExt = 0;
        private static int totDenegadas = 0;
        private static ArrayList _cuentas { get; } = new ArrayList(); //EJ 3 ES EL GET: propiedad readonly autoimplementada
        //private static readonly ArrayList _deMentira = (ArrayList)_cuentas.Clone();
        private int _ID { get; } //no quiero que me modifiquen el id :(
        private double _monto;

        public Cuenta()
        {
            IDTot++;
            _ID = IDTot;
            _monto = 0;
            _cuentas.Add(this);
            Console.WriteLine("Se creo la cuenta ID = " + _ID);
        }

        public Cuenta Depositar(double valor)
        {
            _monto += valor;
            cantDep++;
            totDep += valor;
            Console.WriteLine($"Se depositó {valor} en la cuenta {_ID} (Saldo = {_monto})");
            return this;
        }

        public Cuenta Extraer(double valor)
        {
            if (_monto - valor < 0){
                totDenegadas++;
                Console.WriteLine("Operación cancelada: monto insuficiente.");
                return null;
            }
            else{
                _monto -= valor;
                cantExt++;
                totExt += valor;
                Console.WriteLine($"Se extrajo {valor} de la cuenta {_ID} (Saldo = {_monto})");
                return this;
            }
        }

        public static void ImprimirDetalle()
        {
            Console.WriteLine($"CUENTAS CREADAS: {IDTot}");
            Console.WriteLine($"DEPÓSITOS: {cantDep, 6} - Total depositado: {totDep, -3}");
            Console.WriteLine($"EXTRACCIONES: {cantExt, 3} - Total extraído: {totExt}");
            Console.WriteLine($"                  - Saldo {0}", totDep - totExt);
            Console.WriteLine($"* Se denegaron {totDenegadas} extracciones por falta de fondos");
        }

        //EJ2
        public static ArrayList GetCuentas()
        {
            ArrayList deMentira;
            deMentira = (ArrayList)_cuentas.Clone();
            return deMentira;
        }
        
        
    }
}
