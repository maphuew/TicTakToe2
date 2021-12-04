using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTakToe2;
using Xunit;

namespace TikTakToe2Tests
{
    public class PlayerTests
    {
        [Fact]
        public void GivenOnePlayer_AssignCharacterX()
        {
            var board = new Board();
            var player = new Player(board);
            Assert.Equal('X', player.Symbol);
        }

        [Fact]
        public static void GivenSecondPlayer_AssignCharacterY()
        {
            var board = new Board();
            _ = new Player(board);
            var player2 = new Player(board);
            Assert.Equal('O', player2.Symbol);
        }
    }
}
