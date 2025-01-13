using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear una lista de asignaturas
        List<string> asignaturas = new List<string>
        {
            "Matemáticas",
            "Física",
            "Química",
            "Historia",
            "Lengua"
        };

        // Mostrar cada asignatura en la consola
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine($"Yo estudio {asignatura}");
        }

        // Esperar a que el usuario presione una tecla antes de cerrar
        Console.ReadKey();
    }
}
