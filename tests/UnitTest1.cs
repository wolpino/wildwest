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
                    throw new InvalidOperationException("Deck has been infiltrated with bad cards");
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
                throw new InvalidOperationException("New hand is sized wrong.");
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
                    throw new InvalidOperationException("Playcard not removing card from hand");
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
                    throw new InvalidOperationException("Play card didn't add card to pile");
                }
        }
                
    }
   public class GameTesting
    {
        [Theory]
        [InlineData('Y')]        
        [InlineData(1)]
        [InlineData(1)]
        [InlineData()]
        [InlineData(2)]
        public void new_round_hand_reset_to_cardsavail()
        {
            Player player = new Player("test");
            Game game = new Game(2);
            var handCount = player.hand;
            var avail = player.cards_avail;            
            Round round = new Round(game.players, game.firstPlayer);
            if(handCount != avail)
                {
                    throw new InvalidOperationException("Hand didnt reset!");
                }

        }

        [Theory]
        [InlineData('Y')]        
        [InlineData(1)]
        [InlineData(1)]
        [InlineData()]
        [InlineData(2)]
         public void new_round_pile_set_to_0()
        {
            Player player = new Player("test");
            Game game = new Game(2);
            Round round = new Round(game.players, game.firstPlayer);
            var pileCount = player.pile.Count;            
            if(pileCount != 0)
                {
                    throw new InvalidOperationException("Pile did not reset to 0!");
                }

        }
        public void when_no_cardsavail_player_removed_from_turn()
        {
            Player player = new Player("test");
            Game game = new Game(2);
            player.cards_avail.Clear();
            Round.currentPlayers = players;
            foreach (Player player in players)        
            if(player.playerName == "player")
                {
                    throw new InvalidOperationException("Player has no cards_avail and wasn't removed from currentPlayers");
                }

        }
        
    }           

            
}
        // public void Test2()
        // {
        //     // play card doesn't work after first bid


        //     //if player has 2 points player wins
            
        // }

        


