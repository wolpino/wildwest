using System;
using System.Collections.Generic;
using System.Linq;

namespace GoldScorpion
{
    public class Game
    {
        public List<Player> players = new List<Player>();
        public Player winner;
        public Player firstPlayer;

        public Game(int playerNumber)
        {
            firstPlayer = new Player("Partner");
            players.Add(firstPlayer);
            for (int i = 0; i < playerNumber; i++)
            {
                players.Add(new CompOpponent($"cpu{i}"));
            }
            System.Console.WriteLine(@"


   ___    ___    _      ___    ___    ___    ___    ___     ___   ___    ___   _  _   
  / __|  / _ \  | |    |   \  / __|  / __|  / _ \  | _ \   | _ \ |_ _|  / _ \ | \| |  
 | (_ | | (_) | | |__  | |) | \__ \ | (__  | (_) | |   /   |  _/  | |  | (_) || .` |  
  \___|  \___/  |____| |___/  |___/  \___|  \___/  |_|_\  _|_|_  |___|  \___/ |_|\_|  
_|'''''_|'''''_|'''''_|'''''_|'''''_|'''''_|'''''_|'''''_|''''' _|'''''_|'''''_|''''' 
'`-0-0-'`-0-0-'`-0-0-'`-0-0-'`-0-0-'`-0-0-'`-0-0-'`-0-0-'`-0-0-'`-0-0-'`-0-0-'`-0-0-' 

                /||\                                         /||\                              
                ||||                                         ||||                                      
         _______||||______                                ___||||______                              
       _/       |||| /|\  \_                     ________/   |||| /|\  \_           
     _/    /|\  |||| |||    \_                 _/      //|\  |||| |||    \_      
 ---/      |||  |||| |||      \_             _/         |||  |||| |||      \_    
           |||  |||| |||        \________ __/           |||  |||| |||        \______________  
           |||  |||| d||                      ____      |||  |||| d||          
           |||  |||||||/                     /    \      |||  |||||||/          
           ||b._||||~~'             ________/      \     ||b._||||~~'          
           \||||||||               /                \   \||||||||              
            `~~~||||            __/                  \   `~~~||||              
                ||||        __/                       \___   ||||              
                ||||       /                               \ ||||              
~~~~~~~~~~~~~~~~||||~~~~~~~~~~~~~~  __ ~~ __  ~~~~~~~~~~~~~~~~||||~~~~~~~~~~~~~~
  \/..__..--  . |||| \/  .  ..     (_<    >_)  \/..__ --  . |||| \/  .  ..    
\/         \/ \/    \/            //        \\  \/         \/ \/    \/            
        .  \/              \/    .\\___..___//        .  \/              \/    
. \/ ((__))                 .      `-(    )-'. \/            .    (( ))    .      
   __( O O)      ._      .     \/    _|__|_                   \/  (o o)
\/  . `\_\\  .      \/    __..--..  /_|__|_\ .   .    \/     \/    \_/ 
                                    /_|__|_\            
     Welcome to the Wild Wild West  /_\__/_\            Go ahead and take your chances
  We're gonna go huntin' for gold    \ || /   _)        see how many rocks you can flip
    in these parts. But you better     ||    ( )        before you get bit!
      watch out for those scorp's!      \\___//  
       They have a meeeean bite!         `---'
                                            Max
\\--//    .          _
      _ `---'    .)=\oo|=(.   _   .   .    .
 _  ^      .  -    . \.|


");
            System.Console.WriteLine("Would you like to play? Y/N?");
            string start = Console.ReadLine();
            if(start == "n" || start == "N")
            {
                 System.Console.WriteLine("Well too bad");
            }   
            else if (start == "y" || start == "Y");
            {
            while (winner == null)
            {
                Round current = new Round(players, firstPlayer);
                winner = current.winner;
                firstPlayer = current.next; 
            }
            System.Console.WriteLine("The Winner is: {0}", winner.name);
        }
    }
    public class Round
    {
        public Player winner = null;
        public Player next;
        Dictionary<int, Player> bids = new Dictionary<int, Player>();
        List<Player> currentPlayers;

        public Round(List<Player> players, Player firstPlayer)
        {
            currentPlayers = players;
            foreach (Player player in players)
            {
                player.Hand();
                player.pile.Clear();
            }
            next = firstPlayer;
            while(bids.Count<1)
            {
                play();
            }
            foreach(Player playah in players)
            {
                if(playah.points > 1)
                {
                    winner = playah;
                }
            }
        }
        private void GetBids()
        {
            foreach (Player player in currentPlayers)
            {
                if(player is CompOpponent)
                {
                    if(Player.rand.Next(2)==0)
                    {
                        int bid = Player.rand.Next(bids.Keys.Max(),currentPlayers.Count*4);
                        System.Console.WriteLine($"{player.name} bid {bid} rocks!");
                    }
                    else
                    {
                        System.Console.WriteLine($"{player.name} passed.");
                    }
                }
                else
                {
                    System.Console.WriteLine($"How lucky are you feelin' about this gold, {player.name}? Let me know if you'd rather bid or pass.");
                    string bidorpass = Console.ReadLine();
                    if(bidorpass == "bid" || bidorpass == "Bid")
                    {
                        System.Console.WriteLine("Good choice bucko, how many of these here rocks can you flip without finding a scorpion?");
                        if(bids.Count>0)
                        {
                            System.Console.WriteLine("The highest bid so far is: {0} by {1}", bids.Keys.Max(), bids[bids.Keys.Max()].name);
                        }
                        Int32.TryParse(Console.ReadLine(), out int attemptedBid);
                        bids.Add(attemptedBid, player);
                    }
                }
            }
        }
        private void flipCards(int maxBid)
        {
            int flipsLeft = maxBid;
            int totalFlipped = 0;
            bids[bids.Keys.Max()].flip(flipsLeft);
            while (totalFlipped <  maxBid)
            {
                System.Console.WriteLine($"Now whose rocks do you want to flip next?, {bids[bids.Keys.Max()].name}");
                List<Player> temp = currentPlayers.Where(plyr => plyr != bids[bids.Keys.Max()]).ToList();
                for (int i = 0; i < temp.Count; i++)
                {
                    System.Console.WriteLine("{0}. {1}, cards in pile: {2}", i,  temp[i].name, temp[i].pile.Count);
                }
                Int32.TryParse(Console.ReadLine(), out int chosenPlayer);

                while (chosenPlayer>currentPlayers.Count || chosenPlayer<0)
                {
                    System.Console.WriteLine($"Invalid player. Please choose a number from 0 to {currentPlayers.Count-1}");
                    Int32.TryParse(Console.ReadLine(), out chosenPlayer);
                }
                flipsLeft = temp[chosenPlayer].flip(flipsLeft);

                if (flipsLeft == -1)
                {
                    System.Console.WriteLine(@"
                     ___    ___
                    ( _<    >_ )
                    //        \\
                    \\___..___//
                    `-(    )-'
                      _|__|_
                     /_|__|_\
                     /_|__|_\
                     /_\__/_\
                      \ || /   _)
                        ||    ( )
                    Max  \\___//
                         `---'
                                        
                    
                    A Scorpion!");
                    System.Console.WriteLine();
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
        
        public void play()
        {
            foreach(Player player in currentPlayers)
            {
                System.Console.WriteLine($"What would you like to do, {player.name}?");
                if(player is CompOpponent)
                {
                    CompOpponent comp = (CompOpponent)player;
                    int play = comp.makeMove();
                    if(play == 0)
                    {
                        System.Console.WriteLine($"{player.name} added a card to their pile");
                    }
                    else
                    {
                        if(bids.Count == 0)
                        {
                            GetBids();
                            flipCards(bids.Keys.Max());
                            break;
                        }
                    }
                }
                else
                {
                    if(bids.Count == 0 && player.hand.Count>0)
                    {
                        System.Console.WriteLine("Would you like to (1) play a card or (2) start the bidding?");
                        // int move = 1;
                        Int32.TryParse(Console.ReadLine(), out int move);
                        if(move == 1)
                        {
                            System.Console.WriteLine("Which card would you like to play?");
                            for(int i=0;i<player.hand.Count;i++)
                            {
                                System.Console.WriteLine("{0}) {1}",i, player.hand[i].cardName);
                            }
                            // int cardnum = 1;
                            Int32.TryParse(Console.ReadLine(), out int cardnum);
                            if(cardnum>player.hand.Count-1){
                                System.Console.WriteLine($"Invalid Card. Try again with a number from 0 to {player.hand.Count-1}");
                                Int32.TryParse(Console.ReadLine(), out cardnum);
                            }
                            player.playCard(cardnum);
                        }
                        else if(move == 2)
                        {
                            GetBids();
                            flipCards(bids.Keys.Max());
                            break;
                        }
                    }
                    else 
                    {
                        GetBids();
                        flipCards(bids.Keys.Max());
                        break;
                    }
                }
            }
        }
    }
}
}
