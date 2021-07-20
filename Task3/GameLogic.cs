using System;
using System.Collections.Generic;

namespace Task3
{
    internal class GameLogic
    {
        private static readonly Random rnd = new Random();
        private static int _computerMove;
        private static int _userMove;
        private static int _argsLength;
        private static int _result;
        private readonly List<int> _winMoves;
        private readonly int _center;

        public GameLogic(int availableМoves)
        {
            _computerMove = rnd.Next(availableМoves);
            _argsLength = availableМoves;
            _winMoves = new List<int>();
            _center = availableМoves / 2;
        }

        public void Logic()
        {
            for (var i = 0; i <= _center; i++)
                _winMoves.Add((_userMove + i) % _argsLength);

            if (_userMove == _computerMove)
                _result = (int)GameResult.Draw;
            else if (_winMoves.Contains(_computerMove))
                _result = (int)GameResult.Lose;
            else
                _result = (int)GameResult.Win;
        }

        public void ShowResult()
        {
            switch (_result)
            {
                case 0:
                    Console.WriteLine("Ничья");
                    break;
                case 1:
                    Console.WriteLine("Вы выиграли!");
                    break;
                case -1:
                    Console.WriteLine("Вы проиграли.");
                    break;
            }
        }

        public int Get_ComputerMove()
        {
            return _computerMove;
        }

        public int Get_UserMove()
        {
            return _userMove;
        }

        public void Set_UserMove(int userMove)
        {
            _userMove = userMove;
        }
    }
}
