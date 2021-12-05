using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
