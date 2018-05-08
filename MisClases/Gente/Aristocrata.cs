namespace MisClases.Gente
{

public class Aristocrata : Persona
    {
        public Aristocrata(string nombre, string apellidos, int edad, Genero genero, string titulo) 
        : base(nombre, apellidos, edad, genero)
        {
            Titulo = titulo;
        }

        
    public string Titulo {get; set; }

    public override string GetNombreCompleto()
    {
        return GetPreTitulo() + " " + Titulo + " " + Nombre + " " + Apellidos;
    }

    public override string GetDatos()
    {
        return GetNombreCompleto() + " "  + " " + Edad + " " + Genero;
    }


    private string GetPreTitulo()
    {
        if(Genero == Genero.Hombre){
            return "Mr.";
        }
            return "Lady";
    }
}
    }
