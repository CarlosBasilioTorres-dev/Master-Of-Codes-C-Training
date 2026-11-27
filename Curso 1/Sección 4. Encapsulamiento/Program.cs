namespace Sección_4._Encapsulamiento;

class Program
{
    /*
     * Identificadores de acceso en C#
     *
     * public:
     *      Permite acceder al miembro desde cualquier parte del código,
     *      sin restricciones de acceso.
     *
     * private:
     *      Permite acceder al miembro únicamente desde la clase o estructura
     *      donde fue declarado.
     *
     * protected:
     *      Permite acceder al miembro desde la clase donde fue declarado
     *      y desde las clases que heredan de ella.
     *
     * internal:
     *      Permite acceder al miembro desde cualquier clase dentro del
     *      mismo ensamblado (proyecto compilado).
     *
     * protected internal:
     *      Permite acceder al miembro desde el mismo ensamblado o desde
     *      clases derivadas, incluso si se encuentran en otro ensamblado.
     *
     * private protected:
     *      Permite acceder al miembro únicamente desde la clase donde fue
     *      declarado y sus clases derivadas dentro del mismo ensamblado.
     *
     * file:
     *      Limita la visibilidad de un tipo (class, struct, interface, etc.)
     *      al archivo de código fuente donde fue declarado.
     *
     */

    /*
     *  Descriptores de acceso
     *
     *  Set
     *  Get
     *
     */

    /*
     * ENSAMBLADO (ASSEMBLY)
     *
     * Es la unidad básica de implementación, distribución y versionado
     * de una aplicación en .NET.
     *
     * Se genera durante el proceso de compilación y contiene:
     *
     *      - Código intermedio (IL / CIL).
     *      - Metadatos que describen los tipos, clases, métodos y referencias.
     *      - Manifiesto del ensamblado (Assembly Manifest), que contiene
     *        información de identidad, versión y dependencias.
     *      - Recursos adicionales, cuando existen.
     *
     * TIPOS DE ARCHIVOS:
     *
     *      DLL (Dynamic Link Library):
     *          Biblioteca que contiene código reutilizable.
     *          No se ejecuta directamente como una aplicación convencional.
     *
     *      EXE (Executable):
     *          Archivo ejecutable que sirve como punto de entrada
     *          de una aplicación.
     *
     * CARACTERÍSTICAS:
     *
     *      - Puede contener múltiples clases, interfaces y estructuras.
     *      - Puede hacer referencia a otros ensamblados.
     *      - Permite organizar y distribuir componentes de software.
     *      - Define el alcance del modificador de acceso INTERNAL.
     *
     * IMPORTANTE:
     *
     *      Un ensamblado no es lo mismo que un namespace.
     *
     *      NAMESPACE:
     *          Organiza lógicamente los tipos y evita conflictos de nombres.
     *
     *      ASSEMBLY:
     *          Agrupa físicamente los tipos compilados en un archivo DLL o EXE.
     *
     */

    /*
     * Orden de declaraciones de miembros de una clase
     *
     * Orden de modificacodes de acceso (public, internal, protected, private)
     * 1. Campos constantes, estaticos, de instancia
     * 2. Propiedades (primero autoimplementadas, luego con logica)
     * 3. Constructores
     * 4. Indexadores
     * 5. Operadores
     * 6. Métodos
     * 7. Eventos
     * 8. Implementacion de interfaces
     * 9. Finalizadores
     * 10. Tipos anidados (clases, estructuras, enumeraciones)
     */
    class Producto
    {
        /*
         *campos
         * 
         */
        private decimal precio;

        private string nombre;
        /*
         * Propiedades    
         * Implementacion de set y get con método tradicional
         */
        public decimal Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        /**
         * Implementacion de set y get con cuerpo de expresion
         */
        public string Nombre
        {
            get => nombre;
            set => nombre = value ?? throw new ArgumentNullException(nameof(value));
        }

        /*
         * solo estamos aplicando get
         
        // public string Nombre => nombre;
        */
        
        /*
         * Propiedades auto implementadas
         */

        public int Id { get; set; } = 35;


    }
    
    /*
     * Modificador static 
     *
     * modificador que indica que un miembro pertenece a la clase, no al objeto
     */

    class Alumno
    {
        public static int id ;
        // public int id;
        public string nombre;

        /**
         * El atributo id ppertenece a la clase, por tanto se puede utilizar sin instancia,
         * al modificar el valor del atributo, todos los objetos conocen el valor actualizado
         */
        public Alumno(string nombre)
        {
            id++;
            this.nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        }

        public static void IdsOcupados()
        {
            Console.WriteLine($"Tenemos {id} alumnos ");
        }
        
        /*
         * Por convencion, si tu quieres inicializar de alguna manera un campo estatico, se recomienda hacerlo
         * en un constructor estatico, el cual no puede ser llamado por una instancia ya que por defecto es
         * privado.
         */

        static Alumno()
        {
            id = 0;
            materias = 10;
        }
        
        /*
         * Propiedades estatica
         * Nos permiten acceder a propiedades estaticas desde el exterior
         */

        private static int materias;
        

        public static int Materias
        {
            get => materias;
            set => materias = value;
        }
    }

    /**
     * Clase estática
     *
     * Funcionan cuando necesitas agrupar funcionalidades que no necesariamente
     * requieren de una instancia para funcionar
     */

    static class Calculadora
    {
        public static float Suma(float a, float b)
        {
            return a + b;
        }

        public static float restar(float a, float b)
        {
            return a - b;
        }
    }

    /**
     * Métodos privados
     *
     * un método privado es una técnica utilizada para realizar tareas internas a la clase,
     * no necesariamente tareas pensadas para ser utilizadas fuera de la misma.
     *
     * Notece en el ejemplo siguiente, que isUser valida el usuario y la contraseña de
     * manera interna a la clase, pero esa l´gica no debe ser pública, contrario
     * al método que recibe la instruccion de login del usuario.
     * 
     */

    public class Autenticacion
    {
        /*
         * Método privado:
         * Contiene la lógica interna para validar las credenciales.
         */
        private bool IsUser(string username, string password)
        {
            // Ejemplo ilustrativo, no es una validación segura.
            return username.Equals(password);
        }

        /*
         * Método público:
         * Permite que otras clases soliciten el inicio de sesión.
         */
        public bool Login(string username, string password)
        {
            return IsUser(username, password);
        }
    }
    
    
    /*
     * Sanitizacion de datos
     *
     * Es importante validar cada dato que entra a nuestras clases, de esta manera
     * la integridad de los datos es completa
     */

    class Usuario
    {
        private string nombre;
        private int edad;

        public int Edad
        {
            get {return edad; }
            set
            {
                if (value >= 0)
                {
                    this.edad = value;
                }
                else
                {
                    throw new ArgumentException("La edad debe ser mayor o igual a 0");
                }
            }
        }
    }

    
    /**
     * inmutabilidad
     *
     * como su nombre lo indica, este concepto habla de entidades que,
     * una vez inicializadas, no pueden cambiar.
     *
     * En el ejemplo siguiente podemos ver que existen 2 atributos, nombre y edad, los cuales solo tienen
     * un get en sus propiedades.
     *
     * El constructor permitirá inicializarlos, pero despues de ello, no podremos modificar nada.
     *
     *
     * Palabra reservada readonly
     *
     * partiendo un poco de lo anterior, readonly tmabien permite establecer un estado de
     * inmutabilidad, la unica diferencia es que, la propiedad get solamente nos asegura
     * que fuera de la clase no podrá ser modificado pero dentro de la clase aun
     * lo pueden moificar métodos internos. readonly garantiza que de ninguna manera se puede modificar
     */
    class PersonaInmutable
    {
        private readonly string nombre;
        private int edad;
        
        public string Nombre { get; }
        public int Edad { get; }

        public PersonaInmutable(string nombre, int edad)
        {
            this.nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.edad = edad;
        }
    }

    /*
     * init viene a ser una version mas moderna de como utilizar variables inmutables
     * puede inicializarse de 2 maneras
     *
     * 1 mediante el constructor
     * 2 al momento de instanciarlo
     * 
     */
    class PersonaInit
    {
        public string Nombre { get; init; }
        //
        // public PersonaInit(string nombre)
        // {
        //     Nombre = nombre;
        // }
    }
    
    /*
     * Lo anterior puede ser sustituido por una única linea de codigo
     * utilizando clases inmutables, haciendo uso de record class
     */
    
    record PersonaRecord (string Nombre, int Edad);
    
    static void Main(string[] args)
    {
        Producto producto1 = new Producto();
        producto1.Id=1;
        Console.WriteLine(producto1.Id);

        Alumno alumno = new Alumno("Carlos");
        Console.WriteLine(Alumno.id);
        Console.WriteLine(Alumno.Materias);
        Alumno.IdsOcupados();
        Console.WriteLine(Calculadora.Suma(5, 5));

        double? puntosExtra = null;
        double calificacionFinal = 7;
        calificacionFinal += puntosExtra ?? 0;
        
        /*
         * inicializando init  
         */
        
        PersonaInit pi = new PersonaInit()
        {
            Nombre = "Pesho",
        };

        PersonaRecord pr = new PersonaRecord("carlos",25);

    }
    
}