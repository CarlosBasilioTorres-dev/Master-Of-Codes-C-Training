# MasterOfCodes -- C# Training

Manual de estudio y consulta de **C# y .NET**, construido a partir de
apuntes de clase, ejemplos prácticos y explicaciones complementarias.

> El objetivo de este documento es transformar los apuntes en una guía
> técnica progresiva. Los ejemplos utilizan convenciones habituales de
> C#, como `PascalCase` para clases, métodos y propiedades, y
> `camelCase` para variables y parámetros.

## Índice

1.  [Namespaces y estructura de un
    programa](#1-namespaces-y-estructura-de-un-programa)
    -   [File-scoped
        namespace](#11-declaración-moderna-file-scoped-namespace)
    -   [Block-scoped
        namespace](#12-declaración-tradicional-block-scoped-namespace)
    -   [Estructura básica de un
        programa](#13-estructura-básica-de-un-programa)
2.  [Clases, objetos y miembros](#2-clases-objetos-y-miembros-en-c)
    -   [Miembros de una clase](#21-miembros-de-una-clase)
    -   [Ejemplo: clase Consola](#22-ejemplo-práctico-clase-consola)
    -   [Objetos e instancias](#23-objetos-e-instancias)
    -   [Paso de parámetros](#24-paso-de-parámetros-a-métodos)
    -   [Devolver información con
        `out`](#25-devolver-información-adicional-mediante-out)
3.  [Abstracción](#3-abstracción-en-c)
    -   [Interfaces](#31-interfaces)
    -   [Implementación de interfaces](#32-implementación-de-interfaces)
    -   [Sobrecarga de métodos](#33-sobrecarga-de-métodos)
    -   [`NotImplementedException`](#34-notimplementedexception)
    -   [Polimorfismo mediante
        interfaces](#35-polimorfismo-mediante-interfaces)
    -   [Varias interfaces](#36-implementar-varias-interfaces)
4.  [Encapsulamiento](#4-encapsulamiento-en-c)
    -   [Modificadores de
        acceso](#41-modificadores-de-acceso-access-modifiers)
    -   [Ensamblados](#42-ensamblados-assemblies)
    -   [Propiedades](#43-propiedades-properties)
    -   [Accesores con acceso
        restringido](#44-modificadores-de-acceso-en-propiedades)
    -   [Ejemplo
        práctico](#45-ejemplo-práctico-encapsulamiento-de-producto)
    -   [Importancia del
        encapsulamiento](#46-por-qué-es-importante-el-encapsulamiento)

------------------------------------------------------------------------

# 1. Namespaces y estructura de un programa

Un `namespace` (espacio de nombres) permite organizar clases,
interfaces, estructuras y otros tipos relacionados. También ayuda a
evitar conflictos entre identificadores que tienen el mismo nombre.

## 1.1. Declaración moderna: file-scoped namespace

A partir de **C# 10** se introdujo la sintaxis *file-scoped namespace*.
En esta forma no es necesario delimitar el contenido del namespace
mediante llaves.

``` csharp
/*
 * Declaración moderna de un namespace.
 * Todo el contenido posterior del archivo pertenece
 * al namespace declarado.
 */
namespace Proyecto_1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
```

Características:

-   La declaración termina con punto y coma (`;`).
-   No necesita llaves para delimitar el namespace.
-   Todo el contenido del archivo que aparece después de la declaración
    pertenece a ese namespace.
-   Solo puede existir una declaración *file-scoped namespace* por
    archivo.
-   No se puede combinar con una declaración tradicional de namespace en
    el mismo archivo.

## 1.2. Declaración tradicional: block-scoped namespace

La forma tradicional delimita el contenido del namespace mediante
llaves.

``` csharp
namespace Proyecto_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
```

Características:

-   Utiliza llaves `{ }` para delimitar el namespace.
-   Permite declarar varios namespaces en un mismo archivo.
-   Facilita organizar explícitamente diferentes bloques de código.

Ambas formas cumplen la misma función. La diferencia principal está en
la sintaxis y en las posibilidades de organización del archivo.

  Característica                    File-scoped               Block-scoped
  --------------------------------- ------------------------- ----------------------------
  Sintaxis                          `namespace Proyecto_1;`   `namespace Proyecto_1 { }`
  Llaves del namespace              No                        Sí
  Disponible desde                  C# 10                     Versiones anteriores
  Varios namespaces en el archivo   No                        Sí

## 1.3. Estructura básica de un programa

``` csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
```

Elementos principales:

-   `class Program`: declara una clase llamada `Program`.
-   `static`: indica que el método pertenece al tipo y puede invocarse
    sin crear una instancia de `Program`.
-   `void`: indica que el método no devuelve un valor.
-   `Main`: es el punto de entrada tradicional de una aplicación.
-   `string[] args`: recibe los argumentos enviados al ejecutar el
    programa.
-   `Console.WriteLine()`: escribe información en la consola y agrega un
    salto de línea.

### Consideración sobre `Main`

En C# moderno también existen los *top-level statements*. Permiten
escribir instrucciones directamente en un archivo sin declarar
explícitamente una clase `Program` ni un método `Main`. El compilador
genera el punto de entrada correspondiente.

------------------------------------------------------------------------

# 2. Clases, objetos y miembros en C

Una **clase** es una plantilla o modelo que define los datos y
comportamientos que tendrán los objetos creados a partir de ella.

Los elementos que forman parte de una clase se conocen como
**miembros**.

## 2.1. Miembros de una clase

  -----------------------------------------------------------------------
  Miembro                             Descripción
  ----------------------------------- -----------------------------------
  Campos (*fields*)                   Variables declaradas en un tipo que
                                      almacenan su estado.

  Métodos (*methods*)                 Bloques de código que definen
                                      comportamientos.

  Constantes (*constants*)            Valores constantes conocidos en
                                      tiempo de compilación.

  Constructores (*constructors*)      Miembros especiales que inicializan
                                      una instancia.

  Propiedades (*properties*)          Proporcionan una forma controlada
                                      de consultar o modificar datos.

  Finalizadores (*finalizers*)        Permiten ejecutar limpieza no
                                      determinista cuando el recolector
                                      de basura finaliza un objeto.

  Indexadores (*indexers*)            Permiten acceder a un objeto
                                      mediante una sintaxis similar a la
                                      de los arreglos.

  Operadores (*operators*)            Permiten definir operadores para
                                      tipos personalizados.

  Eventos (*events*)                  Permiten notificar a otros
                                      componentes cuando ocurre una
                                      acción o situación.
  -----------------------------------------------------------------------

No todas las clases necesitan todos estos miembros.

## 2.2. Ejemplo práctico: clase Consola

Una consola de videojuegos permite representar los campos, constantes,
constructores, métodos y propiedades de una clase.

``` csharp
namespace Objetos;

class Program
{
    public class Consola
    {
        // Campos
        private string nombre;
        private string compania;
        private decimal precio;

        // Constante
        private const string Firma = "1234";

        // Constructor
        public Consola(string nombre, string compania, decimal precio)
        {
            this.nombre = nombre;
            this.compania = compania;
            this.precio = precio;
        }

        // Método
        public void Encender()
        {
            Console.WriteLine("Encendiendo la consola " + Firma);
        }

        // Propiedad
        public string Nombre
        {
            get => nombre;
            set => nombre = value
                ?? throw new ArgumentNullException(nameof(value));
        }
    }

    static void Main(string[] args)
    {
        Consola play = new Consola("PS1", "SONY", 1500m);

        play.Encender();

        Console.WriteLine(play.Nombre);
    }
}
```

### Campos

``` csharp
private string nombre;
private string compania;
private decimal precio;
```

Los campos almacenan información relacionada con cada objeto. En este
ejemplo:

-   `nombre`: modelo de la consola.
-   `compania`: fabricante.
-   `precio`: precio de la consola.

El modificador `private` impide acceder directamente a estos campos
desde fuera de la clase.

### Constantes

``` csharp
private const string Firma = "1234";
```

Una constante representa un valor que no puede modificarse. Debe
inicializarse al declararse y su valor debe poder determinarse en tiempo
de compilación.

Los miembros `const` son implícitamente estáticos: pertenecen al tipo y
no a cada instancia.

### Constructores

``` csharp
public Consola(string nombre, string compania, decimal precio)
{
    this.nombre = nombre;
    this.compania = compania;
    this.precio = precio;
}
```

El constructor se ejecuta al crear una instancia y permite inicializar
su estado.

La palabra reservada `this` hace referencia a la instancia actual:

-   `this.nombre`: campo de la instancia.
-   `nombre`: parámetro recibido por el constructor.

### Métodos

``` csharp
public void Encender()
{
    Console.WriteLine("Encendiendo la consola " + Firma);
}
```

Los métodos representan acciones o comportamientos que puede realizar un
objeto.

### Propiedades

``` csharp
public string Nombre
{
    get => nombre;
    set => nombre = value
        ?? throw new ArgumentNullException(nameof(value));
}
```

Las propiedades controlan el acceso a los datos:

-   `get`: permite consultar el valor.
-   `set`: permite asignar un valor.
-   `value`: representa el valor recibido por el accesor `set`.
-   `nameof(value)`: obtiene el nombre del identificador indicado.

El operador `??` comprueba si el valor de la izquierda es `null`. Si lo
es, se lanza una excepción.

## 2.3. Objetos e instancias

Una vez declarada una clase, podemos crear objetos a partir de ella.

``` csharp
Consola play = new Consola("PS1", "SONY", 1500m);
```

  Elemento         Función
  ---------------- -------------------------------------------------
  `Consola`        Tipo de dato o clase.
  `play`           Variable que almacena una referencia al objeto.
  `new`            Crea una nueva instancia.
  `Consola(...)`   Invoca el constructor.

Un objeto es una instancia de una clase y mantiene su propio estado.

``` csharp
Consola play = new Consola("PS1", "SONY", 1500m);
Consola xbox = new Consola("Xbox", "Microsoft", 5000m);
```

Ambos objetos utilizan la misma definición de clase, pero mantienen sus
propios valores.

## 2.4. Paso de parámetros a métodos

En C# existen diferentes mecanismos para pasar argumentos a los métodos.
En este apartado se estudian el paso por valor, `ref` y `out`.

### 2.4.1. Paso por valor

Es el comportamiento predeterminado. El método recibe una copia del
argumento. En el caso de un tipo de valor, modificar el parámetro no
modifica la variable original.

``` csharp
static void CambiaValor(int valor)
{
    valor += 1;
    Console.WriteLine("Dentro vale: " + valor);
}

// En Main
int x = 10;

CambiaValor(x);

Console.WriteLine("Fuera vale: " + x);
```

Resultado:

``` text
Dentro vale: 11
Fuera vale: 10
```

El método recibe una copia de `10`, la incrementa a `11` y la variable
original `x` permanece en `10`.

**Importante:** el paso por valor también aplica a los tipos de
referencia. En ese caso se copia la referencia al objeto, no el objeto
completo. El método puede modificar el estado del objeto a través de esa
referencia, pero reasignar el parámetro no cambia la variable original
que se pasó.

### 2.4.2. Paso por referencia: `ref`

`ref` permite que el método trabaje con la variable original. Los
cambios realizados sobre el parámetro se reflejan en esa variable.

``` csharp
static void CambiaValor2(ref int valor)
{
    valor += 1;
    Console.WriteLine("Dentro vale: " + valor);
}

// En Main
int y = 11;

Console.WriteLine("Antes de la función: " + y);

CambiaValor2(ref y);

Console.WriteLine("Después de la función: " + y);
```

Resultado:

``` text
Antes de la función: 11
Dentro vale: 12
Después de la función: 12
```

Características de `ref`:

-   Se utiliza en la declaración del parámetro y en la llamada.
-   La variable debe estar inicializada antes de enviarse.
-   El método puede leer y modificar el valor.
-   Los cambios realizados sobre el parámetro se reflejan en la variable
    original.

### 2.4.3. Parámetro de salida: `out`

`out` permite que un método entregue información mediante uno o varios
parámetros adicionales. La variable no necesita estar inicializada antes
de la llamada, pero el método debe asignarle un valor antes de
finalizar.

``` csharp
static void CambiaValor3(out int valor)
{
    valor = 1;
    Console.WriteLine("Dentro vale: " + valor);
}

// En Main
int z;

CambiaValor3(out z);

Console.WriteLine("Después de la función: " + z);
```

Resultado:

``` text
Dentro vale: 1
Después de la función: 1
```

Características de `out`:

-   No requiere inicialización previa de la variable.
-   El método debe asignarle un valor antes de finalizar.
-   Se utiliza en la declaración del parámetro y en la llamada.
-   Permite devolver información adicional al valor de retorno habitual.

### 2.4.4. Comparación: valor, `ref` y `out`

  -----------------------------------------------------------------------
  Característica    Por valor         `ref`             `out`
  ----------------- ----------------- ----------------- -----------------
  Inicialización    Sí, para          Sí                No
  previa            variables locales                   
                    usadas como                         
                    argumento                           

  Puede leer el     Sí                Sí                No debe leerse
  valor inicial                                         antes de
                                                        asignarlo

  Debe asignarse    No                No                Sí, antes de
  dentro del método                                     finalizar

  Puede modificar   No directamente   Sí                Sí
  la variable del                                       
  llamador                                              

  Palabra reservada No                Sí                Sí
  en la llamada                                         
  -----------------------------------------------------------------------

Regla para recordar:

-   **Valor:** el método recibe una copia.
-   **`ref`:** el método recibe acceso por referencia a la variable.
-   **`out`:** el método debe proporcionar un valor a través del
    parámetro.

## 2.5. Devolver información adicional mediante `out`

Normalmente, un método utiliza `return` para devolver un resultado.
Podemos combinar `return` y `out` cuando necesitamos entregar
información adicional.

``` csharp
static int Suma(int a, int b, out string mensaje)
{
    mensaje = $"La suma de {a} + {b} es {a + b}";
    return a + b;
}

// En Main
string mensaje;

int resultado = Suma(5, 6, out mensaje);

Console.WriteLine("Resultado: " + resultado);
Console.WriteLine(mensaje);
```

Resultado:

``` text
Resultado: 11
La suma de 5 + 6 es 11
```

-   `return` devuelve el resultado numérico.
-   `out mensaje` entrega información adicional.
-   La llamada guarda ambos resultados en variables diferentes.

------------------------------------------------------------------------

# 3. Abstracción en C

La **abstracción** es uno de los cuatro pilares de la Programación
Orientada a Objetos (POO).

Consiste en identificar las características y comportamientos esenciales
de un elemento, exponiendo lo necesario y ocultando los detalles
internos de su implementación.

En C#, la abstracción se puede implementar principalmente mediante:

-   Interfaces (`interface`).
-   Clases abstractas (`abstract class`).

En esta sección se estudian las interfaces.

## 3.1. Interfaces

Una interfaz es un contrato que establece qué miembros debe implementar
una clase o estructura que decida utilizarla.

Define qué debe hacer un objeto, pero no necesariamente cómo debe
hacerlo.

Se declara utilizando la palabra reservada `interface`.

``` csharp
public interface IAnimal
{
    void Comer();
    void Dormir();
    void Moverse();
}
```

Características:

-   Por convención, los nombres de las interfaces comienzan con `I`.
-   Define miembros que los tipos que la implementan deben proporcionar,
    según el tipo de miembro y su implementación.
-   Una clase puede implementar varias interfaces.
-   No se pueden crear instancias directamente de una interfaz.
-   Permite establecer contratos comunes entre clases diferentes.

Los métodos abstractos tradicionales de una interfaz son públicos de
forma implícita. No es necesario escribir `public` en cada declaración.

## 3.2. Implementación de interfaces

Para implementar una interfaz, una clase utiliza los dos puntos (`:`),
seguidos del nombre de la interfaz.

``` csharp
namespace Seccion_3_Abstraccion;

class Program
{
    public interface IAnimal
    {
        void Comer();
        void Dormir();
        void Moverse();
    }

    public class Carnivoro : IAnimal
    {
        public void Comer()
        {
            Console.WriteLine("Carnívoro come");
        }

        public void Comer(string comida)
        {
            Console.WriteLine("Carnívoro come " + comida);
        }

        public void Dormir()
        {
            Console.WriteLine("El carnívoro está durmiendo");
        }

        public void Moverse()
        {
            Console.WriteLine("El carnívoro está caminando");
        }
    }

    public class Herbivoro : IAnimal
    {
        public void Comer()
        {
            Console.WriteLine("Herbívoro come");
        }

        public void Dormir()
        {
            Console.WriteLine("El herbívoro está durmiendo");
        }

        public void Moverse()
        {
            Console.WriteLine("El herbívoro está caminando");
        }
    }

    static void Main(string[] args)
    {
        Carnivoro c = new Carnivoro();
        c.Comer();
        c.Comer("Carne");
    }
}
```

### Análisis

**Declaración de la interfaz**

``` csharp
public interface IAnimal
{
    void Comer();
    void Dormir();
    void Moverse();
}
```

Establece un contrato con tres métodos. Las clases que implementen esta
interfaz deben proporcionar las implementaciones correspondientes.

**Implementación en `Carnivoro`**

``` csharp
public class Carnivoro : IAnimal
```

La clase implementa `IAnimal` y proporciona sus propias versiones de
`Comer`, `Dormir` y `Moverse`.

**Implementación en `Herbivoro`**

``` csharp
public class Herbivoro : IAnimal
```

Esta clase también cumple el contrato, pero puede proporcionar
comportamientos diferentes.

Ambas clases cumplen la misma interfaz aunque su implementación interna
sea distinta.

## 3.3. Sobrecarga de métodos (Method Overloading)

En la clase `Carnivoro` se declaran dos métodos llamados `Comer`:

``` csharp
public void Comer()
{
    Console.WriteLine("Carnívoro come");
}

public void Comer(string comida)
{
    Console.WriteLine("Carnívoro come " + comida);
}
```

Esto se conoce como **sobrecarga de métodos**. Consiste en declarar
varios métodos con el mismo nombre, pero con diferentes listas de
parámetros.

``` csharp
Carnivoro c = new Carnivoro();

c.Comer();
c.Comer("Carne");
```

El compilador determina qué método ejecutar según los argumentos
recibidos. La sobrecarga no forma parte del contrato de `IAnimal` en
este ejemplo: es una funcionalidad adicional de `Carnivoro`.

## 3.4. `NotImplementedException`

Durante el desarrollo puede utilizarse:

``` csharp
public void Dormir()
{
    throw new NotImplementedException();
}
```

Esta instrucción lanza una excepción cuando se invoca el método,
indicando que su comportamiento todavía no está implementado.

El código puede compilar, pero al ejecutar ese método se producirá la
excepción. No debe confundirse con una implementación funcional del
contrato.

## 3.5. Polimorfismo mediante interfaces

Una ventaja importante de las interfaces es que permiten trabajar con
diferentes clases utilizando un mismo tipo de referencia.

``` csharp
IAnimal animal1 = new Carnivoro();
IAnimal animal2 = new Herbivoro();

animal1.Comer();
animal2.Comer();
```

Aunque ambas variables son de tipo `IAnimal`, cada una ejecuta la
implementación correspondiente al objeto que contiene.

Esto permite escribir código que dependa de un contrato común y no de
una clase específica.

## 3.6. Implementar varias interfaces

Una clase puede implementar más de una interfaz.

``` csharp
public interface IAnimal
{
    void Comer();
}

public interface IReproduccion
{
    void Reproducirse();
}

public class Carnivoro : IAnimal, IReproduccion
{
    public void Comer()
    {
        Console.WriteLine("Comiendo carne");
    }

    public void Reproducirse()
    {
        Console.WriteLine("Reproduciéndose");
    }
}
```

En `Carnivoro : IAnimal, IReproduccion`, la clase declara que cumple
ambos contratos.

Esto permite combinar diferentes capacidades sin necesitar heredar de
varias clases base.

------------------------------------------------------------------------

# 4. Encapsulamiento en C

El **encapsulamiento** es uno de los cuatro pilares de la Programación
Orientada a Objetos (POO).

Consiste en proteger y controlar el acceso a los datos internos de una
clase, evitando que otras partes del programa puedan modificarlos
libremente.

En C#, el encapsulamiento se implementa principalmente mediante:

-   Modificadores de acceso.
-   Campos privados.
-   Propiedades (`get` y `set`).
-   Métodos que controlan las operaciones sobre los datos.

Su objetivo es mantener el estado de un objeto bajo control y garantizar
que los datos cumplan las reglas establecidas por la clase.

## 4.1. Modificadores de acceso (Access Modifiers)

Los modificadores de acceso determinan desde qué partes del programa se
puede acceder a una clase, método, propiedad, campo u otro miembro.

### `public`

Permite acceder al miembro desde cualquier parte del código donde el
tipo sea accesible.

``` csharp
public class Producto
{
    public string Nombre;
}
```

### `private`

Permite acceder al miembro únicamente desde el tipo donde fue declarado.

``` csharp
public class Producto
{
    private decimal precio;
}
```

Es el modificador utilizado habitualmente para proteger los campos
internos de una clase.

### `protected`

Permite acceder al miembro desde el tipo donde fue declarado y desde los
tipos derivados.

``` csharp
public class Producto
{
    protected decimal precio;
}

public class ProductoDigital : Producto
{
    public void MostrarPrecio()
    {
        Console.WriteLine(precio);
    }
}
```

### `internal`

Permite acceder al miembro desde cualquier tipo que pertenezca al mismo
ensamblado (*assembly*).

``` csharp
internal class Producto
{
    internal decimal precio;
}
```

### `protected internal`

Combina dos posibilidades de acceso:

-   Desde cualquier parte del mismo ensamblado.
-   Desde tipos derivados, incluso si se encuentran en otro ensamblado.

Es una condición **OR**: basta con cumplir una de las dos condiciones.

``` csharp
public class Producto
{
    protected internal decimal precio;
}
```

### `private protected`

Permite acceder al miembro desde el tipo donde fue declarado y desde sus
tipos derivados, siempre que estos pertenezcan al mismo ensamblado.

Es una condición más restrictiva: deben cumplirse tanto la relación de
herencia como la pertenencia al mismo ensamblado.

``` csharp
public class Producto
{
    private protected decimal precio;
}
```

### `file`

Introducido en C# 11, limita la visibilidad de un tipo al archivo de
código fuente donde fue declarado.

Se utiliza para tipos como clases, estructuras e interfaces.

``` csharp
file class ProductoInterno
{
}
```

Una declaración `file` no puede utilizarse para campos o métodos
individuales.

### Tabla comparativa

  Modificador            Alcance
  ---------------------- ----------------------------------------------------
  `public`               Desde cualquier lugar donde el tipo sea accesible.
  `private`              Dentro del tipo que lo declara.
  `protected`            Dentro del tipo y sus tipos derivados.
  `internal`             Dentro del mismo ensamblado.
  `protected internal`   Mismo ensamblado o tipos derivados.
  `private protected`    Tipos derivados dentro del mismo ensamblado.
  `file`                 Dentro del archivo de código fuente.

## 4.2. Ensamblados (Assemblies)

Un ensamblado es una unidad básica de implementación, distribución y
versionado de código en .NET.

Se genera durante la compilación y contiene información necesaria para
que el entorno .NET pueda identificar y utilizar los componentes
compilados.

Entre sus elementos encontramos:

-   Código intermedio (IL / CIL).
-   Metadatos que describen clases, métodos, propiedades y otros tipos.
-   Manifiesto del ensamblado (*Assembly Manifest*).
-   Recursos adicionales, cuando existen.

### Tipos de archivos

**DLL (Dynamic Link Library)**

Es una biblioteca que contiene código reutilizable. Puede ser
referenciada por otros proyectos o aplicaciones.

**EXE (Executable)**

Es un archivo ejecutable que puede actuar como punto de entrada de una
aplicación.

### Características

-   Pueden contener múltiples clases, interfaces y estructuras.
-   Pueden hacer referencia a otros ensamblados.
-   Permiten distribuir componentes de software.
-   Determinan el alcance del modificador `internal`.

### Diferencia entre Namespace y Assembly

  -----------------------------------------------------------------------
  Namespace                           Assembly
  ----------------------------------- -----------------------------------
  Organiza lógicamente los tipos.     Agrupa componentes compilados.

  Ayuda a evitar conflictos de        Permite distribuir y versionar
  nombres.                            componentes.

  Se declara mediante `namespace`.    Se genera durante la compilación.

  No determina por sí mismo el        Define el alcance de `internal`.
  acceso.                             
  -----------------------------------------------------------------------

Un mismo ensamblado puede contener varios namespaces. También es posible
que un namespace esté distribuido entre diferentes ensamblados.

## 4.3. Propiedades (Properties)

Las propiedades permiten controlar el acceso a los campos de una clase
mediante los métodos de acceso `get` y `set`.

Son uno de los mecanismos más importantes para implementar
encapsulamiento en C#.

### `get` y `set`

-   `get`: permite obtener o consultar el valor de una propiedad.
-   `set`: permite asignar o modificar el valor de una propiedad.
-   `value`: representa el valor que se intenta asignar mediante `set`.

``` csharp
public class Producto
{
    private decimal precio;

    public decimal Precio
    {
        get { return precio; }
        set { precio = value; }
    }
}
```

En este ejemplo:

-   `precio` es un campo privado.
-   `Precio` es una propiedad pública.
-   `get` permite consultar el campo.
-   `set` permite modificar el campo.

Uso:

``` csharp
Producto producto = new Producto();

producto.Precio = 150.50m;

Console.WriteLine(producto.Precio);
```

### 4.3.1. Implementación tradicional

La forma tradicional utiliza bloques de código para implementar los
accesores.

``` csharp
public decimal Precio
{
    get
    {
        return precio;
    }

    set
    {
        precio = value;
    }
}
```

Esta implementación es útil cuando necesitamos ejecutar varias
instrucciones al consultar o modificar un valor.

### 4.3.2. Cuerpos de expresión (Expression-bodied members)

C# permite simplificar los accesores utilizando `=>`.

``` csharp
public string Nombre
{
    get => nombre;
    set => nombre = value;
}
```

Ambas formas realizan la misma operación. Los cuerpos de expresión
permiten escribir operaciones sencillas de manera más compacta.

### 4.3.3. Validaciones dentro de las propiedades

Una ventaja importante de las propiedades es que podemos incorporar
reglas para controlar los valores que se asignan.

``` csharp
private string nombre;

public string Nombre
{
    get => nombre;

    set => nombre = value
        ?? throw new ArgumentNullException(nameof(value));
}
```

Si recibimos `null`, se genera una excepción. Si recibimos un valor
válido, se almacena.

### 4.3.4. Propiedades de solo lectura

Podemos declarar propiedades que únicamente permitan consultar
información.

``` csharp
public string Nombre => nombre;
```

Esta sintaxis es una propiedad de solo lectura cuyo `get` devuelve
directamente el campo `nombre`.

También podemos escribirla de forma tradicional:

``` csharp
public string Nombre
{
    get { return nombre; }
}
```

En ambos casos no existe un `set` público, por lo que el código externo
no puede modificar la propiedad mediante una asignación.

### 4.3.5. Propiedades autoimplementadas (Auto-implemented Properties)

C# permite declarar propiedades sin necesidad de crear manualmente un
campo privado.

``` csharp
public int Id { get; set; } = 35;
```

El compilador genera internamente un campo de respaldo (*backing field*)
para almacenar el valor.

En este ejemplo:

-   `Id` es una propiedad pública.
-   `get` permite consultar el valor.
-   `set` permite modificarlo.
-   `= 35` establece su valor inicial.

Uso:

``` csharp
Producto producto = new Producto();

Console.WriteLine(producto.Id); // 35

producto.Id = 1;

Console.WriteLine(producto.Id); // 1
```

No necesitamos declarar un campo adicional para almacenar `Id`.

### Comparación de propiedades

  -----------------------------------------------------------------------------------
  Tipo                    Ejemplo                             Característica
  ----------------------- ----------------------------------- -----------------------
  Tradicional             `get { return precio; }`            Permite escribir lógica
                                                              completa.

  Cuerpo de expresión     `get => precio;`                    Sintaxis simplificada.

  Solo lectura            `public string Nombre => nombre;`   No permite asignación
                                                              externa.

  Autoimplementada        `public int Id { get; set; }`       El compilador genera el
                                                              campo interno.
  -----------------------------------------------------------------------------------

## 4.4. Modificadores de acceso en propiedades

Los modificadores de acceso también pueden aplicarse individualmente a
los accesores `get` y `set`.

Esto permite controlar quién puede consultar una propiedad y quién puede
modificarla.

``` csharp
public class Producto
{
    public int Id { get; private set; }
}
```

En este caso:

-   `get` es público: cualquier código que pueda acceder a la propiedad
    puede consultar el identificador.
-   `set` es privado: únicamente el tipo `Producto` puede modificarlo.

Otro ejemplo:

``` csharp
public class Producto
{
    public decimal Precio { get; protected set; }
}
```

El precio puede consultarse públicamente, pero solamente el tipo y sus
tipos derivados pueden modificarlo.

**Regla:** cuando se declara un modificador de acceso en un accesor
individual, este debe ser más restrictivo que el de la propiedad. Solo
uno de los accesores puede tener un modificador de acceso explícito.

## 4.5. Ejemplo práctico: encapsulamiento de Producto

``` csharp
public class Producto
{
    // Campos privados
    private decimal precio;
    private string nombre;

    // Propiedad con get y set tradicionales
    public decimal Precio
    {
        get { return precio; }
        set { precio = value; }
    }

    // Propiedad con cuerpos de expresión
    public string Nombre
    {
        get => nombre;
        set => nombre = value
            ?? throw new ArgumentNullException(nameof(value));
    }

    // Propiedad autoimplementada
    public int Id { get; set; } = 35;
}
```

Uso:

``` csharp
static void Main(string[] args)
{
    Producto producto1 = new Producto();

    producto1.Id = 1;
    producto1.Nombre = "Laptop";
    producto1.Precio = 15000m;

    Console.WriteLine(producto1.Id);
    Console.WriteLine(producto1.Nombre);
    Console.WriteLine(producto1.Precio);
}
```

Resultado:

``` text
1
Laptop
15000
```

Podemos acceder a las propiedades públicas, pero no directamente a los
campos privados. Por ejemplo, esto genera un error de compilación:

``` csharp
producto1.precio = 15000m;
```

Esto sucede porque `precio` está declarado como `private`.

## 4.6. ¿Por qué es importante el encapsulamiento?

Imaginemos que permitimos modificar libremente el precio de un producto:

``` csharp
producto1.Precio = -500;
```

Técnicamente, el programa lo permitiría, aunque un precio negativo no
tenga sentido en este escenario.

Podemos mejorar la propiedad incorporando una validación:

``` csharp
public decimal Precio
{
    get => precio;

    set
    {
        if (value < 0)
        {
            throw new ArgumentException(
                "El precio no puede ser negativo."
            );
        }

        precio = value;
    }
}
```

Ahora la clase controla las condiciones bajo las cuales puede
modificarse su información.

Esta es una de las finalidades principales del encapsulamiento:
**proteger la integridad de los datos y controlar cómo se modifica el
estado de un objeto.**

## 4.7. Consideraciones importantes

1.  Los campos generalmente deben declararse como `private`, evitando
    exponer directamente el estado interno de los objetos.
2.  Las propiedades permiten proporcionar acceso controlado a los
    campos.
3.  No todas las propiedades necesitan tener `get` y `set`; podemos
    utilizar propiedades de solo lectura.
4.  Las propiedades autoimplementadas son útiles cuando no necesitamos
    lógica adicional.
5.  `internal` está relacionado con el ensamblado, no con el namespace.
6.  `protected internal` utiliza una condición OR, mientras que
    `private protected` requiere cumplir ambas condiciones.
7.  El encapsulamiento no consiste únicamente en ocultar información,
    sino también en controlar las operaciones permitidas sobre ella.

------------------------------------------------------------------------

# Glosario general

  -----------------------------------------------------------------------
  Término                             Significado
  ----------------------------------- -----------------------------------
  Namespace                           Espacio lógico para organizar
                                      tipos.

  Assembly                            Unidad compilada de implementación
                                      y distribución en .NET.

  Clase                               Plantilla que define datos y
                                      comportamientos.

  Objeto                              Instancia de una clase.

  Campo                               Variable que almacena el estado de
                                      un tipo u objeto.

  Método                              Bloque de código que define una
                                      operación.

  Constante                           Valor que no puede cambiar y se
                                      determina en compilación.

  Constructor                         Miembro que inicializa una
                                      instancia.

  Propiedad                           Mecanismo controlado de acceso a
                                      datos.

  Interfaz                            Contrato que define miembros que
                                      deben implementarse.

  Abstracción                         Representación de las
                                      características esenciales de un
                                      elemento.

  Encapsulamiento                     Protección y control del estado
                                      interno de un objeto.

  Polimorfismo                        Capacidad de utilizar distintas
                                      implementaciones mediante un tipo
                                      común.

  `ref`                               Permite pasar una variable por
                                      referencia al método.

  `out`                               Permite devolver información
                                      mediante un parámetro de salida.

  `get`                               Accesor para consultar una
                                      propiedad.

  `set`                               Accesor para modificar una
                                      propiedad.

  Backing field                       Campo interno que almacena el valor
                                      de una propiedad.
  -----------------------------------------------------------------------

------------------------------------------------------------------------

# Progreso del entrenamiento

  Sección   Tema                                             Estado
  --------- ------------------------------------------------ -------------
  1         Namespaces y estructura de un programa           Documentado
  2         Clases, objetos, miembros y paso de parámetros   Documentado
  3         Abstracción mediante interfaces                  Documentado
  4         Encapsulamiento y modificadores de acceso        Documentado
  5         Herencia                                         Pendiente
  6         Polimorfismo                                     Pendiente
  7         Abstracción mediante clases abstractas           Pendiente

> **Nota:** este manual se encuentra en construcción. Los temas se irán
> ampliando conforme avance el entrenamiento, incorporando ejemplos,
> buenas prácticas y relaciones entre conceptos.
