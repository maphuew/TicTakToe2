using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe2
{
    public class Game
    {
        public Board board;

        bool Over => board.Winner != null;

        readonly string NewLine = Environment.NewLine;

        public Game()
        {
            board = new Board(3);
            board.AddNewPlayer();
            board.AddNewPlayer();
        }

        public string StartGame()
        {
            return "Welcome to Tic Tak Toe!" + NewLine +
                "Here's the current board:" + NewLine +
                board.View();
        }

        public string PlayNext(int row, int col)
        {
            if (Over) return null;

            var nextPlayer = GetCurrentPlayersTurn();
            var result = board.MakePlayerMove(new Move(nextPlayer, row, col));
            if (result)
            {
                return "Move accepted, here's the current board:" + NewLine
                    + board.View() + NewLine;
            }
            else
            {
                return "Oh no, a piece is already at this place! Try again...";
            }
        }

        public Player GetCurrentPlayersTurn()
        {
            if (board.History.Count == 0) return board.Players[0];
            var lastTurn = board.History.Last();
            var lastPlayerIndex = board.Players.IndexOf(lastTurn.Player);
            if (lastPlayerIndex == board.Players.Count - 1) return board.Players[0];
            return board.Players[lastPlayerIndex + 1];
        }
    }
}
