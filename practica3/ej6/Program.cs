using System;

namespace ej6
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] m1 = generadorMatriz(4, 4);
            double[,] m2 = generadorMatriz(4, 4);
            Console.WriteLine("Matriz 1: ");
            ImprimirMatriz(m1);
            Console.WriteLine("Matriz 2: ");
            ImprimirMatriz(m2);
            try
            {
                Console.WriteLine("Suma: ");
                double[,] suma = Suma(m1, m2);
                if(suma != null){
                    ImprimirMatriz(Suma(m1, m2));
                }
                Console.WriteLine("Resta: ");
                double[,] resta = Resta(m1, m2);
                if(resta != null){
                    ImprimirMatriz(Resta(m1, m2));
                }
                Console.WriteLine("Multiplicacion: ");
                ImprimirMatriz(Multiplicacion(m1, m2));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static double[,] Suma(double[,] A, double[,] B)
        {
            if (tamaños(A, B)){
                double[,] sum = new double[A.GetLength(0), A.GetLength(1)];
                for(int i = 0; i < A.GetLength(0); i++){
                    for(int j = 0; j < A.GetLength(1); j++){
                        sum[i,j] = A[i,j] + B[i,j];
                    }
                }
                return sum;
            }else return null;
        }

        static double[,] Resta(double[,] A, double[,] B)
        {
            if (tamaños(A, B)){
                double[,] res = new double[A.GetLength(0), A.GetLength(1)];
                for(int i = 0; i < A.GetLength(0); i++){
                    for(int j = 0; j < A.GetLength(1); j++){
                        res[i,j] = A[i,j] - B[i,j];
                    }
                }
                return res;
            }else return null;
        }

        
        static double multiplicarElem(double[] X, double[] Y)
        {
            double producto = 0;
            for(int i = 0; i < X.Length; i++){
                producto += X[i] * Y[i];
            }
            return producto;
        }
        static double[,] Multiplicacion(double[,] A, double[,] B)
        {
            if(A == null || B == null){
                return null;
            }
            if (A.GetLength(1) != B.GetLength(0)){
                throw new ArgumentException("Las filas de B deben ser iguales a las columnas de A");
            }else {
                double[,] mul = new double[A.GetLength(0), A.GetLength(1)];

                for(int i = 0; i < mul.GetLength(0); i++){
                    for(int j = 0; j < mul.GetLength(1); j++){
                        mul[i, j] = 0; //inicializo la suma de productos en 0
                        for(int z = 0; z < B.GetLength(1); z++){
                            mul[i, j] += A[i, z] * B[z, j]; //hago ({a11·b11 + a12·b21 + a13·b31 + a14·b41} = {0·0 + 1·4 + 2·8 + 3·12} para el primer elemento de C)
                        }
                    }
                }
                return mul;
            }
        }

        static bool tamaños(double[,] A, double[,] B)
        {
            return (A.GetLength(0) == B.GetLength(0) && A.GetLength(1) == B.GetLength(1));
        }

        static double[,] generadorMatriz(int a, int b)
        {
            double[,] matriz = new double[a, b];
            for (int i = 0; i <= (a*b)-1; i++){
                matriz[i/b, i%b] = i;
            }
            return matriz;
        }

        static void ImprimirMatriz(double[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++){
                for (int j = 0; j < matriz.GetLength(1); j++){
                    Console.Write($"{matriz[i, j], 5}");
                }
                Console.WriteLine();
            }
        }

    }
}
