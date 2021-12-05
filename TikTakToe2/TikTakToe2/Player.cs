using System;

namespace TikTakToe2
{
    public class Player
    {
        readonly Board _board;

        public readonly char Symbol;

        internal Player(Board board)
        {
            _board = board;
            _board.Players.Add(this); //TODO: Ask Aashiq which class should be responsible for this line and why
            Symbol = _board.Players.Count switch
            {
                1 => 'X',
                2 => 'O',
                _ => throw new NotImplementedException()
            };
        }
    }
}
