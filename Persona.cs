public class Persona
{
    public int Dni;
    public string Apellido, Nombre, Email;
    public List<string> Intereses;
    public DateTime FechaNacimiento;
    public Persona(int dni, string ape, string nom, DateTime fnac, string email)
    {
        this.Dni = dni;
        this.Apellido = ape;
        this.Nombre = nom;
        this.FechaNacimiento = fnac;
        this.Email = email;
        this.Intereses = new List<string>();
    }
    public bool PuedeVotar()
    {
        return ObtenerEdad() >= 16;
    }

    public int ObtenerEdad()
    {
        DateTime today = DateTime.Now;
        int y = today.Year - this.FechaNacimiento.Year;
        if (!(today.Month - this.FechaNacimiento.Month > 0 || today.Month - this.FechaNacimiento.Month == 0 && today.Day >= this.FechaNacimiento.Day))
            y -= 1;
        return y;
    }

    
}