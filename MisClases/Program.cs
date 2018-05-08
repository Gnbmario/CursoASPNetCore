using System;
using MisClases.Gente;

namespace MisClases
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Producto p = new Producto("0001", "Platanito");

            // {
            // p.Codigo = "0001";
            //p.Nombre = "Platanito";
            // p.Precio = 5;
            // }

            // var p2 = new Producto()
            // {
            //     Codigo = "0002",
            //     Nombre = "Mora negra",
            //     Precio = 0.05m
            // };

            var p2 = new Producto("0002", "Mora Negra", 0.05m);

            var p3 = new Producto("0003", "Dentadura", 1);

            var p4 = new Producto("0004", "fresa");

            Console.WriteLine(p.GetDescripcionProducto());
            Console.WriteLine(p2.GetDescripcionProducto());
            Console.WriteLine(p3.GetDescripcionProducto());
            Console.WriteLine(p4.GetDescripcionProducto());

            var yo = new Plebeyo("Mario", "González Beldad", 22, Genero.Hombre,"Ingeniero");
            var otro = new Plebeyo("Josefa", "La Cerda", 15, Genero.Mujer, "Presentadora");
            var otromas = new Plebeyo("Marco", "Aurelio", 28,Genero.Hombre, "Comandante");


            var duque = new Aristocrata("Miguel", "Cervantes", 68, Genero.Hombre, "Duque");
            var conde = new Aristocrata("Javier", "De las Heras", 40, Genero.Hombre, "Conde");
            var marques = new Aristocrata("Luisa", "Hernandez", 32, Genero.Mujer, "Marques");
            
            PrintDatos(yo);
            PrintDatos(duque);
            PrintDatos(otro);
            PrintDatos(marques);

        }

            static void PrintDatos(Persona p)
            {
                Console.WriteLine(p.GetDatos());
            }
    }
}
