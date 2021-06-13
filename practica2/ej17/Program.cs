using System;

namespace ej17
{
    class Program
    {
        static void Main(string[] args)
        {
            int nro = int.Parse(args[0]);
            int res;
            Fac(nro, out res); //nro!
            Console.WriteLine("FacA " + res);
            FacR(nro, out res);
            Console.WriteLine("FacB " + res);
        }

        //A
        static void Fac(int n, out int f){
            f = 1;
            for (int i = 2; i <= n; i++){
                f *= i;
            }
        }

        //B - RECURSIVA
        static void FacR(int n, out int f){
            if (n == 0){
                f = 1;
            }else{
                FacR(n-1, out f);
                f *= n;
            }
        }
    }
}
