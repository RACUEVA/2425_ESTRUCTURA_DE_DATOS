using System;

class Program
{
    static void Main()
    {
        int n = 3; // Número de discos
        SolveHanoi(n, 'A', 'C', 'B'); // A: origen, C: destino, B: auxiliar
    }

    static void SolveHanoi(int n, char source, char target, char auxiliary)
    {
        if (n == 1)
        {
            Console.WriteLine($"Mover disco 1 desde {source} a {target}");
            return;
        }
        SolveHanoi(n - 1, source, auxiliary, target);
        Console.WriteLine($"Mover disco {n} desde {source} a {target}");
        SolveHanoi(n - 1, auxiliary, target, source);
    }
}
