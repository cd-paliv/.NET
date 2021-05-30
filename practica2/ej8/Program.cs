using System;

namespace ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i=0; i < args.Length; i++){
                if (args[i] == "Paula"){
                    Console.WriteLine("Hola queen");
                }else if (args[i] == "Ivo"){
                    Console.WriteLine("Hola KING");
                }else{
                    Console.WriteLine("Another white man? ugh");
                }
            }
            foreach(string st in args){
                if (st == "Paula"){
                    Console.WriteLine("Hola queen");
                }else if (st == "Ivo"){
                    Console.WriteLine("Hola KING");
                }else{
                    Console.WriteLine("Another white man? ugh");
                }
            }
        }
    }
}
