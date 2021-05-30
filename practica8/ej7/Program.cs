using System;

namespace ej7
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Ingresar lineas: ");
            
            ContadorDeLineas contador = new ContadorDeLineas();
            contador.Contar();

            Console.ReadKey();
        }
    }

    delegate void LineasContadasEventHandler();

    class ContadorDeLineas
    {
        private int _cantLineas = 0;
        public void Contar()
        {
            Ingresador _ingresador = new Ingresador();
            //_ingresador.Contador = this;
            _ingresador.NroIngresado = UnaLineaMas;
            _ingresador.Ingresar();
            Console.WriteLine($"Cantidad de líneas ingresadas: {_cantLineas}");
        }
        public void UnaLineaMas() => _cantLineas++;
    }
    class Ingresador
    {
        //public ContadorDeLineas Contador {get;set;} esto no debería ir
        public LineasContadasEventHandler NroIngresado;
        public void Ingresar()
        {
            string st = Console.ReadLine();
            while (st != "")
            {
                //Contador.UnaLineaMas();
                if(NroIngresado != null) NroIngresado.Invoke();
                st = Console.ReadLine();
            }
        }
    }
}
