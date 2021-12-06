using System;

namespace TikTakToe2
{
    public class Player
    {
        readonly Board _board;

        public int Number;
        public readonly char Symbol;

        internal Player(Board board)
        {
            _board = board;
            _board.Players.Add(this); //TODO: Ask Aashiq which class should be responsible for this line and why
            Number = board.Players.Count;
            Symbol = _board.Players.Count switch
            {
                1 => 'X',
                2 => 'O',
                3 => 'Z',
                _ => throw new NotImplementedException()
            };
        }
    }
}
