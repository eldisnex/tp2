public class Trabajador : Persona
{
    public double Salario;
    public Trabajador(int dni, string ape, string nom, DateTime fnac, string email, double salario) : base(dni, ape, nom, fnac, email)
    {
        this.Dni = dni;
        this.Apellido = ape;
        this.Nombre = nom;
        this.FechaNacimiento = fnac;
        this.Email = email;
        this.Salario = salario;
    }
}