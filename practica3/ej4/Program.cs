using System;

namespace ej4
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matriz = new double[4, 4];
            for (int i = 0; i <= 15; i++){
                matriz[i / 4, i % 4] = i;
            }
            try
            {
                Console.Write("Diagonal principal:    ");
                ImprimirDiagonal(GetDiagonalPrincipal(matriz));
                Console.Write("Diagonal secundaria:   ");
                ImprimirDiagonal(GetDiagonalSecundaria(matriz));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static double[] GetDiagonalPrincipal(double[,] m) //esq sup izq a esq inf der
        {
            if (m.GetLength(0) != m.GetLength(1)){
                throw new ArgumentException ("La matriz no es cuadrada");
            }
            double[] vector = new double[m.GetLength(0)];
            for(int i = 0; i < m.GetLength(0); i++){
                vector[i] = m[i,i];
            }
            return vector;
        }

        static double[] GetDiagonalSecundaria(double[,] m) //esquina sup der a esquina inf izq
        {
            if (m.GetLength(0) != m.GetLength(1)){
                throw new ArgumentException ("La matriz no es cuadrada");
            }
            double[] vector = new double[m.GetLength(0)];
            for (int i = 0; i < m.GetLength(0); i++){
                vector[i] = m[i, (m.GetLength(0) -1) - i]; //getlength me da el nro sin contar el 0, se lo tengo que agregar
            }
            return vector;
        }

        static void ImprimirDiagonal(double[] v)
        {
            //Console.WriteLine();
            for (int i = 0; i < v.Length; i++){
                Console.Write($"{v[i], -5}");
            }
            Console.WriteLine();
        }
    }
}
