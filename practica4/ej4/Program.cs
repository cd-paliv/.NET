using System;

namespace ej4
{
    class Program
    {
        static void Main(string[] args)
        {
            Hora h = new Hora(23, 30, 15);
            h.Imprimir();
            Hora h2 = new Hora(14.45);
            h2.Imprimir();
        }
    }

    class Hora
    {
        private TimeSpan ts;

        public Hora(int hora, int minutos, int segundos) => ts = new TimeSpan(hora, minutos, segundos);

        public Hora(double nro) => ts = TimeSpan.FromHours(nro); //convierto double a horas, minutos, segundos

        public void Imprimir() => Console.WriteLine($"{ts.Hours} horas, {ts.Minutes} minutos, {ts.Seconds:0.000} segundos");
    }
}
