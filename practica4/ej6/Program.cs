using System;

namespace ej6
{
    class Program
    {
        static void Main(string[] args)
        {
            Ecuacion2 e = new Ecuacion2(1, -2, -3);
            e.ImprimirRaices();
        }
    }

    class Ecuacion2
    {
        private double _a;
        private double _b;
        private double _c;

        public Ecuacion2(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public double GetDiscriminante()
        {
            return Math.Pow(_b, 2) - (4 * _a * _c);
        }

        public int GetCantidadDeRaices()
        {
            if (GetDiscriminante() < 0){
                return 0;
            }else if (GetDiscriminante() == 0){
                return 1;
            }else return 2;
        }

        public void ImprimirRaices()
        {
            if (GetCantidadDeRaices() == 0){
                Console.WriteLine("La ecuación no posee raíces reales");
            }else{
                double raizPositiva = (- _b + (Math.Sqrt(GetDiscriminante()))) / (2 * _a);
                double raizNegativa = (- _b - (Math.Sqrt(GetDiscriminante()))) / (2 * _a);
                if (raizPositiva != raizNegativa){
                    Console.WriteLine($"X1: {raizPositiva}");
                    Console.WriteLine($"X2: {raizNegativa}");
                }else Console.WriteLine($"X: {raizPositiva}");
            }
        }
    }
}
