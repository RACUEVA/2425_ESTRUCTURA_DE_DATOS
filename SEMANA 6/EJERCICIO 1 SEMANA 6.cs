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
        
        // Contar elementos en la lista
        int numeroDeElementos = lista.ContarElementos();
        
        Console.WriteLine($"El número de elementos en la lista es: {numeroDeElementos}");
        
        // Esperar a que el usuario presione una tecla antes de cerrar
        Console.ReadKey();
    }
}
