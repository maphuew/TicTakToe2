using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe2
{
    public class Player
    {
        readonly Board _board;

        public readonly char Symbol;

        public Player(Board board)
        {
            _board = board;
            _board.Players.Add(this);
            Symbol = _board.Players.Count switch
            {
                1 => 'X',
                2 => 'O',
                _ => throw new NotImplementedException()
            };
        }
    }
}
