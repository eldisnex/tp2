using System.Reflection;
using System.Text.RegularExpressions;

namespace TP2_Stolar;
class Program
{
    static void Main(string[] args)
    {
        List<Persona> listaPersonas = new List<Persona>();
        Console.WriteLine("------ Control de personas ------");
        // Menu(listaPersonas);
    }

    private static void Menu(List<Persona> l)
    {
        bool exit = false;
        while (!exit)
        {
            int c;
            c = IngresarCaracter("Ingrese un numero") - '0';
            Console.WriteLine();
            switch (c)
            {
                case 1:
                    CargarPersona(l);
                    break;
                case 2:
                    Censo(l);
                    break;
                case 3:
                    BuscarPersona(l);
                    break;
                case 4:
                    ModificarMail(l);
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("No existe dicha opcion");
                    break;
            }
        }
    }

    // ---- Funciones menu ----

    // Cargar nueva persona
    public static void CargarPersona(List<Persona> l)
    {
        l.Add(new Persona(IngresarDni(), IngresarString("Ingrese apellido"), IngresarString("Ingrese nombre"), IngresarFecha("Ingrese nacimiento"), IngresarEmail()));
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
        int dni = IngresarDni(), persona = IndicePersona(l, dni);
        if (persona != -1)
        {
            Console.WriteLine($"---- {l[persona].Nombre} {l[persona].Apellido} ----");
            Console.WriteLine(
            $"Edad: {l[persona].ObtenerEdad()}\n" +
            $"Fecha de nacimiento: {l[persona].FechaNacimiento}\n" +
            $"Email: {l[persona].Email}\n" +
            $"Puede votar: {(l[persona].PuedeVotar() ? "Si" : "No")}");
        }
        else
            Console.WriteLine("No se encuentra el DNI");
    }

    // Modificar mail de otra persona
    public static void ModificarMail(List<Persona> l)
    {
        int dni = IngresarDni(), persona = IndicePersona(l, dni);
        string email;
        if (persona != -1)
        {
            email = IngresarEmail();
            l[persona].Email = email;
        }
        else
            Console.WriteLine("No se encuentra el DNI en la lista");
    }

    // ---- Otras funciones ----

    private static int IndicePersona(List<Persona> l, int dni)
    {
        int i = l.Count - 1;
        while (i > 0 && l[i].Dni != dni)
            i--;
        return i;
    }
    private static string IngresarEmail()
    {
        const string EMAIL_REGEX = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        string r;
        do
        {
            r = IngresarString("Ingrese Email");
        } while (!Regex.IsMatch(r, EMAIL_REGEX));
        return r;
    }
    private static DateTime IngresarFecha(string me)
    {
        DateTime r;
        int d, m, y;
        Console.WriteLine(me);
        d = IngresarEnteroPositivo("Dia:");
        m = IngresarEnteroPositivo("Mes:");
        y = IngresarEnteroPositivo("Año:");
        r = new DateTime(y, m, d);
        return r;
    }

    private static string IngresarString(string m)
    {
        Console.WriteLine(m);
        return Console.ReadLine();
    }
    private static int IngresarDni()
    {
        int r;
        do
        {
            r = IngresarEnteroPositivo("Ingrese DNI");
        } while (r / 10000000 == 0);
        return r;
    }

    private static int IngresarEnteroPositivo(string m, int min = int.MinValue, int max = int.MaxValue)
    {
        int r;
        do
        {
            Console.WriteLine(m);
            r = int.Parse(Console.ReadLine());
        } while (r < 0 || r < min || r > max);
        return r;
    }

    private static char IngresarCaracter(string m)
    {
        Console.WriteLine(m);
        return Console.ReadKey().KeyChar;
    }

}