using System;
using System.Collections.Generic;
using System.Linq;

namespace Colecciones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Colecciones
            // Lista de elementos
            // que se trata como una unidad
            // Permite manipular su contenido

            // Matriz
            string[] listaNombres ={"Antonio", "Bea", "Mario", "Jose"};

            Console.WriteLine("Elementos en la lista: " + listaNombres.Length);

            for( int i = 0; i < listaNombres.Length; i++)
            {
                Console.WriteLine(listaNombres[i]);
            }

            // Lista
            List<Decimal> precios = new List<decimal>();
            precios.Add(23.15m);
            precios.Add(32.56m);
            precios.Add(4.26m);

            var miPrecio = precios[2]; // 4.26

            var p1 = new Producto("1", "Mahou", 1.5);
            var p2 = new Producto("2", "Alhambra", 1.8);
            var p3 = new Producto("3", "Amstel", 2);
            

            var productos = new List<Producto>();
            productos.Add(p1);
            productos.Add(p2);
            productos.Add(p3);
            productos.Add(new Producto("4","Cruzcampo",2.1));
            productos.Add(new Producto("5","Mahou negra",2));

            productos.Remove(p2);
            Console.WriteLine("¿Donde está p3? posición: " + productos.IndexOf(p3));
            
            // Lambda
            // función anónima
            var mahou = productos.Where(p => p.Nombre.ToUpper().Contains("MAH"));

            Console.WriteLine("¿Hay mahou?" + mahou.Any());
            ListaProductos(mahou.ToList());

            ListaProductos(productos);
            IncrementaPrecio(productos,5);
            ListaProductos(productos);
        }
        private static void ListaProductos(List<Producto> productos)
        {
            Console.WriteLine("Productos disponibles...");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto.Codigo + " " + producto.Nombre + " precio: " + producto.Precio);
            }
        }

        private static void IncrementaPrecio(List<Producto> productos, double porcentaje)
        {
            var porcentajeAAplicar = 1 + (porcentaje/100);
            foreach (var producto in productos)
            { 
                producto.Precio += producto.Precio * porcentajeAAplicar;
            }
        }

    }

    public class Producto 
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
         public double Precio { get; set; }

        public Producto (string codigo, string nombre, double precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
        }
    }
}
