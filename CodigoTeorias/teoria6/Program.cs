using System;

namespace teoria6
{
    class Program
    {
        static void Main(string[] args)
        {
            Automotor[] v = new Automotor[2];
            v[0] = new Auto("Ford", 2000, TipoAuto.Familiar);
            v[1] = new Colectivo("Mercedes", 2010, 20);
            ImprimidorAutomotores.Imprimir(v);

        }
    }
    enum TipoAuto { Familiar, Deportivo, Camioneta }
    class Automotor //deriva de object
    {
        public string Marca;
        private int _modelo;
        public int Modelo
        {
            get => _modelo;
            protected set => _modelo = (value < 2005) ? 2005 : value; //sólo se puede setear el modelo desde un tipo Automotor
        }
        public Automotor() {}
        public Automotor(string marca, int modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }

        public virtual void Imprimir() => Console.WriteLine($"{Marca} {Modelo}");

    }
    class Auto : Automotor
    { //Auto deriva de Automotor
        public TipoAuto tipo;
        //public Auto() : base(){}
        public Auto(string marca, int modelo, TipoAuto tip) : base(marca, modelo) => tipo = tip;
        public override void Imprimir(){
            Console.Write($"Auto {tipo} ");
            base.Imprimir();
        }

    }

    class Colectivo: Automotor
    {
        public int cantPasajeros;
        //public Colectivo() : base() {}
        public Colectivo(string marca, int modelo, int cant) : base(marca, modelo)
        {
            this.cantPasajeros = cant;
        }
        public override void Imprimir() => Console.WriteLine($"{Marca} {Modelo} ({cantPasajeros} pasajeros) ");
    }

    static class ImprimidorAutomotores{
        public static void Imprimir(Automotor[] vector){
            foreach(Automotor a in vector){
                a.Imprimir();
            }
        }
    }
}
