using System;
using System.Collections.Generic;

class Contacto
{
    public string Nombre { get; set; }
    public string NumeroTelefono { get; set; }
    public string CorreoElectronico { get; set; }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}, Teléfono: {NumeroTelefono}, Correo: {CorreoElectronico}");
    }
}

class Agenda
{
    private List<Contacto> contactos = new List<Contacto>();

    public void AgregarContacto(Contacto nuevoContacto)
    {
        contactos.Add(nuevoContacto);
        MostrarContactos();
    }

    public void MostrarContactos()
    {
        Console.WriteLine("\nLista de Contactos:");
        foreach (var contacto in contactos)
        {
            contacto.MostrarInformacion();
            Console.WriteLine("------------");
        }
    }

    public void BuscarContacto(string nombre)
    {
        var encontrados = contactos.FindAll(c => c.Nombre.ToLower() == nombre.ToLower());
        if (encontrados.Count > 0)
        {
            Console.WriteLine($"\nInformación de contacto para '{nombre}':");
            foreach (var contacto in encontrados)
            {
                contacto.MostrarInformacion();
                Console.WriteLine("------------");
            }
        }
        else
        {
            Console.WriteLine($"No se encontró ningún contacto con el nombre '{nombre}'.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Agenda miAgenda = new Agenda();

        while (true)
        {
            Console.WriteLine("\n¿Que deseas hacer?");
            Console.WriteLine("1. Agregar contacto");
            Console.WriteLine("2. Buscar contacto por nombre");
            Console.WriteLine("3. Salir");

            int opcion;
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, introduce un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("\nIngrese el nombre del contacto:");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el número de teléfono:");
                    string telefono = Console.ReadLine();
                    Console.WriteLine("Ingrese el correo electrónico:");
                    string correo = Console.ReadLine();

                    Contacto nuevoContacto = new Contacto
                    {
                        Nombre = nombre,
                        NumeroTelefono = telefono,
                        CorreoElectronico = correo
                    };
                    miAgenda.AgregarContacto(nuevoContacto);
                    break;

                case 2:
                    Console.WriteLine("\nIngrese el nombre del contacto a buscar:");
                    string nombreBuscar = Console.ReadLine();
                    miAgenda.BuscarContacto(nombreBuscar);
                    break;

                case 3:
                    Console.WriteLine("¡Hasta luego!");
                    return;

                default:
                    Console.WriteLine("Opción no válida. Por favor, elige una opción válida.");
                    break;
            }
        }
    }
}
