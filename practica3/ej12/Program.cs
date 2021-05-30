using System;
using System.Collections;

namespace ej12
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue cola = new Queue();
            int[] clave = {5, 3, 9, 7};
            //encolo la clave de enteros
            cola = reencolar(cola, clave);

            //me guardo el abecedario en un vector
            String abc = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ ";
            char[] abecedario = abc.ToCharArray();

            //solicito texto y lo convierto en array
            Console.WriteLine("Ingrese mensaje a cifrar");
            String mensaje = Console.ReadLine();
            mensaje = mensaje.ToUpper();

            //me guardo los valores del mensaje decodificado y después codifico el mensaje
            int[] vectorValoresMensaje = vectorNroMensajeDecodificado(mensaje, abecedario);
            char[] codificado = codificarMensaje(mensaje, cola, abecedario, vectorValoresMensaje);

            //vacío y vuelvo a cargar la cola para calcular bien la deco con la clave
            cola = reencolar(cola, clave);

            //me guardo los valores del mensaje codificado y después decodifico el mensaje
            int[] vectorValoresCodificado = vectorNroMensajeCodificado(mensaje, codificado, abecedario);
            char[] decodificado = decodificarMensaje(codificado, cola, abecedario, vectorValoresCodificado);

            //VERIFICO
            //mensaje original
            Console.Write("Mensaje original: " + mensaje);
            
            //codigo sin cifrar
            Console.WriteLine();
            foreach (int elem in vectorValoresMensaje){
                Console.Write($" | {elem, 2}");
            }
            Console.Write(" <= Código sin cifrar");

            //clave repetida
            Console.WriteLine();
            cola = reencolar(cola, clave);
            for(int i = 0; i < mensaje.Length; i++){
                if (cola.Count > 0){
                    Console.Write($" | {cola.Dequeue(), 2}");
                }else{
                    cola = reencolar(cola, clave);
                    Console.Write($" | {cola.Dequeue(), 2}");
                }
            }
            Console.Write(" <= Clave repetida");

            //codigo cifrado
            Console.WriteLine();
            foreach (int elem in vectorValoresCodificado){
                Console.Write($" | {elem, 2}");
            }
            Console.Write(" <= Código cifrado");

            //mensaje cifrado
            Console.WriteLine();
            foreach (char elem in codificado){
                Console.Write($" | {elem, 2}");
            }
            Console.Write(" <= Mensaje cifrado");
            Console.Read();
            
            //decodificado
            Console.WriteLine();
            foreach (char elem in decodificado){
                Console.Write($"{elem} ");
            }
            Console.Write(" <= Mensaje descifrado");
            Console.ReadKey();

        }


        //------------------------------------------------------CODIFICAR-------------------------------------------------------------

        static char[] codificarMensaje(String mens, Queue cola, char[] abc, int[] valores) //mens = mensaje solicitado, cola con clave, abc = abecedario[], valores = vectorValoresMensaje
        {
            char[] cod = new char[mens.Length]; //vector donde voy a poder leer el mensaje codificado
            for (int i = 0; i < cod.Length; i++){
                int nro = (int)cola.Dequeue(); //tomo el primer valor de la cola
                int valor = valores[i]; //obtengo el entero correspondiente al char (ej: H = 7)
                int suma = valor + nro;
                if (suma > 28){ //si llega a 28, tengo que empezar a contar de vuelta
                    suma -= 28;
                }
                cod[i] = abc[suma]; //el char correspondiente a suma es el que reemplaza al anterior (H: 7 + clave: 5 = M: 12)
                cola.Enqueue(nro); //encolo el nro de la clave para volver a usarlo después
            }
            return cod;
        }

        static int[] vectorNroMensajeDecodificado(String mens, char[] abc)
        {
            int[] vector = new int[mens.Length]; //vector que va a guardar los valores de cada char (vector[1] = H: 7)
            for(int i = 0; i < mens.Length; i++){
                vector[i] = getValorNro(mens[i], abc);
            }
            return vector;
        }

        //consigo el valor de cada caracter en el vector abc
        static int getValorNro (char a, char[] abecedario) //a = cada char del mensaje ingresado (mensaje[i])
        {
            if(a.Equals(" ")){
                return 28;
            }else{
                int i = 0;
                while (abecedario[i] != a){ //busco el char en el abecedario
                    i++; //la posicion representa su valor numérico
                }
                return i;
            }
        }


        //------------------------------------------------------DECODIFICAR-------------------------------------------------------------

        static char[] decodificarMensaje(char[] cod, Queue cola, char[] abc, int[] valores) //cod = char[] codificado, cola, abc = abecedario, valores = vectorValoresCodificado
        {
            char[] deco = new char[cod.Length];
            for(int i = 0; i < cod.Length; i++){
                int nro = (int)cola.Dequeue();
                int valor = valores[i]; //obtengo el entero correspondiente al char codificado (H pasó a ser M que tiene valor 12)
                int resta = valor - nro;
                if (resta >= 0){ //si la resta da negativa es porque llegó a 28 cuando hice la suma y empecé de vuelta, así que se lo tengo que sumar
                    deco[i] = abc[resta];
                }else{
                    deco[i] = abc[resta + 28];
                }
                cola.Enqueue(nro);
            }
            return deco;
        }

        //creo un vector con los valores de cada char del mensaje codificado
        static int[] vectorNroMensajeCodificado(String mens, char[] cod, char[] abc)
        {
            int[] vector = new int[mens.Length]; //vector que va a guardar los valores de cada char del mensaje encriptado
            for (int i = 0; i < mens.Length; i++){
                vector[i] = getValorChar(cod[i], abc);
            }
            return vector;
        }

        //consigo cada caracter del vector
        static int getValorChar(char c, char[] abc) //c = cada char del mensaje codificado (codificado[i])
        {
            int i = 0;
            while (abc[i] != c){ //mientras no encuentre el char, recorro el abecedario
                i++;
            }
            return i;

        }


        //------------------------OTROS--------------------------------

        static Queue reencolar(Queue cola, int[] c) //cola, c = vector de clave
        {
            while(cola.Count > 0){ //vacío cola de ser necesario
                cola.Dequeue();
            }
            for (int i = 0; i < c.Length; i++){ //encolo la clave
                cola.Enqueue(c[i]);
            }
            return cola;
        }
    }
}
