﻿using System.Collections.Generic;

namespace TikTakToe2
{
    public class Board
    {
        public List<Player> Players { get; } = new();

        public int BoardSize { get; }
        public Player[,] Grid { get; }

        public Player Winner => CalculateWinner();

        public Board(int boardSize)
        {
            Grid = new Player[boardSize, boardSize];
            BoardSize = boardSize;
        }

        public Player AddNewPlayer()
        {
            return new Player(this);
        }

        /// <returns>True if the move was added, false the spot has already been taken</returns>
        public bool MakePlayerMove(Player player, int x, int y)
        {
            if (Grid[x, y] == null)
            {
                Grid[x, y] = player;
                return true;
            }
            return false;
        }

        Player CalculateWinner()
        {
            // Check Vertical:
            for (int i = 0; i < BoardSize; i++)
            {// For each row
                if (Grid[i, 0] == null) continue;
                int a = 1;
                while (Grid[i, a] == Grid[i, a - 1])
                {
                    if (a == BoardSize - 1) return Grid[i, a];
                    a++;
                }
            }
            // Check Horizontal:
            for (int i = 0; i < BoardSize; i++)
            {// For each column
                if (Grid[0, i] == null) continue;
                int a = 1;
                while (Grid[a, i] == Grid[a - 1, i])
                {
                    if (a == BoardSize - 1) return Grid[a, i];
                    a++;
                }
            }
            // Check Diagonal:
            // Check top left diagonal
            if (Grid[0, 0] != null)
            {
                for (int i = 1; i <= BoardSize; i++)
                {
                    if (i == BoardSize) return Grid[0, 0];
                    if (Grid[i, i] != Grid[i - 1, i - 1]) break;
                }
            }
            // Check top right diagonal
            if (Grid[BoardSize - 1, 0] != null)
            {
                for (int i = 1; i <= BoardSize; i++)
                {
                    if (i == BoardSize) return Grid[BoardSize - 1, 0];
                    if (Grid[BoardSize - 1 - i, i] != Grid[BoardSize - i, i - 1]) break;
                }
            }
            return null;
        }
    }
}
