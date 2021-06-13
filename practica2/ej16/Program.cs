using System;

namespace ej16
{
    class Program
    {
        static void Main(string[] args)
        {
            int nro = int.Parse(args[0]);
            Console.WriteLine("FacA: " + Fac(nro));
            Console.WriteLine("FacB: " + FacR(nro));
            Console.WriteLine("FacC: " + FacE(nro));
        }

        //A
        static int Fac(int n){
            int res = 1;
            for (int i = 2; i <= n; i++){
                res *= i;
            }
            return res;
        }

        //B - RECURSIVA
        static int FacR(int n){
            if (n == 1)
                return 1;
            return n*FacR(n-1);
        }

        //C - Expression-Bodied Method (x ? y : z)
        static int FacE(int n) => n==1 ? 1 : n*FacE(n-1);
    }
}
