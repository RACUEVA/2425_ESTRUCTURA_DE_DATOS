using System;
using System.Collections.Generic;
using System.Linq;

public class Vuelos
{
    public static void Main(string[] args)
    {
        // Datos de vuelos en formato de tabla (origen, destino, precio)
        var vuelos = new List<(string Origen, string Destino, int Precio)>
        {
            ("Quito", "Bogotá", 100),
            ("Quito", "Miami", 400),
            ("Bogotá", "Miami", 300),
            ("Bogotá", "Quito", 150),
            ("Miami", "Quito", 500)
        };

        // Crear un grafo dirigido como diccionario de diccionarios
        var grafo = new Dictionary<string, Dictionary<string, int>>();
        foreach (var vuelo in vuelos)
        {
            if (!grafo.ContainsKey(vuelo.Origen))
            {
                grafo[vuelo.Origen] = new Dictionary<string, int>();
            }
            grafo[vuelo.Origen][vuelo.Destino] = vuelo.Precio;
        }

        // Aplicar el algoritmo de Dijkstra para encontrar el vuelo más barato
        string origen = "Quito";
        string destino = "Miami";

        var (camino, costo) = Dijkstra(grafo, origen, destino);

        // Mostrar el camino más barato y el costo total
        Console.WriteLine($"El camino más barato de {origen} a {destino} es: {string.Join(" -> ", camino)}");
        Console.WriteLine($"El costo total del vuelo es: ${costo}");
    }

    // Algoritmo de Dijkstra
    public static (List<string>, int) Dijkstra(Dictionary<string, Dictionary<string, int>> grafo, string origen, string destino)
    {
        var distancias = new Dictionary<string, int>();
        var previos = new Dictionary<string, string>();
        var nodosNoVisitados = new HashSet<string>(grafo.Keys);

        foreach (var nodo in grafo.Keys)
        {
            distancias[nodo] = int.MaxValue;
        }
        distancias[origen] = 0;

        while (nodosNoVisitados.Count > 0)
        {
            var nodoActual = nodosNoVisitados.OrderBy(nodo => distancias[nodo]).First();
            nodosNoVisitados.Remove(nodoActual);

            if (nodoActual == destino)
            {
                break;
            }

            if (!grafo.ContainsKey(nodoActual))
            {
                continue;
            }

            foreach (var vecino in grafo[nodoActual])
            {
                var distanciaAlternativa = distancias[nodoActual] + vecino.Value;
                if (distanciaAlternativa < distancias[vecino.Key])
                {
                    distancias[vecino.Key] = distanciaAlternativa;
                    previos[vecino.Key] = nodoActual;
                }
            }
        }

        // Reconstruir el camino más corto
        var camino = new List<string>();
        var nodoActualCamino = destino;
        while (previos.ContainsKey(nodoActualCamino))
        {
            camino.Add(nodoActualCamino);
            nodoActualCamino = previos[nodoActualCamino];
        }
        camino.Add(origen);
        camino.Reverse();

        return (camino, distancias[destino]);
    }
}
