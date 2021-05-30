using System;
using System.Collections;

namespace prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue cola = new Queue();
            int[] clave = {5, 3, 9, 7};
            //encolo la clave de enteros
            for (int i = 0; i < clave.Length; i++){
                cola.Enqueue(clave[i]);
            }
             for (int i = 0; i < clave.Length; i++){
                Console.WriteLine(cola.Dequeue());
            }
            //----------
            String abc = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ ";
            char[] abecedario = abc.ToCharArray();

            Console.WriteLine("Espacio?"+abecedario[27]+"si");
            Console.WriteLine("Mensaje descifrado: ");
            for(int i = 0; i < abecedario.Length-1; i++){
                Console.Write(abecedario[i] + " ");
            }
        }
    }
}
