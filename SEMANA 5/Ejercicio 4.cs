using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Almacenar el abecedario en una lista
        List<char> abecedario = new List<char>();
        for (char c = 'A'; c <= 'Z'; c++)
        {
            abecedario.Add(c);
        }

        // Eliminar letras en posiciones múltiplos de 3
        for (int i = abecedario.Count - 1; i >= 0; i--)
        {
            if ((i + 1) % 3 == 0) // +1 porque las posiciones son 1-based
            {
                abecedario.RemoveAt(i);
            }
        }

        // Mostrar la lista resultante
        Console.WriteLine("Lista resultante del abecedario:");
        foreach (char letra in abecedario)
        {
            Console.Write(letra + " ");
        }

        // Esperar a que el usuario presione una tecla para cerrar
        Console.ReadKey();
    }
}
