using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, string> espanolIngles = new Dictionary<string, string>()
    {
        {"día", "day"},
        {"ojo", "eye"},
        {"tiempo", "time"},
        {"persona", "person"},
        {"año", "year"},
        {"camino", "way"},
        {"cosa", "thing"},
        {"hombre", "man"},
        {"mundo", "world"},
        {"vida", "life"},
        {"mano", "hand"},
        {"parte", "part"},
        {"niño", "child"},
        {"niña", "child"},
        {"mujer", "woman"},
        {"lugar", "place"},
        {"trabajo", "work"},
        {"semana", "week"},
        {"caso", "case"},
        {"punto", "point"},
        {"tema", "point"},
        {"gobierno", "government"},
        {"empresa", "company"},
        {"compañía", "company"}
    };

    static Dictionary<string, string> inglesEspanol = new Dictionary<string, string>()
    {
        {"day", "día"},
        {"eye", "ojo"},
        {"time", "tiempo"},
        {"person", "persona"},
        {"year", "año"},
        {"way", "camino"},
        {"thing", "cosa"},
        {"man", "hombre"},
        {"world", "mundo"},
        {"life", "vida"},
        {"hand", "mano"},
        {"part", "parte"},
        {"child", "niño"},
        {"woman", "mujer"},
        {"place", "lugar"},
        {"work", "trabajo"},
        {"week", "semana"},
        {"case", "caso"},
        {"point", "punto"},
        {"government", "gobierno"},
        {"company", "empresa"},
        {"child", "niño"}
    };

    static void TraducirFrase(string frase, bool espanolInglesFlag)
    {
        string[] palabras = frase.Split(' ');
        string traduccion = "";

        if (espanolInglesFlag)
        {
            foreach (var palabra in palabras)
            {
                if (espanolIngles.ContainsKey(palabra.ToLower()))
                {
                    traduccion += espanolIngles[palabra.ToLower()] + " ";
                }
                else
                {
                    traduccion += palabra + " ";
                }
            }
        }
        else
        {
            foreach (var palabra in palabras)
            {
                if (inglesEspanol.ContainsKey(palabra.ToLower()))
                {
                    traduccion += inglesEspanol[palabra.ToLower()] + " ";
                }
                else
                {
                    traduccion += palabra + " ";
                }
            }
        }

        Console.WriteLine("Su frase traducida es: " + traduccion.Trim());
    }

    static void AgregarPalabras()
    {
        Console.Write("Ingrese la palabra en español: ");
        string espanol = Console.ReadLine();
        Console.Write("Ingrese la palabra en inglés: ");
        string ingles = Console.ReadLine();

        espanolIngles.Add(espanol, ingles);
        inglesEspanol.Add(ingles, espanol);

        Console.WriteLine("Palabras agregadas con éxito.");
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("MENU");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese la frase: ");
                    string frase = Console.ReadLine();
                    Console.Write("Traducir de español a inglés (1) o inglés a español (2): ");
                    int idioma = Convert.ToInt32(Console.ReadLine());
                    bool espanolInglesFlag = idioma == 1;
                    TraducirFrase(frase, espanolInglesFlag);
                    break;
                case 2:
                    AgregarPalabras();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    break;
            }
        }
    }
}
