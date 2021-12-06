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

        public bool GameOver => board.Winner != null;

        readonly string NL = Environment.NewLine;

        public Game()
        {
            board = new Board(3);
            board.AddNewPlayer();
            board.AddNewPlayer();
        }

        public string StartGame()
        {
            return "Welcome to Tic Tak Toe!" + NL +
                "Here's the current board:" + NL +
                board.View() +
                GetTurnPrompt();
        }

        public string GetTurnPrompt()
        {
            var currentPlayer = GetCurrentPlayersTurn();
            return $"Player {currentPlayer.Number} enter a coord x,y to place your {currentPlayer.Symbol} or enter 'q' to give up:";
        }

        public string PlayNext(int row, int col)
        {
            if (GameOver) return null;

            var nextPlayer = GetCurrentPlayersTurn();
            var result = board.MakePlayerMove(new Move(nextPlayer, row, col));
            if (result)
            {
                if (GameOver)
                {
                    return "Move accepted, well done you've won the game!" + NL + NL
                        + board.View();
                }
                else
                {
                    return "Move accepted, here's the current board:" + NL
                        + board.View() +
                        GetTurnPrompt();
                }
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
