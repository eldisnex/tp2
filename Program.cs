namespace TP2_Stolar;

class Program
{
    static void Main(string[] args)
    {
        List<Persona> listaPersonas = new List<Persona>();
    }

    public static void Menu()
    {
        // IngresarChar();
    }

    public static char IngresarChar(string m, char[] opciones)
    {
        ConsoleKeyInfo n;
        Console.WriteLine(m);
        n = Console.ReadKey();
        while (Array.IndexOf(opciones, n.KeyChar) == -1)
        {
            Console.WriteLine("Error. Ingrese un caracter válido.");
            n = Console.ReadKey();
        }
        return n.KeyChar;
    }

    // Cargar nueva persona
    public static void CargarPersona(List<Persona> l)
    {
        l.Add(new Persona(ingresarDni(), ingresarString(), ingresarString(), ingresarFecha(), ingresarEmail()));
        Console.WriteLine($"Se ha creado la persona {l.Last().Nombre} {l.Last().Apellido} y se ha agregado a la lista");
    }

    // Obtener estadisticas del censo
    public static void Censo(List<Persona> l)
    {
        if (l.Count == 0)
            Console.WriteLine("Aún no se ingresaron personas en la lista");
        else
        {
            int votar = 0, promedio = 0;
            foreach (Persona p in l)
            {
                if (p.PuedeVotar())
                    votar += 1;
                promedio += p.ObtenerEdad();
            }
            promedio /= l.Count;
            Console.WriteLine("Estadisticas del censo:");
            Console.WriteLine($"Cantidad de personas: {l.Count}");
            Console.WriteLine($"Cantidad de personas habilitadas para votar: {votar}");
            Console.WriteLine($"Promedio de edad: {promedio}");
        }
    }

    // Buscar persona
    public static void BuscarPersona(List<Persona> l)
    {
        int dni = ingresarDni(), i = l.Count;
        bool encontrado = false;
        while(i > 0 && !encontrado){
            i--;
            encontrado = l[i].Dni == dni;
        }
        Console.WriteLine(/*Datos persona*/);
    }

}