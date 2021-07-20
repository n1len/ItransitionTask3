using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ArgumentsValidation.Validation(args);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            Game.Run(args);
        }
    }
}
