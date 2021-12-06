using System;
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
            board.MakePlayerMove(new Move(player1, x, y));
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
                board.MakePlayerMove(new Move(player, 0, i));
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
                board.MakePlayerMove(new Move(player, i, 0));
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
                board.MakePlayerMove(new Move(player, i, i));
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
                board.MakePlayerMove(new Move(player, boardSize - i - 1, i));
            }
            Assert.Equal(player, board.Winner);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void BoardCanBePrinted(int boardSize)
        {
            var board = new Board(boardSize);
            var expectedOutput = "";
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    expectedOutput += ". ";
                }
                expectedOutput += Environment.NewLine;
            }
            Assert.Equal(expectedOutput, board.View());
        }

        [Fact]
        public void BoardRemembersHistory()
        {
            var board = new Board(5);
            var player1 = board.AddNewPlayer();
            var player2 = board.AddNewPlayer();
            var player3 = board.AddNewPlayer();

            board.MakePlayerMove(new Move(player3, 0, 0));
            board.MakePlayerMove(new Move(player1, 1, 0));
            board.MakePlayerMove(new Move(player2, 2, 0));
            board.MakePlayerMove(new Move(player3, 3, 0));
            board.MakePlayerMove(new Move(player3, 4, 0));

            Assert.Equal(player3, board.History[0].Player);
            Assert.Equal(0, board.History[0].Row);
            Assert.Equal(0, board.History[0].Column);
            Assert.Equal(player1, board.History[1].Player);
            Assert.Equal(1, board.History[1].Row);
            Assert.Equal(0, board.History[1].Column);
            Assert.Equal(player2, board.History[2].Player);
            Assert.Equal(2, board.History[2].Row);
            Assert.Equal(0, board.History[2].Column);
            Assert.Equal(player3, board.History[3].Player);
            Assert.Equal(3, board.History[3].Row);
            Assert.Equal(0, board.History[3].Column);
            Assert.Equal(player3, board.History[4].Player);
            Assert.Equal(4, board.History[4].Row);
            Assert.Equal(0, board.History[4].Column);
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
