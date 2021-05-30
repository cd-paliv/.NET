using System;

namespace ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingresador ingresador = new Ingresador();
            ingresador.LineaVaciaIngresada += (sender, e) =>
                { Console.WriteLine("Se ingresó una línea en blanco"); };
            ingresador.NroIngresado += (sender, e) =>
                { Console.WriteLine($"Se ingresó el número {e.Valor}"); };
            ingresador.Ingresar();
        }
    }

    class LineaNumericaEventArgs : EventArgs
    {
        public int Valor { get; set; }
    }
    delegate void LineaNumericaEventHandler(object sender, LineaNumericaEventArgs e);
    class Ingresador
    {
        private EventHandler _lineaVaciaIngresada;
        public event EventHandler LineaVaciaIngresada
        {
            add
            {
                _lineaVaciaIngresada += value;
            }
            remove
            {
                _lineaVaciaIngresada -= value;
            }
        }
        
        private LineaNumericaEventHandler _nroIngresado; //usa la var Valor, así que necesito declarar un EventHandler
        public event LineaNumericaEventHandler NroIngresado
        {
            add
            {
                _nroIngresado += value;
            }
            remove
            {
                _nroIngresado -= value;
            }
        }

        public void Ingresar()
        {
            String linea = Console.ReadLine();
            while(linea != "fin")
            {
                linea = Console.ReadLine();
                if(linea == ""){
                    _lineaVaciaIngresada(this, new EventArgs());
                }
                if(int.TryParse(linea, out int i)){ //devuelve true si linea pudo ser convertido a int
                    _nroIngresado(this,new LineaNumericaEventArgs() { Valor = i });
                }
            }
        }
    }
}
