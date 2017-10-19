using System;
using System.Collections.Generic;
using System.Linq;

namespace GoldScorpion
{
    class Game
    {
        public List<Player> players;
        public string winner;
        public string first;
        private Player firstPlayer;

        public Game(int playerNumber)
        {
            firstPlayer = new Player("You");
            players.Add(firstPlayer);
            for (int i = 0; i < playerNumber; i++)
            {
                players.Add(new Player($"cpu{i}"));
            }
            while (winner == null)
            {
                Round current = new Round(players, firstPlayer);
                winner = current.winner;
                firstPlayer = current.next; 
            }
            System.Console.WriteLine("The Winner is: {0}", winner);
        }
    }
    class Round
    {
        public string winner = null;
        public Player next;
        Dictionary<int, Player> bids = new Dictionary<int, Player>();
        List<Player> currentPlayers;

        public Round(List<Player> players, Player firstPlayer)
        {
            currentPlayers = players;
            foreach (Player player in players)
            {
                player.Hand();
                player.pile = null;
            }
            next = firstPlayer;
        }
        private void GetBids()
        {
            foreach (Player player in currentPlayers)
            {
                System.Console.WriteLine("How many rocks can you flip without finding a scorpion?");
                System.Console.WriteLine("The highest bid so far is: {0} by {1}", bids.Keys.Max(), bids[bids.Keys.Max()]);
                Int32.TryParse(Console.ReadLine(), out int attemptedBid);
                bids.Add(attemptedBid, player);
            }
        }
        private void flipCards()
        {
            
        }
    }
}
