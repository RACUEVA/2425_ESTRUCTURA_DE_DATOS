using System;
using System.Collections.Generic;

namespace AsignaturasCurso
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una lista para almacenar las asignaturas
            List<string> asignaturas = new List<string>
            {
                "Matemáticas",
                "Física",
                "Química",
                "Historia",
                "Lengua"
            };

            // Mostrar las asignaturas por pantalla
            Console.WriteLine("Asignaturas del curso:");
            foreach (var asignatura in asignaturas)
            {
                Console.WriteLine(asignatura);
            }

            // Esperar a que el usuario presione una tecla antes de cerrar
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
