using System;
using Xunit;

namespace GoldScorpion
{
    public class CardAndPlayerTesting
    {
        [Fact]
        public void player_starts_with_correct_hand()
        {
            Player player = new Player("test");
            var testhand = player.cards_avail;
            foreach(Card hand in testhand)
            {
                if(hand.cardName != "scorpion" && hand.cardName != "gold")
                {
                    throw new InvalidOperationException();
                }
            }
                
        }
        [Fact]
        public void new_hand_has_4_cards()
        {
            Player player = new Player("test");
            int handcount = player.cards_avail.Count;
            if(handcount != 4)
            {
                throw new InvalidOperationException();
            }
          
        }
        [Fact]
         public void play_card_removes_card_from_hand()
        {
            Player player = new Player("test");
            int count = player.hand.Count;
            player.playCard(2);
            int count2 = player.hand.Count;
            if(count != (count2+1))
                {
                    throw new InvalidOperationException();
                }
        }
        [Fact]
         public void play_card_adds_card_to_pile()
        {
            Player player = new Player("test");
            int count = player.pile.Count;
            player.playCard(2);
            int count2 = player.pile.Count;
            if(count != (count2-1))
                {
                    throw new InvalidOperationException();
                }
        }
                
    }
    public class GameTesting
    {
        [Theory]
        [InlineData(1)]
        public void new_round_hand_reset_to_cardsavail()
        {
            Player player = new Player("test");
            Game game = new Game(2);
            System.Console.WriteLine("1");
            player.playCard(2);
            player.playCard(1);
            var handCount = player.hand;
            var avail = player.cards_avail;            
            Round round = new Round(game.players, game.firstPlayer);
            if(handCount != avail)
                {
                    throw new InvalidOperationException("Hand didnt reset!");
                }

        }
    }           

            
}
        // public void Test2()
        // {
        //     // play card doesn't work after first bid

        //     // at start of round, hand gets reset to cards available

        //     //at start of round pile gets set to 0

        //     //if cards available == 0, player 

        //     //if player has 2 points player wins
            
        // }

        


