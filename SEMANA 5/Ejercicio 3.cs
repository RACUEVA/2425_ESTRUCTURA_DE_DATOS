using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear una lista para almacenar los números del 1 al 10
        List<int> numeros = new List<int>();

        // Llenar la lista con los números del 1 al 10
        for (int i = 1; i <= 10; i++)
        {
            numeros.Add(i);
        }

        // Invertir la lista
        numeros.Reverse();

        // Mostrar los números en orden inverso, separados por comas
        Console.WriteLine(string.Join(", ", numeros));
    }
}
