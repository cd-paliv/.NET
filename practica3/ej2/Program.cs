using System;

namespace ej2
{
    class Program
    {
        static void Main(string[] args)
        {
            double [,] matriz = new double[4,4];
            for (int i = 0; i <= 15; i++){ //4*4=16 como empieza en 0 le resto 1
                matriz[i / 4, i % 4] = i;
            }
            ImprimirMatriz(matriz);
            Console.WriteLine("------------------------------------");
            /*ej 3*/
            string formato = "0.0";
            ImprimirMatriz(matriz, formato);
        }

        static void ImprimirMatriz(double[,] m)
        {
            for(int i = 0; i < m.GetLength(0); i++){ //getlength(0) me da el tamaño de las filas
                for (int j = 0; j < m.GetLength(1); j++){ //getlength(1) me da el tamaño de las columnas
                    Console.Write($"{m[i,j], 5}"); //,3 es los espacios entre valores
                }
                Console.WriteLine();
            }
        }

        static void ImprimirMatriz(double[,] m, string f)
        {
            for (int i = 0; i < m.GetLength(0); i++){
                for(int j = 0; j < m.GetLength(1); j++){
                    Console.Write($"{m[i, j].ToString(f), 7}"); //el método tostring acepta un parámetro que es una máscara de formato
                }
                Console.WriteLine();
            }
        }
    }
}
