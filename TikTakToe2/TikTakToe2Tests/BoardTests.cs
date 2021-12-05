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
        public void GivenDimensionX_returnsBoardOfSize(int boardSize)
        {
            var board = new Board(boardSize);
            Assert.Equal(boardSize, board.Grid.GetLength(0));
            Assert.Equal(boardSize, board.Grid.GetLength(1));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void GivenDimensionX_newBoardIsEmpty(int boardSize)
        {
            var board = new Board(boardSize);
            AssertBoardIsEmpty(board);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(2, 1)]
        public void PlayerCanAddToBoard(int x, int y)
        {
            var board = new Board(3);
            var player1 = board.AddNewPlayer();
            Assert.Null(board.Grid[x, y]);
            board.MakePlayerMove(player1, x, y);
            Assert.Equal(player1, board.Grid[x, y]);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void CheckVerticalWinner(int boardSize)
        {
            var board = new Board(boardSize);
            var player = board.AddNewPlayer();
            for (int i = 0; i < boardSize; i++)
            {
                Assert.Null(board.Winner);
                board.MakePlayerMove(player, 0, i);
            }
            Assert.Equal(player, board.Winner);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void CheckHorizontalWinner(int boardSize)
        {
            var board = new Board(boardSize);
            var player = board.AddNewPlayer();
            for (int i = 0; i < boardSize; i++)
            {
                Assert.Null(board.Winner);
                board.MakePlayerMove(player, i, 0);
            }
            Assert.Equal(player, board.Winner);
        }


        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void CheckDiagonalWinner1(int boardSize)
        {
            var board = new Board(boardSize);
            var player = board.AddNewPlayer();
            for (int i = 0; i < boardSize; i++)
            {
                Assert.Null(board.Winner);
                board.MakePlayerMove(player, i, i);
            }
            Assert.Equal(player, board.Winner);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void CheckDiagonalWinner2(int boardSize)
        {
            var board = new Board(boardSize);
            var player = board.AddNewPlayer();
            for (int i = 0; i < boardSize; i++)
            {
                Assert.Null(board.Winner);
                board.MakePlayerMove(player, boardSize - i - 1, i);
            }
            Assert.Equal(player, board.Winner);
        }

        public static void AssertBoardIsEmpty(Board board)
        {
            foreach (var spot in board.Grid)
            {
                Assert.Null(spot);
            }
        }
    }
}
