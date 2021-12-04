using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTakToe2;
using Xunit;

namespace TikTakToe2Tests
{
    class PlayerTests
    {
        public void GivenOnePlayer_AssignCharacterX()
        {
            var player = new Player();
            Assert.Equal('X', player.Symbol);
        }
    }
}
