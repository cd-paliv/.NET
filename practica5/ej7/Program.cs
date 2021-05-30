using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ej7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PERSONAS\n");
            
            ListaDePersonas listap = new ListaDePersonas();
            
            Persona p = new Persona();
            p.nombre = "Pedro";
            p.DNI = 52;
            Console.Write("Persona 1: ");
            p.imprimir();
            listap.Agregar(p); //l => p

            Persona p2 = new Persona();
            p2.nombre = "Lucas";
            p2.DNI = 8728937;
            Console.Write("Persona 2: ");
            p2.imprimir();
            listap.Agregar(p2); //l => p => p2

            Persona p3 = new Persona();
            p3.nombre = "Paula";
            p3.DNI = 42827257;
            Console.Write("Persona 3: ");
            p3.imprimir();
            listap.Agregar(p3); //l => p => p2 => p3

            Console.WriteLine("\n-------------------------------------------\n");


            //Ej8
            try{
                String nom = listap[8728937].nombre;
                Console.WriteLine("DNI: 872893 = " + nom);
            }
            catch(ArgumentException e) {
                Console.WriteLine(e.Message);
            }

            Console.Write("Personas con la 1era letra P:");
            //String[] nombres = listap['P'];
            foreach(String aux in listap['P']){
                Console.Write($" |{aux}");
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }

    class Persona
    {
        public string nombre { get; set; }
        public char sexo { get; set; }
        public int DNI { get; set; }
        public DateTime FechaNacimiento { get; set;}
        public int Edad { get; }

        public object this[int i]
        {
            get
            {
                switch (i){
                    case 0: return nombre;
                    case 1: return sexo;
                    case 2: return DNI;
                    case 3: return FechaNacimiento;
                    case 4: return Edad;
                    default: return null;

                }
            }
            set
            {
                switch(i){
                    case 0: nombre = (String)value;
                            break;
                    case 1: sexo = (Char)value;
                            break;
                    case 2: DNI = (int)value;
                            break;
                    case 3: FechaNacimiento = (DateTime)value;
                            break;
                    default: break;
                }
            }
        }

        public void imprimir(){
            Console.WriteLine("Nombre " + this[0] + " - DNI " + this[2]);
        }
    }
    //ejercicio 8
    class ListaDePersonas
    {
        private Hashtable ht = new Hashtable();
        public void Agregar(Persona p)
        {
            ht[p.DNI] = p;
        }

        public Persona this[int nro]
        {
            get{
                if(ht.ContainsKey(nro))
                    return (Persona)ht[nro];
                else //si no existe una llave con ese nro en el ht tengo que tirar error
                    throw new ArgumentException("ERROR: No existe una persona con ese DNI");
                
            }
        }

        public String[] this[char c]
        {
            get{
                ArrayList aux = new ArrayList();
                foreach(DictionaryEntry elem in ht){
                    Persona p = (Persona) elem.Value;
                    if(p.nombre[0] == c){
                        aux.Add(p.nombre);
                    }
                }
                String[] vector = aux.ToArray(typeof(String)) as String[];
                return vector;
            }
        }
    }
}
