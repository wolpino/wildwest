using System;

namespace GoldScorpion
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("john");
            System.Console.WriteLine(player.cards_avail.Count);
            Game game = new Game(2);
        }
    }
}
