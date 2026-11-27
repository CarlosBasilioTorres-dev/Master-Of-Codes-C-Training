namespace Sección_5._Herencia;

class Program
{
    class Persona
    {
        private string nombre;
        private string apellido;
        private int edad;

        public Persona(string nombre, string apellido, int edad)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
            Edad = edad;
        }

        public string Nombre
        {
            get => nombre;
            set => nombre = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Apellido
        {
            get => apellido;
            set => apellido = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Edad
        {
            get => edad;
            set => edad = value;
        }
    }

    class Empleado : Persona
    {
        public Empleado(string nombre, string apellido, int edad) : base(nombre, apellido, edad)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
            Edad = edad;
        }
        
        
    }
    
    static void Main(string[] args)
    {
        Empleado empleado = new Empleado("Juan", "Juan", 35);
        Console.WriteLine(empleado.Nombre);
    }
}