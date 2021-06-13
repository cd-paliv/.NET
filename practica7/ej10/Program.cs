using System;
using System.Collections;
using System.IO;

namespace ej10
{
    class Program
    {
        static ArrayList lista = new ArrayList(); //constante
        static void Main(string[] args)
        {
            int opc = opciones();
            while(opc != 5){
                switch(opc)
                {
                    case 1:
                        //permite al usuario agregar autos a la lista actual en memoria ingresando la marca y el modelo por la consola.
                        lista.Clear();
                        CrearListaAutos();
                        break;
                    case 2:
                        //carga en memoria una lista de autos previamente guardada en algún archivo de texto.
                        lista.Clear();
                        CargarListaEnMemoria();
                        break;
                    case 3:
                        //guarda en un archivo de texto la lista actual en memoria.
                        GuardarListaEnTxt();
                        break;
                    case 4:
                        //produce un listado por consola de todos los autos en la lista actual en memoria.
                        Imprimir();
                        break;
                }
                opc = opciones();
            }
        }
        
        private static int opciones()
        {
            ConsoleKeyInfo tecla;
            int valorTecla = -1;
            Console.WriteLine("\nMenú de opciones\n================\n");
            do{
                Console.WriteLine(" 1 - Ingresar autos desde la consola");
                Console.WriteLine(" 2 - Cargar lista de autos desde el disco");
                Console.WriteLine(" 3 - Guardar lista de autos en el disco");
                Console.WriteLine(" 4 - Listar por consola");
                Console.WriteLine(" 5 - Salir");
                Console.Write("Ingrese su opción: "); tecla = Console.ReadKey(true); Console.WriteLine(tecla.KeyChar);
                valorTecla = (int) Char.GetNumericValue(tecla.KeyChar);
                Console.WriteLine(" ");
            }while (valorTecla > 5 && valorTecla < 0);
            return valorTecla;
        }

        //case 1
        private static void CrearListaAutos()
        {
            Console.Write("Ingresar marca del auto: "); String marca = Console.ReadLine();
            if(! String.IsNullOrEmpty(marca)){
                do{
                    Console.Write("Ingresar modelo del auto: "); String modelo = Console.ReadLine();
                    lista.Add(new Auto(marca, modelo));
                    Console.Write("Ingresar marca del auto: "); marca = Console.ReadLine();
                }while (! String.IsNullOrEmpty(marca));
            }
        }

        //case 2
        private static void CargarListaEnMemoria()
        {
            using (StreamReader sr = new StreamReader("fuente.txt"))
            {
                while (! sr.EndOfStream)
                {
                    Auto a = new Auto(sr.ReadLine(), sr.ReadLine());
                    lista.Add(a);
                }
            }
            Console.WriteLine("Lista cargada");
        }

        //case 3
        private static void GuardarListaEnTxt()
        {
            using (StreamWriter archivotxt = new StreamWriter("autos-3.txt"))
            {
                foreach (Auto a in lista)
                {
                    archivotxt.WriteLine(a.Marca);
                    archivotxt.WriteLine(a.Modelo);
                }
            }
            Console.WriteLine("Lista exportada");
        }

        //case 4
        private static void Imprimir()
        {
            foreach(Auto a in lista){
                Console.WriteLine(a);
            }
        }
    }
    

    class Auto
    {
        public String Marca {get; private set;}
        public String Modelo {get; private set;}

        public Auto(String marca, String modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }

        public override String ToString()
        {
            return $"Auto {Marca}, modelo {Modelo}";
        }
    }

    
}
