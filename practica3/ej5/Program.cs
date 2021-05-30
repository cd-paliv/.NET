using System;
using System.Collections;

namespace ej5
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matriz = new double[4, 4];
            for (int i = 0; i <= 15; i++)
            {
                matriz[i / 4, i % 4] = i;
            }
            ImprimirArregloDeArreglo(GetArregloDeArreglo(matriz));
        }

        static double[][] GetArregloDeArreglo(double[,] m)
        {
            //creo arreglo de arreglos
            double[][] arreglo = new double[m.GetLength(0)][];
            //a cada elemento le asigno un array
            for(int x = 0; x < m.GetLength(0); x++){
                arreglo[x] = new double[m.GetLength(1)];
            }

            //cargo arreglo con matriz
            for(int i = 0; i < m.GetLength(0); i++){
                for(int j = 0; j < m.GetLength(1); j++){
                    arreglo[i][j] = m[i,j];
                }
            }
            return arreglo;
        }

        static void ImprimirArregloDeArreglo(double[][] v)
        {
            for(int i = 0; i < v.Length; i++){
                for(int j = 0; j < v.Length; j++){
                    Console.Write($"{v[i][j], 5}");
                }
                Console.WriteLine();
            }
        }
    }
}
