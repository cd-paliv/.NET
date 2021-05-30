using System;
using System.Collections;

namespace ej7
{
    class Program
    {
        static void Main(string[] args)
        {
            Nodo n = new Nodo(7);
            n.Insertar(8);
            n.Insertar(10);
            n.Insertar(3);
            n.Insertar(1);
            n.Insertar(5);
            n.Insertar(14);
            ArrayList l = n.GetInorden();
            if (l == null) Console.WriteLine("No hay elementos en el arbol");
            else{
                for (int i = 0; i < l.Count; i++){
                    Console.Write(l[i] + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine("Altura: " + n.GetAltura());
            Console.WriteLine("Cantidad de nodos: " + n.GetCantNodos());
            Console.WriteLine("Valor max: " + n.GetValorMaximo());
            Console.WriteLine("Valor min: " + n.GetValorMinimo());
            Console.ReadKey();
        }
    }

    class Nodo
    {
        private int dato;
        private Nodo HI;
        private Nodo HD;

        public Nodo(int valor)
        {
            dato = valor;
            HI = null;
            HD = null;
        }

        public int GetDato(){
            return dato;
        }
        
        public void Insertar(int valor)
        {
            if(this.dato < valor){
                if(HD == null){
                    this.HD = new Nodo(valor);
                }else this.HD.Insertar(valor);
            }else if (this.dato > valor){
                if(HI == null){
                    this.HI = new Nodo(valor);
                }else this.HI.Insertar(valor);
            }
        }

        private void GetInorder(Nodo n, ArrayList l)
        {
            if(n != null){
                GetInorder(n.HI, l);
                l.Add(n.dato);
                GetInorder(n.HD, l);
            }
        }
        public ArrayList GetInorden()
        {
            ArrayList l = new ArrayList();
            GetInorder(this, l);
            return l;
        }


        private int calcularAltura(Nodo n)
        {
            if(n != null){
                return 1 + Math.Max(calcularAltura(n.HI), calcularAltura(n.HD));
            }else return 0;
        }
        public int GetAltura()
        {
            return calcularAltura(this) - 1; //le resto la raíz xq tiene altura 0
        }

        
        
        private int Cantidad(Nodo n, int cant)
        {
            if(n != null){
                return 1 + Cantidad(n.HI, cant) + Cantidad(n.HD, cant);
            }else return 0;
        }
        public int GetCantNodos()
        {
            return Cantidad(this, 0);
        }

        public int GetValorMaximo()
        {
            if(this != null){
                Nodo aux = this;
                while(aux.HD != null)
                    aux = aux.HD;
                return aux.GetDato();
            }else return 0;
        }

        public int GetValorMinimo()
        {
            if(this != null){
                Nodo aux = this;
                while(aux.HI != null)
                    aux = aux.HI;
                return aux.GetDato();
            }else return 0;
        }
    }
}
