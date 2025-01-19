using System;

public class Nodo
{
    public int Valor { get; set; }
    public Nodo Siguiente { get; set; }

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

public class ListaEnlazada
{
    private Nodo cabeza;

    public ListaEnlazada()
    {
        cabeza = null;
    }

    // Método para agregar un nodo al final de la lista
    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }

    // Función que calcula el número de elementos en la lista
    public int ContarElementos()
    {
        int contador = 0;
        Nodo actual = cabeza;

        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }

        return contador;
    }

    // Método para buscar un valor en la lista y contar cuántas veces aparece
    public void Buscar(int valor)
    {
        int contador = 0;
        Nodo actual = cabeza;

        while (actual != null)
        {
            if (actual.Valor == valor)
            {
                contador++;
            }
            actual = actual.Siguiente;
        }

        if (contador > 0)
        {
            Console.WriteLine($"El valor {valor} se encuentra {contador} veces en la lista.");
        }
        else
        {
            Console.WriteLine($"El valor {valor} no fue encontrado en la lista.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();
        
        // Agregar elementos a la lista
        lista.Agregar(10);
        lista.Agregar(20);
        lista.Agregar(30);
        lista.Agregar(20); // Agregamos un segundo 20 para probar la búsqueda
        
        // Contar elementos en la lista
        int numeroDeElementos = lista.ContarElementos();
        
        Console.WriteLine($"El número de elementos en la lista es: {numeroDeElementos}");
        
        // Buscar valores en la lista
        lista.Buscar(20); // Debería encontrar 2 veces
        lista.Buscar(30); // Debería encontrar 1 vez
        lista.Buscar(40); // No debería encontrar nada
        
        // Esperar a que el usuario presione una tecla antes de cerrar
        Console.ReadKey();
    }
}
