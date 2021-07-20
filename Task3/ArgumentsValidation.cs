using System;
using System.Linq;

namespace Task3
{
    internal class ArgumentsValidation
    {
        private const string Example = "rock paper scissors";

        public static void Validation(string[] args)
        {
            var distinctValues = args.Distinct().Count();
            if (args.Length < 3)
                throw new ArgumentException($"Кол-во строк должно быть больше трёх. Пример правильного ввода: {Example}");

            if (args.Length % 2 == 0)
                throw new ArgumentException($"Кол-во строк должно быть нечётным. Пример правильного ввода: {Example}");

            if (distinctValues != args.Length)
                throw new ArgumentException($"Значения не должны повторяться. Пример правильного ввода: {Example}");
        }
    }
}
