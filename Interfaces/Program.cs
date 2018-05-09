using System;
using System.Collections.Generic;

namespace Interfaces
{
    class Program
    {


        static void Main(string[] args)
        {
            List<ILogger> loggers = new List<ILogger>();
            loggers.Add(new DatabaseLogger());
            loggers.Add(new ConsoleLogger());

            MetodoQueHaceAlgo(loggers);

            // var logger = new ILogger();
            try
            {
                // Este método "casca" y queremos "logear" la excepción
                throw new ArgumentNullException();
            }
            catch(ArgumentNullException ex)
            {
                //Se ha producido un error de argumento nulo, quiero guardar el error
                foreach (var logger in loggers)
                {
                    logger.LogError(ex.Message);
                }
            }


        }

    private static void MetodoQueHaceAlgo(List<ILogger> loggers)
    {
        // cualquier instrucción, operacioón....
        foreach(var logger in loggers)
        {
            logger.LogInfo("He pasado por MetodoQueHaceAlgo");
        }
    }
}
    public interface ILogger
    {
        void LogError(string logMessage);
        void LogInfo(string logMessage);
        string GetStorage();
    }

    public class DatabaseLogger : ILogger
    {
        public string GetStorage()
        {
            return "Database";
        }

        public void LogError(string logMessage)
        {
            Console.WriteLine("Error guardado en DB: " + logMessage);
        }

        public void LogInfo(string logMessage)
        {
            Console.WriteLine("Información guardada en DB: " + logMessage);
        }
    }

        public class ConsoleLogger : ILogger
    {
        public string GetStorage()
        {
            return "Console";
        }

        public void LogError(string logMessage)
        {
            Console.WriteLine("Error volcado en consola: " + logMessage);
        }

        public void LogInfo(string logMessage)
        {
            Console.WriteLine("Información volcada en consola: " + logMessage);
        }
    }

        public class FileLogger : ILogger
    {
        public string GetStorage()
        {
            return "Database";
        }

        public void LogError(string logMessage)
        {
            Console.WriteLine("Error guardado en DB: " + logMessage);
        }

        public void LogInfo(string logMessage)
        {
            Console.WriteLine("Información guardada en DB: " + logMessage);
        }
    }
}
