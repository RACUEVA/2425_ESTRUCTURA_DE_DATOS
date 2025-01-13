using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Inicializar la lista con los precios
        List<int> precios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };

        // Encontrar el menor y el mayor precio
        int menorPrecio = int.MaxValue; // Inicializar con el valor máximo posible
        int mayorPrecio = int.MinValue; // Inicializar con el valor mínimo posible

        foreach (int precio in precios)
        {
            if (precio < menorPrecio)
            {
                menorPrecio = precio; // Actualizar menor precio
            }
            if (precio > mayorPrecio)
            {
                mayorPrecio = precio; // Actualizar mayor precio
            }
        }

        // Mostrar los resultados
        Console.WriteLine("El menor precio es: " + menorPrecio);
        Console.WriteLine("El mayor precio es: " + mayorPrecio);
    }
}
