namespace Objetos;

class Program
{
    /*
     * Una clase contiene diferentes miembros que permiten definir
     * las características y comportamientos de los objetos.
     *
     * CAMPOS:
     *      Variables que se declaran dentro de una clase y almacenan
     *      información. Pueden ser públicas o privadas.
     *
     * MÉTODOS:
     *      Bloques de código que definen comportamientos y ejecutan
     *      instrucciones dentro de tu clase.
     *
     * CONSTANTES:
     *      Valores que se declaran dentro de una clase y que no
     *      pueden modificarse después de su declaración.
     *
     * CONSTRUCTORES:
     *      Métodos especiales que se ejecutan al crear una instancia
     *      de una clase y permiten inicializar sus datos.
     *
     * PROPIEDADES:
     *      Los típicos get y set que permiten consultar o actualizar
     *      un dato, pudiendo incluir reglas para controlar su acceso.
     *
     * FINALIZADORES:
     *      Permiten ejecutar tareas de limpieza antes de que el
     *      recolector de basura libere un objeto.
     *
     * INDEXADORES:
     *      Permiten acceder a los elementos de un objeto utilizando
     *      una sintaxis similar a la de los arreglos, mediante índices.
     *
     * OPERADORES:
     *      Permiten definir cómo funcionan determinados operadores
     *      (+, -, *, ==, etc.) cuando se utilizan con objetos
     *      de una clase.
     *
     * EVENTOS:
     *      Permiten que una clase notifique a otras partes del programa
     *      cuando ocurre una acción o situación determinada.
     */
    
    
    public class Consola
    {
        
        /*Campos*/
        private String nombre;
        private String compañia;
        private float  precio;
        
        /*
         * Constantes
         */
        
        const String firma = "1234";
        
        /*
         * Constructo         
         */

        public Consola(String nombre, String compañia, float precio)
        {
            this.nombre = nombre;
            this.compañia = compañia;
            this.precio = precio;
        }
        

        /*
         * Métodos
         */

        public void encender()
        {
            Console.WriteLine("Encendiendo la consola " + firma);
        }
        
        /*propiedades*/
        public string Nombre
        {
            get => nombre;
            set => nombre = value ?? throw new ArgumentNullException(nameof(value));
        }
    }

    static void Main(string[] args)
    {
        Consola play = new Consola("PS1", "SONY", 1500);
        play.encender();
        Console.WriteLine(play.Nombre);
        
        /*
         * Paso de dato por valor
         *
         * Mandamos una copia de un valor a un método, este valor no modifica el valor original
         */

            int x = 10;
           cambiaValor(x); 
            Console.WriteLine("Fuera vale: "+ x);
            
        /*
         *Paso por referencia
         * Al enviar la referencia de donde guardamos el dato original, este si será modificado
         */

        int y = 11;
        
        Console.WriteLine("Antes de la funcion cambiaValor2 : " + y);
        cambiaValor2(ref  y);
        Console.WriteLine("Despues de la funcion cambiaValor2 : " + y);
        
        /*
         * Paso de variables por referencia sin que esten inicializadas
         */
        
        int  z;
        cambiaValor3(out z);
        Console.WriteLine("Despues de la funcion cambiaValor3 : " + z);
        
        /*
         * Imagina que quieres hacer una funcion que devuelva el valor de una suma,
         * Debemos devolver ademas un mensaje intermedio y guardar todo el comportamiento
         * por tanto podemos hacer lo siguiente
         */

        string mensaje;
        suma(5, 6, out mensaje);
        Console.WriteLine(mensaje);

    }

    static void cambiaValor(int valor)
    {
        valor += 1;
        Console.WriteLine("Dentro vale: " + valor);
    }
    static void cambiaValor2(ref int valor)
    {
        valor += 1;
        Console.WriteLine("Dentro vale: " + valor);
    }
    static void cambiaValor3(out int valor)
    {
        valor = 1;
        Console.WriteLine("Dentro vale: " + valor);
    }

    static int suma(int a, int b, out string  mensaje)
    {
        mensaje = $"La suma de {a} + {b} es {a + b}";
        return a + b;
    }
}