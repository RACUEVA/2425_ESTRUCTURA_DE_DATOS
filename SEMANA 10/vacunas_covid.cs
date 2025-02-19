using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Generar 500 ciudadanos ficticios
        var ciudadanos = Enumerable.Range(1, 500)
            .Select(i => new Ciudadano { Id = i, Nombre = $"Ciudadano {i}" })
            .ToList();

        // Asignar vacunas: 75 Pfizer, 75 AstraZeneca (algunos pueden tener ambas)
        var rnd = new Random();
        var vacunadosPfizer = ciudadanos.OrderBy(x => rnd.Next()).Take(75).ToHashSet();
        var vacunadosAstraZeneca = ciudadanos.OrderBy(x => rnd.Next()).Take(75).ToHashSet();

        // Operaciones de conjuntos
        var noVacunados = ciudadanos.Except(vacunadosPfizer.Union(vacunadosAstraZeneca)).ToList();
        var ambasVacunas = vacunadosPfizer.Intersect(vacunadosAstraZeneca).ToList();
        var soloPfizer = vacunadosPfizer.Except(ambasVacunas).ToList();
        var soloAstraZeneca = vacunadosAstraZeneca.Except(ambasVacunas).ToList();

        // Mostrar resultados
        Console.WriteLine("=== Reporte de Vacunación COVID ===");
        Console.WriteLine($"No vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ambas vacunas: {ambasVacunas.Count}");
        Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Solo AstraZeneca: {soloAstraZeneca.Count}");
    }
}

class Ciudadano
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}