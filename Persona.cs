class Persona
{
    public int Dni;
    public string Apellido, Nombre, Email;
    public double Salario;
    public List<string> Intereses;
    public DateTime FechaNacimiento;

    public Persona(int dni, string ape, string nom, DateTime fnac, string email, double salario = 0)
    {
        Dni = dni;
        Apellido = ape;
        Nombre = nom;
        FechaNacimiento = fnac;
        Email = email;
        Salario = salario;
    }
    public bool PuedeVotar()
    {
        return ObtenerEdad() >= 16;
    }

    public int ObtenerEdad()
    {
        DateTime today = DateTime.Now;
        int y = today.Year - FechaNacimiento.Year;
        if (!(today.Month - FechaNacimiento.Month > 0 || today.Month - FechaNacimiento.Month == 0 && today.Day >= FechaNacimiento.Day))
            y -= 1;
        return y;
    }
}