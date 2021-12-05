using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe2
{
    public class Game
    {

        public Board board = new(3);

        public string Start()
        {
            return "Welcome to Tic Tak Toe!";
        }
    }
}
