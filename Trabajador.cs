class Trabajador : Persona
{
    public double Salario { get; private set; }
    public Trabajador(int dni, string ape, string nom, DateTime fnac, string email, double salario) : base(dni, ape, nom, fnac, email)
    {

        this.Salario = salario;
    }
}