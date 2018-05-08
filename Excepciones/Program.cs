using System;

namespace Excepciones
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var motorDiesel = new Motor("Diesel", 15);
                var furgo = new Vehiculo(motorDiesel);
                furgo.Arrancar();

                var motorGasolina = new Motor("Gasolina", 20);
                var coche = new Vehiculo(motorGasolina);
                coche.Arrancar();  

                var motorGas2 = new Motor("Gasolina", 0);
                var moto = new Vehiculo(motorGas2);
                moto.Arrancar();

                throw new NullReferenceException();
            }
            catch (System.NullReferenceException ex)
            {
                // Huy ! pues parece que no hay errores....
                // PUES NO!!! HAY ERRORES, PERO NO LOS CAPTURAS!!!
                // Console.WriteLine("Error de la referencia nula: " + ex.Source);         
            }
            catch (System.Exception)
            {

               // Hay un error, enviaos un mail de socorro...
            }
            Console.WriteLine("La vida sigue...");
        }
    }

    public class MotorException :Exception
    {
        public MotorException(string message): base(message){

        }
    }

    public class Vehiculo
    {
        public Motor Motor { get; set; }
    public Vehiculo (Motor motor)
    {
        Motor = motor;
    }
    public void Arrancar()
    {
        if (!string.IsNullOrEmpty(Motor.Combustible) && Motor.Litros > 0)
        {
            Console.WriteLine(Motor.Litros);
            Console.WriteLine("Brrrrrrrm...");
        }
        else
        {
            //No podemos arrancar
            throw new ArgumentException("No se ha especificado comsubtible para el motor");
        }
    }
}
    public class Motor
    {
        public string Combustible { get; set; }
        public int Litros { get; set; }
        public Motor (string combustible, int litros)
        {
            if(string.IsNullOrEmpty(combustible))
                throw new MotorException("Debe indicar combustible");

                if (litros>0)
                     throw new ArgumentException("Litros debe ser mayor que cero","litros");

            Combustible = combustible;
            Litros = litros;
        }
    }
}
