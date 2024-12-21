using System;

namespace FigurasGeometricas
{
    // Clase que representa un círculo
    public class Circulo
    {
        // Propiedad que almacena el radio del círculo
        public double Radio { get; set; }

        // Constructor que inicializa el radio
        public Circulo(double radio)
        {
            Radio = radio;
        }

        // Método para calcular el área del círculo
        // CalcularArea es una función que devuelve un valor double,
        // se utiliza para calcular el área de un círculo, requiere como argumento el radio del círculo
        public double CalcularArea()
        {
            return Math.PI * Radio * Radio;
        }

        // Método para calcular el perímetro del círculo
        // CalcularPerimetro es una función que devuelve un valor double,
        // se utiliza para calcular el perímetro de un círculo, no requiere argumentos adicionales
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * Radio;
        }
    }

    // Clase que representa un rectángulo
    public class Rectangulo
    {
        // Propiedades que almacenan la base y la altura del rectángulo
        public double Base { get; set; }
        public double Altura { get; set; }

        // Constructor que inicializa la base y la altura
        public Rectangulo(double baseRect, double altura)
        {
            Base = baseRect;
            Altura = altura;
        }

        // Método para calcular el área del rectángulo
        // CalcularArea es una función que devuelve un valor double,
        // se utiliza para calcular el área de un rectángulo, requiere como argumentos la base y la altura
        public double CalcularArea()
        {
            return Base * Altura;
        }

        // Método para calcular el perímetro del rectángulo
        // CalcularPerimetro es una función que devuelve un valor double,
        // se utiliza para calcular el perímetro de un rectángulo, no requiere argumentos adicionales
        public double CalcularPerimetro()
        {
            return 2 * (Base + Altura);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creación de un objeto Circulo con radio 5
            Circulo circulo = new Circulo(5);
            Console.WriteLine($"Área del círculo: {circulo.CalcularArea()}");
            Console.WriteLine($"Perímetro del círculo: {circulo.CalcularPerimetro()}");

            // Creación de un objeto Rectangulo con base 4 y altura 6
            Rectangulo rectangulo = new Rectangulo(4, 6);
            Console.WriteLine($"Área del rectángulo: {rectangulo.CalcularArea()}");
            Console.WriteLine($"Perímetro del rectángulo: {rectangulo.CalcularPerimetro()}");
        }
    }
}
