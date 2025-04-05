using System;
using System.Collections.Generic;
using System.Linq;

public class Flight
{
    public string Origin { get; set; }
    public string Destination { get; set; }
    public int Price { get; set; }
}

public class Dijkstra
{
    public static (List<string>, int) FindShortestPath(Dictionary<string, Dictionary<string, int>> graph, string start, string end)
    {
        var distances = new Dictionary<string, int>();
        var previous = new Dictionary<string, string>();
        var nodes = new List<string>(graph.Keys);

        foreach (var node in nodes)
        {
            distances[node] = int.MaxValue;
        }
        distances[start] = 0;

        while (nodes.Count > 0)
        {
            nodes.Sort((a, b) => distances[a].CompareTo(distances[b]));
            var currentNode = nodes.First();
            nodes.RemoveAt(0);

            if (currentNode == end)
            {
                break;
            }

            if (distances[currentNode] == int.MaxValue)
            {
                break; // No reachable nodes left
            }

            if (graph.ContainsKey(currentNode))
            {
                foreach (var neighbor in graph[currentNode])
                {
                    var newDistance = distances[currentNode] + neighbor.Value;
                    if (newDistance < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = newDistance;
                        previous[neighbor.Key] = currentNode;
                    }
                }
            }
        }

        var path = new List<string>();
        var current = end;
        while (previous.ContainsKey(current))
        {
            path.Insert(0, current);
            current = previous[current];
        }
        path.Insert(0, start);

        return (path, distances.ContainsKey(end) ? distances[end] : -1); // Return -1 if no path found
    }

    public static void Main(string[] args)
    {
        // Datos de vuelos
        List<Flight> flightsData = new List<Flight>()
        {
            new Flight { Origin = "Quito", Destination = "Bogotá", Price = 100 },
            new Flight { Origin = "Quito", Destination = "Miami", Price = 400 },
            new Flight { Origin = "Bogotá", Destination = "Miami", Price = 300 },
            new Flight { Origin = "Bogotá", Destination = "Quito", Price = 150 },
            new Flight { Origin = "Miami", Destination = "Quito", Price = 500 }
        };

        // Crear el grafo dirigido
        var flightGraph = new Dictionary<string, Dictionary<string, int>>();
        foreach (var flight in flightsData)
        {
            if (!flightGraph.ContainsKey(flight.Origin))
            {
                flightGraph[flight.Origin] = new Dictionary<string, int>();
            }
            flightGraph[flight.Origin][flight.Destination] = flight.Price;
        }

        // Aplicar el algoritmo de Dijkstra
        string origen = "Quito";
        string destino = "Miami";

        var (shortestPath, totalCost) = FindShortestPath(flightGraph, origen, destino);

        // Mostrar el camino más barato y el costo total
        Console.WriteLine($"El camino más barato de {origen} a {destino} es: {string.Join(" -> ", shortestPath)}");
        Console.WriteLine($"El costo total del vuelo es: ${totalCost}");

        Console.WriteLine("\nNota: La visualización del grafo con matplotlib no tiene una equivalencia directa y sencilla en C# estándar.");
        Console.WriteLine("Para visualización de grafos en C#, se pueden usar bibliotecas como QuickGraph o GraphSharp,");
        Console.WriteLine("pero su implementación requeriría la instalación de paquetes adicionales y un código más extenso.");
    }
}
