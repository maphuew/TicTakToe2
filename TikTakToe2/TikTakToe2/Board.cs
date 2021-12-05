using System.Collections.Generic;

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

        /// <returns>True if the move was added, false the spot has already been taken</returns>
        public bool MakeMove(Player player, int x, int y)
        {
            if (Grid[x, y] == null)
            {
                Grid[x, y] = player;
                return true;
            }
            return false;
        }
    }
}
