using System;

namespace ej13
{
    class Program
    {
        static void Main(string[] args)
        {
            string st, st1 = "x", st2 = null, st3 = "y", st4 = null;
            
            st = st1 ??= st2 ??= st3 ?? st2;
            st4 = "valor por defecto" ?? "otra cosa";

            /*
            if (st1 == null){
                if(st2 == null){
                    st = st3;
                }else{
                    st = st2;
                }
            }else{
                st = st1;
            }
            if(st4 == null){
                st4 = "valor por defecto";
            }*/

            Console.WriteLine(st);
            Console.WriteLine(st4);
        }
    }
}
