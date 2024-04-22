public class Persona
{
    public int Dni { get; private set; }
    public string Apellido { get; private set; }
    public string Nombre { get; private set; }
    public string Email;
    public DateTime FechaNacimiento { get; private set; }
    protected Persona(int dni, string ape, string nom, DateTime fnac, string email)
    {
        this.Dni = dni;
        this.Apellido = ape;
        this.Nombre = nom;
        this.FechaNacimiento = fnac;
        this.Email = email;
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