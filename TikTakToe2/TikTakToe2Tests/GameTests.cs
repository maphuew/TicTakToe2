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
            BoardTests.AssertBoardIsEmpty(game.board);
        }

        [Fact]
        public void GivenNewGameStart_ReturnGreeting()
        {
            var game = new Game();
            var prompt = game.Start();
            Assert.Equal("Welcome to Tic Tak Toe!", prompt);
        }
    }
}
