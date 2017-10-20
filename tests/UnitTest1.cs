using System;
using Xunit;

namespace GoldScorpion
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Player starts with correct hand
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
        public void Test2()
        {
            //new hand has 4 cards
            Player player = new Player("test");
            int handcount = player.cards_avail.Count;
            if(handcount != 4)
            {
                throw new InvalidOperationException();
            }
          
        }
         [Fact]
         public void Test3()
        {
            //play card removes a card from the hand
            Player player = new Player("test");
            int count = player.cards_avail.Count;
            player.playCard(2);
            int count2 = player.cards_avail.Count;
            if(count != (count2+1))
                {
                    throw new InvalidOperationException();
                }
        }
                
    }           

            //play card removes a card from the hand

            //play card adds a card to the pile
            
}
        // public void Test2()
        // {
        //     // play card doesn't work after first bid

        //     // at start of round, hand gets reset to cards available

        //     //at start of round pile gets set to 0

        //     //if cards available == 0, player 

        //     //if player has 2 points player wins
            
        // }

        


