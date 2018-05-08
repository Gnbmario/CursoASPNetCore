namespace MisClases.Gente 
{ 
public enum Genero 
{ 
Hombre, 
Mujer 
}

public abstract class Persona
{
    public string Nombre { get; private set; }
    public string Apellidos { get; private set; }
    public int Edad { get; private set; }
    public Genero Genero { get; private set; }

    public Persona (string nombre, string apellidos, int edad, Genero genero)
    {
        Nombre = nombre;
        Apellidos = apellidos;
        Edad = edad;
        Genero = genero;
    }

    public abstract string GetNombreCompleto();

    public abstract string GetDatos();

    public bool EsMayorDeEdad()
    {
        return Edad >= 18;
    }
}
}