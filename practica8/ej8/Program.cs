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
            //cada vez que se invoque LineaVaciaIngresada, se va a ejecutar el console.writeln

            ingresador.NroIngresado += (sender, e) =>
                { Console.WriteLine($"Se ingresó el número {e.Valor}"); };
            //cada vez que se invoque NroIngresado se va a ejecutar el console.writeln
            
            ingresador.Ingresar();
        }
    }

    class LineaNumericaEventArgs : EventArgs
    {
        public int Valor { get; set; } //necesito poder guardar y leer el nro
    }
    delegate void LineaNumericaEventHandler(object sender, LineaNumericaEventArgs e); //descriptor de acceso
    class Ingresador
    {
        private EventHandler _lineaVaciaIngresada; 
        public event EventHandler LineaVaciaIngresada
        {//evento que notifica cuando se ingresó línea vacía
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
        {//evento que notifica cuando se ingresa un nro
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
                    _nroIngresado(this,new LineaNumericaEventArgs() { Valor = i }); //genera un nuevo evento
                }
            }
        }
    }
}
