using System;

namespace ej18
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 4; i++){
                // string st = i < 3 ? i==2 ? "dos" : i == 1 ? "uno" : "< 1" : i < 4 ? "tres" : "> 3"; //consultar;
                // Console.WriteLine(st);
                if (i < 3){
                    if (i == 2){
                        Console.WriteLine("dos");
                    }else if (i == 1){
                        Console.WriteLine("uno");
                    }else{
                        Console.WriteLine("< 1");
                    }
                }else{
                        if (i < 4){
                            Console.WriteLine("tres");
                        }else{
                            Console.WriteLine("> 3");
                        }
                    }
            }
            Console.ReadLine();
        }
    }
}
