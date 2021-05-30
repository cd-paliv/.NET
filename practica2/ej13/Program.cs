using System;

namespace ej13
{
    enum Meses{
        Enero, Febrero, Marzo, Abril, Mayo, Junio, Julio, Agosto,
        Septiembre, Octubre, Noviembre, Diciembre
    }
    class Program
    {
        static void Main(string[] args)
        {
            for (Meses i = Meses.Diciembre; i >= Meses.Enero; i--){
                Console.WriteLine(i);
            }

            Console.WriteLine("Ingresar un mes");
            string mesingresado = Console.ReadLine();
            bool encontre = false;
            for (Meses i=Meses.Enero; i <= Meses.Diciembre; i++){
                if (mesingresado.Equals(Enum.GetName(i))){
                    encontre = true;
                }
            }
            Console.WriteLine(encontre);
            Console.ReadKey();

        }
    }
}
