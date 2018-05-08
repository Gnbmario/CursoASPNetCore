namespace MisClases.Gente
{
    public class Plebeyo : Persona
    {

        public string Trabajo {get; set;}
        public Plebeyo(string nombre, string apellidos, int edad, Genero genero,string trabajo) 
            : base(nombre, apellidos, edad, genero)
        {
            Trabajo = trabajo;
        }

        public override string GetNombreCompleto()
        {
            return Nombre + " " + Apellidos;
        }
            public override string GetDatos()
    {
        return GetNombreCompleto() +" " + Edad + " " + Genero + " " + Trabajo;
    }
    }

}