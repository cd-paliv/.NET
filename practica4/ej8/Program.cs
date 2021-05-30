using System;

namespace ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            Matriz A = new Matriz(2, 3);
            for(int i = 0; i < 6; i++)
                A.SetElemento(i / 3, i % 3, (i + 1) / 3.0);
            Console.WriteLine("Matriz A: ");
            A.Imprimir("0.000");

            double[,] aux = new double[,] { {1, 2, 3}, {4, 5, 6}, {7, 8, 9} };
            Matriz B = new Matriz(aux);
            Console.WriteLine("\nMatriz B: ");
            B.Imprimir();

            Console.WriteLine($"\nAcceso al elemento B[1, 2] = {B.GetElemento(1, 2)}");

            Console.Write("\nFila 1 de A: ");
            foreach(double d in A.GetFila(1)) Console.Write("{0:0.0} ", d);

            Console.Write("\n\nColumna 0 de B: ");
            foreach (double d in B.GetColumna(0)) Console.Write("{0} ", d);

            Console.Write("\n\nDiagonal principal de B: ");
            foreach (double d in B.GetDiagonalPrincipal()) Console.Write("{0} ", d);

            Console.Write("\n\nDiagonal secundaria de B: ");
            foreach (double d in B.GetDiagonalSecundaria()) Console.Write("{0} ", d);

            try{
                A.MultiplicarPor(B);
                Console.WriteLine("\n\nA multiplicado por B");
                A.Imprimir();
            }
            catch (ArgumentException e){
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }

    class Matriz
    {
        private double[,] m;
        private int _filas;
        private int _columnas;

        public Matriz(int filas, int columnas)
        {
            _filas = filas;
            _columnas = columnas;
            m = new double[_filas, _columnas];
        }
        public Matriz(double[,] matriz){
            m = matriz;
            _filas = matriz.GetLength(0);
            _columnas = matriz.GetLength(1);
        }

        public int getFilas(){
            return _filas;
        }
        public int getColumnas(){
            return _columnas;
        }

        public void SetElemento(int fila, int columna, double elemento)
        {
            if ((fila >= 0 && fila <= _filas) && (columna >= 0 && columna <= _columnas)){ //si la fila y la columna existen
                m[fila, columna] = elemento;
            }
        }

        public double GetElemento(int fila, int columna)
        {
            if ((fila >= 0 && fila <= _filas) && (columna >= 0 && columna <= _columnas)){ //si la fila y la columna existen
                return m[fila, columna];
            }else return -1;
        }

        public void Imprimir()
        {
            for (int i = 0; i < _filas; i++){
                for (int j = 0; j < _columnas; j++){
                    Console.Write(this.GetElemento(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
        public void Imprimir(string formato)
        {
            for (int i = 0; i < _filas; i++){
                for (int j = 0; j < _columnas; j++){
                    Console.Write(this.GetElemento(i, j).ToString(formato) + " ");
                }
                Console.WriteLine();
            }
        }

        public double[] GetFila(int fila)
        {
            double[] vector = new double[_columnas];
            for (int i = 0; i < _columnas; i++){
                vector[i] = m[fila, i];
            }
            return vector;
        }
        public double[] GetColumna(int columna)
        {
            double[] vector = new double[_filas];
            for (int i = 0; i < _filas; i++){
                vector[i] = m[i, columna];
            }
            return vector;
        }
        public double[] GetDiagonalPrincipal() //esq sup izq a esq inf der
        {
            if (_filas != _columnas){
                throw new ArgumentException ("ERROR: La matriz no es cuadrada");
            }
            double[] vector = new double[_filas];
            for(int i = 0; i < _filas; i++){
                vector[i] = m[i, i];
            }
            return vector;
        }
        public double[] GetDiagonalSecundaria() //esquina sup der a esquina inf izq
        {
            if (_filas != _columnas){
                throw new ArgumentException ("ERROR: La matriz no es cuadrada");
            }
            double[] vector = new double[_filas];
            for (int i = 0; i < _filas; i++){
                vector[i] = m[i, (_filas - 1) - i];
            }
            return vector;
        }
        public double[][] GetArregloDeArreglo()
        {
            //creo arreglo (de arreglos) con longitud de filas
            double[][] arreglo = new double[_filas][];
            //a cada elemento le asigno un array de longitud columnas
            for(int x = 0; x < _filas; x++){
                arreglo[x] = new double[_columnas];
            }

            //cargo arreglo con matriz
            for(int i = 0; i < _filas; i++){
                for(int j = 0; j < _columnas; j++){
                    arreglo[i][j] = m[i, j];
                }
            }
            return arreglo;
        }

        public void Sumarle(Matriz matriz)
        {
            if (_filas == matriz.getFilas() && _columnas == matriz.getColumnas()){
                for(int i = 0; i < _filas; i++){
                    for(int j = 0; j < _columnas; j++){
                        m[i, j] += matriz.GetElemento(i, j);
                    }
                }
            }else throw new ArgumentException("ERROR: No es posible realizar la suma porque las matrices no son iguales");
        }
        public void Restarle(Matriz matriz)
        {
            if (_filas == matriz.getFilas() && _columnas == matriz.getColumnas()){
                for(int i = 0; i < _filas; i++){
                    for(int j = 0; j < _columnas; j++){
                        m[i, j] -= matriz.GetElemento(i, j);
                    }
                }
            }else throw new ArgumentException("ERROR: No es posible realizar la resta porque las matrices no son iguales");
        }
        public void MultiplicarPor(Matriz matriz)
        {
            if(this == null || matriz == null){
                throw new ArgumentException("ERROR: Una de las matrices está vacía");
            }
            if (this._columnas != matriz.getFilas()){
                throw new ArgumentException("ERROR: Las filas de B deben ser iguales a las columnas de A");
            }else {
                double[,] mul = new double[this._filas, this._columnas];

                for(int i = 0; i < _filas; i++){
                    for(int j = 0; j < _columnas; j++){
                        mul[i, j] = 0; //inicializo la suma de productos en 0
                        for(int z = 0; z < matriz.getColumnas(); z++){
                            mul[i, j] += m[i, z] * matriz.GetElemento(z, j); //hago ({a11·b11 + a12·b21 + a13·b31 + a14·b41} = {0·0 + 1·4 + 2·8 + 3·12} para el primer elemento de C)
                        }
                    }
                }
                m = mul; //reemplazo la matrix con los valores calculados
            }
        }
        
    }
}
