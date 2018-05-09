using System;

namespace Control
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Sentencias de control de código


            Console.WriteLine("Pulsa una tecla...");
            var a = Console.ReadKey();
            var teclaPulsada = a.KeyChar;


            // IF - Else
            if (teclaPulsada == '5')
            {
                Console.WriteLine("Has pulsado 5");
            }
            else if(teclaPulsada == '8')
            {
                Console.WriteLine("Vete a saber...");
            }

            // Switch 

            switch(teclaPulsada)
            {
                case 'a':
                    Console.WriteLine("Añadir elemento");
                    break;
                case 'e':
                    Console.WriteLine("Eliminar elemento");
                    break;
                case 'l':
                    Console.WriteLine("Listar elemento");
                    break;
                default:
                    break;                           
            }

            // Iteraciones

            // While y bucle do-While
            int i = 0;
            while(i<5)
            {
                Console.WriteLine(i++);
            }

            // do - while
            Console.WriteLine("Ejecutando do-while");
            int x = 0;
            do
            {
                Console.WriteLine(x++);
            }
            while (x < 7);

            // for
            Console.WriteLine("Ejecutando for");
            for(int b = 0; b < 10; b++)
            {
                Console.WriteLine(b);
            }

            Console.ReadKey();
        }
    }
}
