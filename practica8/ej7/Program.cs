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

    //delegate void LineasContadasEventHandler(); //el compilador crea un campo privado EventHandler e implementa descriptores de acceso

    class ContadorDeLineas
    {
        private int _cantLineas = 0;
        public void Contar()
        {
            Ingresador _ingresador = new Ingresador();
            //_ingresador.Contador = this;
            _ingresador.NroIngresado += (sender, e) => _cantLineas++; //a NroIngresado le asigno el método UnaLineaMas, cada vez que haga Invoke va a invocar ese método
            _ingresador.Ingresar();
            Console.WriteLine($"Cantidad de líneas ingresadas: {_cantLineas}");
        }
        //public void UnaLineaMas() => _cantLineas++;
    }
    class Ingresador
    {
        //public ContadorDeLineas Contador {get;set;} esto no debería ir
        public event EventHandler NroIngresado; //en lugar de usar el objeto, uso un descriptor de acceso
        public void Ingresar()
        {
            string st = Console.ReadLine();
            while (st != "")
            {
                //Contador.UnaLineaMas();
                if(NroIngresado != null) NroIngresado.Invoke(this, EventArgs.Empty); //si hay algún suscriptor, invoco
                st = Console.ReadLine();
            }
        }
    }
}
