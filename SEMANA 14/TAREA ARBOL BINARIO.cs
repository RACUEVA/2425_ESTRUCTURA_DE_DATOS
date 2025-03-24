using System;

public class Nodo
{
    public int Clave { get; set; }
    public int Valor { get; set; }
    public Nodo Izquierda { get; set; }
    public Nodo Derecha { get; set; }

    public Nodo(int clave, int valor)
    {
        Clave = clave;
        Valor = valor;
        Izquierda = null;
        Derecha = null;
    }
}

public class ArbolBinario
{
    public Nodo Raiz { get; set; }

    public ArbolBinario()
    {
        Raiz = null;
    }

    public void Insertar(int clave, int valor)
    {
        Raiz = InsertarRecursivo(Raiz, clave, valor);
    }

    private Nodo InsertarRecursivo(Nodo nodo, int clave, int valor)
    {
        if (nodo == null)
        {
            return new Nodo(clave, valor);
        }

        if (clave < nodo.Clave)
        {
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, clave, valor);
        }
        else if (clave > nodo.Clave)
        {
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, clave, valor);
        }
        else
        {
            nodo.Valor = valor; // Actualizar si la clave ya existe
        }

        return nodo;
    }

    public int? Buscar(int clave)
    {
        return BuscarRecursivo(Raiz, clave);
    }

    private int? BuscarRecursivo(Nodo nodo, int clave)
    {
        if (nodo == null)
        {
            return null;
        }

        if (clave == nodo.Clave)
        {
            return nodo.Valor;
        }
        else if (clave < nodo.Clave)
        {
            return BuscarRecursivo(nodo.Izquierda, clave);
        }
        else
        {
            return BuscarRecursivo(nodo.Derecha, clave);
        }
    }

    public void Eliminar(int clave)
    {
        Raiz = EliminarRecursivo(Raiz, clave);
    }

    private Nodo EliminarRecursivo(Nodo nodo, int clave)
    {
        if (nodo == null)
        {
            return null;
        }

        if (clave < nodo.Clave)
        {
            nodo.Izquierda = EliminarRecursivo(nodo.Izquierda, clave);
        }
        else if (clave > nodo.Clave)
        {
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, clave);
        }
        else
        {
            if (nodo.Izquierda == null)
            {
                return nodo.Derecha;
            }
            else if (nodo.Derecha == null)
            {
                return nodo.Izquierda;
            }

            nodo.Clave = EncontrarMinimo(nodo.Derecha).Clave;
            nodo.Valor = EncontrarMinimo(nodo.Derecha).Valor;
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, nodo.Clave);
        }

        return nodo;
    }

    private Nodo EncontrarMinimo(Nodo nodo)
    {
        while (nodo.Izquierda != null)
        {
            nodo = nodo.Izquierda;
        }
        return nodo;
    }

    public void RecorridoInorden()
    {
        RecorridoInordenRecursivo(Raiz);
        Console.WriteLine();
    }

    private void RecorridoInordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            RecorridoInordenRecursivo(nodo.Izquierda);
            Console.Write($"({nodo.Clave}: {nodo.Valor}) ");
            RecorridoInordenRecursivo(nodo.Derecha);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();

        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Insertar nodo");
            Console.WriteLine("2. Buscar nodo");
            Console.WriteLine("3. Eliminar nodo");
            Console.WriteLine("4. Recorrido inorden");
            Console.WriteLine("5. Salir");

            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese la clave (entero): ");
                    int claveInsertar = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el valor (entero): ");
                    int valorInsertar = int.Parse(Console.ReadLine());
                    arbol.Insertar(claveInsertar, valorInsertar);
                    break;
                case "2":
                    Console.Write("Ingrese la clave a buscar: ");
                    int claveBuscar = int.Parse(Console.ReadLine());
                    int? valorBuscar = arbol.Buscar(claveBuscar);
                    if (valorBuscar.HasValue)
                    {
                        Console.WriteLine($"Valor encontrado: {valorBuscar.Value}");
                    }
                    else
                    {
                        Console.WriteLine("Clave no encontrada.");
                    }
                    break;
                case "3":
                    Console.Write("Ingrese la clave a eliminar: ");
                    int claveEliminar = int.Parse(Console.ReadLine());
                    arbol.Eliminar(claveEliminar);
                    break;
                case "4":
                    Console.WriteLine("Recorrido inorden:");
                    arbol.RecorridoInorden();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}