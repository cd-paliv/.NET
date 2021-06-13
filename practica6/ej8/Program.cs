using System;

namespace ej8
{
    class Program
    {
        static void Main(string[] args)
        {
            Empleado[] empleados = new Empleado[] {
                new Administrativo("Ana", 20000000, DateTime.Parse("26/4/2018"), 10000) {Premio=1000},
                new Vendedor("Diego", 30000000, DateTime.Parse("2/4/2010"), 10000) {Comision=2000},
                new Vendedor("Luis", 33333333, DateTime.Parse("30/12/2011"), 10000) {Comision=2000}
            };
            foreach (Empleado e in empleados)
            {
                Console.WriteLine(e);
                e.AumentarSalario();
                Console.WriteLine(e);
            }
        }
    }

    abstract class Empleado{
        //propiedades públicas de sólo lectura
        public String nombre {get;}
        public int DNI {get;}
        public DateTime FechaDeIngreso {get;}
        public double SalarioBase {get; protected set;}
        protected abstract double Salario { get; } //propiedad abstracta ya que dependiendo del tipo de empleado se calcula de una manera u otra
        protected int antiguedad(DateTime FechaActual)
        {
            if(FechaDeIngreso.CompareTo(FechaActual) < 0){ //compareTo Less than zero = This instance.precedes(value). 
                return FechaActual.Year - FechaDeIngreso.Year -1;
            }else{
                return FechaActual.Year - FechaDeIngreso.Year;
            }
        }

        protected Empleado(String nom, int DNI, DateTime Fecha, double SalarioBase)
        {
            this.nombre = nom;
            this.DNI = DNI;
            this.FechaDeIngreso = Fecha;
            this.SalarioBase = SalarioBase;
        }

        public abstract void AumentarSalario();
    }

    class Administrativo : Empleado {
        public double Premio {get; set;}
        protected override double Salario { get => SalarioBase + Premio; }

        public Administrativo(String nom, int DNI, DateTime Fecha, double SalarioBase) : base(nom, DNI, Fecha, SalarioBase){
            //this.Premio = Premio;
        }
        public double calcularSalario() => this.Premio + this.SalarioBase;
        public override void AumentarSalario() => SalarioBase += SalarioBase * (antiguedad(DateTime.Today) * 0.01);

        public override string ToString()
        {
            return $"Administrativo Nombre: {nombre}, DNI {DNI} Antiguedad: {antiguedad(DateTime.Today)}\nSalario base: ${SalarioBase:0.00}, Salario: ${Salario}\n-----------------------";
        }

    }

    class Vendedor : Empleado {
        public double Comision {get; set;}
        protected override double Salario { get => SalarioBase + Comision; }

        public Vendedor(String nom, int DNI, DateTime Fecha, double SalarioBase) : base(nom, DNI, Fecha, SalarioBase){
            //this.Comision = Comision;
        }
        public double calcularSalario() => Comision + this.SalarioBase;
        public override void AumentarSalario(){
            //se incrementará el salario base en un 5% si su antigüedad es inferior a 10 años o en un 10% en caso contrario.
            if(antiguedad(DateTime.Today) < 10){
                SalarioBase += SalarioBase * 0.05;
            }else{
                SalarioBase += SalarioBase * 0.1;
            }
        }

        public override string ToString()
        {
            return $"Vendedor Nombre: {nombre}, DNI {DNI} Antiguedad: {antiguedad(DateTime.Today)}\nSalario base: ${SalarioBase:0.00}, Salario: ${Salario}\n-----------------------";
        }

    }
}
