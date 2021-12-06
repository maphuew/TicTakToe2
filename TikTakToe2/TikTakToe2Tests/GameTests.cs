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
Player 1 enter a coord x,y to place your X or enter 'q' to give up:
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
            game.PlayNext(1, 1);
            game.PlayNext(2, 2);
            Assert.Equal(player1, game.board.Grid[0, 0]);
            Assert.Equal(player2, game.board.Grid[1, 1]);
        }

        [Fact]
        public void GameCanBeWon()
        {
            var game = new Game();
            game.StartGame();
            game.PlayNext(0, 0);
            game.PlayNext(1, 1);
            game.PlayNext(1, 0);
            game.PlayNext(0, 2);
            var result = game.PlayNext(2, 0);
            Assert.Equal(
                @"Move accepted, well done you've won the game!

X . O 
X O . 
X . . 
", result);
            Assert.True(game.GameOver);
        }
    }
}
