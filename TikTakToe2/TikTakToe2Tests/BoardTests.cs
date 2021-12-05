using TikTakToe2;
using Xunit;

namespace TikTakToe2Tests
{
    public class BoardTests
    {
        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void GivenDimensionX_returnsBoardOfSize(int dimension)
        {
            var board = new Board(dimension);
            Assert.Equal(dimension, board.Grid.GetLength(0));
            Assert.Equal(dimension, board.Grid.GetLength(1));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void GivenDimensionX_newBoardIsEmpty(int dimesion)
        {
            var board = new Board(dimesion);
            foreach (var spot in board.Grid)
            {
                Assert.Null(spot);
            }
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(2, 1)]
        public void PlayerCanAddToBoard(int x, int y)
        {
            var board = new Board(3);
            var player1 = board.AddNewPlayer();
            Assert.Null(board.Grid[x, y]);
            board.MakeMove(player1, x, y);
            Assert.Equal(player1, board.Grid[x, y]);
        }
    }
}
