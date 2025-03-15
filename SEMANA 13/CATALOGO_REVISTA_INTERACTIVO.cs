using System;

// Clase para representar un nodo del árbol
public class Nodo
{
    public string Titulo { get; set; }
    public Nodo Izquierdo { get; set; }
    public Nodo Derecho { get; set; }

    public Nodo(string titulo)
    {
        Titulo = titulo;
        Izquierdo = Derecho = null;
    }
}

// Clase para gestionar el árbol binario de búsqueda
public class CatalogoRevistas
{
    private Nodo raiz;

    public CatalogoRevistas()
    {
        raiz = null;
    }

    // Insertar un título en el árbol (recursivo)
    public void Insertar(string titulo)
    {
        raiz = InsertarRecursivo(raiz, titulo);
    }

    private Nodo InsertarRecursivo(Nodo nodo, string titulo)
    {
        if (nodo == null)
            return new Nodo(titulo);

        int comparacion = string.Compare(titulo, nodo.Titulo);
        if (comparacion < 0)
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, titulo);
        else if (comparacion > 0)
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, titulo);

        return nodo;
    }

    // Buscar un título en el árbol (recursivo)
    public bool Buscar(string titulo)
    {
        return BuscarRecursivo(raiz, titulo);
    }

    private bool BuscarRecursivo(Nodo nodo, string titulo)
    {
        if (nodo == null)
            return false;

        int comparacion = string.Compare(titulo, nodo.Titulo);
        if (comparacion == 0)
            return true;
        else if (comparacion < 0)
            return BuscarRecursivo(nodo.Izquierdo, titulo);
        else
            return BuscarRecursivo(nodo.Derecho, titulo);
    }
}

class Program
{
    static void Main()
    {
        CatalogoRevistas catalogo = new CatalogoRevistas();

        // Ingresar 10 títulos
        Console.WriteLine("Ingrese 10 títulos de revistas:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Título {i + 1}: ");
            string titulo = Console.ReadLine();
            catalogo.Insertar(titulo);
        }

        // Menú interactivo
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Buscar título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título a buscar: ");
                    string tituloBuscado = Console.ReadLine();
                    Console.WriteLine(catalogo.Buscar(tituloBuscado) ? "Encontrado" : "No encontrado");
                    break;
                case "2":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}