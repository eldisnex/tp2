class Desmpleado : Persona
{
    public List<string> Intereses;
    public Desmpleado(int dni, string ape, string nom, DateTime fnac, string email, List<string> intereses) : base(dni, ape, nom, fnac, email)
    {
        this.Intereses = intereses;
    }
}