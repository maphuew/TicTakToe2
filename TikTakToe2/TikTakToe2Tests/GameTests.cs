using System;
using TikTakToe2;
using Xunit;

namespace TikTakToe2Tests
{
    public class GameTests
    {
        [Fact]
        public void GivenNewGame_HasEmptyBoard()
        {
            var game = new Game();
            game.StartGame();
            BoardTests.AssertBoardIsEmpty(game.board);
        }

        [Fact]
        public void GivenNewGameStart_ReturnGreeting()
        {
            var game = new Game();
            var prompt = game.StartGame();
            Assert.Equal(
@"Welcome to Tic Tak Toe!
Here's the current board:
. . . 
. . . 
. . . 
", prompt);
        }

        [Fact]
        public void GameCanProcessTurns()
        {
            var game = new Game();
            game.StartGame();
            var player1 = game.board.Players[0];
            var player2 = game.board.Players[1];
            game.StartGame();
            game.PlayNext(0, 0);
            game.PlayNext(1, 1);
            Assert.Equal(player1, game.board.Grid[0, 0]);
            Assert.Equal(player2, game.board.Grid[1, 1]);
        }
    }
}
