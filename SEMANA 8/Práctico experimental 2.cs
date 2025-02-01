using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Queue<string> colaAsientos = new Queue<string>();
        int capacidad = 30;

        Console.WriteLine("Simulación de asignación de asientos en un parque de diversiones.");

        for (int i = 1; i <= capacidad; i++)
        {
            Console.Write($"Ingrese el nombre de la persona {i}: ");
            string nombre = Console.ReadLine();
            colaAsientos.Enqueue(nombre);
        }

        Console.WriteLine("\nTodos los asientos han sido asignados.");

        Console.WriteLine("\nOrden de ingreso a la atracción:");
        while (colaAsientos.Count > 0)
        {
            string persona = colaAsientos.Dequeue();
            Console.WriteLine($"{persona} ha subido a la atracción.");
        }

        Console.WriteLine("\nTodos los asientos han sido ocupados.");
    }
}