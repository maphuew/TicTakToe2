using TikTakToe2;
using Xunit;

namespace TikTakToe2Tests
{
    public class PlayerTests
    {
        [Fact]
        public void GivenOnePlayer_AssignCharacterX()
        {
            var board = new Board(3);
            var player = board.AddNewPlayer();
            Assert.Equal('X', player.Symbol);
        }

        [Fact]
        public static void GivenSecondPlayer_AssignCharacterY()
        {
            var board = new Board(3);
            _ = board.AddNewPlayer();
            var player2 = board.AddNewPlayer();
            Assert.Equal('O', player2.Symbol);
        }
    }
}
