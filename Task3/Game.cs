using System;

namespace Task3
{
    internal class Game
    {
        private static int _i = 1;
        private static int _userTurn;
        private static bool _validTurn;

        public static void Run(string[] args)
        {
            while (true)
            {
                HMACGenerator.Set_HMACKey();
                GameLogic gameLogic = new GameLogic(args.Length);

                HMACGenerator.Set_HMAC(args[gameLogic.Get_ComputerMove()]);
                Console.WriteLine($"HMAC: {HMACGenerator.Get_HMAC()}");

                Console.WriteLine("Доступные ходы: ");
                foreach (var arg in args)
                {
                    Console.WriteLine($"{_i} - {arg}");
                    _i++;
                }
                _i = 1;

                Console.WriteLine("0 - выход");
                Console.Write("Выберите ваш ход: ");

                _validTurn = int.TryParse(Console.ReadLine(), out _userTurn);
                if (_validTurn == false || _userTurn > args.Length)
                {
                    Console.WriteLine("Ошибка во время ввода хода");
                    continue;
                }
                if (_userTurn == 0)
                    Environment.Exit(0);
                gameLogic.Set_UserMove(_userTurn - 1);

                Console.WriteLine($"Ваш выбор: {args[gameLogic.Get_UserMove()]}");
                Console.WriteLine($"Выбор компьютера: {args[gameLogic.Get_ComputerMove()]}");

                gameLogic.Logic();
                gameLogic.ShowResult();

                Console.WriteLine($"HMAC Key: {HMACGenerator.Get_HMACKey()}");
            }
        } 
    }
}
