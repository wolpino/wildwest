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
        private void flipCards(int maxBid)
        {
            int flipsLeft = maxBid;
            int totalFlipped = 0;
            while (totalFlipped <  maxBid)
            {
                System.Console.WriteLine("Choose a player whose cards you'll flip next");
                for (int i = 0; i < currentPlayers.Count; i++)
                {
                    System.Console.WriteLine("{0}. {1}, cards in pile: {2}", i,  currentPlayers[i].name, currentPlayers[i].pile.Count);
                }
                Int32.TryParse(Console.ReadLine(), out int chosenPlayer);
                flipsLeft = currentPlayers[chosenPlayer].flip(maxBid);
                if (flipsLeft == -1)
                {
                    System.Console.WriteLine("A Scorpion!");
                    bids[maxBid].Discard();
                    break;
                }
                else if(flipsLeft == 0) 
                {
                    System.Console.WriteLine("You make it to town with all your gold!");
                    bids[maxBid].points += 1;
                    break;
                }
                else
                {
                    System.Console.WriteLine("You have {0} flips left", flipsLeft);
                    totalFlipped = maxBid - flipsLeft;
                }
            }
        }
    }
}
