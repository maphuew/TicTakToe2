using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe2
{
    public class Board
    {
        public readonly List<Player> Players = new();

        public readonly Player[,] Grid;

        public Board(int dimesion)
        {
            Grid = new Player[dimesion, dimesion];
        }

        public Player AddNewPlayer()
        {
            return new Player(this);
        }
    }
}
