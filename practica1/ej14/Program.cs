using System;

namespace ej14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresar un nro entero");
            int nro = int.Parse(Console.ReadLine());
            if (nro > 0){
                string res = Convert.ToString(nro/365);
                Console.WriteLine("El resultado de dividir "+nro+" por 365 es:");
                for (int i=0; i<res.Length-1; i++){
                    Console.Write(res[i]+" ");
                }
            }else{
                Console.WriteLine("El nro debe ser mayor a cero");
            }
            Console.ReadLine();
        }
    }
}
