using System;

namespace TikTakToe2
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new();

            Console.Write(game.StartGame());

            while (!game.GameOver)
            {
                Tuple<int, int> move = ReadMove();
                if (move == null) Environment.Exit(1);
                Console.Write(game.PlayNext(move.Item1, move.Item2));
            }
        }

        static Tuple<int, int> ReadMove()
        {
            string content = Console.ReadLine().ToLower().Trim();
            if (content == "q") return null;
            var splitContent = content.Split(',');
            return new Tuple<int, int>(int.Parse(splitContent[0]), int.Parse(splitContent[1]));
        }
    }
}
