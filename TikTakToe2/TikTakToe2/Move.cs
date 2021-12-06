using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe2
{
    public class Move
    {
        public Move(Player player, int row, int column)
        {
            Player = player;
            Row = row;
            Column = column;
        }

        public Player Player { get; }
        public int Row { get; }
        public int Column { get; }
    }
}
