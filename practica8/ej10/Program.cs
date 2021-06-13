using System;

namespace ej10
{
    class Program
    {
        static void Main(string[] args)
        {
            Articulo a = new Articulo();
            a.PrecioCambiado += precioCambiado;
            a.Codigo = 1;
            a.Precio = 10;
            a.Precio = 12;
            a.Precio = 12;
            a.Precio = 14;
            }
        public static void precioCambiado(object sender, PrecioCambiadoEventArgs e)
        {
            string texto = $"Artículo {e.Codigo} valía {e.PrecioAnterior}";
            texto += $" y ahora vale {e.PrecioNuevo}";
            Console.WriteLine(texto);
        }
    }

    class PrecioCambiadoEventArgs : EventArgs //agregamos esta clase ya que queremos pasar informacion mediante el evento
    {
        public int Codigo { get; set; }
        public double PrecioNuevo { get; set; }
        public double PrecioAnterior { get; set; }

    }

    delegate void PrecioCambiadoEventHandler (object sender, PrecioCambiadoEventArgs e); //descriptor de acceso abreviado (add - remove)

    class Articulo
    {
        private double _precio = 0;
        public double Precio
        {
            set
            {
                 _precioCambiado(this, new PrecioCambiadoEventArgs() { Codigo = this.Codigo,PrecioAnterior = this._precio,PrecioNuevo = value });
                _precio = value;
            }
            get
            {
                return _precio;
            }
        }
        public int Codigo{ get; set; }

        private PrecioCambiadoEventHandler _precioCambiado;

        public event PrecioCambiadoEventHandler PrecioCambiado
        {
            add
            {
                this._precioCambiado += value;
            }
            remove
            {
                this._precioCambiado-=value;
            }
        }
    }
}
